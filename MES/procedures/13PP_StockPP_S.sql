SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[13PP_StockPP_S]
  @PLANTCODE		  VARCHAR(30) -- 공장
, @LOTNO			  VARCHAR(30) -- LOTNO
, @ITEMCODE			  VARCHAR(30) -- 품번
, @ITEMNAME			  VARCHAR(30) -- 품목명
, @ITEMTYPE			  VARCHAR(30) -- 품목 구분

, @LANG				  VARCHAR(10) = 'KO'
, @RS_CODE			  VARCHAR(1) OUTPUT
, @RS_MSG			  VARCHAR(100) OUTPUT


AS
BEGIN
	SELECT 0                                      AS CHK           	 -- 원자재 출고 내역 취고하는 체크박스
	     , SPP.PLANTCODE     					  AS PLANTCODE     	 -- 공장 코드
	     , SPP.ITEMCODE      					  AS ITEMCODE      	 -- 품목 코드
	     , ITM.ITEMNAME      					  AS ITEMNAME      	 -- 품목 명 
	     , ITM.ITEMTYPE      					  AS ITEMTYPE      	 -- 품목 구분
	     , SPP.LOTNO         					  AS LOTNO         	 -- LOT NO
	     , SPP.WHCODE        					  AS WHCODE        	 -- 창고 코드
	     , SPP.STORAGELOCCODE					  AS STORAGELOCCODE	 -- 저장 위치
	     , SPP.STOCKQTY      					  AS STOCKQTY      	 -- 재고 수량
	     , SPP.NOWQTY        					  AS NOWQTY        	 -- 현 재고량
	     , SPP.UNITCODE      					  AS UNITCODE      	 -- 단위
	     , SPP.INDATE        					  AS INDATE        	 -- 입고 일자
	     , DBO.FN_WORKERNAME(SPP.MAKER)			  AS MAKER         	 -- 등록자
	     , CONVERT(VARCHAR, SPP.MAKEDATE, 120)	  AS MAKEDATE      	 -- 등록 일시
	     , DBO.FN_WORKERNAME(SPP.EDITOR)		  AS EDITOR        	 -- 수정자
	     , CONVERT(VARCHAR, SPP.EDITDATE, 120)    AS EDITDATE      	 -- 수정 일시
	  FROM TB_StockPP SPP WITH(NOLOCK) LEFT JOIN TB_ItemMaster ITM WITH(NOLOCK)
	                                          ON SPP.PLANTCODE = ITM.PLANTCODE
											 AND SPP.ITEMCODE  = ITM.ITEMCODE
	 WHERE SPP.PLANTCODE LIKE '%' + @PLANTCODE
	   AND SPP.LOTNO     LIKE '%' + @LOTNO    + '%'
	   AND ISNULL(ITM.ITEMTYPE, '')  LIKE '%' + @ITEMTYPE
	   AND ISNULL(ITM.ITEMNAME, '')  LIKE '%' + @ITEMNAME + '%'
	   AND ISNULL(SPP.ITEMCODE, '')  LIKE '%' + @ITEMCODE + '%'
	;
	
	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';
END
GO
