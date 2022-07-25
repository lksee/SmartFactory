<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.time.*" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

<%
	LocalDate spcdate = LocalDate.of(2022, 7, 20);
	String spc = spcdate.getYear() + "년";
	spc += spcdate.getMonth() + "월";
	spc += spcdate.getDayOfMonth() + "일";
	spc += spcdate.getDayOfMonth() + "주";
	
	out.print("특별한 날 : " + spc + "<br/>");

%>

</body>
</html>