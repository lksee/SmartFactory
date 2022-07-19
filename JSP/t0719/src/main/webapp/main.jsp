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
	<h2>include 지시어 테스트</h2>
	<hr>
	<%@include file="mainnews.jsp" %>
	<table border=0 cellpadding=10 >
		<tr>
			<td><font color=blue><%@include file="news.jsp" %></font></td>
			<td><font color=green><%@include file="shopping.jsp" %></font></td>
		</tr>
		<tr>
			<td colspan=2><%@include file="copy.jsp" %></td>
		</tr>
	</table>
</center>
</body>
</html>
