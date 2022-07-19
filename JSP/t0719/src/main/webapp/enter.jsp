<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<%
	
	String name = request.getParameter("name");
	System.out.print(name);
	
	int age = 0;

	if (request.getMethod().equals("POST")) {
		age = Integer.parseInt(request.getParameter("age"));
	}

	if (age < 20) {
%>
	<script type="text/javascript">
		alert("19세 미만은 입장 불가");
		history.go(-1);
	</script>
<%
	} else {
		out.print(request.getParameter("age"));
%>
	<script type="text/javascript">
		alert("환영합니다.");
	</script>
<%
		request.setAttribute("name", "신재호");
		// RequestDispatcher dispatcher = request.getRequestDispatcher("enter.jsp");
		// dispatcher.forward(request, response);
	}
%>
</body>
</html>