<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<script>
alert('수정했습니다.');
location.href="/LectureMVC/board/detail.do?no=${ no }";
</script>
</body>
</html>