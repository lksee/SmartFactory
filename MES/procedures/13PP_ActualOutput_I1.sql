SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      이기수
-- Create date: 2022.07.07
-- Description:	생산 실적 등록 - 작업자 등록.
-- =============================================
CREATE PROCEDURE [dbo].[13PP_ActualOutput_I1]
	@PLANTCODE			VARCHAR(10) -- 공장 코드
  , @WORKCENTERCODE		VARCHAR(10) -- 작업장
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
	SET @LS_NOWDATE = CONVERT(VARCHAR, @LD_NOWDATE, 23); -- yyyy-MM-dd

	-- 1. 등록된 작업자인지 확인.
	IF (
		SELECT COUNT(*)
		  FROM TB_WorkerList WITH(NOLOCK)
		 WHERE PLANTCODE = @PLANTCODE
		   AND WORKERID  = @WORKERID
	   ) = 0
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = @WORKERID +'는 등록되지 않은 작업자입니다.';
		RETURN;
	END;

	-- 2. 작업장 상태 테이블에 현재 선택한 작업자를 등록.
	if (
		SELECT COUNT(*)
		  FROM TP_WorkcenterStatus WITH(NOLOCK)
		 WHERE WORKCENTERCODE = @WORKCENTERCODE
	)<> 0
	BEGIN
		UPDATE TP_WorkcenterStatus
		   SET WORKER   = @WORKERID
		     , EDITDATE = @LD_NOWDATE
			 , EDITOR   = @WORKERID
		 WHERE PLANTCODE      = @PLANTCODE
		   AND WORKCENTERCODE = @WORKCENTERCODE
		;
		/*
		-- https://docs.microsoft.com/ko-kr/sql/t-sql/functions/rowcount-transact-sql?view=sql-server-ver16
		-- @@ROWCOUNT : 가장 마지막에 작업한 쿼리의 결과 개수를 담고 있다.
		IF(@@ROWCOUNT = 0)
		BEGIN
			INSERT INTO TP_WorkcenterStatus (PLANTCODE, WORKCENTERCODE, WORKER, STATUS, MAKEDATE, MAKER)
			VALUES (@PLANTCODE, @WORKCENTERCODE, @WORKERID, 'S', @LD_NOWDATE, @WORKERID)
		END;
		*/
	END
	ELSE
	BEGIN
		INSERT INTO TP_WorkcenterStatus (PLANTCODE, WORKCENTERCODE, WORKER, STATUS, MAKEDATE, MAKER)
		VALUES (@PLANTCODE, @WORKCENTERCODE, @WORKERID, 'S', @LD_NOWDATE, @WORKERID)
	END;


	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 처리';
END
GO
