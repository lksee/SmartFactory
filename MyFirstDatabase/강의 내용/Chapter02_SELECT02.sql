-- 1. 데이터를 포함하는 행 조회 --> LIKE
-- WHERE 조건에 검색하고자 하는 데이터의 일부분만 입력하여
-- 해당 내용이 포함된 모든 데이터를 표현 '%'

-- TB_ItemMaster 테이블에 ITEMCODE 컬럼의 데이터 중 'E'가 포함된 컬럼 데이터를 모두 조회
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '%E%' -- E를 포함하고 있는 모든 데이터 조회.
 ;

-- TB_ItemMaster 테이블에서 ITEMCODE 컬럼의 데이터 중 '64'로 시작하는 데이터를 모두 조회
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '64%'
 ;

-- TB_ItemMaster 테이블에서 ITEMCODE 컬럼의 데이터 중 '3X000E'로 끝나는 데이터를 모두 조회
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '%3X000E'
 ;

-- 2. NULL 값이 아닌 데이터 조회 및 NULL 값인 데이터 조회(IS NULL, IS NOT NULL)
--    NULL : 데이터가 없고 비어있는 상태. 데이터가 할당되지 않은 상태

-- TB_ItemMaster 테이블에서 MAXSTOCK 컬럼이 NULL인 행을 조회.
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK IS NULL
;

-- TB_ItemMaster 테이블에서 MAXSTOCK 컬럼이 NULL이 아닌 데이터 검색.
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK IS NOT NULL
 ;

-- TB_ItemMaster 테이블에서 BOXSPEC 컬럼의 데이터가 '01'로 끝나면서 NULL이 아닌 PLANTCODE, ITEMCODE, ITEMNAME 컬럼의 데이터를 검색하세요.
SELECT PLANTCODE, ITEMCODE, ITEMNAME
  FROM TB_ItemMaster
 WHERE BOXSPEC LIKE '%01'
   AND BOXSPEC IS NOT NULL
;

-- 3. 검색 결과 정렬 --> ORDER BY ASC/DESC (ASC: 오름차순/DESC: 내림차순)
--    테이블에서 검색한 결과를 조건에 따라 정렬하여 나타낸다.

-- TB_ItemMaster 테이블의 ITEMTYPE = 'HALB'인
-- ITEMCODE, ITEMTYPE 컬럼의 데이터를 ITEMCODE 컬럼 데이터 기준으로 오름차순 조회
SELECT ITEMCODE
     , ITEMTYPE
  FROM TB_ItemMaster
 WHERE ITEMTYPE = 'HALB'
 ORDER BY ITEMCODE ASC;

-- ORDER BY 조건이 여러컬럼이 될 경우 왼쪽부터 순차적으로 우선순위를 갖는다.
SELECT ITEMCODE
     , ITEMTYPE
	 , WHCODE
	 , BOXSPEC
  FROM TB_ItemMaster
 ORDER BY ITEMTYPE, WHCODE, BOXSPEC;

-- 조회하지 않는 컬럼의 데이터 정렬 조건 추가하기
-- TB_ItemMaster 테이블에서 ITEMTYPE = 'HALB'인 
-- ITEMTYPE, WHCODE, BOXSPEC 컬럼을
-- ITEMCODE 순서대로 정렬하여 검색
SELECT ITEMTYPE
     , WHCODE
	 , BOXSPEC
  FROM TB_ItemMaster
 WHERE ITEMTYPE = 'HALB'
 ORDER BY ITEMCODE;

-- 역순으로 정렬하기 DESC
-- TB_ItemMaster 테이블의 ITEMTYPE = 'HALB'인
-- ITEMCODE, ITEMTYPE, 컬럼의 데이터를 ITEMCODE 컬럼 데이터 기준으로 내림차순하여 조회
SELECT ITEMCODE
     , ITEMTYPE
  FROM TB_ItemMaster
 WHERE ITEMTYPE = 'HALB'
 ORDER BY ITEMCODE DESC
;

-- TB_ItemMaster 테이블에서 INSPFLAG가 NULL이 아닌
-- ITEMTYPE, WHCODE, INSPFLAG 컬럼을
-- ITEMTYPE 값은 오름차순, WHCODE 내림차순, INSPFLAG는 오름차순으로 정렬하시오.
SELECT ITEMTYPE
     , WHCODE
	 , INSPFLAG
  FROM TB_ItemMaster
 WHERE INSPFLAG IS NOT NULL
 ORDER BY ITEMTYPE ASC, WHCODE DESC, INSPFLAG ASC;

-- 실습 --
-- TB_ItemMaster 테이블에서 MATERIALGRAD 컬럼의 값이 NULL 이고
-- CARTYPE 컬럼 값이 MD, RB, TL이 아니면서 
-- ITEMCODE 컬럼 값이 '001'을 포함하고 
-- UNITCOST 컬럼 값이 0인 행의 모든 컬럼을 
-- ITEMNAME 컬럼은 내림차순으로 WHCODE 컬럼은 오름차순으로 조회하세요.
SELECT *
  FROM TB_ItemMaster
 WHERE MATERIALGRADE IS NULL
   AND CARTYPE NOT IN ('MD', 'RB', 'TL')
   AND ITEMCODE LIKE '%001%'
   AND UNITCOST = 0
 ORDER BY ITEMNAME DESC, WHCODE ASC;

