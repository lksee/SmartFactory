<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>

<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h2>forward 파일</h2>
	<hr>
	<jsp:forward page="footer.jsp">
		<jsp:param name="tel" value="010-1111-1111" />
		<jsp:param name="email" value="bluegony@nate.com" />
	</jsp:forward>
</body>
</html>