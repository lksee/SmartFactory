<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" errorPage="addrbook_error.jsp" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<link rel="stylesheet" href="addrbook.css" type="text/css" media="screen"/>
</head>
<body>
<div align=center>
	<h2>주소록 화면</h2>
	<hr>
	<a href="addrbook_list.jsp">주소록 목록</a>
	
	<form method="POST" action="addrbook_control.jsp">
		<input type="hidden" name="action" value="insert">
		<table border=1>
			<tr>
				<th>이름</th>
				<td><input type="text" name="ab_name" maxlength=15></td>
			</tr>
			<tr>
				<th>email</th>
				<td><input type="text" name="ab_email" maxlength=20></td>
			</tr>
			<tr>
				<th>전화번호</th>
				<td><input type="text" name="ab_tel" maxlength=15></td>
			</tr>
			<tr>
				<th>생일</th>
				<td><input type="date" name="ab_birth"></td>
			</tr>
			<tr>
				<th>회사</th>
				<td><input type="text" name="ab_comdept" maxlength=20></td>
			</tr>
			<tr>
				<th>메모</th>
				<td><input type="text" name="ab_memo"></td>
			</tr>
			<tr>
				<td colspan=2>
					<input type="submit" value="확인">
					<input type="reset" value="취소">
				</td>
			</tr>
		</table>	
	</form>
</div>
</body>
</html>