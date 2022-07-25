<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h2>결과화면</h2>
	<hr>
	<%=application.getAttribute("name") %><br>
	<%
		Integer count = (Integer)application.getAttribute("count");
	int cnt = count.intValue() + 1;
	application.setAttribute("count", cnt);
	%>
	
	방문자수 <%=cnt %>
</body>
</html>