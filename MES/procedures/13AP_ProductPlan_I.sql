SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.01
-- Description:	생산 계획 등록
-- =============================================
ALTER PROCEDURE [dbo].[13AP_ProductPlan_I]
	@PLANTCODE		   VARCHAR(10) -- 공장
  , @ITEMCODE		   VARCHAR(30) -- 품목 코드
  , @PLANQTY		   FLOAT       -- 계획 수량
  , @UNITCODE		   VARCHAR(10) -- 단위
  , @MAKER			   VARCHAR(30) -- 생성자(계획 편성자)

  , @LANG			   VARCHAR(10) = 'KO'
  , @RS_CODE		   VARCHAR(1)   OUTPUT 
  , @RS_MSG			   VARCHAR(100) OUTPUT 

AS
BEGIN
	-- 프로시져에서 공통으로 사용할 일자, 일시 변수.
	DECLARE @LD_NOWDATE DATETIME    -- PROCEDURE 실행 일시
	      , @LS_NOWDATE VARCHAR(10) -- PROCEDURE 실행 일자
	;

		SET @LD_NOWDATE = GETDATE();
		SET @LS_NOWDATE = CONVERT(VARCHAR, @LD_NOWDATE, 23);

	-- 생산 계획 번호 채번.
	DECLARE @LI_SEQ			INT				-- 일자별 계획 순번
	      , @LS_PLANNO		VARCHAR(30)		-- 계획 번호가 담길 변수
	;

	-- 생산 계획 및 작업지시 테이블 TB_ProductPlan에서 오늘 일자로 내려진 생산 계획 순번 찾기.
	SELECT @LI_SEQ = ISNULL(MAX(PLANSEQ), 0) + 1
	  FROM TB_ProductPlan
	 WHERE PLANTCODE = @PLANTCODE
	   AND PLANDATE  = @LS_NOWDATE;

	-- 생산 계획 번호 채번
	SET @LS_PLANNO = 'PL' + CONVERT(VARCHAR, @LD_NOWDATE, 112) + RIGHT('0000' + CONVERT(VARCHAR, @LI_SEQ), 4);
	
	-- 생산 계획 등록:         공장,       계획번호,   품목,      계획수량, 단위,      계획일자,    일자별 계획순번
	INSERT INTO TB_ProductPlan(PLANTCODE,  PLANNO,     ITEMCODE,  PLANQTY,  UNITCODE,  PLANDATE,    PLANSEQ, MAKER,  MAKEDATE)
	                    VALUES(@PLANTCODE, @LS_PLANNO, @ITEMCODE, @PLANQTY, @UNITCODE, @LS_NOWDATE, @LI_SEQ, @MAKER, @LD_NOWDATE);

	SET @RS_CODE = 'S'	
END
GO
