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
<h2>request 테스트 폼</h2>
<hr>
<table border=1>
	<tr>
		<td>이름</td>
		<td>
			<%=request.getParameter("userName") %>
		</td>
	</tr>
	<tr>
		<td>직업</td>
		<td>
			<%=request.getParameter("job") %>
		</td>
	</tr>
	<tr>
		<td>관심 분야</td>
		<td>
			<%
				String favs[] = request.getParameterValues("fav");
				for (String f : favs) {
					out.print(f + "&nbsp;&nbsp;");
				}
			%>
		</td>
	</tr>
</table>
</body>
</html>