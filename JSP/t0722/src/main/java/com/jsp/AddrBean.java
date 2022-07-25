package com.jsp;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;

public class AddrBean {
	// 디비 연결
	Connection conn = null;
	PreparedStatement pstmt = null;
	
	// 오라클 관련 정보
	String driver = "oracle.jdbc.driver.OracleDriver";
	String url = "jdbc:oracle:thin:@127.0.0.1:1521/ORACLEDB";
	
	// 디비 연결
	public void connection() {
		try {
			Class.forName(driver);
			conn = DriverManager.getConnection(url, "bdwrtr", "oracle12!@");
			System.out.println("DB 연결 성공");
		} catch (Exception e) {
			System.out.println("DB 연결 실패");
		}
	}
	
	// 디비 연결 해제
	public void disconnection() {
		if (pstmt != null) {
			try {
				pstmt.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
		
		if (conn != null) {
			try {
				conn.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
	
	// 주소록 입력
	public boolean insertDB(AddrBook addrbook) {
		connection();
		String sql = "insert into addrbook (ab_id, ab_name, ab_email, ab_birth, ab_tel, ab_comdept, ab_memo) values(seq_ab.nextVal, ?, ?, ?, ?, ?, ?)";
		try {
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, addrbook.getAb_name());
			pstmt.setString(2, addrbook.getAb_email());
			pstmt.setString(3, addrbook.getAb_birth());
			pstmt.setString(4, addrbook.getAb_tel());
			pstmt.setString(5, addrbook.getAb_comdept());
			pstmt.setString(6, addrbook.getAb_memo());
			
			pstmt.executeUpdate();
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		} finally {
			disconnection();
		}
		return true;
	}
	
	// 주소록 수정
	public boolean updateDB(AddrBook addrbook) {
		connection();
		String sql = "update addrbook set ab_name=?, ab_email=?, ab_birth=?, ab_tel=?, ab_comdept=?, ab_memo=? where ab_id=?";
		try {
			pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, addrbook.getAb_name());
			pstmt.setString(2, addrbook.getAb_email());
			pstmt.setString(3, addrbook.getAb_birth());
			pstmt.setString(4, addrbook.getAb_tel());
			pstmt.setString(5, addrbook.getAb_comdept());
			pstmt.setString(6, addrbook.getAb_memo());
			pstmt.setInt(7, addrbook.getAb_id());
			
			pstmt.executeUpdate();
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		} finally {
			disconnection();
		}
		return true;
	}
	
	// 주소록 삭제
	public boolean deleteDB(int gb_id) {
		connection();
		String sql = "delete from addrbook where ab_id=?";
		try {
			pstmt = conn.prepareStatement(sql);
			pstmt.setInt(1, gb_id);
			
			pstmt.executeUpdate();
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		} finally {
			disconnection();
		}
		return true;
	}
	
	// 특정 주소 하나 가져오기(상세내용)
	public AddrBook getDB(int gb_id) {
		AddrBook addrbook = new AddrBook();
		connection();
		String sql = "select * from addrbook where ab_id=?";
		try {
			pstmt = conn.prepareStatement(sql);
			pstmt.setInt(1, gb_id);
			ResultSet rs = pstmt.executeQuery();
			
			// 데이터 하나 가져오는 코드 작성
			rs.next();
			addrbook.setAb_id(rs.getInt("ab_id"));
			addrbook.setAb_name(rs.getString("ab_name"));
			addrbook.setAb_email(rs.getString("ab_email"));
			addrbook.setAb_birth(rs.getString("ab_birth"));
			addrbook.setAb_tel(rs.getString("ab_tel"));
			addrbook.setAb_comdept(rs.getString("ab_comdept"));
			addrbook.setAb_memo(rs.getString("ab_memo"));
			
			rs.close();
		} catch(Exception e) {
			e.printStackTrace();
		} finally {
			disconnection();
		}
		return addrbook;
	}
	
	
	// 전체 내용 가져오기
	public ArrayList<AddrBook> getDBList() {
		connection();
		String sql = "select * from addrbook order by ab_id asc";
		ArrayList<AddrBook> result = new ArrayList<AddrBook>();
		try {
			pstmt = conn.prepareStatement(sql);
			ResultSet rs = pstmt.executeQuery();
			
			// 데이터 전체 가져오는 코드 작성
			while(rs.next()) {
				AddrBook addrbook = new AddrBook();
				addrbook.setAb_id(rs.getInt("ab_id"));
				addrbook.setAb_name(rs.getString("ab_name"));
				addrbook.setAb_email(rs.getString("ab_email"));
				addrbook.setAb_birth(rs.getString("ab_birth"));
				addrbook.setAb_tel(rs.getString("ab_tel"));
				addrbook.setAb_comdept(rs.getString("ab_comdept"));
				addrbook.setAb_memo(rs.getString("ab_memo"));
				result.add(addrbook);
			}
			rs.close();
		} catch(Exception e) {
			e.printStackTrace();
		} finally {
			disconnection();
		}
		return result;
	}
}
