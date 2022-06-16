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