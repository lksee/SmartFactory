SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.06.30
-- Description:	비가동 항목 조회
-- =============================================
ALTER PROCEDURE [dbo].[13BM_StopListMaster_S]
--CREATE PROCEDURE [dbo].[13BM_StopListMaster_S]
	@PLANTCODE		VARCHAR(10)		-- 공장
  , @STOPCODE		VARCHAR(10)		-- 비가동 코드
  , @STOPNAME		VARCHAR(20)		-- 비가동 명
  , @USEFLAG		VARCHAR(1)		-- 사용여부

  , @LANG			VARCHAR(10) = 'KO'
  , @RS_CODE		VARCHAR(1) OUTPUT
  , @RS_MSG			VARCHAR(100) OUTPUT

AS
BEGIN
	SELECT SLM.PLANTCODE                       AS   PLANTCODE	-- 공장
         , SLM.STOPCODE	                       AS	STOPCODE	-- 비가동 코드
         , SLM.STOPNAME	                       AS	STOPNAME	-- 비가동 명
         , SLM.REMARK	                       AS	REMARK		-- 비고
         , SLM.USEFLAG	                       AS	USEFLAG		-- 사용여부
         , DBO.FN_WORKERNAME(SLM.MAKER)   	   AS	MAKER   	-- 생성자
         , CONVERT(VARCHAR, SLM.MAKEDATE, 120) AS	MAKEDATE	-- 생성일자
         , DBO.FN_WORKERNAME(SLM.EDITOR)       AS	EDITOR   	-- 수정자
         , CONVERT(VARCHAR, SLM.EDITDATE, 120) AS	EDITDATE	-- 수정일자
	  FROM TB_StopListMaster SLM WITH(NOLOCK)
	 WHERE SLM.PLANTCODE LIKE ISNULL('%' + @PLANTCODE + '%', '')
	   AND SLM.STOPCODE  LIKE ISNULL('%' + @STOPCODE + '%', '')
	   AND SLM.STOPNAME  LIKE ISNULL('%' + @STOPNAME + '%', '')
	   AND SLM.USEFLAG   LIKE ISNULL('%' + @USEFLAG + '%', '');

END
GO
