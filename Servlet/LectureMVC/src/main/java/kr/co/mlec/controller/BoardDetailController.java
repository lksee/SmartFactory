package kr.co.mlec.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.board.dao.BoardDAO;
import kr.co.mlec.board.vo.BoardVO;

public class BoardDetailController implements Controller {

	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		// http://localhost:8080/LectureMVC/board/detail.do?no=3 요청 시
		/*
		 *  1. 조회할 게시물 번호 추출(no)
		 *  2. t_board 테이블에서 추출된 번호의 해당 게시물 조회(BoardDAO)
		 *  3. 공유 영역에 게시물 등록
		 *  4. 조회된 게시물 detail.jsp 출력
		 */
		int boardNo = Integer.parseInt(request.getParameter("no"));
		
		BoardDAO dao = new BoardDAO();
		// 조회수 증가
		dao.updateViewCnt(boardNo);
		
		// 게시글 조회
		BoardVO board = dao.selectByNo(boardNo);
		
		request.setAttribute("board", board);
		
		return "/jsp/board/detail.jsp";
	}

}
