SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.01
-- Description:	생산 계획별 작업 지시 확정 및 취소.
-- =============================================
ALTER PROCEDURE [dbo].[13AP_ProductPlan_U]
	@PLANTCODE   			VARCHAR(10)  -- 공장
  , @PLANNO   				VARCHAR(30)  -- 작업 지시를 확정 및 취소할 생산 계획 번호
  , @ORDERFLAG  			VARCHAR(1)   -- 작업 지시 확정/취소 여부
  , @WORKCENTERCODE			VARCHAR(100) -- 작업장
  , @EDITOR   				VARCHAR(30)  -- 작업 지시 확정 및 취소자

  , @LANG					 VARCHAR(10) = 'KO'
  , @RS_CODE				 VARCHAR(1)   OUTPUT
  , @RS_MSG					 VARCHAR(100) OUTPUT

AS
BEGIN
	-- 프로시져에서 공통으로 사용할 일자, 일시 변수.
	DECLARE @LD_NOWDATE DATETIME    -- PROCEDURE 실행 일시
	      , @LS_NOWDATE VARCHAR(10) -- PROCEDURE 실행 일자
	;

		SET @LD_NOWDATE = GETDATE();
		SET @LS_NOWDATE = CONVERT(VARCHAR, @LD_NOWDATE, 23);
	
	IF (@ORDERFLAG = 'Y') -- 작업 지시 확정
	BEGIN
		-- 작업지시 확정 여부 확인
		DECLARE @LS_ORDERFLAG VARCHAR(1);
		SELECT @LS_ORDERFLAG = ORDERFLAG
		  FROM TB_ProductPlan WITH(NOLOCK)
		 WHERE PLANTCODE = @PLANTCODE
		   AND PLANNO    = @PLANNO

		IF (@LS_ORDERFLAG = 'Y')
		BEGIN
			SET @RS_CODE = 'E'
			SET @RS_MSG  = '이미 확정된 작업 지시입니다.';
			RETURN;
		END;

		-- 작업 지시 번호 채번.
		DECLARE @LI_SEQ INT;
		SELECT @LI_SEQ = ISNULL(MAX(ORDERSEQ), 0) + 1
		  FROM TB_ProductPlan WITH(NOLOCK)
		 WHERE PLANTCODE = @PLANTCODE
		   AND ORDERDATE = @LS_NOWDATE;
		

		DECLARE @LS_ORDERNO VARCHAR(30);
		SET @LS_ORDERNO = 'ORD' + CONVERT(VARCHAR, @LD_NOWDATE, 112) + RIGHT('0000' + CONVERT(VARCHAR, @LI_SEQ), 4);

		UPDATE TB_ProductPlan
		   SET ORDERFLAG      = 'Y'		         -- 작업 지시 확정 여부
		     , ORDERNO        = @LS_ORDERNO      -- 작업 지시 번호
			 , ORDERSEQ       = @LI_SEQ	         -- 일자별 작업 지시 순번
			 , ORDERDATE      = @LS_NOWDATE      -- 작업 지시 일자
			 , ORDERTEMP      = @LD_NOWDATE      -- 작업 지시 일시
			 , ORDERWORKER    = @EDITOR          -- 작업 지시 확정자
			 , WORKCENTERCODE = @WORKCENTERCODE  -- 작업장
			 , EDITDATE       = @LD_NOWDATE      -- 수정일시
			 , EDITOR         = @EDITOR          -- 수정자
		 WHERE PLANTCODE      = @PLANTCODE
		   AND PLANNO         = @PLANNO          -- 생산 계획 번호별 작업지시 등록
		   ;

	END;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';

END
GO
