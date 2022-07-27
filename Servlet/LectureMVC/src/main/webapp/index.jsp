<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<c:if test="${ not empty userVO }">
		현재 로그인된 사용자 : [${ userVO.userId }(${ userVO.userName })]<br>
	</c:if>
		<a href="/LectureMVC/board/list.do">전체 게시글 조회</a><br>
		<a href="/LectureMVC/board/writeForm.do">새글 등록</a><br>
	<c:choose>
		<c:when test="${ empty userVO }">
			<a href="/LectureMVC/login.do">로그인</a><br>
		</c:when>
		<c:otherwise>
			<a href="/LectureMVC/logout.do">로그아웃</a><br>
		</c:otherwise>
	</c:choose>
</body>
</html>