package kr.co.mlec.board.dao;

import java.io.InputStream;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import kr.co.mlec.board.vo.BoardVO;
import kr.co.mlec.util.ConnectionFactory;
import kr.co.mlec.util.JDBCClose;

/**
 * t_board 테이블의 게시판 데이터 CRUD 기능 클래스
 * 
 * @author user
 */
public class BoardDAO {

	/**
	 * 전체 게시글 조회 기능
	 */
	public List<BoardVO> selectAll() {
		// 기본 값 초기화
		List<BoardVO> boardList = new ArrayList<BoardVO>();
		Connection conn = null;
		PreparedStatement pstmt = null;

		try {
			conn = new ConnectionFactory().getConnection();

			// 3단계 : SQL 생성 및 쿼리 실행 객체(PreparedStatement) 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("select no, title, writer, to_char(reg_date, 'yyyy-mm-dd') as reg_date ");
			sql.append("  from t_board ");
			sql.append(" order by no desc ");

			pstmt = conn.prepareStatement(sql.toString());

			// 4단계 : 쿼리 실행 및 결과 반환
			// insert/upadte/delete --> pstmt.executeUpdate();
			// select --> pstmt.executeQuery();
			ResultSet rs = pstmt.executeQuery();

			while (rs.next()) {
				int no = rs.getInt("no");
				String title = rs.getString("title");
				String wrtier = rs.getString("writer");
				String reg_date = rs.getString("reg_date");

				BoardVO board = new BoardVO();
				board.setNo(no);
				board.setTitle(title);
				board.setWriter(wrtier);
				board.setRegDate(reg_date);

				boardList.add(board);
//				System.out.println(board); // Override한 board.toString()의 반환값 출력
			}

		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB 접속(PreparedStatement, Connection) 종료
			JDBCClose.close(pstmt, conn);
		}

		return boardList;
	}

	/**
	 * 새글 등록 서비스
	 * 
	 * @param board
	 */
	public void insert(BoardVO board) {

		// 기본 값 초기화
		List<BoardVO> boardList = new ArrayList<BoardVO>();
		Connection conn = null;
		PreparedStatement pstmt = null;
		InputStream input = null;
		String url = "";
		String user = "";
		String password = "";

		try {
			conn = new ConnectionFactory().getConnection();

			// 3단계 : sql 생성 및 실행 객체 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("insert into t_board(no, title, writer, content) ");
			sql.append("values(seq_t_board_no.nextval, ?, ?, ?)");

			pstmt = conn.prepareStatement(sql.toString());

			pstmt.setString(1, board.getTitle());
			pstmt.setString(2, board.getWriter());
			pstmt.setString(3, board.getContent());

			// 4단계 : 쿼리 실행
			int insertCnt = pstmt.executeUpdate();
			System.out.println(insertCnt);

		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB 접속 종료
			JDBCClose.close(pstmt, conn);
		}
	}

	/**
	 * 게시물 내용 조회
	 * 
	 * @param boardNo
	 * @return
	 */
	public BoardVO selectByNo(int boardNo) {
		// 기본 값 초기화
		Connection conn = null;
		PreparedStatement pstmt = null;

		try {
			conn = new ConnectionFactory().getConnection();

			// 3단계 : SQL 생성 및 쿼리 실행 객체(PreparedStatement) 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("SELECT NO, title, writer, content, view_cnt, to_char(reg_date, 'yyyy-mm-dd') AS reg_date ");
			sql.append("  FROM t_board ");
			sql.append(" WHERE NO = ? ");
			sql.append(" ORDER BY no DESC ");

			pstmt = conn.prepareStatement(sql.toString());
			pstmt.setInt(1, boardNo);

			// 4단계 : 쿼리 실행 및 결과 반환
			// insert/upadte/delete --> pstmt.executeUpdate();
			// select --> pstmt.executeQuery();
			ResultSet rs = pstmt.executeQuery();

			if (rs.next()) {

				int no = rs.getInt("no");
				String title = rs.getString("title");
				String wrtier = rs.getString("writer");
				String content = rs.getString("content");
				int view_cnt = rs.getInt("view_cnt");
				String reg_date = rs.getString("reg_date");

				BoardVO board = new BoardVO(no, title, wrtier, content, view_cnt, reg_date);
				return board;
				// return 하더라도 finally 부분은 무조건 실행된다.
			}
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB 접속(PreparedStatement, Connection) 종료
			JDBCClose.close(pstmt, conn);
		}
		return null;
	}

	/**
	 * 게시물 조회수 증가
	 * @param boardNo
	 */
	public void updateViewCnt(int boardNo) {
		// 기본 값 초기화
		Connection conn = null;
		PreparedStatement pstmt = null;

		try {
			// 1단계 드라이버 설정, 2단계 DB 접속
			conn = new ConnectionFactory().getConnection();

			// 3단계 : SQL 생성 및 쿼리 실행 객체(PreparedStatement) 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("UPDATE T_BOARD ");
			sql.append("   SET view_cnt = view_cnt + 1 ");
			sql.append(" WHERE NO = ? ");

			pstmt = conn.prepareStatement(sql.toString());
			pstmt.setInt(1, boardNo);

			// 4단계 : 쿼리 실행 및 결과 반환
			pstmt.executeUpdate();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB 접속(PreparedStatement, Connection) 종료
			JDBCClose.close(pstmt, conn);
		}
	}

	/**
	 * 게시물 삭제
	 * @param boardNo
	 */
	public void deleteByNo(int boardNo) {
		// 기본 값 초기화
		Connection conn = null;
		PreparedStatement pstmt = null;

		try {
			// 1단계 드라이버 설정, 2단계 DB 접속
			conn = new ConnectionFactory().getConnection();

			// 3단계 : SQL 생성 및 쿼리 실행 객체(PreparedStatement) 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("DELETE T_BOARD ");
			sql.append(" WHERE NO = ? ");

			pstmt = conn.prepareStatement(sql.toString());
			pstmt.setInt(1, boardNo);

			// 4단계 : 쿼리 실행 및 결과 반환
			pstmt.executeUpdate();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB 접속(PreparedStatement, Connection) 종료
			JDBCClose.close(pstmt, conn);
		}
		
	}

	/**
	 * 게시물 수정
	 * @param board
	 */
	public void updateByNo(BoardVO board) {
		// 기본 값 초기화
		Connection conn = null;
		PreparedStatement pstmt = null;

		try {
			// 1단계 드라이버 설정, 2단계 DB 접속
			conn = new ConnectionFactory().getConnection();

			// 3단계 : SQL 생성 및 쿼리 실행 객체(PreparedStatement) 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("UPDATE T_BOARD ");
			sql.append("   set writer = ? ");
			sql.append("     , title = ? ");
			sql.append("     , content = ? ");
			sql.append(" WHERE NO = ? ");

			pstmt = conn.prepareStatement(sql.toString());
			pstmt.setString(1, board.getWriter());
			pstmt.setString(2, board.getTitle());
			pstmt.setString(3, board.getContent());
			pstmt.setInt(4, board.getNo());

			// 4단계 : 쿼리 실행 및 결과 반환
			pstmt.executeUpdate();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB 접속(PreparedStatement, Connection) 종료
			JDBCClose.close(pstmt, conn);
		}
	}
}
