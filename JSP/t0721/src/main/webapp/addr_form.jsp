<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <% request.setCharacterEncoding("UTF-8"); %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<div align="center">
	<h2>주소록 등록</h2>
	<hr>
	<form action="addr_add.jsp" method="post" name="form1">
	<table>
		<tr>
			<td>이름</td>
			<td>
				<input type="text" name="username">
			</td>
		</tr>
		<tr>
			<td>전화번호</td>
			<td>
				<input type="text" name="tel">
			</td>
		</tr>
		<tr>
			<td>이메일</td>
			<td>
				<input type="text" name="email">
			</td>
		</tr>
		<tr>
			<td>성별</td>
			<td>
				<select name="gender">
					<option>남자</option>
					<option>여자</option>
				</select>
			</td>
		</tr>
		<tr>
			<td colspan=2>
				<input type="submit" value="등록">
				<input type="reset"	value="취소">
			</td>
		</tr>
	</table>
	</form>

</div>
</body>
</html>