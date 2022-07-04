SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.04
-- Description:	구매자재 발주 내역 입고 등록.
-- =============================================
ALTER PROCEDURE [dbo].[13MM_POMake_U]
  -- PK
	@PLANTCODE 			   VARCHAR(10) -- 공장 코드
  , @PONO				   VARCHAR(20) -- 발주 번호
  , @PODATE 			   VARCHAR(10) -- 발주 일자
  , @POSEQ  			   VARCHAR(10) -- 발주 시퀀스

  -- 입고 관련
  , @ITEMCODE              VARCHAR(10)  -- 품목 코드
--  , @INFLAG				   VARCHAR(10)  -- 입고 여부
  , @INQTY  			   VARCHAR(10)  -- 입고 수량
--  , @LOTNO  			   VARCHAR(10)  -- LOT NO
--  , @INDATE 			   VARCHAR(10)  -- 입고 일자
--  , @INWORKER			   VARCHAR(10)  -- 입고자
  , @EDITOR   			   VARCHAR(10)  -- 입고 등록자

  , @LANG				   VARCHAR(10) = 'KO'
  , @RS_CODE			   VARCHAR(1) OUTPUT
  , @RS_MSG				   VARCHAR(100) OUTPUT

AS
BEGIN
	-- 프로시저에서 공통으로 사용할 일자, 일시 변수.
	DECLARE @LD_NOWDATE DATETIME	-- PROCEDURE 실행 일시
	      , @LS_NOWDATE VARCHAR(10) -- PROCEDURE 실행 일자
		  ;
		SET @LS_NOWDATE = GETDATE();
		SET @LD_NOWDATE = CONVERT(VARCHAR, @LS_NOWDATE, 23);

	/***********************************
	 * 원자재 입고
	 * LOT NO 채번
	 * 1. 발주 내영에 입고 정보 등록.
	 * 2. 자재 재고 생성.
	 * 3. 자재 입/출고 이력 등록.
	 ***********************************/

	-- LOT NO 채번
	DECLARE @LS_LOTNO		VARCHAR(30)
	-- '-', ':', ' ', '.' 제거
	SET @LS_LOTNO = 'LT_R' + REPLACE(REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR,GETDATE(),121),'-',''),':',''),' ',''),'.','')

	-- 1. 발주 내영에 입고 정보 등록.
	UPDATE TB_POMake
	   SET INFLAG   = 'Y'
	     , LOTNO    = @LS_LOTNO
		 , INQTY    = @INQTY
		 , INDATE   = @LS_NOWDATE
		 , INWORKER = @EDITOR
		 , EDITDATE = @LD_NOWDATE
		 , EDITOR   = @EDITOR
	 WHERE PLANTCODE = @PLANTCODE
	   AND PONO      = @PONO
	   AND POSEQ     = @POSEQ
	   AND PODATE    = @PODATE;

	-- CUSTCODE, UNITCODE 가져오기.
	DECLARE @LS_UNITCODE VARCHAR(10)
	      , @LS_CUSTCODE VARCHAR(10);

	SELECT @LS_UNITCODE = UNITCODE
	     , @LS_CUSTCODE = CUSTCODE
	  FROM TB_POMake WITH(NOLOCK)
	 WHERE PLANTCODE = @PLANTCODE
	   AND PONO      = @PONO
	   AND POSEQ     = @POSEQ
	   AND PODATE    = @PODATE;


	-- 2. 자재 재고 생성.
	INSERT INTO TB_StockMM (PLANTCODE,  ITEMCODE,  MATLOTNO,  WHCODE,  STOCKQTY,  UNITCODE,  INDATE,      CUSTCODE,  MAKEDATE,    MAKER)
	                VALUES (@PLANTCODE, @ITEMCODE, @LS_LOTNO, 'WH001', @INQTY,    '',        @LS_NOWDATE, '',        @LD_NOWDATE, @EDITOR)

	-- 3. 자재 입/출고 이력 등록.
	DECLARE @LI_INOUTSEQ INT;
	SELECT @LI_INOUTSEQ =  ISNULL(MAX(INOUTSEQ), 0) + 1
	  FROM TB_StockMMrec WITH(NOLOCK)
	 WHERE PLANTCODE = @PLANTCODE
	   AND INOUTDATE = @LS_NOWDATE;

	INSERT INTO TB_StockMMrec(PLANTCODE,  MATLOTNO,  ITEMCODE,  INOUTDATE,  INOUTQTY,  INOUTCODE,  INOUTWORKER,
	                          PONO,       INOUTSEQ,  WHCODE,    INOUTFLAG,  MAKER,     MAKEDATE)
					   VALUES(@PLANTCODE, @LS_LOTNO, @ITEMCODE, @LS_NOWDATE, @INQTY,   '10',       @EDITOR,
					          @PONO,      @LI_INOUTSEQ, 'WH001', 'IN',       @EDITOR,  @LS_NOWDATE);

	SET @RS_CODE = 'S';
	SET @RS_MSG = '정상 작동';

END
GO
