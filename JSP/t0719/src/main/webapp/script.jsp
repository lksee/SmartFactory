<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h2>구구단을 계산해 드립니다.😎</h2>
	<hr>
	
	<form method="post">
		<input type="text" name="inputValue" />
		<input type="submit" value="계산" />
	</form>

<%

	// 구구단 출력하기.
	// 텍스트 창에서 입력을 받아 3을 입력 받으면 3단을 출력하기.
	
	int inputValue = 0;
	if (request.getMethod().equals("POST")) {
		try {
			inputValue = Integer.parseInt(request.getParameter("inputValue"));
		}
		catch (NumberFormatException e) {
			inputValue = 0;
			out.print(e.toString());
		}
		if (inputValue <= 0) {
			out.print("<br/>");
			out.print("1 이상의 숫자를 입력해 주세요.");
		} else {
%>
	<div>
		<p> 👇👇결과입니다.👇👇</p>

<%
			for (int i = 1; i <= 9; i++) {
				out.print(inputValue + "×" + i + "=" + (inputValue*i));
				out.print("<br/>");
			}
		}
	}
%>
	</div>
</body>
</html>