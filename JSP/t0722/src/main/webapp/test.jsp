<%@page import="java.util.Properties"%>
<%@page import="java.io.FileInputStream"%>
<%@page import="java.io.InputStream"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import ="java.sql.*"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

<%
	// 기본 값 초기화
	InputStream input = null;
	String url = "";
	String user = "";
	String password = "";
	
	Connection conn = null;
	String driver = "oracle.jdbc.driver.OracleDriver";
	Class.forName(driver);

	input = new FileInputStream("D:\\SmartFactory\\JSP\\t0722\\src\\main\\webapp\\WEB-INF\\db.properties");

	Properties prop = new Properties();
	prop.load(input);

	// props.getProperty() 매소드를 통해 properties파일 내부의 설정을 받아옴
	url = prop.getProperty("db.url");
	user = prop.getProperty("db.user");
	password = prop.getProperty("db.pass");
	conn = DriverManager.getConnection(url, user, password);
	Boolean connection = false;
	
	try{
		// 오라클 드라이버 접속
		Class.forName(driver);
		// 실제 db접속
		conn = DriverManager.getConnection(url, user, password);
		
		// 접속 성공 여부
		connection = true;
		conn.close();
	}catch(Exception e){
		connection = false;
		e.printStackTrace();
		
	}
	if(connection == true){
		out.print("DB 연결성공");
	}else{
		out.print("DB 연결실패");
	}

%>
</body>
</html>