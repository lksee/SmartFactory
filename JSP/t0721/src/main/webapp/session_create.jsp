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
	<h2>세션 생성</h2>
	<hr>
	<%
	session.setAttribute("id", "admin");
	session.setAttribute("name", "장준영");
	
	out.print("세션 생성 <br>");
	%>
	
	세션 속성(id) : <%=session.getAttribute("id") %>
	세션 속성(name) : <%=session.getAttribute("name") %>
</center>
</body>
</html>