SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.01
-- Description:	거래처 수정
-- =============================================
ALTER PROCEDURE [dbo].[13BM_CustMaster_U]
	@PLANTCODE		VARCHAR(10)  -- 공장
  , @CUSTCODE 		VARCHAR(10)  -- 거래처 코드
  , @CUSTTYPE 		VARCHAR(100) -- 거래처 구분
  , @CUSTNAME 		VARCHAR(100) -- 거래처 명
  , @ADDRESS		VARCHAR(100) -- 주소
  , @PHONE			VARCHAR(100) -- 연락처
  , @USEFLAG 		VARCHAR(1)   -- 사용여부
  , @EDITOR			VARCHAR(20)  -- 수정자

  , @LANG			VARCHAR(10) = 'KO'
  , @RS_CODE		VARCHAR(1) OUTPUT
  , @RS_MSG			VARCHAR(100) OUTPUT


AS
BEGIN
	UPDATE TB_CustMaster
	   SET CUSTTYPE 	= @CUSTTYPE	  -- 거래처 구분
         , CUSTNAME 	= @CUSTNAME	  -- 거래처 명
         , ADDRESS		= @ADDRESS	  -- 주소
         , PHONE		= @PHONE	  -- 연락처
         , USEFLAG 		= @USEFLAG	  -- 사용여부
         , EDITOR		= @EDITOR	  -- 수정자
		 , EDITDATE		= GETDATE()	  -- 수정일자
	 WHERE PLANTCODE	= @PLANTCODE  -- 공장
       AND CUSTCODE 	= @CUSTCODE	  -- 거래처 코드
         ; 
	
	SET @RS_CODE = 'S';
	SET @RS_MSG  = '정상작동';

END
GO
