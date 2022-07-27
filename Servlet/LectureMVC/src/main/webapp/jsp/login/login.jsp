<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<script>
	function checkForm() {
		if (document.loginForm.userId.value == '') {
			alert('아이디를 입력하세요.');
			document.loginForm.userId.focus();
			return false;
		}
		
		if (document.loginForm.userPw.value == '') {
			alert('비밀번호를 입력하세요.');
			document.loginForm.userPw.focus();
			return false;
		}
		
		return true;
	}
</script>
</head>
<body>
	<div align="center">
		<hr>
		<h2>로그인</h2>
		<hr>
		<form action="/LectureMVC/loginProcess.do" method="post" name="loginForm" onsubmit="return checkForm()">
			<table border="1">
				<tr>
					<th>ID</th>
					<td><input type="text" name="userId"></td>
				</tr>
				<tr>
					<th>PW</th>
					<td><input type="password" name="userPw""></td>
				</tr>
			</table>
			<input type="submit" value="로그인">
			<!-- <button type="submit">로그인</button> -->
		</form>
	</div>

</body>
</html>