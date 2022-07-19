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
int iNum1 = 3;
int iNum2 = 4;
int iSum;
iSum = iNum1 + iNum2;
System.out.print(iNum1+"+"+iNum2+"="+iSum);
%>
<%=iNum1 %>+<%=iNum2 %>=<%=iSum %>
</body>
</html>