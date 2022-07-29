<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<script>
	function checkForm() {
		if(document.loginForm.id.value == '') {
			alert('아이디를 입력하세요')
			document.loginForm.id.focus()
			return false
		}
		
		if(document.loginForm.password.value == '') {
			alert('패스워드를 입력하세요')
			document.loginForm.password.focus()
			return false
		}
		
		return true
	}
</script>
</head>
<body>

	<header>
		<%-- <%@include file="/WEB-INF/jsp/include/topMenu.jsp" %> --%>
		<jsp:include page="/WEB-INF/jsp/include/topMenu.jsp" />
	</header>
	<section>
		<div align="center">
			<hr>
			<h2>로그인</h2>
			<hr>
			<br>
			<form action="${ pageContext.request.contextPath }/login" method="post"
				onsubmit="return checkForm()" name="loginForm">
				<table border="1">
					<tr>
						<th>ID</th>
						<td><input type="text" name="userId"></td>
					</tr>
					<tr>
						<th>PASSWORD</th>
						<td><input type="password" name="userPw"></td>
					</tr>
				</table>
				<br> <input type="submit" value="로그인">
			</form>
		</div>
	</section>
	<footer>
		<%@include file="/WEB-INF/jsp/include/footer.jsp"%>
	</footer>
</body>
</html>









