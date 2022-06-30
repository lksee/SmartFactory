SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.30
-- Description:	작업자 내역 수정
-- =============================================
CREATE PROCEDURE [dbo].[13BM_WorkerMaster_U]
--ALTER PROCEDURE [dbo].[13BM_WorkerMaster_U]
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
  , @EDITOR				VARCHAR(20) -- 수정자

  , @LANG				VARCHAR(10) = 'KO'
  , @RS_CODE			VARCHAR(1)   OUTPUT
  , @RS_MSG				VARCHAR(100) OUTPUT

AS
BEGIN

	UPDATE TB_WorkerList
	   SET WORKERNAME   = @WORKERNAME	
         , BANCODE  	= @BANCODE  	
         , GRPID     	= @GRPID     	
         , DEPTCODE  	= @DEPTCODE  	
         , PHONENO   	= @PHONENO   	
         , INDATE    	= @INDATE    	
         , OUTDATE   	= @OUTDATE   	
         , USEFLAG   	= @USEFLAG   	
         , EDITOR		= GETDATE()		
	 WHERE PLANTCODE = @PLANTCODE
       AND WORKERID  = @WORKERID;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';
END
GO
