<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<a href="${ pageContext.request.contextPath }/hello/hello.do">hello</a><br>
	<a href="${ pageContext.request.contextPath }/editor/editor.do">editor</a><br>
	<a href="${ pageContext.request.contextPath }/method/method.do">method</a><br>
	<a href="${ pageContext.request.contextPath }/form/joinForm.do">form</a><br>
	<a href="${ pageContext.request.contextPath }/ajax/resBody.do">ajax, @ResponseBody</a><br>
	<a href="${ pageContext.request.contextPath }/ajax/resBody.json">json 응답</a><br>
	<a href="${ pageContext.request.contextPath }/ajx/resListVOBody.json">json VO응답</a><br>
</body>
</html>