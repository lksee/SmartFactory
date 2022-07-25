<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" isErrorPage="true"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<div align = center>
	<h2>주소록 에러처리</h2>
	<hr>
	
	<table cellspacing="5px" cellpadding="5px" width="400">
		<tr width=100% bgcolor="#23ccef">
			<td>
				주소록 처리 중 에러가 발생했습니다. <br>
				관리자에게 문의해주세요.<br>
				빠른 시일 내에 복구하겠습니다.
				<hr>
				에러 내용 : <%=exception %>
				<hr>
			</td>
		</tr>
	</table>
</div>
</body>
</html>