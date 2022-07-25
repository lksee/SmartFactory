package com.youandi.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.youandi.dao.ItemMasterDAO;
import com.youandi.vo.ItemMasterVO;

public class ItemMasterController implements Controller {
	@Override
	public String handleRequest(HttpServletRequest request, HttpServletResponse response) throws Exception {
		
		ItemMasterDAO dao = new ItemMasterDAO();
		List<ItemMasterVO> list = dao.selectAll();
		
		request.setAttribute("list", list);
		
		return "/jsp/itemmaster/list.jsp";
	}
}

