/*
1. SELECT
 가. 데이터베이스 내의 테이블에서 원하는 데이터를 추출하는 명령
 나. 가장 기본적인 SQL 구문이지만 데이터베이스 운영 시 중요도가 높은 문법이므로 잘 숙지할 것.

2. SELECT 구문의 기본 형식.
 가. SELECT [열이름]
       FROM [테이블 이름]
	  WHERE [조건] -- (Optional)
	 ;
---------------------------------------------------------------------------------------------
*/

-- 1. 기본적인 SELECT 형식
-- TB_ItemMaster 테이블에 있는 모든 컬럼의 데이터르르 검색 표현.
SELECT *
  FROM TB_ItemMaster;
-- * : asterisk (테이블의 모든 내용을 검색)

-- 2. 특정 컬럼만 검색
-- TB_ItemMaster 테이블에서 ITEMCODE, ITEMNAME, ITEMTYPE 컬럼의 데이터만 조회
SELECT ITEMCODE -- 품목
     , ITEMNAME -- 품목명
	 , ITEMTYPE -- 품목타입
  FROM TB_ItemMaster;

--> 실습 <--
-- TB_ItemMaster 테이블에서 ITEMCODE, WHCODE, BASEUNIT, MAKEDATE 컬럼을 조회하세요.
SELECT ITEMCODE
     , WHCODE
	 , BASEUNIT
	 , MAKEDATE
  FROM TB_ItemMaster;

-- 3. 컬럼에 별칭 주기 --> AS
-- 조회되는 컬럼에 별칭을 부여하고 지정한 컬럼의 별칭으로 조회 가능하다.
-- TB_ItemMaster 테이블에서 ITEMCODE 컬럼을 ITEM_CODE로, ITEMNAME 컬럼을 ITEM_NAME으로, ITEMTYPE 컬럼을 ITEM_TYPE으로 표현
SELECT ITEMCODE AS ITEM_CODE
     , ITEMNAME AS ITEM_NAME
	 , ITEMTYPE AS ITEM_TYPE
  FROM TB_ItemMaster;

-- 4. 조건 절 --> WHERE
-- 검색 조건을 입력하여 원하는 데이터만 조회한다.
-- SQL에서는 ' 홑따옴표로 문자를 정의한다.(C# "" --> string, '' --> char)
-- TB_ItemMaster 테이블에서 BASEUNIT이 'EA'인 모든 컬럼을 검색
SELECT *
  FROM TB_ItemMaster
 WHERE BASEUNIT = 'EA'; -- NULL / 'EA' / 'KG'

SELECT BASEUNIT, COUNT(1) as UNIT_COUNT
  FROM TB_ItemMaster
 GROUP BY BASEUNIT;

-- 검색 조건 추가 AND
-- TB_ItemMaster 테이블에서 BASEUNIT가 'EA'인 것과 ITEMTYPE이 'HALB'인 모든 컬럼을 검색
SELECT *
  FROM TB_ItemMaster
 WHERE BASEUNIT = 'EA'
   AND ITEMTYPE = 'HALB'
;

SELECT ITEMTYPE, COUNT(1) as ITEMTYPE_COUNT
  FROM TB_ItemMaster
 GROUP BY ITEMTYPE;

-- HAWA // 상품
-- FERT // 제품
-- HALB // 반제품
-- ROH  // 원자재


-- 검색 조건 추가 OR
-- TB_ItemMaster 테이블에서 BASEUNIT가 'EA'이거나 ITEMTYPE이 'HALB'인 모든 컬럼을 검색
SELECT *
  FROM TB_ItemMaster
 WHERE BASEUNIT = 'EA'
    OR ITEMTYPE = 'HALB'
;

-- 위 내용은 묶음 단위로 표현 가능.
SELECT *
  FROM TB_ItemMaster
 WHERE (BASEUNIT = 'EA' OR ITEMTYPE = 'HALB')
;

-- **** 주의 **** --
-- 컬럼이 다른 검색 조건에 OR이 사용될 경우
-- BASEUNIT이 EA가 아니며 ITEMTYPE이 HALB가 아닌 데이터가 모두 검색될 수 있다.


-- 실습 --
/*
TB_ItemMaster 테이블에서 WHCODE가 'WH003' 또는 'WH008'인 데이터 중
BASEUNIT가 'KG'을 가진 ITEMCODE, WHCODE, BASEUNIT 컬럼을 조회하세요.
*/

SELECT ITEMCODE
     , WHCODE
	 , BASEUNIT
  FROM TB_ItemMaster
 WHERE (WHCODE = 'WH003' OR WHCODE = 'WH008')
   AND BASEUNIT = 'KG'
;


-- 5. 관계 연산자의 사용.
-- 검색 조건에 시작과 종료에 대한 정보를 입력하여 원하는 결과를 조회한다.
-- 보통 기간이나 숫자를 검색하지만 문자의 내역도 검색 가능하다.

