SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.29
-- Description:	작업자 조회
-- =============================================
CREATE PROCEDURE [dbo].[13BM_WorkerMaster_S]
	@PLANTCODE		VARCHAR(20),			-- 공장
	@BANCODE		VARCHAR(20),			-- 사용자 ID
	@WORKERID		VARCHAR(10),			-- 작업반
	@WORKDERNAME	VARCHAR(30),			-- 작업자
	@USEFLAG		VARCHAR(10),			-- 사용여부

	@LANG			VARCHAR(10) = 'KO',		-- 사용언어
	@RS_CODE		VARCHAR(1)	 OUTPUT,	-- 성공여부 코드
	@RS_MSG			VARCHAR(100) OUTPUT		-- 프로시져에서 전달할 메시지

AS
BEGIN


	SELECT WRK.PLANTCODE                 AS PLANTCODE  -- 공장
	     , WRK.WORKERID                  AS WORKERID   -- 작업자ID
		 , WRK.WORKERNAME                AS WORKERNAME -- 작업자 명
		 , WRK.BANCODE                   AS BANCODE    -- 작업반
		 , WRK.GRPID                     AS GRPID      -- 그룹
		 , WRK.DEPTCODE                  AS DEPTCODE   -- 부서
		 , WRK.PHONENO                   AS PHONENO    -- 연락처
		 , WRK.INDATE                    AS INDATE     -- 입사일
		 , WRK.OUTDATE                   AS OUTDATE    -- 퇴사일
		 , WRK. USEFLAG                  AS USEFLAG    -- 사용여부
		 , DBO.FN_WORKERNAME(WRK.MAKER)  AS MAKER      -- 생성자
		 , WRK.MAKEDATE                  AS MAKEDATE   -- 생성일시
		 , DBO.FN_WORKERNAME(WRK.EDITOR) AS EDITOR     -- 수정자
		 , WRK.EDITDATE                  AS EDITDATE   -- 수정일시
	  FROM TB_WorkerList WRK
	 WHERE ISNULL(WRK.PLANTCODE, '')  LIKE '%'+ISNULL(@PLANTCODE, '')+'%'
	   AND ISNULL(WRK.BANCODE, '')    LIKE '%'+ISNULL(@BANCODE, '')+'%'
	   AND ISNULL(WRK.WORKERID, '')   LIKE '%'+ISNULL(@WORKERID, '')+'%'
	   AND ISNULL(WRK.WORKERNAME, '') LIKE '%'+ISNULL(@WORKDERNAME, '')+'%'
	   AND ISNULL(WRK.BANCODE, '')    LIKE '%'+ISNULL(@BANCODE, '')+'%'

END
GO
