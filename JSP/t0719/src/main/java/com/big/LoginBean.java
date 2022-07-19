package com.big;

public class LoginBean {
	private String id;
	private String pw;
	
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getPw() {
		return pw;
	}
	public void setPw(String pw) {
		this.pw = pw;
	}
	
	public boolean checkUser() { // 로그인이 맞는지 체크 여부 확인
		if (id.equals("admin") && pw.equals("1234")) {
			return true;
		} else {
			return false;
		}
	}
	
}
