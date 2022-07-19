<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<jsp:useBean id="obj" class="com.big.TestBean" scope="page">
	<jsp:setProperty name="obj" property="*" />
</jsp:useBean>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
결과 화면: <jsp:getProperty property="id" name="obj"/>

</body>
</html>