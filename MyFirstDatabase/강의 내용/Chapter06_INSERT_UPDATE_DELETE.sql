/*
1. INSERT
 - 테이블에 데이터를 등록.
 - INSERT의 기본 유형.
  * INSERT INTO <TABLE NAME> (COLM1, COLM2, COLM3, ...) VALUES (VAL1, VAL2, VAL3, ...)

 - PK COLUMN에는 (복합키 포함) 중복되지 않는 데이터를 저장해야 한다.
 - NULL 허용않는 COLUMN에는 NULL 값을 입력할 수 없다.
 - 컬럼이 FK로 설정된 경우 기준 테이블에 없는 데이터는 등록 불가.
*/

-- 1-1 TB_Cust에 데이터 등록.
SELECT * FROM TB_Cust;
INSERT INTO TB_Cust (ID, NAME, PHONE) VALUES (5, '임창정', '5555');

-- 1-2 모든 컬럼의 데이터를 등록할 때는 열이름 생략 가능
INSERT INTO TB_Cust VALUES(6, '윤종신', '6666');

-- 1-3 특정 컬럼만 골라서 데이터 삽입 가능.
INSERT INTO TB_Cust(NAME, PHONE) VALUES ('이수', '7777'); --PK(NOT NULL) 컬럼에 데이터를 입력하지 않아 오류.
INSERT INTO TB_Cust(ID, NAME) VALUES (7, '이수');         --PK 값을 입력하여 정상 동작.
SELECT * FROM TB_Cust;


-- 1-4 테이블의 복사
/*
기본 형태
SELECT * INTO [NEW TABLE NAME] FROM [ORIGINAL TABLE NAME] WHERE 1 = 2 -- WHERE 1=2(FALSE)를 붙이면 테이블만 복사.
SELECT * INTO [NEW TABLE NAME] FROM [ORIGINAL TABLE NAME]             -- WHERE 1=2가 없으면 데이터까지 같이 복사.
*/

-- 테이블 복사
-- 복사 쿼리로 테이블의 구조와 행 데이터는 복사할 수 있으나, PK, FK, INDEX 등은 복사할 수 없다.
SELECT * INTO TB_SaleList2 FROM TB_SaleList WHERE 1=2; -->(0 rows affected)
SELECT * FROM TB_SaleList2; --> 결과값 없음.

-- 1-5 다수의 행 INSERT
-- SELECT 를 통한 다수 행 데이터 등록
INSERT INTO TB_SaleList2 ([DATE], CUST_ID, FRUIT_NAME, AMOUNT)
SELECT [DATE], CUST_ID, FRUIT_NAME, 3000
  FROM TB_SaleList
 WHERE CUST_ID = 3;

SELECT * FROM TB_SaleList2;

-- 단일 데이터만 등록할 경우 SELECT 절만 사용하여 등록 가능.
INSERT INTO TB_SaleList2 ([DATE], CUST_ID, FRUIT_NAME, AMOUNT)
SELECT '2022-06-14', 4, '딸기', 3000;


/*
2. UPDATE
 - 테이블의 데이터를 수정.
 - UPDATE의 기본 유형
  * UPDATE [TABLE NAME] 
       SET COL1 = VAL1
         , COL2 = VAL2
         , ...
     WHERE [조건] -- ※ 생략하면 모든 데이터가 수정된다.
*/
UPDATE TB_SaleList2
   SET AMOUNT = 1000
     , DATE = '2022-06-17'
 WHERE CUST_ID = '4'
 ;

SELECT * FROM TB_SaleList2;


/*
3. DELETE
 - 테이블 행 단위 데이터 삭제(특정 컬럼 지정 불가.)
 - DELETE의 기본 유형
  * DELETE [TABLE NAME]
     WHERE [조건]
*/

DELETE TB_SaleList2
 WHERE CUST_ID = '4';



/*
4. 트랜잭션(TRANSACTION): 데이터 갱신 내역 승인 또는 복구(TRAN, COMMIT, ROLLBACK)
 - 데이터의 일관성을 유지하면서 안전하게 승인 또는 복구하기 위한 작업.
 - MSSQL은 자동으로 UPDATE, INSERT, DELETE를 완료 승인(COMMIT)
  * 데이터 관리시 발생하는 오류사항(10개 데이터 트랜잭션 실행 시 6번째부터 오류 발생할 경우, 관리자의 실수 등에
    대처하기 위해 데이터 갱신 후 승인 또는 복구를 실행할 필요가 있음.
 - BEGIN TRAN 선언 후 반드시 COMMIT, ROLLBACK을 해줘야 한다.
  * 트랜잭션의 독립성(격리성) - 하나의 트랜잭션이 수행되고 있을 때 또 다른 트랜잭션이 갑섭할 수 있다.
  * 내가 트랜잭션을 선언하면 다른 사람이 해당 테이블을 관리할 수 없다.
*/

BEGIN TRAN
DELETE TB_SaleList2;

SELECT * FROM TB_SaleList2;

ROLLBACK;

COMMIT;