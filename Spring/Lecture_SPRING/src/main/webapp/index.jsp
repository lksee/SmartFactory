<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>    
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>메인페이지</title>
</head>
<body>
	<header>
		<%-- <%@include file="/WEB-INF/jsp/include/topMenu.jsp" %> --%>
		<jsp:include page="/WEB-INF/jsp/include/topMenu.jsp" />
	</header>
	<section>
		<a href="${ pageContext.request.contextPath }/board">게시판</a><br>
		<a href="${ pageContext.request.contextPath }/board/write">새글등록</a><br>
		<c:choose>
			<c:when test="${ empty loginVO }">
				<a href="${ pageContext.request.contextPath }/login">로그인</a><br>
			</c:when>
			<c:otherwise>
				<a href="${ pageContext.request.contextPath }/logout">로그아웃</a><br>
			</c:otherwise>
		</c:choose>
	</section>
	<footer>
		<%@include file="/WEB-INF/jsp/include/footer.jsp" %>
	</footer>
</body>
</html>