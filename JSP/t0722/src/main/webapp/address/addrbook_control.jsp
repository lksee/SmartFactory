<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" errorPage="addrbook_error.jsp" %>
<%@ page import="java.util.*, com.jsp.AddrBook" %>
<% request.setCharacterEncoding("UTF-8"); %>
<jsp:useBean id="gb" scope="page" class="com.jsp.AddrBean" />
<jsp:useBean id="addrbook" class="com.jsp.AddrBook" />
<jsp:setProperty name="addrbook" property="*" />

<%
	String action = request.getParameter("action");
	if (action.equals("insert")) { // 삽입
		if (gb.insertDB(addrbook)) {
			response.sendRedirect("addrbook_control.jsp?action=list");
		} else {
			throw new Exception("DB입력 오류");
		}
	} else if (action.equals("list")) { // 조회
		ArrayList<AddrBook> datas = gb.getDBList();
		request.setAttribute("datas", datas);
		pageContext.forward("addrbook_list.jsp");
	} else if (action.equals("edit")) { // 수정
		AddrBook abook = gb.getDB(addrbook.getAb_id());
		if (!request.getParameter("upasswd").equals("1234")) {
			out.print("<script>alert('비밀번호가 틀려요. 다시 입력하세요.');history.go(-1);</script>");
		} else {
			request.setAttribute("ab", abook);
			pageContext.forward("addrbook_edit_form.jsp");
		}
	} else if (action.equals("update")) { // 수정 적용
		if (gb.updateDB(addrbook)) {
			response.sendRedirect("addrbook_control.jsp?action=list");
		} else {
			throw new Exception("DB 갱신 오류");
		}
	} else if (action.equals("delete")) { // 삭제
		if (gb.deleteDB(addrbook.getAb_id())) {
			response.sendRedirect("addrbook_control.jsp?action=list");
		} else {
			out.print("<script>alert('action 파라미터 확인하세요.');</script>");
		}
	} else {
		
	}
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

</body>
</html>