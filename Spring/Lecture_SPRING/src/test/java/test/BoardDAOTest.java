package test;

import java.util.List;

import org.junit.Ignore;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import kr.co.mlec.board.dao.BoardDAO;
import kr.co.mlec.board.vo.BoardVO;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:config/spring/spring-mvc.xml"})
public class BoardDAOTest {
	
	@Autowired
	private BoardDAO dao;
	
	
	@Ignore // 테스트 했던 건에 대해 @Ignore를 달면 Test 대상에서 무시하고 진행한다는 의미
	@Test
	public void 전체게시글조회테스트() throws Exception {
		List<BoardVO> boardList = dao.selectAll();
		for(BoardVO board : boardList) {
			System.out.println(board);
		}
	}
	
	@Test
	public void 상세게시글조회테스트() throws Exception {
		BoardVO board = dao.selectByNo(1);
		System.out.println(board);
	}
}
