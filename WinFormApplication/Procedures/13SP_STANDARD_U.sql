SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.28
-- Description:	공통코드 삽입
-- =============================================
CREATE PROCEDURE [dbo].[13SP_STANDARD_U]
--ALTER PROCEDURE [dbo].[13SP_STANDARD_U]
	@MAJORCODE		VARCHAR(10), -- 주코드
	@MINORCODE		VARCHAR(20), -- 부코드
	@CODENAME		VARCHAR(20), -- 코드명
	@DISPLAYNO		INT          -- 표시순서
AS
BEGIN
	UPDATE TB_Standard
	   SET CODENAME = @CODENAME
	     , DISPLAYNO = @DISPLAYNO
	 WHERE MAJORCODE = @MAJORCODE
	   AND MINORCODE = @MINORCODE;

END
GO
