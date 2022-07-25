<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<style>
	table {
		width: 400px;
		border: 2px solid skyblue;
		border-collapse: collapse;
	}
	td {
		background-color: #fafaee;
		text-align: center;
		border: 1px solid gray;
		padding: 3px;
	}
</style>
<title>Insert title here</title>
</head>
<body>
	<h2>회원가입</h2>
	<hr>
	<form action="customer_re.jsp" method="post">
		<table>
			<caption>
				회원가입창
			</caption>
			
			<tr>
				<td>아이디</td>
				<td>
					<input type="text" name="userId">
				</td>
			</tr>
			<tr>
				<td>비밀번호</td>
				<td>
					<input type="password" name="userPw">
				</td>
			</tr>
			<tr>
				<td>이름</td>
				<td>
					<input type="text" name="userName">
				</td>
			</tr>
			<tr>
				<td>성별</td>
				<td>
					<input type="radio" name="gender" value="M">남자&nbsp;
					<input type="radio" name="gender" value="F">여자&nbsp;
					<input type="radio" name="gender" value="E">기타
					
				</td>
			</tr>
			<tr>
				<td>취미</td>
				<td>
					<input type="checkbox" name="userHobby" value="등산">등산<br>
					<input type="checkbox" name="userHobby" value="잠자기">잠자기<br>
					<input type="checkbox" name="userHobby" value="춤추기">춤추기<br>
					<input type="checkbox" name="userHobby" value="먹기">먹기<br>
					<input type="checkbox" name="userHobby" value="연주하기">연주하기<br>
				</td>
			</tr>
			<tr>
				<td colspan="2">
					<input type="submit" value="가입">
					<input type="reset" value="취소">
				</td>
			</tr>
		</table>
	</form>

</body>
</html>