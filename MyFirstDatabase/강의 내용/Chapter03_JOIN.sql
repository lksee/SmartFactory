/*
1. 테이블 간 데이터 연결 및 조회(JOIN)
JOIN : 둘 이상의 테이블을 연결해서데이터를 검색하는 방법.
       테이블을 서로 연결하기 위해서는 하나 이상의 컬럼을 공유하고 있어야 함.
  ON : 두 테이블을 연결할 기준 컬럼 설정 명령어.

  - 내부 조인(INNER JOIN) : JOIN
  - 외부 조인(OUTER JOIN) : LEFT JOIN, RIGHT JOIN, FULL JOIN
*/

-- JOIN 
-- 공통적인 부분만 조회되는 연결문.

/*
TB_Cust 테이블과 TB_SaleList 테이블에서 
각각 DB_Cust.ID, TB_SaleList.CUST_ID 컬럼 간에 값이 동일한 데이터를 가지고
고객 ID, 고객 이름, 판매일자, 과일, 판매수량을 표현
*/

-- ** 명시적 표현법 JOIN문과 ON

-- 판매 현황 리스트 테이블을 기준으로 고객 정보를 JOIN한 경우
SELECT A.CUST_ID                                           -- 고객 ID
     , B.NAME+' 바보'AS CUST_NAME                          -- 고객 명
	 , A.DATE                                              -- 판매 일자
	 , A.FRUIT_NAME                                        -- 과일 이름
	 , CONVERT(CHAR, A.AMOUNT)+'개' AS "판매수량"          -- 판매수량
  FROM TB_SaleList A JOIN TB_Cust B ON A.CUST_ID = B.ID;

-- 고객 정보를 기준으로 조회하고자 고객정보를 조회하면
-- 아래의 결과처럼 고객 정보가 전부 나타난다.
SELECT *
  FROM TB_Cust
;

-- 고객정보 테이블을 기준으로 테이블로 하고 판매 테이블을 서브 테이블로 JOIN했지만
-- 기준 테이블에 있는 데이터가 나타나지 않는 경우가 생긴다.
SELECT A.ID
     , A.NAME
	 , B.DATE
	 , B.FRUIT_NAME
	 , B.AMOUNT
  FROM TB_Cust A JOIN TB_SaleList B 
                   ON A.ID = B.CUST_ID
;
-- JOIN: 공통적인 부분만 조회되며
-- 연결되는 테이블 간 공유하는 컬럼의 데이터가 둘 다 존재해야 데이터를 나타낸다.

SELECT A.ID
     , A.NAME
	 , A.PHONE
	 , B.DATE
	 , B.FRUIT_NAME
	 , B.AMOUNT
  FROM TB_Cust A
     , TB_SaleList B
 WHERE A.ID = B.CUST_ID
;

-- 묵시적 표현법 : JOIN ON 문을 쓰지않고 테이블만 나열 후 참조될 컬럼을 정의하는 방법.
SELECT A.ID          AS ID
     , A.NAME        AS CUSTNAME
	 , B.FRUIT_NAME  AS FRUIT_NAME
  FROM TB_Cust A
     , TB_SaleList B -- INNER JOIN (JOIN)
 WHERE A.ID  = B.CUST_ID
;

-- 외부JOIN (LEFT JOIN, RIGHT JOIN)

-- LEFT JOIN
-- 왼쪽에 있는 테이블의 데이터를 기준으로 오른쪽에 있는 테이블의 데이터를 검색하고
-- 오른쪽 테이블에 데이터가 없을 경우 NULL로 표시된다.

-- 왼쪽에 있는 TB_SaleList의 내용을 기준으로 판매 현황별 고객 정보를 나타내세요.

SELECT A.DATE         --판매 일자
     , A.CUST_ID      --고객 ID
	 , B.NAME         --고객 명
	 , A.FRUIT_NAME   --과일명
	 , A.AMOUNT       --판매수량.
  FROM TB_SaleList A LEFT JOIN TB_Cust B --LEFT OUTER JOIN
                            ON A.CUST_ID = B.ID
