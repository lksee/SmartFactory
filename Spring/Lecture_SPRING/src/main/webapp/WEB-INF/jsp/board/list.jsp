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
<header>
		<%-- <%@include file="/WEB-INF/jsp/include/topMenu.jsp" %> --%>
		<jsp:include page="/WEB-INF/jsp/include/topMenu.jsp" />
	</header>
	<section>
		<div align="center">
			<h2>전체게시글 조회</h2>

			<table border="1" style="width: 80%" class="table table-striped">
				<tr>
					<th width="7%">번호</th>
					<th>제목</th>
					<th width="15%">작성자</th>
					<th width="17%">등록일</th>
				</tr>
				<c:forEach items="${ list }" var="board">
					<tr>
						<td>${ board.no }</td>
						<td><a href="${ pageContext.request.contextPath }/board/${ board.no }">
								${ board.title } </a></td>
						<td>${ board.writer }</td>
						<td>${ board.regDate }</td>
					</tr>
				</c:forEach>
			</table>
			<br>
			<button onclick="location.href='${ pageContext.request.contextPath }/board/write'"
				class="btn btn-outline-success">새글등록</button>
			<%--
		<a href="/Lecture-MVC/board/writeForm.do">새글등록</a>
		 --%>
		</div>
	</section>
	<footer>
		<%@include file="/WEB-INF/jsp/include/footer.jsp" %>
	</footer>
</body>
</html>