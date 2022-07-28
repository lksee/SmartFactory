package kr.co.mlec.body;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import kr.co.mlec.form.MemberVO;

@Controller
public class ResBodyController {
	public ResBodyController() {
		System.out.println("ResBodyController 생성!");
	}
	
	
	@ResponseBody // 값 자체를 반환한다.
	@RequestMapping("/ajax/resBody.do")
	public String resStringBody() {
		return "OK 오케이!";
	}
	
	@ResponseBody
	@RequestMapping("/ajax/resBody.json")
	public Map<String, String> resJsonBody() {
		Map<String, String> result = new HashMap<String, String>();
		result.put("id", "hong");
		result.put("name", "홍길동");
		result.put("addr", "서울");
		return result;
	}
	
	@ResponseBody
	@RequestMapping("/ajax/resVOBody.json")
	public MemberVO resJsonVOBody() {
		
		MemberVO member = new MemberVO();
		member.setId("Kim");
		member.setPassword("qewrq");
		member.setName("Kardashian");
		
		return member;
	}
	
	@ResponseBody
	@RequestMapping("/ajx/resListVOBody.json")
	public List<MemberVO> resListVOBody() {
		List<MemberVO> memberList = new ArrayList<MemberVO>();
		MemberVO member = new MemberVO();
		member.setId("Kim");
		member.setPassword("qewrq");
		member.setName("Kardashian");

		MemberVO member2 = new MemberVO();
		member2.setId("Ja");
		member2.setPassword("qewrq");
		member2.setName("Varian");
		
		memberList.add(member);
		memberList.add(member2);
		
		return memberList;
	}
}
