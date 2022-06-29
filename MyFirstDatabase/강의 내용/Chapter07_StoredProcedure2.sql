
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022-06-17
-- Description:	프로시져 만들기 실습.(과일가게 매출 정보 등록)
-- =============================================
CREATE PROCEDURE SPROC_SaleList2_IUD
	-- 파라매터 설정 부분.
	@DATE		VARCHAR(10), -- 일자.
	@CUSTID		INT,         -- 고객 ID.
	@FRUIT_NAME	VARCHAR(20), -- 과일 이름
	@AMOUNT		INT          -- 구매 수량.
AS
BEGIN
	-- 프로시져가 수행할 SQL 나열
	-- 1. TB_SALELIST2 테이블 데이터 삭제.
	DELETE TB_SaleList2;

	-- 2. TB_SALELIST2 테이블에 데이터 등록하기
	INSERT INTO TB_SaleList2 VALUES(@DATE, @CUSTID, @FRUIT_NAME, @AMOUNT);

	-- 3. 데이터 수정하기
	UPDATE TB_SaleList2
	   SET AMOUNT = 10
	     , DATE = '2022-06-01'
     WHERE CUST_ID = @CUSTID;
END
GO
