<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<!-- bootstrap -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</head>
<body>
	<div align="center">
		<h2>새글 등록</h2>
		<br>
		<form action="/LectureMVC/board/write.do" method="post">
			<table style="width:80%;" border="1" class="table table-dark table-sm">
				<tr>
					<th>제목</th>
					<td><input type="text" size="50" name="title" required></td>
				</tr>
				<tr>
					<th>작성자</th>
					<td><input type="text" size="50" name="writer" value="${ userVO.userId }" readonly></td>
				</tr>
				<tr>
					<th>내용</th>
					<td>
						<textarea name="content" id="content" rows="10" cols="100" style="width:70%; height:412px;" required></textarea>
					</td>
				</tr>
			</table>
			<br><br>
			<input type="submit" value="등록" class="btn btn-outline-dark">
		</form>
	</div>
</body>
</html>