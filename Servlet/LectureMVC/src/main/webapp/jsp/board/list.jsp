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
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
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
		<h2><mark>전체 게시글 조회</mark>😎</h2>
		<br>
		<table border="1" style="width: 80%;" class="table table-dark table-sm">
			<thead>
				<tr>
					<th width="7%">번호</th>
					<th>제목</th>
					<th width="15%">작성자</th>
					<th width="17%">등록일</th>
				</tr>
			</thead>
			<c:forEach items="${ list }" var="board">
				<tr>
					<td>${ board.no }</td>
					<td><a href="/LectureMVC/board/detail.do?no=${ board.no }">${ board.title }</a></td>
					<td>${ board.writer }</td>
					<td>${ board.regDate }</td>
				</tr>
			</c:forEach>
		</table>
		<br><br>
		<button onclick="location.href = '/LectureMVC/board/writeForm.do'" class="btn btn-outline-dark">새글 등록</button>
		<%-- <a href="/LectureMVC/board/writeForm.do">새글 등록</a> --%>
	</div>
</body>
</html>