<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<div align="center">
	<h2>methodForm</h2>
	<form action="${ pageContext.request.contextPath }/method/method.do" method="post">
		<input type="submit" value="호출">
	</form>
</div>
</body>
</html>