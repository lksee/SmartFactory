/*
SQL 角公1
*/
SELECT REC.*
  FROM TB_StockMMrec REC 
 WHERE REC.MATLOTNO NOT IN (SELECT MM.MATLOTNO
                              FROM TB_StockMM MM)
;


/*
SQL 角公2
*/
SELECT MST.ITEMCODE
     , MST.ITEMNAME
	 , MST.MAXSTOCK
	 , MST.BASEUNIT 
  FROM TB_ItemMaster MST
 WHERE MST.ITEMCODE IN (
						SELECT REC.ITEMCODE
						  FROM TB_StockMMrec REC
						 WHERE REC.MATLOTNO IN (
												SELECT MM.MATLOTNO
												  FROM TB_StockMM MM
												 WHERE MM.STOCKQTY < 5000
											   )
						);


/*
SQL 角公3
*/
SELECT RST.*
  FROM (
	    SELECT REC.INOUTDATE
	    	 , REC.WHCODE
	    	 , COUNT(1) AS CNT
	      FROM TB_StockMMrec REC
	     WHERE REC.INOUTQTY > 1000
	       AND REC.INOUTFLAG = 'I'
	     GROUP BY REC.INOUTDATE
	    		, REC.WHCODE
       ) RST
 WHERE RST.CNT >= 2
 ORDER BY RST.INOUTDATE;


/*
SQL 角公4
*/
SELECT CST.ID AS CUST_ID
     , CST.NAME
	 , SLT.DATE
	 , SLT.FRUIT_NAME
	 , SLT.AMOUNT
	 , SLT.AMOUNT * FRT.PRICE AS BUYPRICE
  FROM TB_Cust CST LEFT JOIN TB_SaleList SLT
                          ON CST.ID = SLT.CUST_ID
                   LEFT JOIN TB_FRUIT FRT
				          ON SLT.FRUIT_NAME = FRT.FRUIT_NAME
 WHERE CST.ID  = (
                  SELECT TOP (1) SLT.CUST_ID
                    FROM TB_SaleList SLT LEFT JOIN TB_FRUIT FRT
                  							  ON SLT.FRUIT_NAME = FRT.FRUIT_NAME
                   WHERE SLT.DATE BETWEEN '2022-06-11' AND '2022-06-13'
                   GROUP BY SLT.CUST_ID
                  		, SLT.DATE
                  		, SLT.FRUIT_NAME
                   ORDER BY SUM(SLT.AMOUNT*FRT.PRICE) DESC
                  );