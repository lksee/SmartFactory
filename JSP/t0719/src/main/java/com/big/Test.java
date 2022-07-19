package com.big;

public class Test {

	private int num1;
	
	
	public int getNum1() {
		return num1;
	}


	public void setNum1(int num1) {
		this.num1 = num1;
	}


	public static void main(String[] args) {
		Test obj = new Test();
		obj.setNum1(7);
		
		System.out.println(obj.getNum1());
	}

}
