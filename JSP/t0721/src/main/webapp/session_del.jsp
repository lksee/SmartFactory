<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.text.SimpleDateFormat, java.util.*" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<center>
	<h2>세션 삭제</h2>
	<hr>
	<%
	long creationTime = session.getCreationTime();
	SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH-mm-ss");
	String creationTimeString = dateFormat.format(new Date(creationTime));

	long lastAccessTime = session.getLastAccessedTime();
	String lastAccessTimeString = dateFormat.format(new Date(lastAccessTime));
	
	long sessionTime = lastAccessTime - creationTime;
	SimpleDateFormat timeFormat = new SimpleDateFormat("HH-mm-ss");
	String sessionTimeString = timeFormat.format(new Date(sessionTime));
	
	out.print("세션 생성 시간 : " + creationTimeString + "초 <br>");
	out.print("클라이언트의 해당 세션 마지막 접근 시간 : " + lastAccessTimeString + "초 <br>");
	out.print("세션 유지 시간 : " + sessionTimeString + "초 <br>");
	out.print("세션 유효 시간 : " + session.getMaxInactiveInterval() + "초 <br>");
	
	session.removeAttribute("id");
	session.removeAttribute("name");
	out.print("세션 삭제 <br>");
	%>

	세션 속성(id) : <%=session.getAttribute("id") %><br>
	세션 속성(name) : <%=session.getAttribute("name") %><br>
	
	<%
	// 세션 객체 초기화
	session.invalidate();
	%>
	
	<a href="session_check.jsp">세션 확인</a><br>
</center>
</body>
</html>