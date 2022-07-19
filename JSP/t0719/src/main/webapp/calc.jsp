<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<%
	// 결과 출력
	double result = 0;

	// 웹페이지 요청하는 post인 경우에 form에서 데이터 전달
	if (request.getMethod().equals("POST")){
		// 연산자 받기
		String op = request.getParameter("op");
		
		// 숫자 받기, 단 문자열을 숫자로 변환하기.
		int iNum1 = Integer.parseInt(request.getParameter("iNum1"));
		int iNum2 = Integer.parseInt(request.getParameter("iNum2"));
		
		if (op.equals("+")){
			result = iNum1 + iNum2;
		} else if (op.equals("-")){
			result = iNum1 - iNum2;
		} else if (op.equals("*")){
			result = iNum1 * iNum2;
		} else if (op.equals("/")){
			result = iNum1 / iNum2;
		} else {
			out.print("잘못 입력했습니다.");
		}
	}
%>
<html>
<head>
<meta charset="UTF-8">
<title>This page is Calculate something you want.</title>
</head>
<body>
	<div align=center>
		<h3>계산기</h3>
		<hr>
		<form method="post">
			<input type="text" name="iNum1">
			<select name="op">
				<option>+</option>
				<option>-</option>
				<option>*</option>
				<option>/</option>
			</select>
			<input type="text" name="iNum2">
			<br>
			<input type="submit" value="확인">
			<input type="reset" value="취소">
		</form>
	</div>
	
	계산 결과: <%=result %>
</body>
</html>