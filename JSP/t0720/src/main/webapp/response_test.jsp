<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<%
	Enumeration<String> enu = request.getHeaderNames();

	while (enu.hasMoreElements()) {
		String name = (String)enu.nextElement();
		String value = (String)request.getHeader(name);
		
		out.print("헤더 이름 : " + name + "<br>");
		out.print("헤더 값 : " + value + "<br>");
	}
%>
</body>
</html>