-- 기간 관계 연산 검색.
SELECT *
  FROM TB_ItemMaster
 WHERE EDITDATE > '2020-08-01'
   AND EDITDATE <= '2020-09-01'
;
-- EDITDATE 컬럼 DATETIME 데이터 형식의 컬럼이지만,
-- DATETIME 형식을 준수하는 문자열을 입력 시 자동으로 형변환하여 비교해준다.

-- 수 관계 연산 검색.
-- 정수형 컬럼 정수 조건으로 검색.
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK > 10
   AND MAXSTOCK <= 20
;


-- 문자열로 입력하여 정수형 컬럼 검색 가능.
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK > '10'
   AND MAXSTOCK <= '20'
;

-- 포함하지 않는 데이터 검색 --> <>
SELECT *
  FROM TB_ItemMaster
 WHERE INSPFLAG <> 'U'
;

-- TB_ItemMaster 테이블에서 INSPFLAG 컬럼 내용이 A 이상이고 U이하인 데이터의 컬럼을 모두 조회
SELECT *
  FROM TB_ItemMaster
 WHERE INSPFLAG >= 'A'
   AND INSPFLAG <= 'U'
;

-- 관계 연산자절 BETWEEN AND
/* TB_ItemMaster 테이블에서 MAXSTOCK이 10 이상, 20 이하인 데이터의 컬럼을 모두 조회 */
SELECT *
  FROM TB_ItemMaster
 WHERE (MAXSTOCK >= 10 AND MAXSTOCK <= 20).

;

SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 10 AND 20
;

-- ** 실습 ** --
/*

TB_ItemMaster 테이블에서 WHCODE가 WH002 ~ WH005 사이의 값을 가지고
UNITCOST가 1000을 초과하고,
INSPFLAG가 I가 아닌 행의
PLANTCODE, ITEMCODE, WHCODE, UNITCOST, INSPFLAG 컬럼을 나타내세요.
IiLl
*/
SELECT PLANTCODE
     , ITEMCODE
	 , WHCODE
	 , UNITCOST
	 , INSPFLAG
  FROM TB_ItemMaster
 WHERE WHCODE BETWEEN 'WH002' AND 'WH005'
   AND INSPFLAG <> 'I'
   AND UNITCOST > 1000
;


-- 6. 특정 컬럼 검색 조건을 N개 설정. (IN / NOT IN)
-- 특정 컬럼이 포함하고 있는 데이터 중 검색하고자 하는 조건이 많은 때 사용.
-- TB_ItemMaster에서 ITEMCODE, ITEMTYPE, MAXSTOCK 컬럼을 조회하고
-- MAXSTOCK의 수량이 1이상 3000 이하인 것 중에
-- ITEMTYPE이 'FERT', 'HALB'인 데이터만 조회
SELECT ITEMCODE -- 품목코드
     , ITEMTYPE -- 품목명
	 , MAXSTOCK -- 최대 수량
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000
   AND ITEMTYPE IN ('FERT', 'HALB')
--   AND (ITEMTYPE = 'FERT' OR ITEMTYPE = 'HALB') -- 검색 조건에 OR을 사용할 경우 범위 지정을 소괄호를 활용하여 명확히 할 것(의도치 않은 결과가 도출될 수 있음).
;

-- 포함하지 않는 데이터의 검색.
-- 특정 컬럼이 포함하고 있는 데이터 중 검색하고자 하는 조건이 많은 때 사용.
-- TB_ItemMaster에서 ITEMCODE, ITEMTYPE, MAXSTOCK 컬럼을 조회하고
-- MAXSTOCK의 수량이 1이상 3000 이하인 것 중에
-- ITEMTYPE이ㅣ 'FERT', 'HALB'가 아닌 데이터만 조회
SELECT ITEMCODE
     , ITEMTYPE
	 , MAXSTOCK
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000
   AND ITEMTYPE NOT IN ('FERT', 'HALB')
;

-- 실습 --
-- TB_ItemMaster 테이블에서 CARTYPE 컬럼의 값이 TL, LM인 것과
-- WHCODE가 'WH004'와 'WH007' 사이에 있는 것 중
-- ITEMTYPE이 'HALB'가 아닌
-- ITEMCODE, ITEMNAME, ITEMTYPE, WHCODE, CARTYPE 컬럼의 데이터 검색하세요.
SELECT ITEMCODE
     , ITEMNAME
	 , ITEMTYPE
	 , WHCODE
	 , CARTYPE
  FROM TB_ItemMaster
 WHERE CARTYPE IN ('TL', 'LM')
   AND WHCODE BETWEEN 'WH004' AND 'WH007'
   AND ITEMTYPE <> 'HALB'
;