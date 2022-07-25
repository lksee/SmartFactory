<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<% request.setCharacterEncoding("UTF-8"); %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>장바구니 추가</title>
</head>
<body>
<%
	String product = request.getParameter("product");
	ArrayList list = (ArrayList)session.getAttribute("productlist");
	if (list == null) {
		list = new ArrayList();
	}
	list.add(product);
	session.setAttribute("productlist", list);
%>
	<script type="text/javascript">
		alert('<%=product %>이(가) 추가되었습니다.');
		history.go(-1);
	</script>
</body>
</html>