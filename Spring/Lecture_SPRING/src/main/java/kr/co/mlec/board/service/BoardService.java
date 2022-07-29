package kr.co.mlec.board.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import kr.co.mlec.board.dao.BoardDAO;
import kr.co.mlec.board.vo.BoardVO;

@Service
public class BoardService {

	@Autowired
	private BoardDAO boardDao;
	
	public List<BoardVO> selectAllBoard() {
		List<BoardVO> boardList = boardDao.selectAll();
		return boardList;
	}
	
	public BoardVO selectOneboard(int boardNo) {
		return boardDao.selectByNo(boardNo);
	}
	
	public void insertBoard(BoardVO board) {
		boardDao.insert(board);
	}
	
	public void deleteBoard(int boardNo) {
		boardDao.deleteByNo(boardNo);
	}
}
