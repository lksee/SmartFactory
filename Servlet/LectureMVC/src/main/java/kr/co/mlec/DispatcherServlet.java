package kr.co.mlec;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.controller.BoardDeleteController;
import kr.co.mlec.controller.BoardDetailController;
import kr.co.mlec.controller.BoardListController;
import kr.co.mlec.controller.BoardUpdateController;
import kr.co.mlec.controller.BoardUpdateFormController;
import kr.co.mlec.controller.BoardWriteController;
import kr.co.mlec.controller.BoardWriteFormController;
import kr.co.mlec.controller.Controller;
import kr.co.mlec.controller.LoginController;
import kr.co.mlec.controller.LoginProcessController;
import kr.co.mlec.controller.LogoutController;

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
//		System.out.println("호출 uri : " + uri);

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
			case "/board/write.do":
				control = new BoardWriteController();
				break;
			case "/board/detail.do":
				control = new BoardDetailController();
				break;
			case "/board/delete.do":
				control = new BoardDeleteController();
				break;
			case "/board/updateForm.do":
				control = new BoardUpdateFormController();
				break;
			case "/board/update.do":
				control = new BoardUpdateController();
				break;
			case "/login.do":
				control = new LoginController();
				break;
			case "/loginProcess.do":
				control = new LoginProcessController();
				break;
			case "/logout.do":
				control = new LogoutController();
				break;
			}

			// forward to JSP pages.
			if (control != null) {
				callPage = control.handleRequest(request, response);

				if (callPage.startsWith("redirect:")) {
					callPage = callPage.substring("redirect:".length());
					response.sendRedirect(context + callPage);
				} else {
					RequestDispatcher dispatcher = request.getRequestDispatcher(callPage);
					dispatcher.forward(request, response);
				}
			}

		} catch (Exception e) {
			e.printStackTrace();
		}

	}

}
