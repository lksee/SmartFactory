package kr.co.mlec.member.vo;

public class MemberVO {

	private String userId;
	private String userPw;
	private String userName;
	private String userType;	// "S" : 관리자, "U" : 일반사용자
	public String getUserId() {
		return userId;
	}
	
	public MemberVO() {
		super();
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}
	public String getUserPw() {
		return userPw;
	}
	public void setUserPw(String userPw) {
		this.userPw = userPw;
	}
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public String getUserType() {
		return userType;
	}
	public void setUserType(String userType) {
		this.userType = userType;
	}
	@Override
	public String toString() {
		return "MemberVO [userId=" + userId + ", userPw=" + userPw + ", userName=" + userName + ", userType=" + userType
				+ "]";
	}

	
	
}