;

-- 왼족에 있는 TB_Cust의 내용을 기준으로 고객별 판매 현황을 나타내세오.

SELECT A.ID           --고객 ID
     , A.NAME         --고객 명
	 , B.DATE         --판매 일자
	 , B.FRUIT_NAME   --과일 명
	 , B.AMOUNT       --수량
  FROM TB_Cust A LEFT JOIN TB_SaleList B
                        ON A.ID = B.CUST_ID
;

-- RIGHT JOIN(RIGHT OUTER JOIN)
-- 오른쪽에 있는 테이블의 데이터를 기준으로 왼쪽에 있는 테이블의 데이터를 검색하고
-- 왼쪽 테이블ㅇ ㅔ데이터가 없을 경우 NULL로 표시한다.(LEFT JOIN과 반대)

-- 오른쪽에 있는 TB_Cust의 내용을 기준으로 고객별 판매현황을 나타내세요.
SELECT B.ID           --고객 ID
     , B.NAME         --고객 명
     , A.[DATE]       --판매일자
     , A.FRUIT_NAME   --과일명
     , A.AMOUNT       --수량
  FROM TB_SaleList A RIGHT JOIN TB_Cust B
                             ON A.CUST_ID = B.ID
;

-- 오른쪽에 있는 TB_SaleList의 내용을 기준으로 판매현황별 고객 정보를 나타내세요.
SELECT B.[DATE]        --판매일자
     , B.CUST_ID       --고객 ID
     , A.NAME          --고객 명
     , B.FRUIT_NAME    --과일 명
     , B.AMOUNT        --수량
  FROM TB_Cust A RIGHT JOIN TB_SaleList B
                         ON A.ID = B.CUST_ID
;


-- 다중 JOIN
-- 참조할 데이터가 여러 테이블에 있을 때 
-- 기준 테이블과 참조 테이블과의 다중 JOIN으로 데이터를 검색할 수 있다.

-- 판매 현황을 판매일자, 고객이름, 고객 연락처, 판매과일, 과일단가, 판매금액으로 나타내시오.
SELECT A.DATE             AS SALEDATE   -- 판매 일자
     , B.NAME             AS CUSTNAME   -- 고객 이름
     , B.PHONE            AS CUSTPHONE  -- 고객 연락처
     , A.FRUIT_NAME       AS FRUITNAME  -- 판매 과일
     , C.PRICE            AS UNITPRICE  -- 과일 단가
     , A.AMOUNT           AS AMOUNT     -- 판매 수량
     , C.PRICE * A.AMOUNT AS SALESPRICE -- 판매 금액
  FROM TB_SaleList A LEFT JOIN TB_Cust B
                            ON A.CUST_ID = B.ID
                     LEFT JOIN TB_FRUIT C                     
                            ON A.FRUIT_NAME = C.FRUIT_NAME
;

-- 실습 --
-- TB_STOCKMMREC (자재 입출 이력) A 테이블에서 ITEMCODE가 NULL이 아니고, INOUTFLAG(입출 여부) = 'I'(입고)
-- 데이터 중
-- TB_ITEMMASTER (품목 마스터) B 테이블에서 ITEMTYPE(품목타입)이 'ROH'인 것의
-- A.INOUTDATE, A.INOUTSEQ, A.MATLOTNO, A.ITEMCODE, B.ITEMNAME, B.CARTYPE 정보를 나타내세요.
-- (입출 일자)  (입출순번)  (LOT 번호)  (품목코드)  (품명)      (차종)
SELECT A.INOUTDATE  -- 입출 일자
     , A.INOUTSEQ   -- 입출순번
     , A.MATLOTNO   -- LOT 번호
     , A.ITEMCODE   -- 품목코드
     , B.ITEMNAME   -- 품명
     , B.CARTYPE    -- 차종
     , B.ITEMTYPE
  FROM TB_StockMMrec A LEFT JOIN TB_ItemMaster B
                              ON A.PLANTCODE = B.PLANTCODE
                             AND A.ITEMCODE  = B.ITEMCODE
 WHERE A.ITEMCODE IS NOT NULL
   AND A.INOUTFLAG = 'I'
   AND B.ITEMTYPE = 'ROH' -- JOIN 이후에 필터링
