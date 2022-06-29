SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.28
-- Description:	사용자 입력
-- =============================================
CREATE PROCEDURE [dbo].[13SP_USERMASTER_I]
	@USERID		VARCHAR(20), -- 사용자 ID
	@USERNAME	VARCHAR(20), -- 사용자 명
	@PW			VARCHAR(20), -- 사용자 비밀번호
	@DEPTCODE	VARCHAR(20), -- 부서코드
	@MAKER		VARCHAR(20)  -- 생성자

AS
BEGIN
	INSERT INTO TB_USER(USERID, USERNAME, PW, DEPTCODE, MAKER, MAKEDATE)
	VALUES (@USERID, @USERNAME, @PW, @DEPTCODE, @MAKER, GETDATE());

END
GO
