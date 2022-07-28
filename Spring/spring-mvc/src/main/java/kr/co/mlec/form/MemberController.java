package kr.co.mlec.form;

import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class MemberController {
	
	@RequestMapping("/form/joinForm.do")
	public String joinForm() {
		return "form/joinForm";
	}
	
	// @RequestMapping("/form/join.do")
	public String join(HttpServletRequest request) {
		// HttpServletRequest request 대신 직접 Parameter로 접근할 수 있다.
		// 이렇게 -> (@RequestParam("id") String id, @RequestParam("password") String password, @RequestParam("name") String name)
		
		String id 		= request.getParameter("id");
		String password = request.getParameter("password");
		String name 	= request.getParameter("name");

		MemberVO member = new MemberVO(id, password, name);
		request.setAttribute("member", member);
		
		return "form/memberInfo";
	}
	
	// @RequestMapping("/form/join.do")
	public String join(@RequestParam("id") String id, 
			           @RequestParam("password") String password, 
			           @RequestParam("name") String name,
			           HttpServletRequest request) {
		MemberVO member = new MemberVO(id, password, name);
		request.setAttribute("member", member);
		
		return "form/memberInfo";
	}
	
	@RequestMapping("/form/join.do")
	public String join(@ModelAttribute("member") MemberVO member) {
		// setter 메서드를 활용해서 VO 객체에 값을 담아서 생성해서 파라미터로 가져오고,
		// 공유영역에 VO 객체를 클래스명에서 제일 앞글자만 소문자로 바꾼 명칭으로 등록해준다.
		// 만약 원하는 객체명을 쓰고 싶으면 @ModelAttribute("원하는 객체명")을 사용한다.
//		return "form/memberInfo";
		
		return "redirect:/hello/hello.do";
	}
	

	
}
