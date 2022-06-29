SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.28
-- Description:	사용자 삭제
-- =============================================
--CREATE PROCEDURE [dbo].[13SP_USERMASTER_D]
ALTER PROCEDURE [dbo].[13SP_USERMASTER_D]
	@USERID		VARCHAR(20)	-- 사용자 아이디

AS
BEGIN
	DELETE TB_USER
	 WHERE USERID = @USERID;

END
GO
