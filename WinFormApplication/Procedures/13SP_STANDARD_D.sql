USE [AppDev_SH]
GO
/****** Object:  StoredProcedure [dbo].[13SP_STANDARD_S]    Script Date: 2022-06-28 오후 5:26:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.28
-- Description:	공통코드 삭제
-- =============================================
CREATE PROCEDURE [dbo].[13SP_STANDARD_D]
--ALTER PROCEDURE [dbo].[13SP_STANDARD_S]
	@MAJORCODE		VARCHAR(10), -- 주코드
	@MINORCODE		VARCHAR(20)  -- 부코드
AS
BEGIN
	DELETE TB_Standard 
     WHERE MAJORCODE = @MAJORCODE
	   AND MINORCODE = @MINORCODE;
END
