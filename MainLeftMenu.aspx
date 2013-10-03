<%@ Page Language="c#" Inherits="EasyExam.MainLeftMenu" CodeFile="MainLeftMenu.aspx.cs" %>
<HTML>
	<HEAD>
		<TITLE>网络考试系统</TITLE>
		<meta http-equiv="Content-Type" content="text/html;charset=gb2312">
		<style type="text/css"> .navPoint {COLOR: white; CURSOR: hand; FONT-FAMILY: Webdings; FONT-SIZE: 9pt}
	.a2{BACKGROUND-COLOR: A4B6D7;}
	.style1 {color: #000000}
	TD { FONT-SIZE: 9pt; COLOR: #333333; LINE-HEIGHT: 150% }
	.sec_menu { BORDER-RIGHT: white 1px solid; BACKGROUND: #d6dff7; OVERFLOW: hidden; BORDER-LEFT: white 1px solid; BORDER-BOTTOM: white 1px solid }
	TH { FONT-SIZE: 9pt; COLOR: #6600cc; LINE-HEIGHT: 150% }
	TD { FONT-SIZE: 9pt; COLOR: #333333; LINE-HEIGHT: 150% }
	.sec_menu { BORDER-RIGHT: white 1px solid; BACKGROUND: #d6dff7; OVERFLOW: hidden; BORDER-LEFT: white 1px solid; BORDER-BOTTOM: white 1px solid }
	.menu_title SPAN { FONT-WEIGHT: bold; LEFT: 10px; COLOR: #215dc6; POSITION: relative; TOP: 2px }
	.menu_title2 SPAN { FONT-WEIGHT: bold; LEFT: 10px; COLOR: #428eff; POSITION: relative; TOP: 2px }
	</style>
		<script language="JavaScript" src="JavaScript/MouseEvent.js"></script>
	</HEAD>
	<body onselectstart="return false" bottomMargin="0" bgColor="#34a9e7" leftMargin="0" topMargin="0"
		rightMargin="0">
		<script language="javascript">
			function switchSysBar()
			{
				if (document.all("frmTitle").style.display=='')
				{
					resizeIcon_Show.style.display = 'none';
					resizeIcon_Hidden.style.display = '';
					document.all("frmTitle").style.display="none"
					top.Bottom.cols='8,*'
				}
				else
				{
					resizeIcon_Show.style.display = '';
					resizeIcon_Hidden.style.display = 'none';
					document.all("frmTitle").style.display=""
					top.Bottom.cols='142,*'
				}
			}
		</script>
		<table height="100%" cellSpacing="0" cellPadding="0" width="142" border="0">
			<tr>
				<td id="frmTitle" vAlign="top" noWrap align="center" width="135">
					<table cellSpacing="0" cellPadding="0" width="135" align="center">
						<tr>
							<td onMouseOver="aa('up')" title="菜单上滚" onMouseOut="StopScroll()" vAlign="bottom" align="center"><font style="CURSOR: hand" face="Webdings" color="#ffffff">5</font></td>
						</tr>
					</table>
					<script language="javascript">
						var he=document.body.clientHeight-40
						document.write("<div id=tt style=height:"+he+";overflow:hidden>")
					</script>
					<table cellSpacing="0" cellPadding="0" width="135" align="center">
						<%=strMainMenu%>
					</table>
					<table cellSpacing="0" cellPadding="0" width="135" align="center">
					</table>
					<script language="javascript">
						document.write("</div>")
					</script>
					<table cellSpacing="0" cellPadding="0" width="135" align="center">
						<tr>
							<td onMouseOver="aa('Down')" title="菜单下滚" onMouseOut="StopScroll()" vAlign="bottom"
								align="center"><font style="CURSOR: hand" face="Webdings" color="#ffffff">6</font></td>
						</tr>
					</table>
					<script language="javascript">
						
						function aa(Dir)
						{tt.doScroll(Dir);Timer=setTimeout('aa("'+Dir+'")',100)}//这里100为滚动速度
						function StopScroll(){if(Timer!=null)clearTimeout(Timer)
						}

						function initIt()
						{
						divColl=document.all.tags("DIV");
						for(i=0; i<divColl.length; i++) {
						whichEl=divColl(i);
						if(whichEl.className=="child")whichEl.style.display="none";}
						}

						function expands(el)
						{
						whichEl1=eval(el+"Child");
						if (whichEl1.style.display=="none"){
						initIt();
						whichEl1.style.display="block";
						}else{whichEl1.style.display="none";}
						}

						var tree= 0;
						function loadThreadFollow()
						{
						if (tree==0){
						document.frames["hiddenframe"].location.replace("LeftTree.asp");
						tree=1
						}
						}

						function showsubmenu(sid)
						{
						whichEl = eval("submenu" + sid);
						imgmenu = eval("imgmenu" + sid);
						if (whichEl.style.display == "none")
						{
						eval("submenu" + sid + ".style.display=\"\";");
						imgmenu.background="images/menuup.gif";
						}
						else
						{
						eval("submenu" + sid + ".style.display=\"none\";");
						imgmenu.background="images/menudown.gif";
						}
						}

						function loadingmenu(id)
						{
						var loadmenu =eval("menu" + id);
						if (loadmenu.innerText=="Loading..."){
						document.frames["hiddenframe"].location.replace("LeftTree.asp?menu=menu&id="+id+"");
						}
						}
						top.document.title="网络考试系统"; 
					</script>
				</td>
				<td width="8" bgColor="#a4b6d7" background="images/ResizeBg.gif">
					<table id="TableTile" height="100%" cellSpacing="0" cellPadding="0" border="0">
						<tr>
							<td><span id="resizeIcon_Show" style="CURSOR:hand" onClick="switchSysBar()" title="隐藏菜单"><img src="images/Resize_Hidden.gif" WIDTH="7" HEIGHT="54"></span><span id="resizeIcon_Hidden" onClick="switchSysBar()" style="DISPLAY:none;CURSOR:hand"
									title="显示菜单"><img src="images/Resize_Show.gif" WIDTH="7" HEIGHT="54"></span>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
