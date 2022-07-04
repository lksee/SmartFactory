SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.04
-- Description:	구매자재 발주 및 입고 내역 조회.
-- =============================================
ALTER PROCEDURE [DBO].[13MM_POMake_S]
     @PLANTCODE			VARCHAR(10) -- 공장 코드
   , @ITEMCODE			VARCHAR(10) -- 품명 코드
   , @CUSTCODE			VARCHAR(10) -- 거래처 코드
   , @STARTDATE			VARCHAR(10) -- 시작 일자
   , @ENDDATE			VARCHAR(10) -- 종료 일자
   , @PONO  			VARCHAR(10) -- 발주 번호

   , @LANG				VARCHAR(10) = 'KO'
   , @RS_CODE			VARCHAR(1) OUTPUT
   , @RS_MSG			VARCHAR(100) OUTPUT
AS
BEGIN
	SELECT POM.PLANTCODE                       AS PLANTCODE	  -- 공장 코드
	     , POM.PONO                            AS PONO 		  -- 발주 번호
	     , POM.POSEQ                           AS POSEQ		  -- 발주 시퀀스
	     , POM.PODATE                          AS PODATE	  -- 발주 일자
	     , POM.ITEMCODE                        AS ITEMCODE	  -- 발주 품목
	     , POM.POQTY                           AS POQTY 	  -- 발주 수량
	     , POM.UNITCODE                        AS UNITCODE	  -- 단위
	     , POM.CUSTCODE                        AS CUSTCODE	  -- 협력 업체
	     , CASE WHEN ISNULL(POM.INFLAG, 'N') = 'Y' THEN 1
		        ELSE 0 END                     AS CHK		  -- 입고 등록
	     , POM.INQTY                           AS INQTY		  -- 입고 수량
	     , POM.LOTNO                           AS LOTNO		  -- LOT NO
	     , POM.INDATE                          AS INDATE 	  -- 입고 일자
	     , POM.INWORKER                        AS INWORKER	  -- 입고자
	     , DBO.FN_WORKERNAME(POM.MAKER)        AS MAKER
	     , CONVERT(VARCHAR, POM.MAKEDATE, 120) AS MAKEDATE	
	     , DBO.FN_WORKERNAME(POM.EDITOR)       AS EDITOR 	
	     , CONVERT(VARCHAR, POM.EDITDATE, 120) AS EDITDATE	
	  FROM TB_POMake POM WITH(NOLOCK)
	 WHERE POM.PLANTCODE             LIKE  '%'+ @PLANTCODE +'%'
	   AND POM.PONO      LIKE  '%'+ @PONO +'%'
	   AND POM.PODATE BETWEEN @STARTDATE AND @ENDDATE
	   AND ISNULL(POM.ITEMCODE, '')  LIKE  '%'+ @ITEMCODE +'%'
	   AND ISNULL(POM.CUSTCODE, '')  LIKE  '%'+ @CUSTCODE +'%'
	;

	SET @RS_CODE = 'S';
	SET @RS_MSG = '정상 처리';

END
GO
