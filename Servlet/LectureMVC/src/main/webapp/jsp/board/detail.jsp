<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="kr.co.mlec.board.vo.BoardVO" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<script>

	function goList() {
		location.href = "/LectureMVC/board/list.do";
	}

	function doDelete() {
		if (!confirm("삭제하시겠습니까?")) {
			return;
		} else {
			location.href = "/LectureMVC/board/delete.do?no=${ board.no }";
		}
	}
	
	function doUpdate() {
		location.href = "/LectureMVC/board/updateForm.do?no=${ board.no }";
	}
	
</script>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</head>
<body>
	<div align="center">
		<h2>글 상세 페이지</h2>
		<br>
		<table border="1" style="width:80%;" class="table table-dark table-sm">
			<tr>
				<th width="25%">번호</th>
				<td>${ board.no }</td>
			</tr>
			<tr>
				<th width="25%">제목</th>
				<td>${ board.title }</td>
			</tr>
			<tr>
				<th width="25%">작성자</th>
				<td>${ board.writer }</td>
			</tr>
			<tr>
				<th width="25%">내용</th>
				<td>${ board.content }</td>
			</tr>
			<tr>
				<th width="25%">조회수</th>
				<td>${ board.viewCnt }</td>
			</tr>
			<tr>
				<th width="25%">등록일</th>
				<td>${ board.regDate }</td>
			</tr>
		</table>
		<br><br>
		<button onclick="goList()" class="btn btn-outline-dark">목록</button>
		<button onclick="doUpdate()" class="btn btn-outline-warning">수정</button>
		<button onclick="doDelete()" class="btn btn-outline-danger">삭제</button>
	</div>
</body>
</html>