SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      이기수
-- Create date: 2022.07.07
-- Description:	생산 실적 등록 - 작업 지시 등록.
-- =============================================
ALTER PROCEDURE [dbo].[13PP_ActualOutput_I2]
	@PLANTCODE			VARCHAR(10) -- 공장 코드
  , @WORKCENTERCODE		VARCHAR(10) -- 작업장
  , @ORDERNO			VARCHAR(30) -- 작업 지시 번호
  , @WORKERID			VARCHAR(30) -- 작업자 ID

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

	-- 1. 투입 LOT가 존재하는 지 확인.
	IF (
		SELECT COUNT(*)
		  FROM TB_StockHALB WITH(NOLOCK)
		 WHERE PLANTCODE = @PLANTCODE
		   AND WORKCENTERCODE = @WORKCENTERCODE
		) <> 0
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = '투입된 원자재 LOT가 존재합니다.' + char(13) + char(10) + '재조회 후 투입 LOT를 취소하세요.';
		RETURN;
	END;

	-- 2. 작업장 현재 상태 테이블에서 작업장의 상태 데이터 가져오기.
	DECLARE @LS_WORKER			  VARCHAR(30) -- 현재 등록된 작업자
	      , @LS_STATUS			  VARCHAR(1)  -- 현재 작업장의 가동 상태
		  , @LS_PERORDERNO		  VARCHAR(30) -- 현재 작업장에 등록된 작업 지시 번호
	
	-- 작업장 현재 상태 테이블에서 데이터 가져오기
	SELECT @LS_WORKER     = WORKER
	     , @LS_STATUS     = STATUS
		 , @LS_PERORDERNO = ORDERNO
	  FROM TP_WorkcenterStatus WITH(NOLOCK)
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE;

	-- 이전 작업 지시 번호와 현재 등록할 작업 지시 번호가 동일한가 확인
	IF (ISNULL(@LS_PERORDERNO, '') = @ORDERNO)
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = '동일한 작업 지시를 선택하였습니다.' +CHAR(13) + CHAR(10) +'작업 지시 선택을 종료합니다.';
		RETURN;
	END;

	-- 작업자 등록 내역 확인
	IF (ISNULL(@LS_WORKER, '') = '')
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = '선택 작업장에 투입된 작업자가 없습니다.' +CHAR(13) + CHAR(10) +'재조회 후 작업자를 등록하세요.';
		RETURN;
	END;

	-- 작업장 가동 상태 확인
	IF (ISNULL(@LS_STATUS, 'S') = 'R')
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = '작업장이 가동 중 입니다.' +CHAR(13) + CHAR(10) +'비가동 등록 후 진행하세요.';
		RETURN;
	END;

	-- 3. 선택 작업장에 새로운 작업 지시 번호 등록.
	DECLARE @LS_ITEMCODE VARCHAR(30)
	      , @LS_UNITCODE VARCHAR(10)
		  ;

	SELECT @LS_ITEMCODE = PP.ITEMCODE
	     , @LS_UNITCODE = PP.UNITCODE
	  FROM TB_ProductPlan PP WITH(NOLOCK)
	 WHERE PP.PLANTCODE = @PLANTCODE
	   AND PP.ORDERNO   = @ORDERNO;

	UPDATE TP_WorkcenterStatus -- 작업장 현재 상태 테이블
	   SET ORDERNO = @ORDERNO
	     , ITEMCODE = @LS_ITEMCODE
		 , UNITCODE = @LS_UNITCODE
		 , EDITDATE = @LS_NOWDATE
		 , EDITOR = @WORKERID
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE;

	-- 작업장별 가동/비가동 이력 현황 등록.
	DECLARE @LI_RSSEQ INT -- 작업장 작업지시별 가동/비가동 이력 SEQ
	;

	-- 이전 작업 시지에 대한 상태 종료 대상 SEQ 찾기
	SELECT @LI_RSSEQ = ISNULL(MAX(RSSEQ), 0)
	  FROM TP_WorkcenterStatusRec WITH(NOLOCK) -- 작업장별 가동/비가동 이력 테이블
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE
	   AND ORDERNO = @ORDERNO
	;

	--이전 가동 정보 업데이트
	UPDATE TP_WorkcenterStatusRec
	   SET RSENDDATE = @LD_NOWDATE
	     , EDITDATE = @LD_NOWDATE
		 , EDITOR = @WORKERID
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE
	   AND ORDERNO = @ORDERNO
	   AND RSSEQ = @LI_RSSEQ
	;

	-- 새로 선택한 작업 지시의 이전 이력 SEQ 찾기
	DECLARE @LI_ORDERSEQ INT;
	SELECT @LI_ORDERSEQ = ISNULL(MAX(RSSEQ), 0) + 1
	  FROM TP_WorkcenterStatusRec WITH(NOLOCK)
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE
	   AND ORDERNO = @ORDERNO

	-- 새로운 작업지시의 비가동 시작 등록
	INSERT INTO TP_WorkcenterStatusRec (PLANTCODE, WORKCENTERCODE, ORDERNO, RSSEQ, WORKER, ITEMCODE, STATUS, REMARK, RSSTARTDATE, MAKEDATE, MAKER)
	VALUES (@PLANTCODE, @WORKCENTERCODE, @ORDERNO, @LI_ORDERSEQ, @WORKERID, @LS_ITEMCODE, 'S', 'A00', @LD_NOWDATE, @LD_NOWDATE, @WORKERID);


	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 처리';
END
GO