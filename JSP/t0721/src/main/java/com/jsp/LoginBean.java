package com.jsp;

public class LoginBean {

	//멤버 변수
	private String userid;
	private String passwd;
	
	final String id = "admin";
	final String pw = "1234";
	
	public String getUserid() {
		return userid;
	}
	public void setUserid(String userid) {
		this.userid = userid;
	}
	public String getPasswd() {
		return passwd;
	}
	public void setPasswd(String passwd) {
		this.passwd = passwd;
	}
	
	// 사용자 정의 함수
	public boolean checkUser() {
		if (userid.equals(id) && passwd.equals(pw)) {
			return true;
		} else return false;
	}
}
