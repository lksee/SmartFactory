package kr.co.mlec.board.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import kr.co.mlec.board.service.BoardService;
import kr.co.mlec.board.vo.BoardVO;

@Controller
public class BoardController {

	@Autowired
	private BoardService service;
	
	@GetMapping("/board")
	public ModelAndView selectAll() {
		List<BoardVO> boardList = service.selectAllBoard();
		
		ModelAndView mav = new ModelAndView("board/list");
		mav.addObject("list", boardList);
		
		return mav;
	}
	
	// path로 넘어오는 값을 파라미터로 지정해주는 @PathVariable을 활용한다.
	@GetMapping("/board/{no}")
	public String detail(@PathVariable("no") int boardNo, HttpServletRequest request) {
		
		BoardVO board = service.selectOneboard(boardNo);
		request.setAttribute("board", board);
		
		return "board/detail";
	}
	
	@GetMapping("/board/write")
	public String writeFrom(Model model) {
		
		BoardVO board = new BoardVO();
		
		// JSP와 Java가 공유할 영역에 값을 저장한다.
		model.addAttribute("boardVO", board);
		
		return "board/write";
	}
	
	@PostMapping("/board/write")
	public String write(@Valid BoardVO board, BindingResult result) {
		
		if (result.hasErrors()) {
			System.out.println("result.hasError(): " + result.hasErrors());
			return "board/write";
		}
		
		service.insertBoard(board);
		
		return "redirect:/board";
	}
	
	@ResponseBody
	@DeleteMapping("/board/{no}")
	public String delete(@PathVariable("no") int boardNo) {
		service.deleteBoard(boardNo);
		return String.valueOf(boardNo);
	}
}
