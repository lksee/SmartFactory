package kr.co.mlec.method;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
public class MethodController {

	public MethodController () {
		System.out.println("MethodController 생성!");
	}
	
	// 1. GET/POST 구분 없이 실행하려면 그냥 URL만 작성
	// 2. GET으로만 동작하는 메서드를 맵핑하려면 @RequestMapping(value="/method/method.do", method=RequestMethod.GET), @GetMapping("/method/method.do")
	// 3. POST로만 동작하는 메서드를 맵핑하려면 @RequestMapping(value="/method/method.do", method=RequestMethod.POST), @PostMapping("method/method.do")
	// @RequestMapping(value="/method/method.do", method=RequestMethod.GET)
	@GetMapping("/method/method.do")
	public String callGet() {
		return "method/methodForm";
	}
	
	// @RequestMapping(value="/method/method.do", method=RequestMethod.POST)
	@PostMapping("/method/method.do")
	public String callPost() {
		return "method/methodProcess";
	}
}
