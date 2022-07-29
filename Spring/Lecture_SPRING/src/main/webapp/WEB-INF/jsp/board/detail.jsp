<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<script src="http://code.jquery.com/jquery-3.6.0.min.js"></script>
<script>
	function goList() {
		location.href = "/Lecture-MVC/board/list.do"
	}
	
	function deleteBoard() {
		if(confirm('${ board.no }번 게시물을 삭제하시겠습니까?')) {
			$.ajax({
				url: '${ pageContext.request.contextPath }/board/${ board.no }',
				type : 'delete',
				success : function(deleteNo) {
					alert(deleteNo + '번 게시물 삭제를 완료하였습니다')
					location.href = '${ pageContext.request.contextPath }/board'
				}
			})
		}
	}
</script>
</head>
<body>
	<header>
		<%-- <%@include file="/WEB-INF/jsp/include/topMenu.jsp" %> --%>
		<jsp:include page="/WEB-INF/jsp/include/topMenu.jsp" />
	</header>
	<section>
		<div align="center">
			<h2>상세페이지</h2>
			<table border="1" style="width: 80%">
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
			<br>
			<%-- <button onclick="location.href='/Lecture-MVC/board/list.do'">목록</button>  --%>
			<button onclick="goList()">목록</button>
			<button>수정</button>
			<button onclick="deleteBoard()">삭제</button>
		</div>
	</section>
	<footer>
		<%@include file="/WEB-INF/jsp/include/footer.jsp"%>
	</footer>
</body>
</html>








