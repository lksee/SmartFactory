/*
KFQS01   강성욱
KFQS02   강희성
KFQS03   김유진
KFQS04   문한석
KFQS05   박건아
KFQS06   박남길
KFQS07   박용희
KFQS08   박형순
KFQS09   백두산
KFQS10   신재호
KFQS11   심재혁
KFQS12   유주연
KFQS13   이기수
KFQS14   이다영
KFQS15   이동현
KFQS16   이슬비
KFQS17   임두형
KFQS18   임현진
KFQS19   장준영
KFQS20   장준혁
KFQS21   조영민
KFQS22   최종현
KFQS23   최현호
KFQS24   한동우
KFQS25   홍성민
*/
DELETE TB_WorkerList
 WHERE WORKERID LIKE 'P_KFQS%';

INSERT INTO TB_WorkerList (PLANTCODE, WORKERID, WORKERNAME, BANCODE, GRPID, DEPTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, MAKER, MAKEDATE) 
	VALUES ('1000', 'P_KFQS01', '강성욱', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
	     , ('1000', 'P_KFQS02', '강희성', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS03', '김유진', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS04', '문한석', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS05', '박건아', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS06', '박남길', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
	     , ('1000', 'P_KFQS07', '박용희', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS08', '박형순', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS09', '백두산', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS10', '신재호', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS11', '심재혁', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
	     , ('1000', 'P_KFQS12', '유주연', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS13', '이기수', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS14', '이다영', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS15', '이동현', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS16', '이슬비', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
	     , ('1000', 'P_KFQS17', '임두형', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS18', '임현진', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS19', '장준영', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS20', '장준혁', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS21', '조영민', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
	     , ('1000', 'P_KFQS22', '최종현', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS23', '최현호', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS24', '한동우', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS25', '홍성민', 'WG007', 'PP', 'PP', '지우지마!', '2022-06-30', '', 'Y', 'FAKER', GETDATE())
;




DECLARE @NUM INT = 1000, @ID VARCHAR(10) = '', @NAME VARCHAR(12) = ''
WHILE @NUM < 10000
BEGIN
	SET @NAME = '갓재혁'+'['+LTRIM(STR(@NUM))+']'
	SET @ID = 'SJH_'+LTRIM(STR(@NUM))
	SET @NUM += 1
	INSERT INTO TB_WorkerList (PLANTCODE, WORKERID, WORKERNAME, BANCODE, GRPID, DEPTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, MAKER, MAKEDATE) 
	VALUES ('1000', @ID, @NAME, 'WG007', 'PP', 'PP', '지워바바', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
END

INSERT INTO TB_WorkerList (PLANTCODE, WORKERID, WORKERNAME, BANCODE, GRPID, DEPTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, MAKER, MAKEDATE) 
	VALUES ('1000', 'P_KFQS41', '이기수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
	     , ('1000', 'P_KFQS42', '3기2수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS43', '4기수3', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS44', '5기수3', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS45', '6기2수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS46', '7기수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS47', '8기3수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS48', '9기23수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS49', '102기2수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS50', '11기1수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS51', '12기2수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS52', '13기24수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS53', '14기1수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS54', '15기4수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS55', '16기2수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS56', '17기수3', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS57', '18기2수', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS58', '19재혁', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS59', '20죄혁', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS60', '21제혁', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS61', '22죄혁', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS62', '23쥐혁', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS63', '24직혁', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS64', '25진현', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS65', '26ㅈㅎ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS66', '이ㅇㅇ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS67', '이ㄱㅇ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS68', '이ㄴㅋ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS69', '이ㅎㅎ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS70', '이ㅎㄷ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS71', '이ㅋㅋ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS72', '이ㅎㅎㄷ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS73', '이ㄷㄷ', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS74', '이멜론', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 , ('1000', 'P_KFQS75', '이킼킼', 'WG007', 'PP', 'PP', '지우지마!', '2016-06-01', '2021-05-30', 'Y', 'FAKER', GETDATE())
		 ;