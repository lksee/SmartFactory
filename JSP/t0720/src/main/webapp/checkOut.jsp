<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<% request.setCharacterEncoding("UTF-8"); %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>계산</title>
</head>
<body>
<center>
	<h2>계산</h2>
	<p>선택한 상품 등록</p>
	<hr>
	<%
		ArrayList productlist = (ArrayList)session.getAttribute("productlist");
		if (productlist == null) {
			out.print("선택한 상품이 없습니다.");
		} else {
			for (Object productname : productlist) {
				out.print(productname + "<br>");
			}
		}
		
	%>
	
</center>
</body>
</html>