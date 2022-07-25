<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    
<% request.setCharacterEncoding("UTF-8"); %>
<!-- useBean 사용 -->
<jsp:useBean id="login" scope="page" class="com.jsp.LoginBean">
	<jsp:setProperty name="login" property="*" />
</jsp:useBean>
<!DOCTYPE html>
<%
	if (login.checkUser()) {
		out.print("로그인 성공");
	} else {
		out.print("로그인 실패");
	}
%>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<center>
	<h2>로그인 확인</h2>
	<hr>
	
	사용자 아이디 : <jsp:getProperty property="userid" name="login" />
	사용자 비밀번호 : <jsp:getProperty property="passwd" name="login" />
</center>
</body>
</html>