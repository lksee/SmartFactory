<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<%
	out.print("버퍼 크기: " + out.getBufferSize() + "<br>");
	out.print("남은 버퍼 크기: " + out.getRemaining() + "<br>");
	out.flush();
	out.print("버퍼 크기: " + out.getBufferSize() + "<br>");
	out.print("버퍼 크기: " + out.getRemaining() + "<br>");
	out.print(out.isAutoFlush());

%>
</body>
</html>