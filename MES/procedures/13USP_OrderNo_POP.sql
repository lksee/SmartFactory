USE [DC_EDU_SH]
GO
/****** Object:  StoredProcedure [dbo].[USP_OrderNo_POP]    Script Date: 2022-07-07 오후 1:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022-07-07
-- Description:	작업지시 조회 팝업, 작업지시 조회
-- =============================================
ALTER PROCEDURE [dbo].[13USP_OrderNo_POP]
	 @PLANTCODE		 VARCHAR(10)
	,@WORKCENTERCODE VARCHAR(20)
	,@WORKCENTERNAME VARCHAR(20)
	,@STARTDATE      VARCHAR(10)
	,@ENDDATE		 VARCHAR(10)

	,@LANG            VARCHAR(10)  ='KO'
    ,@RS_CODE         VARCHAR(1)   OUTPUT
    ,@RS_MSG          VARCHAR(200) OUTPUT

AS
BEGIN
	SELECT PP.PLANTCODE
	      ,PP.WORKCENTERCODE					     AS WORKCENTERCODE
		  ,WCM.WORKCENTERNAME					     AS WORKCENTERNAME
		  ,PP.ORDERNO							     AS ORDERNO
		  ,PP.ORDERDATE						         AS ORDERDATE	
		  ,PP.ITEMCODE							     AS ITEMCODE
		  ,DBO.FU_ITEMNAME(PP.PLANTCODE,PP.ITEMCODE) AS ITEMNAME
		  ,PP.PLANQTY							     AS ORDERQTY
		  , PP.ORDERCLOSEFLAG
	  FROM TB_ProductPlan PP WITH(NOLOCK) LEFT JOIN TB_WorkCenterMaster WCM WITH(NOLOCK)
	                                             ON PP.PLANTCODE = WCM.PLANTCODE
												AND PP.WORKCENTERCODE = WCM.WORKCENTERCODE
	 WHERE PP.PLANTCODE                  LIKE '%' + @PLANTCODE      + '%'
	   AND PP.WORKCENTERCODE             LIKE '%' + @WORKCENTERCODE + '%'
	   AND ISNULL(WCM.WORKCENTERNAME, '') LIKE '%' + @WORKCENTERNAME + '%'
	   AND PP.ordertemp                  BETWEEN @STARTDATE + ' 00:00:00' AND @ENDDATE + ' 23:59:59'
	   AND ISNULL(PP.ORDERCLOSEFLAG,'N') <> 'Y'
END




