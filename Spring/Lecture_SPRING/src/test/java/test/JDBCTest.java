package test;

import static org.junit.Assert.assertNotNull;

import javax.sql.DataSource;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:config/spring/spring-mvc.xml"})
public class JDBCTest {
	// spring-mvc.xml에 작성한 bean에 해당하는 객체가 잘 생성됐는지 확인하기 위한 Test
	
	// 기존에 생성한 객체를 가져온다.
	@Autowired
	private DataSource ds;
	
	@Test
	public void ds테스트() throws Exception {
		// 해당 객체가 null인지 확인한다.
		assertNotNull(ds);
	}

}
