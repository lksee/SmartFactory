package kr.co.mlec.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.board.dao.BoardDAO;
import kr.co.mlec.board.vo.BoardVO;

// client --> DispatcherServlet --> Controller --> DB --> Controller --> DispatcherServlet -forward-> JSP --> client
public class BoardListController implements Controller {
	
	// JSP 경로 반환
	// forward, include, *.xml의 root는 context path 뒤부터이다.
	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		
		BoardDAO dao = new BoardDAO();
		List<BoardVO> list = dao.selectAll();
		
		// 공유영역(request) 등록
		request.setAttribute("list", list);
		
		return "/jsp/board/list.jsp";
	}
}
