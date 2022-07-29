package kr.co.mlec.member.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import kr.co.mlec.member.dao.MemberDAO;
import kr.co.mlec.member.vo.MemberVO;

@Service
public class MemberService {
	
	@Autowired
	public MemberDAO memberDao;
	
	public MemberVO login(MemberVO loginVO) {
		
		MemberVO member = memberDao.login(loginVO);
		
		return member;
	}
	
}
