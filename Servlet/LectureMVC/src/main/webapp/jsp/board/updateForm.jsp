<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</head>
<body>
	<div align="center">
		<h2>글 수정</h2>
		<br>
		<form action="/LectureMVC/board/update.do?no=${ board.no }" method="post">
			<table style="width:80%;" border="1" class="table table-dark table-sm">
				<tr>
					<th>제목</th>
					<td><input type="text" size="50" name="title" value="${ board.title }" required></td>
				</tr>
				<tr>
					<th>작성자</th>
					<td><input type="text" size="50" name="writer" value="${ board.writer }" required></td>
				</tr>
				<tr>
					<th>내용</th>
					<td><textarea rows="7" cols="50" name="content" required>${ board.content }</textarea></td>
				</tr>
			</table>
			<br><br>
			<input type="submit" value="수정" class="btn btn-outline-dark">
		</form>
	</div>
</body>
</html>