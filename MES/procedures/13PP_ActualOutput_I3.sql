SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      이기수
-- Create date: 2022.07.
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[13PP_ActualOutput_I3]
	@PLANTCODE			VARCHAR(10) -- 공장 코드
  , @WORKCENTERCODE		VARCHAR(10) -- 작업장
  , @ITEMCODE      		VARCHAR(30) -- 생산 품번
  , @ORDERNO       		VARCHAR(30) -- 작업 지시 번호
  , @LOTNO         		VARCHAR(30) -- 투입 원자재 LOT NO
  , @WORKERID			VARCHAR(30) -- 작업자 ID(투입하는 사람)
  , @UNITCODE      		VARCHAR(10) -- 생산 품번 단위
  , @INFLAG        		VARCHAR(30) -- 투입 /취소 여부 (IN : 투입 처리, OUT: 취소 처리)

  , @LANG				VARCHAR(10) = 'KO'
  , @RS_CODE			VARCHAR(1) OUTPUT
  , @RS_MSG				VARCHAR(100) OUTPUT


AS
BEGIN
	-- 프로시져에서 공통으로 사용할 일자, 일시 변수.
	DECLARE @LD_NOWDATE DATETIME    -- PROCEDURE 실행 일시
	      , @LS_NOWDATE VARCHAR(10) -- PROCEDURE 실행 일자
	;

	SET @LD_NOWDATE = GETDATE();
	SET @LS_NOWDATE = CONVERT(VARCHAR, @LD_NOWDATE, 23);

	-- 작업 지시 선택 여부 확인
	IF (
		SELECT ISNULL(ORDERNO, '')
		  FROM TP_WorkcenterStatus WITH(NOLOCK)
		 WHERE PLANTCODE = @PLANTCODE
		   AND WORKCENTERCODE = @WORKCENTERCODE
	) = ''
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = '작업 지시를 선택하지 않았습니다.';
		RETURN;
	END;

	-- 원자재 LOT 재공 재고 투입.
	DECLARE @LS_CITEMCODE VARCHAR(30) -- 원자재 LOT 품번
	      , @LF_STOCKQTY FLOAT        -- 원자재 LOT 재고수량
	;

	IF (@INFLAG = 'IN')
	BEGIN
		-- 공정 창고에 등록된 LOT를 투입하려고 하는 지 체크.
		SELECT @LS_CITEMCODE = ITEMCODE
		     , @LF_STOCKQTY  = STOCKQTY
		  FROM TB_StockPP WITH(NOLOCK) -- 공정 창고 재고
		 WHERE PLANTCODE = @PLANTCODE
		   AND LOTNO     = @LOTNO
		;

		IF (ISNULL(@LS_CITEMCODE, '') = '')
		BEGIN
			SET @RS_CODE = 'E';
			SET @RS_MSG  = '공정 창고에 등록되지 않은 원자재입니다.';
			RETURN;
		END;

		-- BOM 상 연결된 하위 품목(원자재)인지 확인.
		IF (
			SELECT COUNT(*)
			  FROM TB_BomMaster WITH(NOLOCK)
			 WHERE ITEMCODE = @ITEMCODE
			   AND COMPONENT = @LS_CITEMCODE
			) = 0
		BEGIN
			SET @RS_CODE = 'E';
			SET @RS_MSG  = '작업 지시 품목을 생산할 수 없는 원자재 LOT 입니다.';
			RETURN;
		END;

		-- 재공 재고에 투입되어 있는 LOT가 있는 지 확인.
		IF (
			SELECT COUNT(*)
			  FROM TB_StockHALB WITH(NOLOCK) -- 재공 재고 테이블
			 WHERE PLANTCODE = @PLANTCODE
			   AND WORKCENTERCODE = @WORKCENTERCODE
			) <> 0
		BEGIN
			SET @RS_CODE = 'E';
			SET @RS_MSG  = '현재 작업장에 투입되어 있는 LOT가 존재합니다. 취소 후 진행하세요.';
			RETURN;
		END;
	END;




	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 처리';
END
GO