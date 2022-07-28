package kr.co.mlec.editor;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class EditorController {

	@RequestMapping("/editor/editor.do")
	public ModelAndView editor() {
		
		ModelAndView mav = new ModelAndView("/editor/editor");
		return mav;
	}
}
