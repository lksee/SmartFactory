<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<%
	request.setCharacterEncoding("UTF-8");

	String user = request.getParameter("userName");
	if (user == null) {
		response.sendRedirect("twitter_login.jsp");
	} else {
		ArrayList<String> list = new ArrayList<String>();
		list.add(user);
		session.setAttribute("user", list);
		response.sendRedirect("twitter_list.jsp");
	}
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

</body>
</html>