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
		
		ModelAndView mav = new ModelAndView("hello/hello");
		mav.addObject("msg", msg);
		
		return mav;
	}
}
