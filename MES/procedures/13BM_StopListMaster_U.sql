SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.30
-- Description:	비가동 항목 수정
-- =============================================
ALTER PROCEDURE [dbo].[13BM_StopListMaster_U]
--CREATE PROCEDURE [dbo].[13BM_StopListMaster_U]
	@PLANTCODE		VARCHAR(10)		-- 공장
  , @STOPCODE		VARCHAR(10)		-- 비가동 코드
  , @STOPNAME		VARCHAR(20)		-- 비가동 명
  , @REMARK			VARCHAR(255)    -- 비고
  , @USEFLAG		VARCHAR(1)		-- 사용여부
  , @EDITOR			VARCHAR(20)     -- 수정자

  , @LANG			VARCHAR(10) = 'KO'
  , @RS_CODE		VARCHAR(1) OUTPUT
  , @RS_MSG			VARCHAR(100) OUTPUT

AS
BEGIN
	UPDATE TB_StopListMaster
	   SET STOPNAME  = @STOPNAME
		 , REMARK    = @REMARK
		 , USEFLAG   = @USEFLAG
		 , EDITOR    = @EDITOR
		 , EDITDATE  = GETDATE()
	 WHERE PLANTCODE = @PLANTCODE
	   AND STOPCODE  = @STOPCODE;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';
	
END
GO
