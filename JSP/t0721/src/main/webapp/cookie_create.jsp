<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<center>
	<h2>쿠키 생성</h2>
	<hr>
	<%
	// 쿠키 객체 생성
	Cookie cookie = new Cookie("id", "admin");
	cookie.setMaxAge(100);
	response.addCookie(cookie);
	
	out.print("쿠키 정보 생성되었습니다.<br>");
	%>
	
	쿠키값 : <%=cookie.getValue() %> <br>
	쿠키 이름 : <%=cookie.getName() %> <br>
	쿠키 시간 : <%=cookie.getMaxAge() %> <br>

</center>
</body>
</html>