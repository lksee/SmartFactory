package kr.co.mlec.util;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

/**
 * Database 접속 종료
 * 
 * @author user
 *
 */
public class JDBCClose {
	public static void close(PreparedStatement pstmt, Connection conn) {
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
}
