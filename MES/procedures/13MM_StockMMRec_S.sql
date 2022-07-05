SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.05
-- Description:	자재 입출고 이력 조회.
-- =============================================
CREATE PROCEDURE [dbo].[13MM_StockMMRec_S]
  @PLANTCODE		 VARCHAR(10) -- 공장
, @ITEMCODE			 VARCHAR(30) -- 품목 코드
, @STARTDATE		 VARCHAR(10) -- 입출 시작 일자
, @ENDDATE			 VARCHAR(10) -- 입출 종료 일자
, @MATLOTNO			 VARCHAR(30) -- LOT NO

, @LANG				 VARCHAR(10) = 'KO'
, @RS_CODE			 VARCHAR(1) OUTPUT
, @RS_MSG			 VARCHAR(100) OUTPUT

AS
BEGIN
	SELECT SMR.PLANTCODE								 AS PLANTCODE
         , SMR.ITEMCODE 								 AS ITEMCODE 
         , ITM.ITEMNAME 								 AS ITEMNAME 
         , SMR.INOUTDATE								 AS INOUTDATE
         , SMR.WHCODE  									 AS WHCODE  
         , SMR.INOUTCODE								 AS INOUTCODE
         , SMR.INOUTFLAG								 AS INOUTFLAG
         , SMR.INOUTQTY 								 AS INOUTQTY 
         , ITM.BASEUNIT 								 AS BASEUNIT 
         , SMR.INOUTWORKER								 AS INOUTWORKER
         , SMR.PONO   									 AS PONO   
         , SMR.MATLOTNO 								 AS MATLOTNO 
         , DBO.FN_WORKERNAME(SMR.MAKER)					 AS MAKER
         , CONVERT(VARCHAR, SMR.MAKEDATE, 120)			 AS MAKEDATE
	  FROM TB_StockMMrec SMR WITH(NOLOCK) LEFT JOIN TB_ItemMaster ITM WITH(NOLOCK)
	                                             ON SMR.PLANTCODE = ITM.PLANTCODE
								                AND SMR.ITEMCODE  = ITM.ITEMCODE
	 WHERE SMR.PLANTCODE             LIKE '%' + @PLANTCODE
	   AND ISNULL(SMR.ITEMCODE, '')  LIKE '%' + @ITEMCODE
	   AND ISNULL(SMR.MATLOTNO, '')  LIKE '%' + ISNULL(@MATLOTNO, '')  + '%'
	   AND SMR.INOUTDATE BETWEEN @STARTDATE AND @ENDDATE
	;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';
END
GO