;

SELECT A.INOUTDATE  -- 입출 일자
     , A.INOUTSEQ   -- 입출순번
     , A.MATLOTNO   -- LOT 번호
     , A.ITEMCODE   -- 품목코드
     , B.ITEMNAME   -- 품명
     , B.CARTYPE    -- 차종
     , B.ITEMTYPE
  FROM TB_StockMMrec A LEFT JOIN TB_ItemMaster B
                              ON A.PLANTCODE = B.PLANTCODE
                             AND A.ITEMCODE  = B.ITEMCODE
                             AND B.ITEMTYPE = 'ROH' -- JOIN을 하기 전에 필터링
 WHERE A.ITEMCODE IS NOT NULL
   AND A.INOUTFLAG = 'I'
;

SELECT *
  FROM TB_StockMMrec
 WHERE ITEMCODE IS NOT NULL
   AND INOUTFLAG = 'I'
   AND MATLOTNO IN ('LTROH1438534870001', 'LTROH1650200500001');

SELECT *
  FROM TB_ItemMaster
 WHERE ITEMTYPE = 'ROH'
;

-- 하위 쿼리의 JOIN
-- 고객별 과일의 총 계산금액 구하기.(고객 ID, 고객명, 과일이름, 과일별총구매금액)
-- 구매 내역이 없는 고객은 ID와 이름만 표현

-- 산출 과정
-- 1. 기준 테이블 설정(구상) -- 고객별 과일의 총 구매 현황이므로 고객 테이블이 기준이 된다. TB_Cust
-- 2. 고객별 과일별 총 판매수량을 구한다.
SELECT CUST_ID AS CUSTID          -- 고객 ID
     , FRUIT_NAME AS FRUITNAME    -- 과일 정보
     , SUM(AMOUNT) AS FRUITCOUNT  -- 과일 판매 수량 합
  FROM TB_SaleList
 GROUP BY CUST_ID, FRUIT_NAME;

-- 3. 고객별 과일의 총 판매 수량에 단가를 곱한다.
-- SELECT 구문을 테이블처럼 FROM절에서 사용하기.
SELECT AA.ID
     , AA.NAME
     , BB.FRUITNAME
     , BB.TOTAL_SALES
  FROM TB_Cust AA LEFT JOIN (
                              SELECT A.CUSTID
                                   , A.FRUITNAME
                                   , A.FRUITCOUNT
                                   , B.PRICE
                                   , A.FRUITCOUNT * B.PRICE AS TOTAL_SALES
                              FROM (SELECT CUST_ID AS CUSTID          -- 고객 ID
                                        , FRUIT_NAME AS FRUITNAME    -- 과일 정보
                                        , SUM(AMOUNT) AS FRUITCOUNT  -- 과일 판매 수량 합
                                        FROM TB_SaleList
                                   GROUP BY CUST_ID, FRUIT_NAME) A LEFT JOIN TB_Fruit B 
                                                                           ON A.FRUITNAME = B.FRUIT_NAME
                             ) BB 
                             ON AA.ID = BB.CUSTID
;

-- 1. 간략하게 줄여서 구현.
SELECT CUST_ID                     -- 고객 ID
     , FRUIT_NAME                  -- 과일 이름
     , SUM(AMOUNT) AS FRUIT_AMOUNT -- 과일별 총 구매수량
  FROM TB_SaleList
 GROUP BY CUST_ID, FRUIT_NAME
