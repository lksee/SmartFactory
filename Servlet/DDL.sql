/*
 * 게시판 테이블(t_board)
 * 번호		정수형	PK
 * 제목		문자형	not null
 * 작성자		문자형	not null
 * 내용		문자형	not null
 * 조회수		정수형	default 0
 * 등록일시	날짜형	default sysdate
 */

CREATE TABLE t_board(
	  no 		number(5) 		PRIMARY KEY
	, title 	varchar2(200) 	NOT NULL
	, writer 	varchar2(30) 	NOT NULL
	, content 	varchar2(4000) 	NOT NULL
	, view_cnt 	number(5) 		DEFAULT 0
	, reg_date 	DATE 			DEFAULT sysdate
);

-- 게시판 일련번호 생성
CREATE SEQUENCE seq_t_board_no nocache;

SELECT NO, title, writer, reg_date
  FROM T_BOARD tb ;

INSERT INTO T_BOARD (no, title, writer, content)
VALUES (seq_t_board_no.nextval, '아싸 1등', '박남길', '아싸라뵹 1등이다.');

INSERT INTO T_BOARD (no, title, writer, content)
VALUES (seq_t_board_no.nextval, 'ㄲㅂ 2등', '이동현', '아숩..');

INSERT INTO T_BOARD (no, title, writer, content)
VALUES (seq_t_board_no.nextval, 'ㅋㅋㅋ', '문한석', '바보~');

COMMIT;