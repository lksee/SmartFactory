package kr.co.mlec.hello;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class HelloController {

	public HelloController () {
		System.out.println("놀랍게도 객체가 생성된다.");
	}
	
	@RequestMapping("/hello/hello.do")
	public ModelAndView hello() {
		// "/WEB-INF/jsp/hello/hello.jsp"
		String msg = "Hellow SPRING!!";
		
		// Model : 공유 영역에 값을 저장, View : forward/sendRedirect할 view(여기선 jsp파일)를 지정
//		ModelAndView mav = new ModelAndView("hello/hello");
		
		// 기본 생성자로 객체를 만들고 ViewName을 별개로 설정 가능
		ModelAndView mav = new ModelAndView();
		mav.addObject("msg", msg);
		mav.setViewName("hello/hello");

		// request 객체에 값을 저장한다.
		mav.addObject("msg", msg);
		
		return mav;
	}
}
