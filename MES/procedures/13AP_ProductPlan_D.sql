SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.04
-- Description:	생산 계획 편성 내역 삭제
-- =============================================
CREATE PROCEDURE [dbo].[13AP_ProductPlan_D]
	@PLANTCODE			VARCHAR(10) -- 공장 코드
  , @PLANNO				VARCHAR(20) -- 계획 번호

  , @LANG				VARCHAR(10) = 'KO'
  , @RS_CODE			VARCHAR(1) OUTPUT
  , @RS_MSG				VARCHAR(100) OUTPUT

AS
BEGIN
	-- 작업 지시 확정된 내역인지 재차 확인.
	

	IF (SELECT ISNULL(ORDERFLAG, 'N')
	      FROM TB_ProductPlan WITH(NOLOCK)
	     WHERE PLANTCODE = @PLANTCODE
	       AND PLANNO	 = @PLANNO) <> 'N'
	BEGIN
		SET @RS_CODE = 'E';
		SET @RS_MSG  = '작업 지시 확정된 내역이 존재합니다. 생산 계획 편성 내역을 삭제하려면 작업 지시 확정된 내역을 먼저 취소하세요.';
		RETURN;
	END;

	-- 생산 계획 편성 내역 삭제.
	DELETE TB_ProductPlan
	 WHERE PLANTCODE = @PLANTCODE
	   AND PLANNO    = @PLANNO;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';
END
GO
