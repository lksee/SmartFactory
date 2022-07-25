<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<h2>request 내장 객체</h2>
<h3>클라이언트 관련 메서드</h3>
클라이언트 IP 주소 : <%=request.getRemoteAddr() %><br>
클라이언트 이름 : <%=request.getRemoteHost() %><br>
클라이언트 포트 : <%=request.getRemotePort() %><br>
클라이언트 사용자 : <%=request.getRemoteUser() %><br>
<hr>
<h3>전송 데이터 관련 메서드</h3>
요청정보 프로토콜 : <%=request.getProtocol() %><br>
요청정보 전송 방식 : <%=request.getMethod() %><br>
요청정보 컨텐츠 타입 : <%=request.getContentType() %><br>
요청정보 인코딩 : <%=request.getCharacterEncoding() %><br>
요청정보 길이 : <%=request.getContentLength() %><br>
<br>
컨텍스트 경로 : <%=request.getContextPath() %><br>
요청 URI : <%=request.getRequestURI() %><br>
요청 URL : <%=request.getRequestURL() %><br>
요청 서블릿 경로 : <%=request.getServletPath() %><br>
<br>
쿠키 정보 : <%=request.getCookies() %><br>
세션 아이디 : <%=request.getRequestedSessionId() %><br>
세션 정보 : <%=request.getSession() %><br>
<br>
<hr>
<h3>서버 관련 메서드</h3>
서버 IP 주소 : <%=request.getLocalAddr() %><br>
호스트 이름 : <%=request.getLocalName() %><br>
서버 포트 : <%=request.getLocalPort() %><br> 
서버 포트 : <%=request.getServerPort() %><br> 
서버 이름 : <%=request.getServerName() %><br> 
<br>
<hr>
<h3>헤더 관련 메서드</h3>
<%
Enumeration<String> enu = request.getHeaderNames();

while (enu.hasMoreElements()) {

	String head_name = (String)enu.nextElement();
	String head_value = request.getHeader(head_name);
	
	out.print("헤더 이름 : " + head_name + "<br>"
			+ "헤더 값 : " + head_value + "<br>");
}
%>
</body>
</html>