SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      이기수
-- Create date: 2022.07.08
-- Description:	생산 실적 등록 - 5. 가동/비가동 등록.
-- =============================================
CREATE PROCEDURE [dbo].[13PP_ActualOutput_I4]
	@PLANTCODE     		VARCHAR(10) -- 공장 코드
  , @WORKCENTERCODE		VARCHAR(10) -- 작업장
  , @ITEMCODE      		VARCHAR(30) -- 작업자 ID
  , @ORDERNO       		VARCHAR(30) -- 작업 지시 번호
  , @STATUS        		VARCHAR(1)  -- 상태

  , @LANG				VARCHAR(10) = 'KO'
  , @RS_CODE			VARCHAR(1) OUTPUT
  , @RS_MSG				VARCHAR(100) OUTPUT


AS
BEGIN
	-- 프로시져에서 공통으로 사용할 일자, 일시 변수.
	DECLARE @LD_NOWDATE DATETIME    -- PROCEDURE 실행 일시
	      , @LS_NOWDATE VARCHAR(10) -- PROCEDURE 실행 일자
	;

	SET @LD_NOWDATE = GETDATE();
	SET @LS_NOWDATE = CONVERT(VARCHAR, @LD_NOWDATE, 23);

	-- 1. 작업장 등록된 작업자 여부 확인하기
	DECLARE @LS_WORKERID VARCHAR(30);

	SELECT @LS_WORKERID = WORKER
	  FROM TP_WorkcenterStatus WITH(NOLOCK)
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE
	;

	IF (@LS_NOWDATE IS NULL)
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = @WORKCENTERCODE + '에 투입된 작업자 정보가 없습니다.';
		RETURN;
	END;

	-- 2. 작업장 현재 상태 테이블에 (가동/비가동) 등록
	UPDATE TP_WorkcenterStatus
	   SET STATUS = @STATUS
	     , EDITOR = @LS_WORKERID
		 , EDITDATE = @LD_NOWDATE
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE
	 ;

	 -- 3. 작업장별 작업 지시 이력 테이블에 마지막 지시 번호에 대한 SEQ 가져오기.
	 DECLARE @LI_RSSEQ INT;

	 SELECT @LI_RSSEQ = ISNULL(MAX(RSSEQ), 0)
	   FROM TP_WorkcenterStatusRec WITH(NOLOCK)
	  WHERE PLANTCODE      = @PLANTCODE
	    AND WORKCENTERCODE = @WORKCENTERCODE
		AND ORDERNO        = @ORDERNO
	;

	UPDATE TP_WorkcenterStatusRec
	   SET RSENDDATE = @LD_NOWDATE
	     , EDITDATE  = @LD_NOWDATE
		 , EDITOR    = @LS_WORKERID
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE
	   AND RSSEQ = @LI_RSSEQ
	;

	-- 변경되는 가동/비가동에 대한 시작 시간 INSERT
	INSERT INTO TP_WorkcenterStatusRec ( PLANTCODE,   WORKCENTERCODE, ORDERNO,  RSSEQ,         WORKER,       ITEMCODE,  STATUS, RSSTARTDATE,   REMARK,   MAKEDATE,     MAKER)
	                            VALUES (@PLANTCODE, @WORKCENTERCODE, @ORDERNO, @LI_RSSEQ + 1, @LS_WORKERID, @ITEMCODE, @STATUS, @LD_NOWDATE,         ,  @LD_NOWDATE, @LS_WORKERID);
	
	-- 작업 지시가 최초 시작일 경우 작업 지시 확정 내역에 작업 지시의 시작 일시를 UPDATE
	IF (@STATUS = 'R')
	BEGIN
		UPDATE TB_ProductPlan
		   SET FIRSTSTARTDATE = @LD_NOWDATE
		     , EDITDATE       = @LD_NOWDATE
			 , EDITOR         = @LS_WORKERID
		 WHERE PLANTCODE = @PLANTCODE
		   AND ORDERNO   = @ORDERNO
		   AND FIRSTSTARTDATE IS NULL
		;
	END;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 처리';
END
GO