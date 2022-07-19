<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<jsp:useBean id="Login" class="com.big.LoginBean" scope="page">
	<jsp:setProperty name="Login" property="*" />
</jsp:useBean>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
사용자 아이디 : <jsp:getProperty name="Login" property="id" />
사용자 패스워드 : <jsp:getProperty name="Login" property="pw" />

<%
	if (!Login.checkUser()) {
		out.print("로그인 실패");
	} else {
		out.print("로그인 성공");
	}
%>
</body>
</html>