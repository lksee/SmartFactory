<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.time.*, java.time.format.DateTimeFormatter" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<center>
<%
	LocalTime loctime = LocalTime.now();
	out.print("LocalTime : " + loctime + "<br/>");
	
	DateTimeFormatter hms = DateTimeFormatter.ofPattern("HH:mm:ss");
	String time1 = loctime.format(hms);
	out.print("DateTimeFormatter(hms) : " + time1 + "<br/>");
	
	String time2 = loctime.format(DateTimeFormatter.ofPattern("HH/mm/ss"));
	out.print("DateTimeFormatter(HH/mm/ss) : " + time2 + "<br/>");
	
	String strTime = loctime.getHour() + "시";
	strTime += loctime.getMinute() + "분";
	strTime += loctime.getSecond() + "초";
	strTime += loctime.getNano() + "나노초";
	
	out.print("메소드 이용 : " + strTime);
	
%>
	</center>
</body>
</html>