SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.30
-- Description:	작업자 내역 삽입
-- =============================================
--CREATE PROCEDURE [dbo].[13BM_WorkerMaster_I]
ALTER PROCEDURE [dbo].[13BM_WorkerMaster_I]
	@PLANTCODE 			VARCHAR(10) -- 공장
  , @WORKERID  			VARCHAR(20) -- 작업자 ID
  , @WORKERNAME			VARCHAR(30) -- 작업자 명
  , @BANCODE  			VARCHAR(10) -- 작업반
  , @GRPID     			VARCHAR(20) -- 그룹
  , @DEPTCODE  			VARCHAR(10) -- 부서코드
  , @PHONENO   			VARCHAR(50) -- 연락처
  , @INDATE    			VARCHAR(10) -- 입사일
  , @OUTDATE   			VARCHAR(10) -- 퇴사일
  , @USEFLAG   			VARCHAR(1) -- 사용여부
  , @MAKER				VARCHAR(20) -- 생성자

  , @LANG				VARCHAR(10) = 'KO'
  , @RS_CODE			VARCHAR(1)   OUTPUT
  , @RS_MSG				VARCHAR(100) OUTPUT

AS
BEGIN
	-- PK Validation check
	DECLARE @CNT INT = 0; -- 결과의 개수를 담을 변수

	-- 1. 직접 오류 내역을 비교하는 구문.
	BEGIN -- {
		IF (SELECT COUNT(*)
		      FROM TB_WorkerList
		     WHERE PLANTCODE = @PLANTCODE
		       AND WORKERID  = @WORKERID) > 0
		BEGIN
			SET @RS_CODE = 'E';
			SET @RS_MSG  = '이미 등록된 사용자입니다.';
			RETURN;
		END;
	END; -- }

	-- 2. 변수에 담은 값으로 비교하는 경우
	SELECT @CNT = COUNT(*)
	  FROM TB_WorkerList
	 WHERE PLANTCODE = @PLANTCODE
	   AND WORKERID  = @WORKERID;
	
	IF (@CNT > 0)
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = '이미 등록된 사용자입니다.';
		RETURN;
	END;
	 

	INSERT INTO TB_WorkerList (PLANTCODE, WORKERID, WORKERNAME, BANCODE, GRPID, DEPTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, MAKER, MAKEDATE) 
	VALUES (@PLANTCODE, @WORKERID, @WORKERNAME, @BANCODE, @GRPID, @DEPTCODE, @PHONENO, @INDATE, @OUTDATE, @USEFLAG, @MAKER, GETDATE());

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';
END
GO
