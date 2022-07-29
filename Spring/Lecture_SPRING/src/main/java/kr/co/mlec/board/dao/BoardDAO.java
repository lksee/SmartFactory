package kr.co.mlec.board.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import kr.co.mlec.board.vo.BoardVO;

@Repository
public class BoardDAO {

	@Autowired
	private DataSource ds;
	
	/**
	 * 전체 게시글 조회
	 */
	public List<BoardVO> selectAll() {
		
		List<BoardVO> boardList = new ArrayList<BoardVO>();
		
		StringBuilder sql = new StringBuilder();
		sql.append(" select no, title, writer, to_char(reg_date, 'yyyy-mm-dd') as reg_date ");
		sql.append("   from t_board ");
		sql.append("  order by no desc ");
		// jdk 1.8부터 사용 가능.
		// try의 괄호 안에 객체는 implement java.lang.AutoCloseable 된 객체만 사용 가능하며, 
		// finally문이 없어도 마지막에 해당 객체를 close() 해준다.
		try(
				Connection conn = ds.getConnection();
				PreparedStatement pstmt = conn.prepareStatement(sql.toString());
		) {
			ResultSet rs = pstmt.executeQuery();
			
			while (rs.next()) {
				BoardVO board = new BoardVO();
				board.setNo(rs.getInt("no"));
				board.setTitle(rs.getString("title"));
				board.setWriter(rs.getString("writer"));
				board.setRegDate(rs.getString("reg_date"));
				
				boardList.add(board);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return boardList;
	}
	
	/**
	 * 상세게시글조회
	 */
	public BoardVO selectByNo(int boardNo) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("select no, title, writer, content, view_cnt, ");
		sql.append("       to_char(reg_date, 'yyyy-mm-dd') as reg_date ");
		sql.append("  from t_board ");
		sql.append(" where no = ? ");
		
		try(
			Connection conn = ds.getConnection();
			PreparedStatement pstmt = conn.prepareStatement(sql.toString());
		) {
				pstmt.setInt(1, boardNo);
			
				ResultSet rs = pstmt.executeQuery();
				if (rs.next()) {
					int no = rs.getInt("no");
					String title = rs.getString("title");
					String writer = rs.getString("writer");
					String content = rs.getString("content");
					int viewCnt = rs.getInt("view_cnt");
					String regDate = rs.getString("reg_date");

					BoardVO board = new BoardVO(no, title, writer, content, viewCnt, regDate);
					return board;
				}
		} catch(Exception e) {
			e.printStackTrace();
		}
		
		return null;
	}
	
	/**
	 * 새글등록 서비스
	 */
	public void insert(BoardVO board) {
		StringBuilder sql = new StringBuilder();
		sql.append("insert into t_board(no, title, writer, content) ");
		sql.append(" values(seq_t_board_no.nextval, ?, ?, ?) ");

		try (
				Connection conn = ds.getConnection();
				PreparedStatement pstmt = conn.prepareStatement(sql.toString());
			){
			pstmt.setString(1, board.getTitle());
			pstmt.setString(2, board.getWriter());
			pstmt.setString(3, board.getContent());

			pstmt.executeUpdate();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * 게시물 삭제(jquery를 활용한 ajax 통신)
	 */
	public void deleteByNo(int boardNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("delete t_board ");
		sql.append(" where no = ? ");
		
		try(
			Connection conn = ds.getConnection();
			PreparedStatement pstmt = conn.prepareStatement(sql.toString());
		){
			pstmt.setInt(1, boardNo);
			pstmt.executeUpdate();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
