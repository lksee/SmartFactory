<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<!-- 선언문 -->
<%!
	// 멤버 변수 선언
	int num1 = 0;
	int num2 = 0;
	String op = "";
	int sum = 0;
	
	// 메서드 선언
	public int cal() {
		if(op.equals("+")) {
			sum = num1 + num2;
		} else if (op.equals("-")) {
			sum = num1 - num2;
		} else if (op.equals("*")) {
			sum = num1 * num2;
		} else if (op.equals("/")) {
			sum = num1 / num2;
		} else {
			return 0;
		}
		
		return sum;
	}
%>
<%
	if (request.getMethod().equals("POST")) {
		num1 = Integer.parseInt(request.getParameter("num1"));
		num2 = Integer.parseInt(request.getParameter("num2"));
		op = request.getParameter("op");
	}

	int re = cal();
%>
<html>
<head>
<meta charset="UTF-8">
<title>Calc2</title>
</head>
<body>
	<form method="post">
		<input type="text" name="num1" />
		<input type="text" name="op" />
		<input type="text" name="num2" />
		<input type="submit" value="OK" />
		<input type="reset" value="Cancle" />
	</form>
	<hr>
	<%=re %>
</body>
</html>