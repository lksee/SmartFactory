<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<!-- 주석문 -->
<%
// 스크립트릿
// 1부터 10까지 출력한 후 합계구하기.
int iSum = 0;
for (int i = 1; i <= 10; i++){
	out.print(i);
	iSum += i;
}
out.print("<br>");
out.print(iSum);
%>
</body>
</html>