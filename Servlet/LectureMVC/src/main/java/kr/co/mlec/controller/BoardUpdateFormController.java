package kr.co.mlec.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.board.dao.BoardDAO;
import kr.co.mlec.board.vo.BoardVO;

public class BoardUpdateFormController implements Controller {

	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		request.setCharacterEncoding("UTF-8");
		int boardNo = Integer.parseInt(request.getParameter("no"));
		BoardDAO dao = new BoardDAO();
		// 게시글 조회
		BoardVO board = dao.selectByNo(boardNo);
		
		request.setAttribute("board", board);
		
		return "/jsp/board/updateForm.jsp";
	}

}
