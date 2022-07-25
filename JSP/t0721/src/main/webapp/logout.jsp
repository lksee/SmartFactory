<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<center>
	세션 속성(id) : <%=session.getAttribute("cust_id") %> <br>
	세션 속성(cust_name) : <%=session.getAttribute("cust_name") %> <br>
	
	<%
		out.print("<b>" + session.getAttribute("cust_id") + "(" + session.getAttribute("cust_name") + ") 님 로그인 중... </b><p>");
		out.print("<b>" + session.getCreationTime() + "초 <br>");
		out.print("유효시간" + session.getMaxInactiveInterval() + "초 <br>");
		
		// 세션 속성 삭제
		session.removeAttribute("cust_id");
		session.removeAttribute("cust_name");
		
		out.print("session.removeAttribute 이후");
		out.print("세션(id)" + session.getAttribute("cust_id") + "<br>");
		out.print("세션(name)" + session.getAttribute("cust_name") + "<br>");
		
		// 세션 초기화
		session.invalidate();
		
		out.print("로그아웃 됨 <br>");
		
	%>
	<a href = "login_form.jsp">세션 삭제 확인</a>
</center>
</body>
</html>