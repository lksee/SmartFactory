-- 1번 --
SELECT *
  FROM TB_StockMMrec
 WHERE MATLOTNO NOT IN (SELECT MATLOTNO
                          FROM TB_StockMM);

-- 2번 --
-- 단계 1 --
-- 자재 재고 테이블에서 STOCKQTY가 5000보다 작은 MATLOTNO
SELECT MATLOTNO
  FROM TB_StockMM
 WHERE STOCKQTY < 5000

-- 단계 2 --
-- 1단계의 값으로 자재재고이력 테이블에서 ITEMCODE 찾아내기
SELECT ITEMCODE
  FROM TB_StockMMrec
 WHERE MATLOTNO IN (SELECT MATLOTNO
					  FROM TB_StockMM
					 WHERE STOCKQTY < 5000);

-- 단계 3 --
-- 2단계에서 나온 ITEMCODE 결과값을 가진 품목마스터 테이블의 품목 정보 조회.
SELECT ITEMCODE
     , ITEMNAME
	 , MAXSTOCK
	 , BASEUNIT
  FROM TB_ItemMaster
 WHERE ITEMCODE IN (SELECT ITEMCODE
					  FROM TB_StockMMrec
					 WHERE MATLOTNO IN (SELECT MATLOTNO
										  FROM TB_StockMM
										 WHERE STOCKQTY < 5000)
					);

-- 3번 --
SELECT *
  FROM (
		SELECT INOUTDATE
			 , WHCODE
			 , COUNT(*) AS CNT
		  FROM TB_StockMMrec
		 WHERE INOUTQTY > 1000
		   AND INOUTFLAG = 'I'
		 GROUP BY INOUTDATE, WHCODE
		) A
 WHERE A.CNT >= 2
;


-- 4번 --
-- 1단계
-- 11일부터 13일까지의 고객별 총 구매 금액 산출.
SELECT A.CUST_ID
     , SUM(A.AMOUNT * B.PRICE) AS FRUIT_PRICE
  FROM TB_SaleList A LEFT JOIN TB_FRUIT B
                            ON A.FRUIT_NAME = B.FRUIT_NAME
 WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
 GROUP BY A.CUST_ID

-- 2단계
-- 총 구매 금액이 가장 큰 1사람 구하기.
SELECT TOP (1) A.CUST_ID
     , SUM(A.AMOUNT * B.PRICE) AS FRUIT_PRICE
  FROM TB_SaleList A LEFT JOIN TB_FRUIT B
                            ON A.FRUIT_NAME = B.FRUIT_NAME
 WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
 GROUP BY A.CUST_ID
 ORDER BY FRUIT_PRICE DESC;

-- 3단계
-- 도출한 구매금액이 가장 큰 사람의 구매 이력 구하기

]