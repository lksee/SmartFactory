/*
VIEW
1. 자주 사용되는 SELECT 구문을 미리 만들어두고, 테이블처럼 호출할 수 있도록 만든 기능.
2. SQL SERVER의 VIEW는 하나의 테이블로부터 특정 컬럼들만 보여주거나, 
   특정 조건에 맞는 행들만 보여주는데 사용될 수 있으며, 
   둘 이상의 테이블을 JOIN하여 하나의 VIEW로 사용자에게 보여줄 수 있다.
3. VIEW 자체는 테이블처럼 실제 데이터를 가지고 있지 않다. 단지 SELECT문의 정의만 가지고 있다.
4. 보안상의 이유로 테이블 중 일부 컬럼만 공개하고자 할 때 사용한다.

VIEW의 작성
과일가게 일자별 판매, 발주한 리스트를 VIEW 형태로 만들고, VIEW를 호출하여 데이터를 표현
*/

CREATE VIEW V_FruitBusinessList AS
SELECT '판매'             AS TITLE
     , A.[DATE]           AS DATE
     , A.CUST_ID          AS CUST_ID
     , B.NAME             AS NAME
     , A.FRUIT_NAME       AS FRUIT_NAME
     , A.AMOUNT           AS AMOUNT
     , A.AMOUNT * C.PRICE AS INOUTPRICE
  FROM TB_SaleList A LEFT JOIN TB_Cust B
                            ON A.CUST_ID = B.ID
                     LEFT JOIN TB_FRUIT C
                            ON A.FRUIT_NAME = C.FRUIT_NAME

UNION ALL

-- 거래처에 발주한 내역
SELECT '발주'                    AS TITLE
     , A.[DATE]                  AS DATE
     , A.CUSTCODE                AS CUST_ID
     , CASE CUSTCODE WHEN 1 THEN '대림'
                     WHEN 2 THEN '삼전'
                     WHEN 3 THEN '하나'
       END                       AS NAME
     , A.FRUIT_NAME              AS FRUIT_NAME
     , A.AMOUNT                  AS AMOUNT
     , -A.AMOUNT * B.ORDER_PRICE AS INOUTPRICE
  FROM TB_OrderList A LEFT JOIN TB_FRUIT B
                             ON A.FRUIT_NAME = B.FRUIT_NAME
;


SELECT DATE
     , SUM(INOUTPRICE) AS INOUTPRICE
  FROM V_FruitBusinessList
 GROUP BY DATE;


-- 실습
-- 과일가게 관리 테이블 (TB_FRUIT, TB_ORDERLIST, TB_SALELIST)에서 
-- 일자별 총 판매금액(V_DAY_SALELIST)와
-- 일자별 총 발주금액(V_DAY_ORDERLIST) SELECT 문을 VIEW 형태로 만들고
-- 생성한 VIEW를 통해 거래(판매, 발주)된 내역의 전체 마진을 구하세요.
-- 컬럼 : TOTALMARGIN

DROP VIEW V_DAY_SALELIST;

CREATE VIEW V_DAY_SALELIST AS
SELECT A.DATE
     , SUM(A.AMOUNT * B.PRICE) AS SALES_PRICE
  FROM TB_SaleList A LEFT JOIN TB_FRUIT B
                            ON A.FRUIT_NAME = B.FRUIT_NAME
 GROUP BY A.DATE;

DROP VIEW V_DAY_ORDERLIST;

CREATE VIEW V_DAY_ORDERLIST AS
SELECT A.DATE
     , -SUM(A.AMOUNT * B.ORDER_PRICE) AS ORDER_PRICE
  FROM TB_OrderList A LEFT JOIN TB_FRUIT B
                             ON A.FRUIT_NAME = B.FRUIT_NAME
 GROUP BY A.DATE;

SELECT S.[DATE]
     , ISNULL(S.SALES_PRICE, 0) + ISNULL(O.ORDER_PRICE, 0) AS TOTALMARGIN
  FROM V_DAY_SALELIST S LEFT JOIN V_DAY_ORDERLIST O
                               ON S.[DATE] = O.[DATE]
;


