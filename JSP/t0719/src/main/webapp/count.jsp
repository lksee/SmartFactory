<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<%
	int count = 0; // 로컬변수(지역변수)
	out.print("결과는 : ");
	out.print(++count);
	out.print("<br>");
%>
</body>
</html>