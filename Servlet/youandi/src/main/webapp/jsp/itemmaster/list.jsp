<%@page import="java.util.List"%>
<%@page import="com.youandi.vo.ItemMasterVO"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Item Master</title>
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
	<div align="center">
		<h2>Item Master😎</h2>
		
		<table border="1" style="width: 80%;">
			<tr>
				<th width="12%">품번</th>
				<th width="22%">품명</th>
				<th width="4%">타입</th>
				<th width="6%">창고</th>
				<th width="4%">단위</th>
				<th width="4%">단가</th>
				<th width="8%">규격</th>
				<th width="8%">최소 발주수량</th>
				<th width="8%">고정 발주수량</th>
				<th width="8%">최대 발주수량</th>
				<th width="8%">생성일</th>
				<th width="8%">생성자</th>
			</tr>
			<c:forEach items="${ list }" var="item">
			<tr>
				<td>${ item.ITEMCODE }</td>
				<td>${ item.ITEMNAME }</td>
				<td>${ item.ITEMTYPE }</td>
				<td>${ item.WHCODE }</td>
				<td>${ item.BASEUNIT }</td>
				<td>${ item.UNITCOST }</td>
				<td>${ item.ITEMSPEC }</td>
				<td>${ item.MINORDERQTY }</td>
				<td>${ item.ORDERQTY }</td>
				<td>${ item.MAXORDERQTY }</td>
				<td>${ item.MAKEDATE }</td>
				<td>${ item.MAKER }</td>
			</tr>
			</c:forEach>
			
		</table>
	</div>
</body>
</html>