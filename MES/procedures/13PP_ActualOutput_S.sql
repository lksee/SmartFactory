SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이기수
-- Create date: 2022.07.06
-- Description:	생산 실적 등록을 위한 작업장 조회.
-- =============================================
ALTER PROCEDURE [DBO].[13PP_ActualOutput_S] 
  @PLANTCODE                 VARCHAR(10) -- 공장
, @WORKCENTERCODE            VARCHAR(10) -- 작업장

, @LANG                      VARCHAR(10) = 'KO'
, @RS_CODE                   VARCHAR(1) OUTPUT
, @RS_MSG                    VARCHAR(100) OUTPUT


AS
BEGIN
	SELECT WCM.PLANTCODE                       AS PLANTCODE      -- 공장
	     , WCM.WORKCENTERCODE                  AS WORKCENTERCODE -- 작업장 코드
	     , WCM.WORKCENTERNAME                  AS WORKCENTERNAME -- 작업장 명
		 , WCS.ORDERNO                         AS ORDERNO        -- 작업장의 현재 작업 중인 지시 번호
		 , WCS.ITEMCODE                        AS ITEMCODE       -- 작업장의 현재 작업 중인 품목 코드
		 , ITM.ITEMNAME                        AS ITEMNAME       -- 작업장의 현재 작업 중인 품목 명
		 , PP.PLANQTY                          AS ORDERQTY       -- 작업장의 현재 작업 지시 수량
		 , PP.PRODQTY                          AS PRODQTY        -- 양품 수량
		 , PP.BADQTY                           AS BADQTY         -- 불량 수량
		 , PP.UNITCODE                         AS UNITCODE       -- 단위
		 , WCS.STATUS                          AS WORKSTATUSCODE -- 현재 상태(가동/비가동)
		 , CASE WHEN WCS.STATUS = 'R' /* RUN */ THEN '가동' 
		        ELSE '비가동' END              AS WORKSTATUS
		 , STH.LOTNO                           AS MATLOTNO       -- 작업장 투입 LOT NO
		 , STH.STOCKQTY                        AS COMPONENTQTY   -- 투입 LOT NO 잔량
		 , WCS.WORKER                          AS WORKER         -- 작업자 ID
		 , DBO.FN_WORKERNAME(WCS.WORKER)       AS WORKERNAME     -- 작업자 명
		 , PP.FIRSTSTARTDATE                   AS STARTDATE      -- 지시 시작 일시
		 , PP.ORDERCLOSEDATE                   AS ENDDATE        -- 지시 종료 일시
	  FROM TB_WorkCenterMaster WCM WITH(NOLOCK) LEFT JOIN TP_WorkcenterStatus WCS WITH(NOLOCK) -- 작업장 현재 상태 테이블
	                                                   ON WCM.PLANTCODE      = WCS.PLANTCODE
													  AND WCM.WORKCENTERCODE = WCS.WORKCENTERCODE
												LEFT JOIN TB_ItemMaster ITM WITH(NOLOCK)
												       ON WCS.PLANTCODE = ITM.PLANTCODE
													  AND WCS.ITEMCODE  = ITM.ITEMCODE
												LEFT JOIN TB_ProductPlan PP WITH(NOLOCK)
												       ON WCS.PLANTCODE = PP.PLANTCODE
													  AND WCS.ORDERNO   = PP.ORDERNO
												LEFT JOIN TB_StockHALB STH WITH(NOLOCK) -- 재공 재고 테이블(작업장별 투입 LOT 관리 테이블)
												       ON WCM.PLANTCODE        = STH.PLANTCODE
													  AND WCM.WORKCENTERCODE   = STH.WORKCENTERCODE
	 WHERE WCM.PLANTCODE      LIKE '%' +      @PLANTCODE
	   AND WCM.WORKCENTERCODE LIKE '%' + @WORKCENTERCODE
	   AND ISNULL(WCM.USEFLAG, 'Y') <> 'N'
	;

	SET @RS_CODE = 'S';
	SET @RS_MSG = '정상 작동';
END
GO
