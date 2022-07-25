<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%
	// 세션 정보
	String cust_id = (String)session.getAttribute("cust_id");
	String cust_name = (String)session.getAttribute("cust_name");
	
	Boolean login = false;
	
	if ((cust_id != null) && (cust_name != null)) {
		// 로그인 상태
		login = true;
	}
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<style>
	table {
		width: 400px;
		height: 200px;
		border-collapse: collapse;
		border-color: white;
		background-color: #CFD0F0;
		border-style: hidden;
	}
	td {
		border-style: hidden;
		font-weight: bold;
		padding: 2px;
		text-align: center;
	}
</style>
</head>
<body>
	<h2>✅Sign-in✅</h2>
	<hr>
	<form action="login_check.jsp" method="post">
		<table>
			<tr>
				<td>아이디😎</td>
				<td>
					<input type="text" name="cust_id">
				</td>
			</tr>
			<tr>
				<td>패스워드🙄</td>
				<td>
					<input type="password" name="cust_pw">
				</td>
			</tr>
			<tr>
				<td colspan="2">
<%
	if (login) {
		out.print("<input type='submit' value='로그인' disabled>"
				+ "<input type='button' value='" + cust_name + "님 로그아웃' onclick=location.href='logout.jsp'>");
	} else {
		out.print("<input type='submit' value='로그인'>"
				+ "<input type='button' value='로그아웃' disabled>");
	}
%>
				</td>
			</tr>
		</table>
	</form>
	<div>
		<p>기부는 큰 힘이 됩니다.</p>
		<p>후원 문의: 010-1004-1004</p>
		<p>예금주: (주)앤젤컴퍼니 천사은행 1004-10-041004</p>
	</div>
</body>
</html>