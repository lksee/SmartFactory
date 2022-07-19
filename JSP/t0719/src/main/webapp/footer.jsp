<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>footer</title>
</head>
<body>
footer 파일
<%=request.getParameter("email") %>, &nbsp;
<%=request.getParameter("tel") %>
</body>
</html>