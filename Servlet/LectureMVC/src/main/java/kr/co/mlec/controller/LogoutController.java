package kr.co.mlec.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class LogoutController implements Controller {

	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		
		// 세션 영역에 등록된 userVO 객체를 삭제
		HttpSession session = request.getSession();
		session.removeAttribute("userVO");
		
		// redirect: 키워드를 활용하면 forward하지 않고 sendRedirect 시킨다.
		return "redirect:/";
	}

}
