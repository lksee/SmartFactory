<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.Scanner" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<!-- 1차원 배열을 이용한 성적처리 프로그램 -->
<%!
// 배열 선언
// 1차원 배열의 3명의 점수를 입력 받아 합계와 평균 구하기.
	int[] score = new int[3];
%>

<%
	int sum = 0; 
	Scanner input = new Scanner(System.in); // 입력 받을 공간 할당
	for(int i=0; i<score.length;i++){
		System.out.print("정수를 입력하세요.");
		score[i] = input.nextInt();
		sum += score[i];
	}
	
	out.print("합계: " + sum);
	out.print("<br>");
	out.print("평균: " + sum/3.0);
%>
</body>
</html>