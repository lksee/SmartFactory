<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="com.jsp.AddrBean" %>
<jsp:useBean id="addr" scope="page" class="com.jsp.AddrBean">
	<jsp:setProperty name="addr" property="*" />
</jsp:useBean>
<jsp:useBean id="am" class="com.jsp.AddrManager" scope="application"/>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<style type="text/css">
	h2 {
		text-align: center;
	}
	table {
		margin: auto;
		align-content: center;
		border-collapse: collapse;
		border: 1;
	}
	td {
		text-align: center;
	}
</style>
</head>
<body>
	<h2>주소록</h2>
	<hr>
	<a href="addr_form.jsp">주소록 추가</a>
	<table>
		<tr>
			<td>이름</td>
			<td>전화번호</td>
			<td>이메일</td>
			<td>성별</td>
		</tr>
<%
	for(AddrBean ab : am.getAddrList()) {
		
%>
		<tr>
			<td><%=ab.getUsername() %></td>
			<td><%=ab.getTel() %></td>
			<td><%=ab.getEmail() %></td>
			<td><%=ab.getGender() %></td>
		</tr>
<%
	}
%>
	</table>
</body>
</html>