;

-- 2. 단가와 구매수량을 합쳐서 총 금액 산출.
SELECT A.CUST_ID
     , C.NAME
     , A.FRUIT_NAME
     , SUM(A.AMOUNT) AS TOTAL_AMOUNTS
     , SUM(A.AMOUNT * B.PRICE) AS TOTAL_SALES
  FROM TB_SaleList A LEFT JOIN TB_FRUIT B
                            ON A.FRUIT_NAME = B.FRUIT_NAME
                     RIGHT JOIN TB_Cust C
                             ON A.CUST_ID = C.ID
 GROUP BY A.CUST_ID
        , C.NAME
        , A.FRUIT_NAME;

-- 실습 --
--과일가게 고객별 총 금액을 구하세요. 판매 내역이 없는 고객은 표현하지 않아도 됨.
SELECT A.ID
     , A.NAME
     , SUM(B.AMOUNT * C.PRICE) AS TOTAL_SALES
  FROM TB_Cust A JOIN TB_SaleList B
                   ON A.ID = B.CUST_ID
                 JOIN TB_FRUIT C
                   ON B.FRUIT_NAME = C.FRUIT_NAME
 GROUP BY A.ID, A.NAME
;

-- 실습 --
-- 고객의 총 구매 금액이 가장 큰 고객만 나타내세요. 고객 ID, 고객 이름, 총 구매금액
SELECT TOP (1)
       A.ID
     , A.NAME
     , SUM(B.AMOUNT * C.PRICE) AS TOTAL_SALES
 FROM TB_Cust A JOIN TB_SaleList B
                ON A.ID = B.CUST_ID
                JOIN TB_FRUIT C
                ON B.FRUIT_NAME = C.FRUIT_NAME
 GROUP BY A.ID, A.NAME
 ORDER BY TOTAL_SALES DESC
;

-- 고객별 총 구매 금액이 40000원이 넘는 고객의 내역만 검색하세요.(고객ID, 고객이름, 총 구매금액)
SELECT A.ID -- 고객ID
     , A.NAME -- 고객 이름
     , SUM(B.AMOUNT * C.PRICE) AS TOTAL_SALES -- 총 구매금액
  FROM TB_CUST A JOIN TB_SaleList B
                   ON A.ID = B.CUST_ID
                 JOIN TB_FRUIT C
                   ON B.FRUIT_NAME = C.FRUIT_NAME
 GROUP BY A.ID, A.NAME
HAVING SUM(B.AMOUNT * C.PRICE) > 40000
;

-- 2022-06-13일부터 2022-06-14일까지의 고객별 총 구매금액을 구하세요.(고객 ID, 고객 이름, 총 구매금액)
SELECT A.ID -- 고객ID
     , A.NAME -- 고객 이름
     , SUM(B.AMOUNT * C.PRICE) AS TOTAL_SALES -- 총 구매금액
  FROM TB_CUST A JOIN TB_SaleList B
                   ON A.ID = B.CUST_ID
                 JOIN TB_FRUIT C
                   ON B.FRUIT_NAME = C.FRUIT_NAME
 WHERE B.[DATE] BETWEEN '2022-06-13' AND '2022-06-14'
 GROUP BY A.ID, A.NAME
;

--------------------------------------------------------------------------------------------------------
-- 2. UNION / UNION ALL
--   - 다수의 검색 내역 병합.
-- UNION : 중복되는 행을 병합하여 표시
-- UNION ALL : 중복을 제거하지 않고 모두 합하여 표시
--
-- 합병될 컬럼의 데이터 형식과 컬럼의 수는 일치해야 한다.

-- UNION
-- 중복되는 데이터는 합병하여 표시한다.
SELECT [DATE]      AS DATE
     , CUST_ID     AS CUSTID
     , FRUIT_NAME  AS FRUITNAME
     , AMOUNT      AS AMOUNT 
  FROM TB_SaleList -- 고객 판매 현황 리스트 --> 총 8개

