package com.youandi.dao;

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

import com.youandi.vo.ItemMasterVO;

/**
 * item_master 테이블 조회
 * @author 이기수
 *
 */
public class ItemMasterDAO {

	public List<ItemMasterVO> selectAll() {
		List<ItemMasterVO> itemmaster = new ArrayList<ItemMasterVO>();
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
			input = new FileInputStream("D:\\SmartFactory\\Servlet\\youandi\\src\\main\\webapp\\WEB-INF\\db.properties");

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
			sql.append("SELECT itemcode, itemname, itemtype, whcode, baseunit, unitcost, itemspec, minorderqty, orderqty, maxorderqty, to_char(MAKEDATE, 'yyyy-mm-dd') AS makedate, maker ");
			sql.append("  FROM ITEM_MASTER ");
			sql.append(" ORDER BY ITEMCODE ASC ");
			
			pstmt = conn.prepareStatement(sql.toString());
			
			// 4단계 : 쿼리 실행 및 결과 반환
			// insert/upadte/delete --> pstmt.executeUpdate();
			// select               --> pstmt.executeQuery();
			ResultSet rs = pstmt.executeQuery();
			
			while (rs.next()) {
				String itemcode		= rs.getString("itemcode");
				String itemname 	= rs.getString("itemname");
				String itemtype		= rs.getString("itemtype");
				String whcode   	= rs.getString("whcode");
				String baseunit 	= rs.getString("baseunit");
				float  unitcost 	= rs.getFloat("unitcost");
				String itemspec 	= rs.getString("itemspec");
				float  minorderqty 	= rs.getFloat("minorderqty");
				float  orderqty		= rs.getFloat("orderqty");
				float  maxorderqty	= rs.getFloat("maxorderqty");
				String makedate		= rs.getString("makedate");
				String maker		= rs.getString("maker");
				
				ItemMasterVO item = new ItemMasterVO();
				item.setITEMCODE(itemcode);
				item.setITEMNAME(itemname);
				item.setITEMTYPE(itemtype);
				item.setWHCODE(whcode);
				item.setBASEUNIT(baseunit);
				item.setUNITCOST(unitcost);
				item.setITEMSPEC(itemspec);
				item.setMINORDERQTY(minorderqty);
				item.setORDERQTY(orderqty);
				item.setMAXORDERQTY(maxorderqty);
				item.setMAKEDATE(makedate);
				item.setMAKER(maker);
				
				itemmaster.add(item);
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
		
		return itemmaster;
	}

}
