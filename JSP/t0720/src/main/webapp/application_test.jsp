<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h2>application 예제</h2>
	<hr>
	
	서버 정보: <%=application.getServerInfo() %><br>
	api 버전 정보: <%=application.getMajorVersion() %><br>
	실제 경로: <%=application.getRealPath(
			"application_test.jsp") %>
	
<%
	application.setAttribute("name", "이동현");
	application.log("name=이동현");
	application.setAttribute("count", 1);
%>
<br>
<a href="app_re.jsp">결과보기</a>
</body>
</html>