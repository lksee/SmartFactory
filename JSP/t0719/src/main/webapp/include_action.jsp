<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Include Action</title>
</head>
<body>
<h2>나는 include 파일</h2>
<hr>
<%!
	int a = 20;
%>
<jsp:include page="footer.jsp">
	<jsp:param value="powerlks89@naver.com" name="email" />
	<jsp:param value="010-0000-0000" name="tel" />
</jsp:include>
</body>
</html>