package kr.co.mlec;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.controller.BoardListController;
import kr.co.mlec.controller.BoardWriteFormController;
import kr.co.mlec.controller.Controller;

@WebServlet("*.do")
public class DispatcherServlet extends HttpServlet {

	@Override
	protected void service(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		System.out.println("service()실행★");

		String context = request.getContextPath();
//		System.out.println("context : " + context);
		// context : /LectureMVC

		String uri = request.getRequestURI();
		uri = uri.substring(context.length());
		System.out.println("호출 uri : " + uri);

		// forward할 JSP 경로를 담을 변수
		Controller control = null;
		String callPage = "";

		try {
			switch (uri) {
			case "/board/list.do":
//				System.out.println("전체 게시글 조회 서비스...");
				control = new BoardListController();
				break;
			case "/board/writeForm.do":
//				System.out.println("새글 등록 서비스...");
				control = new BoardWriteFormController();
				break;
			}

			// forward to JSP pages.
			if (control != null) {
				callPage = control.handleRequest(request, response);

				RequestDispatcher dispatcher = request.getRequestDispatcher(callPage);
				dispatcher.forward(request, response);
			}

		} catch (Exception e) {
			e.printStackTrace();
		}

	}

}
