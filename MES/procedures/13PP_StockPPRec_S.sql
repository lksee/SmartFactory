SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.06
-- Description:	공정 창고 입출력 이력 조회
-- =============================================
ALTER PROCEDURE [dbo].[13PP_StockPPRec_S]
  @PLANTCODE	 VARCHAR(10) -- 공장 코드
, @LOTNO 		 VARCHAR(30) -- LOT NO
, @ITEMCODE		 VARCHAR(30) -- 품번
, @STARTDATE  	 VARCHAR(10) -- 입출 시작 일자
, @ENDDATE 		 VARCHAR(10) -- 입출 종료 일자

, @LANG			 VARCHAR(10) = 'KO'
, @RS_CODE		 VARCHAR(1) OUTPUT
, @RS_MSG		 VARCHAR(100) OUTPUT
AS
BEGIN
	SELECT SPR.PLANTCODE						   AS PLANTCODE	-- 공장 코드
	     , SPR.LOTNO 						       AS LOTNO 	-- LOTNO
	     , SPR.ITEMCODE 						   AS ITEMCODE 	-- 품번
	     , ITM.ITEMNAME 						   AS ITEMNAME 	-- 품명
	     , SPR.RECDATE   						   AS INOUTDATE	-- 입출고일자
	     , SPR.WHCODE   						   AS WHCODE   	-- 창고
	     , SPR.INOUTCODE						   AS INOUTCODE	-- 입출유형
	     , SPR.INOUTFLAG						   AS INOUTFLAG	-- 입출 구분
	     , SPR.INOUTQTY 						   AS INOUTQTY 	-- 입출 수량
	     , SPR.UNITCODE 						   AS BASEUNIT 	-- 단위
	     , DBO.FN_WORKERNAME(SPR.MAKER)			   AS MAKER    	-- 등록자
	     , CONVERT(VARCHAR, SPR.MAKEDATE, 120)	   AS MAKEDATE 	-- 등록 일시
	  FROM TB_StockPPrec SPR WITH(NOLOCK) LEFT JOIN TB_ItemMaster ITM
	                                             ON SPR.PLANTCODE = ITM.PLANTCODE
												AND SPR.ITEMCODE  = ITM.ITEMCODE
	 WHERE SPR.PLANTCODE            LIKE '%' + @PLANTCODE
	   AND ISNULL(SPR.LOTNO, '')    LIKE '%' + @LOTNO + '%'
	   AND ISNULL(SPR.ITEMCODE, '') LIKE '%' + @ITEMCODE
	   AND SPR.RECDATE BETWEEN @STARTDATE AND @ENDDATE
	;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';



END
GO
