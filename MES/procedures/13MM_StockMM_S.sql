SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.04
-- Description:	자재 재고 현황 조회.
-- =============================================
CREATE PROCEDURE [dbo].[13MM_StockMM_S]
    @PLANTCODE		VARCHAR(10) -- 공장 코드
  , @ITEMCODE		VARCHAR(20) -- 품목 코드
  , @MATLOTNO		VARCHAR(30) -- LOT NO

  , @LANG			VARCHAR(10) = 'KO' 
  , @RS_CODE		VARCHAR(1) OUTPUT
  , @RS_MSG			VARCHAR(100) OUTPUT

AS
BEGIN
	SELECT STK.PLANTCODE                       AS PLANTCODE -- 사업장
		 , STK.ITEMCODE                        AS ITEMCODE  -- 품목
		 , ITM.ITEMNAME                        AS ITEMNAME  -- 품목명
		 , STK.MATLOTNO                        AS MATLOTNO  -- LOTNO
		 , STK.WHCODE                          AS WHCODE    -- 창고
		 , STK.STOCKQTY                        AS STOCKQTY  -- 재고수량
		 , STK.UNITCODE                        AS UNITCODE  -- 단위
		 , STK.CUSTCODE                        AS CUSTCODE  -- 거래처
		 , CSM.CUSTNAME                        AS CUSTNAME  -- 거래처 명
		 , STK.INDATE                          AS INDATE    -- 입고일자
		 , DBO.FN_WORKERNAME(STK.MAKER)        AS MAKER     -- 생성자
		 , CONVERT(VARCHAR, STK.MAKEDATE, 120) AS MAKEDATE  -- 생성일시
	  FROM TB_StockMM STK LEFT JOIN TB_ItemMaster ITM
								 ON STK.PLANTCODE = ITM.PLANTCODE
								AND STK.ITEMCODE  = ITM.ITEMCODE
						  LEFT JOIN TB_CustMaster CSM
								 ON STK.PLANTCODE = CSM.PLANTCODE
								AND STK.CUSTCODE  = CSM.CUSTCODE
	 WHERE STK.PLANTCODE			 LIKE '%' + @PLANTCODE + '%'
	   AND STK.MATLOTNO				 LIKE '%' + @MATLOTNO  + '%'
	   AND ISNULL(STK.ITEMCODE, '')  LIKE '%' + @ITEMCODE  + '%'
	;
END
GO
