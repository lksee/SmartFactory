USE [DC_EDU_SH]
GO
/****** Object:  StoredProcedure [dbo].[00PP_ActureOutput_I6]    Script Date: 2022-07-11 오전 9:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022-07-11
-- Description:	생산실적 등록 - 7. 작업지시 종료.
-- =============================================
CREATE PROCEDURE [dbo].[13PP_ActualOutput_I6]
	@PLANTCODE        VARCHAR(10),  -- 공장.
	@WORKCENTERCODE   VARCHAR(10),  -- 작업장
	@ORDERNO		  VARCHAR(30),  -- 작업지시 번호.

	@LANG      VARCHAR(10)  = 'KO',
	@RS_CODE   VARCHAR(1)   OUTPUT,
	@RS_MSG	   VARCHAR(100) OUTPUT


AS
BEGIN 
		-- 현재 시간 정의 공통 변수
	DECLARE @LD_NOWDATE  DATETIME,
	        @LS_NOWDATE  VARCHAR(10);
		SET @LD_NOWDATE = GETDATE();
		SET @LS_NOWDATE = CONVERT(VARCHAR,@LD_NOWDATE,23); -- yyyyy-MM-dd

	-- 작업장이 가동 중인지 확인.
	DECLARE @LS_MATLOTNO  VARCHAR(30) -- 원자재 LOTNO
	       ,@LS_WORKER    VARCHAR(30) -- 작업자 
		   ,@LS_STATUS    VARCHAR(1)  -- 현재 작업장의 상태 (가동/비가동)


	SELECT @LS_WORKER     = WORKER
		  ,@LS_STATUS     = STATUS
	  FROM TP_WorkcenterStatus WITH(NOLOCK)
	 WHERE PLANTCODE      = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE;

	IF (@LS_STATUS = 'R')
	BEGIN
		SET @RS_CODE = 'E'
		SET @RS_MSG  = '현재 작업장이 가동 중입니다.';
		RETURN;
	END;


	-- 투입 된 원자재 LOT 가 있는지 확인.
	SELECT @LS_MATLOTNO = LOTNO
	  FROM TB_StockHALB WITH(NOLOCK)
	 WHERE PLANTCODE     = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE;

     IF (ISNULL(@LS_MATLOTNO,'') <> '')
	 BEGIN
		SET @RS_CODE = 'E'
		SET @RS_MSG  = '투입 된 원자재 정보가 있습니다.';
		RETURN;
	 END


	 -- 작업지시 종료 상태 등록
	 UPDATE TB_ProductPlan
	    SET ORDERCLOSEFLAG = 'Y'
		   ,ORDERCLOSEDATE = @LD_NOWDATE
		   ,EDITDATE       = @LD_NOWDATE
		   ,EDITOR         = @LS_WORKER
	 WHERE PLANTCODE       = @PLANTCODE
	   AND ORDERNO         = @ORDERNO;


	 -- 작업장 현재 상태 관리 테이블 등록.
	 UPDATE TP_WorkcenterStatus
	    SET ORDERNO       = NULL
		   ,ITEMCODE      = NULL
		   ,UNITCODE      = NULL
		   ,REMARK        = NULL
		   ,EDITDATE      = @LD_NOWDATE
		   ,EDITOR        = @LS_WORKER
	 WHERE PLANTCODE      = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE



    -- 작업장 상태 이력 테이블에 종료 시간 업데이트
	UPDATE TP_WorkcenterStatusRec
	   SET RSENDDATE      = @LD_NOWDATE
	      ,EDITDATE       = @LS_NOWDATE
		  ,EDITOR         = @LS_WORKER
	 WHERE PLANTCODE      = @PLANTCODE
	   AND WORKCENTERCODE = @WORKCENTERCODE
	   AND ORDERNO        = @ORDERNO
	   AND RSENDDATE IS NULL

	SET @RS_CODE = 'S';
END
