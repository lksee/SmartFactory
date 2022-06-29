SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.27
-- Description:	사용자 정보 조회
-- =============================================
--CREATE PROCEDURE [DBO].[13SP_USERMASTER_S]
ALTER PROCEDURE [DBO].[13SP_USERMASTER_S]
 -- Parameter 설정 부분
 @USERID		VARCHAR(20), -- 사용자 ID
 @USERNAME		VARCHAR(30), -- 사용자 명
 @DEPTCODE		VARCHAR(10)  -- 부서 코드
AS
BEGIN
	SELECT USERID   AS USERID   -- 사용자 id
	     , USERNAME AS USERNAME -- 사용자 명
		 , PW       AS PW       -- 비밀번호
		 , DEPTCODE AS DEPTCODE -- 부서
		 , MAKEDATE AS MAKEDATE -- 생성일시
		 , MAKER    AS MAKER    -- 생성자
		 , EDITDATE AS EDITDATE -- 수정일시
		 , EDITOR   AS EDITOR   -- 수정자
	  FROM TB_USER WITH(NOLOCK) -- 트랜잭션 설정 무시.
	 WHERE USERID LIKE '%' + @USERID + '%'
	   AND USERNAME LIKE '%' + @USERNAME + '%'
	   AND ISNULL(DEPTCODE, '') LIKE '%' + @DEPTCODE;

END
GO
