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
	<h2>쿠키 확인</h2>
	<hr>
	
	<%
	Cookie[] cookies = request.getCookies(); // 쿠키 생성
	
	if (cookies != null) {
		for (Cookie cookie : cookies) {
			String name = cookie.getName();
			String value = cookie.getValue();
			
			out.print("쿠키 이름 : " + name + "<br>");
			out.print("쿠키 값 : " + value + "<br><br><hr><br>");
		}
	} else {
		out.print("쿠키 정보가 없음");
	}
	
	
	
	%>
	<a href="cookie_del.jsp">쿠키 삭제</a>
</center>
</body>
</html>