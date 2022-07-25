package com.youandi;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.youandi.controller.Controller;
import com.youandi.controller.ItemMasterController;

@WebServlet("*.do")
public class DispatcherServlet extends HttpServlet {

	@Override
	protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		System.out.println("service 시작");
		
		Controller controller = null;
		String callPage = "";
		
		String context = request.getContextPath();
		String uri = request.getRequestURI();
		uri = uri.substring(context.length());
		
		try {
			switch(uri) {
			case "/itemmaster/list.do":
				System.out.println("아이템 마스터");
				controller = new ItemMasterController();
				break;
			}
			
			if (controller != null) {
				callPage = controller.handleRequest(request, response);
				RequestDispatcher dispatcher = request.getRequestDispatcher(callPage);
				dispatcher.forward(request, response);
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
	}
	
}
