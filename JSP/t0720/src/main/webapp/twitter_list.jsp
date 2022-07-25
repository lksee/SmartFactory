<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<% 
	request.setCharacterEncoding("UTF-8"); 
	
	// session에 로그인 정보가 없다면 로그인 페이지로 보낸다.
	Object userList = session.getAttribute("user");
	
	if (userList == null) {
		response.sendRedirect("twitter_login.jsp");
	}
	
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h2>My Simple Twitter!!</h2>
	<hr>
	<form action="tweet.jsp" method="POST">
		@<%=session.getAttribute("user") %> <input type="text" name="msg" >
		<input type="submit" value="Tweet">
	</form>
	<input type="button" value="로그아웃" onclick="location.href='twitter_logout.jsp'" >
	<hr>
	<div align="left">
		<ul>
<%
			// application 내장객체를 통해 msgs 이름으로 저장된 ArrayList를 가지고 옴
			ArrayList<String> msgs = (ArrayList<String>)application.getAttribute("msgs");

			// msgs가 null이 아닌 경우에만 목록 출력
			if (msgs != null) {
				for (String msg: msgs) {
					out.println("<li>" + msg + "</li>");
				}
			}
%>
		</ul>
	</div>
</body>
</html>