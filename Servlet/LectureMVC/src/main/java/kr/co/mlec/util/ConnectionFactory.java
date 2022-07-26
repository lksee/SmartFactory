package kr.co.mlec.util;

import java.io.FileInputStream;
import java.io.InputStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.Properties;

/**
 * Database와 연결 후 java.sql.Connection 반환
 * 
 * @author user
 *
 */
public class ConnectionFactory {

	public Connection getConnection() throws Exception {
		// 1단계 : 드라이버 로딩
		Class.forName("oracle.jdbc.driver.OracleDriver");

		// 2단계 : DB 접속 및 Connection 객체 얻어오기
		InputStream input = new FileInputStream("D:\\SmartFactory\\Servlet\\LectureMVC\\src\\main\\webapp\\WEB-INF\\db.properties");

		Properties prop = new Properties();
		prop.load(input);

		// props.getProperty() 매소드를 통해 properties파일 내부의 설정을 받아옴
		String url = prop.getProperty("db.url");
		String user = prop.getProperty("db.user");
		String password = prop.getProperty("db.pass");
		Connection conn = DriverManager.getConnection(url, user, password);
		
		return conn;
	}
}
