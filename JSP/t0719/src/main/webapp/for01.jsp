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
/*
1
22
333
4444
55555

*/
for(int i = 1; i <= 5; i++){
	for(int j=1; j <=i; j++){
		out.print(i+" ");
	}
	out.print("<br/>");
}
%>
</body>
</html>