UNION -- 합집합에서 중복 제거
-- 중복데이터 DATE: 2022-06-12, CUST_ID: 1, FRUIT_NAME: 사과, AMOUNT: 5

SELECT [DATE]     AS DATE
     , CUSTCODE   AS CUSTID
     , FRUIT_NAME AS FRUITNAME
     , AMOUNT     AS AMOUNT
  FROM TB_OrderList -- 거래처 발주 현황 리스트 --> 총 6개
;

SELECT *
  FROM TB_SaleList A , TB_OrderList B
 WHERE A.AMOUNT = B.AMOUNT
   AND A.CUST_ID = B.CUSTCODE
   AND A.[DATE] = B.[DATE]
   AND A.FRUIT_NAME = B.FRUIT_NAME;



-- UNION ALL
-- 중복되는 데이터는 합병하여 표시한다.
SELECT [DATE]      AS DATE
     , CUST_ID     AS CUSTID
     , FRUIT_NAME  AS FRUITNAME
     , AMOUNT      AS AMOUNT 
  FROM TB_SaleList -- 고객 판매 현황 리스트 --> 총 8개

UNION ALL -- 합집합에서 중복 제거 안 함
-- 중복데이터 DATE: 2022-06-12, CUST_ID: 1, FRUIT_NAME: 사과, AMOUNT: 5

SELECT [DATE]     AS DATE
     , CUSTCODE   AS CUSTID
     , FRUIT_NAME AS FRUITNAME
     , AMOUNT     AS AMOUNT
  FROM TB_OrderList -- 거래처 발주 현황 리스트 --> 총 6개
 ORDER BY DATE, CUSTID, FRUIT_NAME, AMOUNT
;

-- 판매 내역 /발주 내역인지 확인하기 위하여 TITLE을 설정하였을 경우,
SELECT '판매'      AS TITLE
     , [DATE]      AS DATE
     , CUST_ID     AS CUST_ID
     , FRUIT_NAME  AS FRUIT_NAME
     , AMOUNT      AS AMOUNT
  FROM TB_SaleList

UNION ALL

SELECT '발주'      AS TITLE
     , [DATE]      AS DATE
     , CUSTCODE    AS CUST_ID
     , FRUIT_NAME  AS FRUIT_NAME
     , AMOUNT      AS AMOUNT
  FROM TB_OrderList
;



-- 고객 명, 거래처 명으로 표현하고 싶을 경우
-- JOIN / 직접 입력

-- 고객이 구매한 내역
SELECT '판매'        AS TITLE
     , A.[DATE]      AS DATE
     , A.CUST_ID     AS CUST_ID
     , B.NAME        AS NAME
     , A.FRUIT_NAME  AS FRUIT_NAME
     , A.AMOUNT      AS AMOUNT
  FROM TB_SaleList A LEFT JOIN TB_Cust B
                            ON A.CUST_ID = B.ID

UNION ALL

-- 거래처에 발주한 내역
SELECT '발주'      AS TITLE
     , [DATE]      AS DATE
     , CUSTCODE    AS CUST_ID
     , CASE CUSTCODE WHEN 1 THEN '대림'
                     WHEN 2 THEN '삼전'
                     WHEN 3 THEN '하나'
       END         AS NAME
     , FRUIT_NAME  AS FRUIT_NAME
     , AMOUNT      AS AMOUNT
  FROM TB_OrderList B
;


-- 실습 -- 
-- 발주 내역과 판매 내역에 각각의 과일의 총 발주 금액과 주문금액을 추가하여 표현하세요.
-- 컬럼 이름은 INOUTPRICE
-- 발주 금액은 -로 표현
-- 고객이 구매한 내역
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

-- 조회 결과 일자 별로 정렬 ORDER BY
-- UNION 할 대상의 조회내역은 개별적으로 ORDER BY할 수 있다.
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
 ORDER BY A.[DATE]
