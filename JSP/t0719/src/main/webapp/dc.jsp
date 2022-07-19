<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<%!
// 선언문
	String str = "점심시간";
	int a=5, b=-5;

	// 함수 선언
	public int abs(int n){ // 절대값
		if(n<0){
			n=-n;
		}
		return n;
	}
%>

<%
	out.print(str + "+" +"<br>");
	out.print(a + "절대값 : " + abs(a) + "<br>");
	out.print(b + "절대값 : " + abs(b) + "<br>");
	int a = 3;
	out.print(a);
	//데이터형[] 배열명;
	//데이터형[] 배열명 = new 데이터형[크기];
	int[] a1 = new int[5];
	
	out.print(a1.length);
	for(int i=0; i <a1.length;i++){
		a1[i] = i+1;
	}
%>
<%-- jsp 주석문 --%>
<!-- html 주석문 -->
</body>
</html>