<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<!-- Fonts -->
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Black+Han+Sans&family=Nanum+Gothic:wght@400;700;800&family=Nanum+Myeongjo:wght@400;700;800&family=Nanum+Pen+Script&family=Noto+Sans+KR:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">


<!-- editor1 Start -->
<script>
	function htmledit (execute, values) {
		if (values == null) dhtmlframe.document.execCommand(execute);
		else dhtmlframe.document.execCommand(execute, "", values);
	}
	
	function datasubmit() {
		if (dhtmlframe.document.body.innerHTML == '') {
			alert('값을 입력하세요!');
			dhtmlframe.focus();
			return false;
		}
		form1.content.value = dhtmlframe.document.body.innerHTML;
		return true;
	}
</script>
<!-- editor1 End -->

<!-- editor2 Start -->
<style>
	div#editor {
    	padding: 16px 24px;
        border: 1px solid #D6D6D6;
        border-radius: 4px;
    }
    #img-selector {
        display: none;
    }
    #editor img {
    	max-width: 100%;
    }
    button.active {
        background-color: purple;
        color: #FFF;
    }
</style>
<!-- editor2 End -->
</head>
<body>
	<!-- editor1 Start -->
	<a href="javascript:htmledit('bold');">볼드</a>
	<a href="javascript:htmledit('italic');">이탤릭</a>
	<a href="javascript:htmledit('underline');">언더라인</a>
	<a href="javascript:htmledit('cut');">자르기</a>
	<a href="javascript:htmledit('copy');">복사</a>
	<a href="javascript:htmledit('paste');">붙여넣기</a>
	<a href="javascript:htmledit('justifyleft');">좌측 정렬</a>
	<a href="javascript:htmledit('justifycenter');">중심 정렬</a>
	<a href="javascript:htmledit('justifyright');">우측 정렬</a>
	<a href="javascript:htmledit('insertorderedlist');">숫자 목록</a>
	<a href="javascript:htmledit('insertunorderedlist');">점 목록</a>
	<a href="javascript:htmledit('outdent');">들여쓰기 줄이기</a>
	<a href="javascript:htmledit('indent');">들여쓰기 늘이기</a>
	<a href="javascript:htmledit('createlink');">링크</a>
	<a href="javascript:htmledit('fontname', '궁서체');">궁서체 글꼴</a>
	<a href="javascript:htmledit('fontsize', '10em');">글사이즈 10em</a>
	<form name="form1" onsubmit="return datasubmit()" action="" method="post">
		<P><TEXTAREA NAME="content" ROWS="3" style="display:none;"></TEXTAREA></P>
		<iframe name="dhtmlframe" width="700" height="400"></iframe>
		<input type="submit" value="전송">
	</form>
	<script>
		dhtmlframe.document.designMode = "On"
	</script>
	<!-- editor1 End -->
	
	<!-- editor2 Start-->
	<!-- 출처 : https://dev-bak.tistory.com/16 -->
	<div class="editor-menu">
		<button id="btn-bold">
			<b>B</b>
		</button>
		<button id="btn-italic">
			<i>I</i>
		</button>
		<button id="btn-underline">
			<u>U</u>
		</button>
		<button id="btn-strike">
			<s>S</s>
		</button>
		<button id="btn-ordered-list">OL</button>
		<button id="btn-unordered-list">UL</button>
		<button id="btn-image">IMG</button>
		<input id="img-selector" type="file" accept="image/*"/>
		<select id="select-font-size">
		    <option value="">폰트 사이즈</option>
		    <option value="1">10px</option>
		    <option value="2">13px</option>
		    <option value="3">16px</option>
		    <option value="4">18px</option>
		    <option value="5">24px</option>
		    <option value="6">32px</option>
		    <option value="7">48px</option>
		</select>
		<select id="select-font-name">
			<option value="">폰트</option>
			<option value="Black Han Sans">Black Han Sans</option>
			<option value="Noto Sans KR">Noto Sans</option>
			<option value="Nanum Gothic">Nanum Gothic</option>
			<option value="Nanum Myeongjo">Nanum Myeongjo</option>
			<option value="Nanum Pen Script">Nanum Pen Script</option>
		</select>
		<select id="select-font-color">
			<option value="">폰트 색상</option>
			<option value="#000000">검정</option>
			<option value="#FFFFFF">흰색</option>
			<option value="#CCCCCC">회색</option>
			<option value="#F03E3E">빨강</option>
			<option value="#1971C2">파랑</option>
			<option value="#37B24D">녹색</option>
		</select>
		<select id="select-font-background">
			<option value="rgba(0, 0, 0, 0)">폰트 백그라운드</option>
			<option value="#000000">검정</option>
			<option value="#FFFFFF">흰색</option>
			<option value="#CCCCCC">회색</option>
			<option value="#F03E3E">빨강</option>
			<option value="#1971C2">파랑</option>
			<option value="#37B24D">녹색</option>
		</select>
	</div>
	<div id="editor" contenteditable="true"></div>
	
	
