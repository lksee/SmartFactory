<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Schedule Table</title>
</head>
<body>
	<table border="1" width=800 height=800>
	<caption>시간표</caption>
		<tr bgcolor="pink" height="100">
			<th><i>Time</i></th>
			<th style="color:red;">SUN</th>
			<th>MON</th>
			<th>TUE</th>
			<th>WED</th>
			<th>THU</th>
			<th>FRI</th>
			<th style="color:blue;">SAT</th>
		</tr>
		<tr>
			<td>09:30~12:30</td>
			<td rowspan=5 style="color:red;">휴식</td>
			<td colspan=5>스마트팩토리 오전 수업</td>
			<td rowspan=5 style="color:blue;">휴식</td>
		</tr>
		<tr>
			<td>12:30~13:30</td>
			<td colspan=5>점심 시간</td>
		</tr>
		<tr>
			<td>13:30~18:30</td>
			<td colspan=5>스마트팩토리 오후 수업</td>
		</tr>
		<tr>
			<td>18:30~19:00</td>
			<td colspan=5>저녁 식사</td>
		</tr>
		<tr>
			<td>19:00~21:00</td>
			<td colspan=5>공부</td>
		</tr>
	</table>
</body>
</html>