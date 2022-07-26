package kr.co.mlec.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.board.dao.BoardDAO;
import kr.co.mlec.board.vo.BoardVO;

public class BoardUpdateController implements Controller {

	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		request.setCharacterEncoding("UTF-8");
		BoardDAO dao = new BoardDAO();
		
		int no = Integer.parseInt(request.getParameter("no"));
		String title = request.getParameter("title");
		String writer = request.getParameter("writer");
		String content = request.getParameter("content");
		BoardVO board = new BoardVO(no, title, writer, content); 
		
		dao.updateByNo(board);

		//return "/jsp/board/update.jsp?no=" + no;
		request.setAttribute("no", no);
		return "/jsp/board/update.jsp";
	}

}
