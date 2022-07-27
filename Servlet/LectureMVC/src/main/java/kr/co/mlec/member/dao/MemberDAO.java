package kr.co.mlec.member.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import kr.co.mlec.member.vo.MemberVO;
import kr.co.mlec.util.ConnectionFactory;
import kr.co.mlec.util.JDBCClose;

/**
 * t_member 테이블 CRUD 위한 기능 클래스
 * @author user
 *
 */
public class MemberDAO {

	/**
	 * 로그인 서비스
	 * @param MemberVO
	 * @return MemberVO
	 */
	public MemberVO login(MemberVO loginVO) {
		
		Connection conn = null;
		PreparedStatement pstmt = null;
		try {
			conn = new ConnectionFactory().getConnection();
			
			StringBuilder sql = new StringBuilder();
			sql.append("select userId, userPw, userName, userType ");
			sql.append("  from t_member ");
			sql.append(" where userId = ? and userPw = ?");
			
			pstmt = conn.prepareStatement(sql.toString());
			
			pstmt.setString(1, loginVO.getUserId());
			pstmt.setString(2, loginVO.getUserPw());
			
			ResultSet rs = pstmt.executeQuery();
			
			if (rs.next()) {
				String userId 	= rs.getString("userId");
				String userPw 	= rs.getString("userPw");
				String userName = rs.getString("userName");
				String userType = rs.getString("userType");
				
				return new MemberVO(userId, userPw, userName, userType);
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		finally {
			JDBCClose.close(pstmt, conn);
		}
		return null;
	}
}
