package kr.co.mlec.member.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import kr.co.mlec.member.vo.MemberVO;

@Repository
public class MemberDAO {
	
	@Autowired
	private DataSource ds;

	/**
	 * 로그인 서비스
	 */
	public MemberVO login(MemberVO loginVO) {
		
		MemberVO member = null;
		
		StringBuilder sql = new StringBuilder();
		sql.append("select userId, userPw, userName, userType ");
		sql.append("  from t_member ");
		sql.append(" where userId = ? and userPw = ? ");
		
		try (
				Connection conn = ds.getConnection();
				PreparedStatement pstmt = conn.prepareStatement(sql.toString());
			) {
			pstmt.setString(1, loginVO.getUserId());
			pstmt.setString(2, loginVO.getUserPw());
			
			ResultSet rs = pstmt.executeQuery();
			if(rs.next()) {
				member = new MemberVO();
				member.setUserId(rs.getString("userId"));
				member.setUserPw(rs.getString("userPw"));
				member.setUserName(rs.getString("userName"));
				member.setUserType(rs.getString("userType"));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return member;
	}
	
}
