SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.04
-- Description:	원자재 발주 등록.
-- =============================================
ALTER PROCEDURE [dbo].[13MM_POMake_I]
	@PLANTCODE		   VARCHAR(10) -- 공장
  , @ITEMCODE		   VARCHAR(30) -- 발주 품목(자재)
  , @PODATE			   VARCHAR(10) -- 발주 일자
  , @POQTY  		   FLOAT       -- 발주 수량
  , @UNITCODE		   VARCHAR(10) -- 단위
  , @CUSTCODE		   VARCHAR(10) -- 거래처(협력업체)
  , @MAKER			   VARCHAR(30) -- 등록자

  , @LANG			   VARCHAR(10) = 'KO'
  , @RS_CODE		   VARCHAR(1) OUTPUT
  , @RS_MSG			   VARCHAR(100) OUTPUT

AS
BEGIN
	-- 프로시저에서 공통으로 사용할 일자, 일시 변수.
	DECLARE @LD_NOWDATE DATETIME		  -- 프로시저 실행 일시
	      , @LS_NOWDATE VARCHAR(10);	  -- 프로시저 실행 일자
		SET @LD_NOWDATE = GETDATE();
		SET @LS_NOWDATE = CONVERT(VARCHAR, @LD_NOWDATE, 23);

	DECLARE @LI_SEQ INT
	      , @LS_PONO VARCHAR(30);


	SELECT @LI_SEQ = ISNULL(MAX(POSEQ), 0) +1
	  FROM TB_POMake WITH(NOLOCK)
	 WHERE PLANTCODE = @PLANTCODE
	   AND PODATE    = @PODATE;

	SET @LS_PONO = 'PO' + REPLACE(@PODATE, '-', '') + RIGHT('00000' + CONVERT(VARCHAR, @LI_SEQ), 4);

	--                     공장        품목       발주번호  발주 순번   발주 일자   발주 수량     단위        협력업체     등록자   등록 일자
	INSERT INTO TB_POMake (PLANTCODE,  ITEMCODE,  PONO,     POSEQ,      PODATE,     POQTY,       UNITCODE,    CUSTCODE,    MAKER,   MAKEDATE)
	     VALUES           (@PLANTCODE, @ITEMCODE, @LS_PONO, @LI_SEQ,    @PODATE,    @POQTY,      @UNITCODE,   @CUSTCODE,   @MAKER,  @LD_NOWDATE);

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';

END
GO
