package kr.co.mlec.board.dao;

import java.sql.Connection;
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
		
		// jdk 1.8부터 사용 가능.
		// try의 괄호 안에 객체는 implement java.lang.AutoCloseable 된 객체만 사용 가능하며, 
		// finally문이 없어도 마지막에 해당 객체를 close() 해준다.
		try(
				Connection conn = ds.getConnection();
		) {
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}
}
