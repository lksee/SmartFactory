<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<style>
	.error {
		color: red;
	}
</style>
</head>
<body>
	<header>
		<%-- <%@include file="/WEB-INF/jsp/include/topMenu.jsp" %> --%>
		<jsp:include page="/WEB-INF/jsp/include/topMenu.jsp" />
	</header>
	<section>
		<div align="center">
			<h2>새글 등록</h2>
			<!-- modelAttribute는 Controller에서 만든 공유 영역의 여러 객체 중 특정 객체명을 지정해서 선택하기 위한 옵션이다. -->
			<form:form method="post" modelAttribute="boardVO">
				<table style="width: 100%;">
					<tr>
						<th width="25%">제목</th>
						<td>
							<form:input path="title" />
							<form:errors path="title" class="error" />
						</td>
					</tr>
					<tr>
						<th width="25%">작성자</th>
						<td>
							<form:input path="writer" />
							<form:errors path="writer" class="error" />
						</td>
					</tr>
					<tr>
						<th width="25%">내용</th>
						<td>
							<form:textarea path="content" rows="7" cols="50" />
							<form:errors path="content" class="error" />
						</td>
					</tr>
				</table>
				<input type="submit" value="등록">
			</form:form>
		</div>
	
	</section>
	<footer>
		<%@include file="/WEB-INF/jsp/include/footer.jsp"%>
	</footer>
</body>
</html>