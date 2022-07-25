<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" errorPage="addrbook_error.jsp" %>
<%@ page import="com.jsp.AddrBook, java.util.*" %>
<!DOCTYPE html>
<jsp:useBean id="datas" class="java.util.ArrayList" scope="request" />

<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<link rel="stylesheet" href="addrbook.css" type="text/css" media="screen"/>

<script type="text/javascript">
	function check (ab_id) {
		pwd = prompt('수정/삭제 하려면 비밀번호를 넣으세요.');
		document.location.href = "addrbook_control.jsp?action=edit&ab_id=" + ab_id + "&upasswd=" + pwd;
	}
</script>
</head>
<body>
<div align=center>
	<h2>주소록 목록 화면</h2>
	<hr>
	<form>
		<input type="hidden" name="action" value="list">
		<a href="addrbook_form.jsp">주소록 등록</a><p>
		<table border=1>
			<tr>
				<th>번호</th>	<th>이름</th>	<th>전화번호</th>	<th>이메일</th>	<th>생일</th>	<th>회사</th>	<th>메모</th>
			</tr>
			<% for (AddrBook ab : (ArrayList<AddrBook>) datas) { %>
			<tr>
				<td><a href="javascript:check(<%=ab.getAb_id() %>)"><%=ab.getAb_id() %></a></td>
				<td><%=ab.getAb_name() %></td>
				<td><%=ab.getAb_tel() %></td>
				<td><%=ab.getAb_email() %></td>
				<td><%=ab.getAb_birth() %></td>
				<td><%=ab.getAb_comdept() %></td>
				<td><%=ab.getAb_memo() %></td>
			</tr>
			<% }%>
			<!-- 
			<tr>
				<td><a href="addrbook_edit_form.jsp">1</a></td>
				<td>이슬비</td>	<td>010-5555-7777</td>	<td>lee@gmail.com</td>	<td>1997-9-8</td>	<td>삼성전자</td>	<td>커리우먼</td>			
			</tr>		
		
			<tr>
				<td><a href="addrbook_edit_form.jsp">2</a></td>
				<td>박남길</td>	<td>010-3333-7777</td>	<td>park@gmail.com</td>	<td>2000-1-1</td>	<td>Lg전자</td>	<td>전업주부</td>			
			</tr>
			 -->
		</table>	
	</form>




</div>
</body>
</html>