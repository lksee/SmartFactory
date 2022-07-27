package kr.co.mlec.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import kr.co.mlec.member.dao.MemberDAO;
import kr.co.mlec.member.vo.MemberVO;

public class LoginProcessController implements Controller {

	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		/*
		 * 작업 순서
		 * 1. 파라미터로 날아온 ID, Password 추출
		 * 2. t_member 테이블에 userId, userPw에 적합한 회원 존재여부 판단(MemberDAO)
		 * 3. 화면에 결과메시지 출력 
		 */
		
		request.setCharacterEncoding("UTF-8");
		
		String userId = request.getParameter("userId");
		String userPw = request.getParameter("userPw");
		
		MemberVO loginVO = new MemberVO();
		loginVO.setUserId(userId);
		loginVO.setUserPw(userPw);
		
		MemberDAO dao = new MemberDAO();
		MemberVO member = dao.login(loginVO);
		
		String msg = "";
		String url = "";
		if (member != null) {
			// 로그인 성공
			msg = "로그인에 성공하였습니다.";
			url = "/LectureMVC";
			
			// member 객체 세션 등록
			HttpSession session = request.getSession();
			session.setAttribute("userVO", member);
		} else {
			// 로그인 실패
			msg = "아이디 또는 패스워드를 잘못 입력했습니다.";
			url = "/LectureMVC/login.do";
		}
		request.setAttribute("msg", msg);
		request.setAttribute("url", url);
		return "/jsp/login/loginProcess.jsp";
	}

}