;


-- 실습 --
-- 두 가지 방법으로 과일 가게의 일자별 마진 금액을 산출하시오.
-- 마진 금액 : 판매한 금액 - 발주 금액
-- 표현할 컬럼 : DATE, MARGIN

-- 1. 위의 UNION 방법을 사용하고 구할 것.
SELECT AA.DATE
     , SUM(AA.MARGIN) AS MARGIN
  FROM (
        SELECT A.[DATE] AS DATE
             , A.AMOUNT * B.PRICE AS MARGIN
        FROM TB_SaleList A LEFT JOIN TB_FRUIT B
                                 ON A.FRUIT_NAME = B.FRUIT_NAME
        UNION ALL
        SELECT DATE
             , -A.AMOUNT * B.ORDER_PRICE AS MARGIN
        FROM TB_OrderList A LEFT JOIN TB_FRUIT B
                                 ON A.FRUIT_NAME = B.FRUIT_NAME
  ) AA
 GROUP BY AA.DATE
 ORDER BY AA.DATE
;


-- 2. UNION을 쓰지말고 구할 것
-- 1) SALES LIST의 일자별 이윤 구하기.
SELECT A.DATE
     , SUM(A.AMOUNT * B.PRICE) AS SALES_PRICE
  FROM TB_SaleList A LEFT JOIN TB_FRUIT B
                            ON A.FRUIT_NAME = B.FRUIT_NAME
 GROUP BY A.DATE;

-- 2) ORDER LIST의 일자별 발주 금액 구하기.
SELECT A.DATE
     , -SUM(A.AMOUNT * B.ORDER_PRICE) AS ORDER_PRICE
  FROM TB_OrderList A LEFT JOIN TB_FRUIT B
                             ON A.FRUIT_NAME = B.FRUIT_NAME
 GROUP BY A.DATE;

-- 3) 일자별 판매 금액과 일자별 발주 금액 합하기.
SELECT A.DATE
     , ISNULL(A.SALES_PRICE, 0) + ISNULL(B.ORDER_PRICE, 0) AS MARGIN
  FROM (SELECT A.DATE
             , SUM(A.AMOUNT * B.PRICE) AS SALES_PRICE
          FROM TB_SaleList A LEFT JOIN TB_FRUIT B
                                    ON A.FRUIT_NAME = B.FRUIT_NAME
         GROUP BY A.DATE) A LEFT JOIN (SELECT A.DATE
                                            , -SUM(A.AMOUNT * B.ORDER_PRICE) AS ORDER_PRICE
                                         FROM TB_OrderList A LEFT JOIN TB_FRUIT B
                                                                    ON A.FRUIT_NAME = B.FRUIT_NAME
                                        GROUP BY A.DATE) B
                                   ON A.DATE = B.DATE
;

SELECT A.[DATE]
     , ISNULL(MARGIN_O, 0) + ISNULL(MARGIN_S, 0) AS MARGIN
  FROM (SELECT DISTINCT A.[DATE]
          FROM TB_SaleList A  FULL JOIN TB_OrderList B ON A.[DATE] = B.[DATE]) A
          FULL JOIN (SELECT A.[DATE]
                          , SUM(A.AMOUNT * B.PRICE) AS MARGIN_S
                       FROM TB_SaleList A LEFT JOIN TB_FRUIT B ON A.FRUIT_NAME = B.FRUIT_NAME
                      GROUP BY A.[DATE]) B ON A.[DATE] = B.[DATE]
                       FULL JOIN (SELECT A.[DATE]
                                       , -SUM(A.AMOUNT * B.ORDER_PRICE) AS MARGIN_O
                                    FROM TB_OrderList A LEFT JOIN TB_FRUIT B ON A.FRUIT_NAME = B.FRUIT_NAME
                                   GROUP BY A.[DATE]) C ON A.[DATE] = C.[DATE]
;

