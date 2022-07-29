package kr.co.mlec.member.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import kr.co.mlec.member.service.MemberService;
import kr.co.mlec.member.vo.MemberVO;

@Controller
public class MemberController {

	@Autowired
	private MemberService service;
	
	@GetMapping("/login")
	public String login() {
		return "login/login";
	}
	
	@PostMapping("/login")
	public String loginProcess(MemberVO loginVO, HttpSession session) {
		
		MemberVO member = service.login(loginVO);
		
		if (member == null) {
			System.out.println("fail");
			return "login/login";
		}
		System.out.println("success");
		session.setAttribute("loginVO", member);
		
		return "redirect:/";
	}
	
	@GetMapping("/logout")
	public String logout(HttpSession session) {
		// 모든 세션 정보를 지운다.
		session.invalidate();
		return "redirect:/";
	}
	
}
