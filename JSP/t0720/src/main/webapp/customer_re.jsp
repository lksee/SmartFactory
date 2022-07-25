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
	<h2>회원가입 결과 창</h2>
	<hr>
	<table>
		<tr>
			<td>아이디: </td>
			<td><%=request.getParameter("userId") %></td>
		</tr>
		<tr>
			<td>이름: </td>
			<td><%=request.getParameter("userName") %></td>
		</tr>
		<tr>
			<td>비번: </td>
			<td><%=request.getParameter("userPw") %></td>
		</tr>
		<tr>
			<td>성별: </td>
			<td>
			<%
				String gender = request.getParameter("gender");
				if (gender.equals("M")) {
					out.print("남자");
				} else if (gender.equals("F")) {
					out.print("여자");
				} else if (gender.equals("E")) {
					out.print("기타");
				}
			%>
			</td>
		</tr>
		<tr>
			<td>취미: </td>
			<td>
				<% 
				String[] hobbies = request.getParameterValues("userHobby"); 
				for (String hobby : hobbies) {
					out.print(hobby + "&nbsp;");
				}
				%>
			</td>
		</tr>
		<tr>
			<td>
				<a href="customer.jsp">회원가입 화면으로 이동</a>
			</td>
		</tr>
	</table>
</body>
</html>