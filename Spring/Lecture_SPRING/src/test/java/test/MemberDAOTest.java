package test;

import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertNull;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import kr.co.mlec.member.dao.MemberDAO;
import kr.co.mlec.member.vo.MemberVO;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:config/spring/spring-mvc.xml"})
public class MemberDAOTest {
	@Autowired
	private MemberDAO memberDao; 
	
	@Test
	public void 로그인테스트() throws Exception {
		MemberVO loginVO = new MemberVO();
		loginVO.setUserId("user");
		loginVO.setUserPw("user");
		MemberVO member = memberDao.login(loginVO);
		assertNotNull(member);
	}

}
