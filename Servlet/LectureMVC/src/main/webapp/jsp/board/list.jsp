<%@page import="java.util.List"%>
<%@page import="kr.co.mlec.board.vo.BoardVO"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<style>
table {
	border-collapse: collapse;
}
th {
	background-color: ivory;
}
td {
	text-align: center;
}
</style>
</head>
<body>
	<%-- <%= ((List<BoardVO>)request.getAttribute("list")).get(0).getTitle() %> --%>
	
	<!-- EL : Expression Language -->
	<%-- ${ list[0].title } : ${ list[0].writer }<br> --%>
	
	<!-- JSTL : JSP Standard Tag Library -->
	<%-- 
	<c:forEach items="${ list }" var="board">
		${ board.title } : ${ board.writer }<br>
	</c:forEach>
	--%>
	
	<div align="center">
		<h2>전체 게시글 조회😎</h2>
		
		<table border="1" style="width: 80%;">
			<tr>
				<th width="7%">번호</th>
				<th>제목</th>
				<th width="15%">작성자</th>
				<th width="17%">등록일</th>
			</tr>
			<c:forEach items="${ list }" var="board">
				<tr>
					<td>${ board.no }</td>
					<td>${ board.title }</td>
					<td>${ board.writer }</td>
					<td>${ board.regDate }</td>
				</tr>
			</c:forEach>
			
		</table>
	</div>
</body>
</html>