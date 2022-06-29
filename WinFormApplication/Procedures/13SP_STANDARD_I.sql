SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.28
-- Description:	공통코드 삽입
-- =============================================
--CREATE PROCEDURE [dbo].[13SP_STANDARD_I]
ALTER PROCEDURE [dbo].[13SP_STANDARD_I]
	@MAJORCODE		VARCHAR(10), -- 주코드
	@MINORCODE		VARCHAR(20), -- 부코드
	@CODENAME		VARCHAR(20), -- 코드명
	@DISPLAYNO		INT          -- 표시순서
AS
BEGIN
	INSERT INTO TB_Standard(MAJORCODE, MINORCODE, CODENAME, DISPLAYNO)
	VALUES(@MAJORCODE, @MINORCODE, @CODENAME, @DISPLAYNO);

END
GO
