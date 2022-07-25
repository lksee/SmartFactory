package kr.co.mlec.board.dao;

import java.io.FileInputStream;
import java.io.InputStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

import kr.co.mlec.board.vo.BoardVO;

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
		InputStream input = null;
		String url = "";
		String user = "";
		String password = "";

		try {
			// 1단계 : 드라이버 로딩
			Class.forName("oracle.jdbc.driver.OracleDriver");

			// 2단계 : DB 접속 및 Connection 객체 얻어오기
			input = new FileInputStream("D:\\SmartFactory\\Servlet\\LectureMVC\\src\\main\\webapp\\WEB-INF\\db.properties");

			Properties prop = new Properties();
			prop.load(input);

			// props.getProperty() 매소드를 통해 properties파일 내부의 설정을 받아옴
			url = prop.getProperty("db.url");
			user = prop.getProperty("db.user");
			password = prop.getProperty("db.pass");
			conn = DriverManager.getConnection(url, user, password);
			System.out.println("conn : " + conn);
			
			// 3단계 : SQL 생성 및 쿼리 실행 객체(PreparedStatement) 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("select no, title, writer, to_char(reg_date, 'yyyy-mm-dd') as reg_date ");
			sql.append("  from t_board ");
			sql.append(" order by no desc ");
			
			pstmt = conn.prepareStatement(sql.toString());
			
			// 4단계 : 쿼리 실행 및 결과 반환
			// insert/upadte/delete --> pstmt.executeUpdate();
			// select               --> pstmt.executeQuery();
			ResultSet rs = pstmt.executeQuery();
			
			while (rs.next()) {
				int no 			= rs.getInt("no");
				String title 	= rs.getString("title");
				String wrtier 	= rs.getString("writer");
				String reg_date = rs.getString("reg_date");
				
				BoardVO board = new BoardVO();
				board.setNo(no);
				board.setTitle(title);
				board.setWriter(wrtier);
				board.setRegDate(reg_date);
				
				boardList.add(board);
				System.out.println(board); // Override한 board.toString()의 반환값 출력
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB 접속(PreparedStatement, Connection) 종료
			try {
				pstmt.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
			
			try {
				conn.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}

		return boardList;
	}

	public static void main(String[] args) {
		BoardDAO dao = new BoardDAO();
		dao.selectAll();
	}
}
