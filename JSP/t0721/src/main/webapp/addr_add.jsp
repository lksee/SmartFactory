<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<% request.setCharacterEncoding("UTF-8"); %>
<!-- useBean 사용 -->
<jsp:useBean id="addr" scope="page" class="com.jsp.AddrBean">
	<jsp:setProperty name="addr" property="*" />
</jsp:useBean>
<jsp:useBean id="am" class="com.jsp.AddrManager" scope="application"/>
<% am.add(addr); %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<center>
	<h2>등록 내용</h2>
	<hr>
	이름 : <%=addr.getUsername() %>
	전화번호 : <jsp:getProperty name="addr" property="tel" />
	이메일 : <jsp:getProperty name="addr" property="email" />
	성별 : <jsp:getProperty name="addr" property="gender" />
</center>
<a href="addr_list.jsp">목록 보기</a>
</body>
</html>