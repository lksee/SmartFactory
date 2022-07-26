package kr.co.mlec.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.board.dao.BoardDAO;

public class BoardDeleteController implements Controller {

	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		int boardNo = Integer.parseInt(request.getParameter("no"));
		BoardDAO dao = new BoardDAO();
		dao.deleteByNo(boardNo);
		
		return "/jsp/board/delete.jsp";
	}

}