<script>
	const editor = document.getElementById('editor');
	const btnBold = document.getElementById('btn-bold');
	const btnItalic = document.getElementById('btn-italic');
	const btnUnderline = document.getElementById('btn-underline');
	const btnStrike = document.getElementById('btn-strike');
	const btnOrderedList = document.getElementById('btn-ordered-list');
	const btnUnorderedList = document.getElementById('btn-unordered-list');
	const btnImage = document.getElementById('btn-image');
	const imageSelector = document.getElementById('img-selector');
	const selectFontColor = document.getElementById('select-font-color');
	const selectFontBackground = document.getElementById('select-font-background');
	const fontSizeSelector = document.getElementById('select-font-size');
	const fontNameSelector = document.getElementById('select-font-name');
	const fontSizeList = [10, 13, 16, 18, 24, 32, 48];

	btnBold.addEventListener('click', function() {
		setStyle('bold');
	});

	btnItalic.addEventListener('click', function() {
		setStyle('italic');
	});

	btnUnderline.addEventListener('click', function() {
		setStyle('underline');
	});

	btnStrike.addEventListener('click', function() {
		setStyle('strikeThrough')
	});

	btnOrderedList.addEventListener('click', function() {
		setStyle('insertOrderedList');
	});

	btnUnorderedList.addEventListener('click', function() {
		setStyle('insertUnorderedList');
	});

	function setStyle(style) {
        document.execCommand(style);
        focusEditor();
        checkStyle();
    }

	// 버튼 클릭 시 에디터가 포커스를 잃기 때문에 다시 에디터에 포커스를 해줌
	function focusEditor() {
		editor.focus({
			preventScroll : true
		});
	}
	
	// img add process
    btnImage.addEventListener('click', function () {
        imageSelector.click();
    });

    imageSelector.addEventListener('change', function (e) {
        const files = e.target.files;
        if (files) {
        	console.log('imgFile1');
            insertImageDate(files[0]);
        }
    });
    
    function insertImageDate(file) {
        const reader = new FileReader();
        reader.addEventListener('load', function (e) {
            focusEditor();
            document.execCommand('insertImage', false, reader.result);
            // document.execCommand('insertHTML', false, reader.result);
        });
        reader.readAsDataURL(file);
    }
    
    editor.addEventListener('keydown', function () {
        checkStyle();
    });

    editor.addEventListener('mousedown', function () {
        checkStyle();
    });
    
    // Button control
    function checkStyle() {
        if (isStyle('bold')) {
            btnBold.classList.add('active');
        } else {
            btnBold.classList.remove('active');
        }
        if (isStyle('italic')) {
            btnItalic.classList.add('active');
        } else {
            btnItalic.classList.remove('active');
        }
        if (isStyle('underline')) {
            btnUnderline.classList.add('active');
        } else {
            btnUnderline.classList.remove('active');
        }
        if (isStyle('strikeThrough')) {
            btnStrike.classList.add('active');
        } else {
            btnStrike.classList.remove('active');
        }
        if (isStyle('insertOrderedList')) {
            btnOrderedList.classList.add('active');
        } else {
            btnOrderedList.classList.remove('active');
        }
        if (isStyle('insertUnorderedList')) {
            btnUnorderedList.classList.add('active');
        } else {
            btnUnorderedList.classList.remove('active');
        }
        reportFont();
    }

    function isStyle(style) {
        return document.queryCommandState(style);
    }
    
    // Fonts control

	// 폰트 사이즈에 따른 값을 찾기 위해서 넣은 배열
	
	fontSizeSelector.addEventListener('change', function () {
		changeFontSize(this.value);
	});
	fontNameSelector.addEventListener('change', function () {
		changeFontName(this.value);
	});

	function changeFontName(name) {
		document.execCommand('fontName', false, name);
		focusEditor();
	}

	function changeFontSize(size) {
		document.execCommand('fontSize', false, size);
		focusEditor();
	}

	  // 폰트 정보 가져오는 코드 참고 : https://stackoverflow.com/questions/8770008/contenteditable-get-current-font-color-size
	function getComputedStyleProperty(el, propName) {
		if (window.getComputedStyle) {
			return window.getComputedStyle(el, null)[propName];
		} else if (el.currentStyle) {
			return el.currentStyle[propName];
		}
	}

	function reportFont() {
		let containerEl, sel;
		if (window.getSelection) {
			sel = window.getSelection();
			if (sel.rangeCount) {
				containerEl = sel.getRangeAt(0).commonAncestorContainer;
				if (containerEl.nodeType === 3) {
					containerEl = containerEl.parentNode;
				}
			}
		} else if ((sel = document.selection) && sel.type !== 'Control') {
			containerEl = sel.createRange().parentElement();
		}

		if (containerEl) {
			const fontSize = getComputedStyleProperty(containerEl, 'fontSize');
			const fontName = getComputedStyleProperty(containerEl, 'fontFamily');
			const size = parseInt(fontSize.replace('px', ''));
			const fontColor = getComputedStyleProperty(containerEl, 'color');
			const backgroundColor = getComputedStyleProperty(containerEl,
					'backgroundColor');
			fontSizeSelector.value = fontSizeList.indexOf(size) + 1;

			// fontName이 문자열 "폰트명"으로 오기 때문에 "를 제거해주는 코드 추가
			selectFontColor.value = fontName.replaceAll('"', '')
			selectFontBackground.value = rgbToHex(fontColor).toUpperCase();
			// 기본 배경색은 rgba(0, 0, 0, 0)
			if (backgroundColor === 'rgba(0, 0, 0, 0)') {
				selectFontBackground.value = backgroundColor;
			} else {
				selectFontBackground.value = rgbToHex(backgroundColor)
						.toUpperCase();
			}
		}
	}

	selectFontColor.addEventListener('change', function() {
		setFontColor(this.value);
	});

	selectFontBackground.addEventListener('change', function() {
		setFontBackground(this.value);
	});

	function setFontColor(color) {
		document.execCommand('foreColor', false, color);
		focusEditor();
	}

	function setFontBackground(color) {
		document.execCommand('hiliteColor', false, color);
		focusEditor();
	}

	// 폰트 색상 rgb to hex, hex to rgb
	// 참고 : https://stackoverflow.com/questions/5623838/rgb-to-hex-and-hex-to-rgb
	function componentToHex(c) {
		const hex = parseInt(c).toString(16);
		// console.log(hex);
		return hex.length == 1 ? '0' + hex : hex;
	}

	function rgbToHex(color) {
		// rgb(r, g, b)에서 색상값만 뽑아 내기 위해서 rgb() 제거
		const temp = color.replace(/[^0-9,]/g, '');
		// r,g,b만 남은 값을 ,로 [r,g,b] 배열로 변환
		const rgb = temp.split(',');
		return '#' + componentToHex(rgb[0]) + componentToHex(rgb[1])
				+ componentToHex(rgb[2]);
	}
</script>
	<!-- editor2 End -->
</body>
</html>