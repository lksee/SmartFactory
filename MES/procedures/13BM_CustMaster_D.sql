SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.01
-- Description:	거래처 삭제
-- =============================================
CREATE PROCEDURE [dbo].[13BM_CustMaster_D]
	@PLANTCODE		VARCHAR(10)  -- 공장
  , @CUSTCODE 		VARCHAR(10)  -- 거래처 코드

  , @LANG			VARCHAR(10) = 'KO'
  , @RS_CODE		VARCHAR(1) OUTPUT
  , @RS_MSG			VARCHAR(100) OUTPUT

AS
BEGIN
	DELETE TB_CustMaster
	 WHERE PLANTCODE = @PLANTCODE  -- 공장
	   AND CUSTCODE  = @CUSTCODE  -- 거래처 코드
	   ;

	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상 작동';
END
GO
