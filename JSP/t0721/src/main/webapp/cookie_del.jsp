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
	<h2>쿠키 삭제</h2>
	<hr>
	<%
	
	Cookie[] cookies = request.getCookies();
	
	if (cookies != null) {
		for(int i = 0; i<cookies.length;i++) {
			cookies[i].setMaxAge(0); // 쿠키 삭제
			response.addCookie(cookies[i]);
			
			out.print("쿠키 삭제 <br>");
		}
	} else {
		out.print("설정된 쿠키 없음 <br>");
	}
	
	%>
	
	<a href="cookie_check.jsp">쿠키 정보 확인</a>
	
</center>
</body>
</html>