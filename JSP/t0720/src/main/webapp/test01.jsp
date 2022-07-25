<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<h2>request 테스트 폼</h2>
<hr>
<form action="re.jsp" method="post">
	<table border=1>
		<tr>
			<td>이름</td>
			<td><input type="text" name="userName"></td>
		</tr>
		<tr>
			<td>직업</td>
			<td>
				<select name="job">
					<option value="무직">무직</option>
					<option value="학생" selected>학생</option>
					<option value="직장인">직장인</option>
					<option value="사업가">사업가</option>
				</select>
			</td>
		</tr>
		<tr>
			<td>관심 분야</td>
			<td>
				<input type="checkbox" name="fav" value="정치">정치
				<input type="checkbox" name="fav" value="사회">사회
				<input type="checkbox" name="fav" value="정보통신">정보통신
			</td>
		</tr>
		<tr align="center">
			<td colspan="2">
				<input type="submit" value="확인"/>
				<input type="reset" value="취소"/>
			</td>
		</tr>
		
	</table>
</form>
</body>
</html>