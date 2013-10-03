<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.MyLog" CodeFile="MyLog.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

		<title>查看答卷</title>
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <LINK href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
    <style type="text/css">
    #tblPaper td {
	padding: 5px;
}
    </style>
</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
    
     <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="../PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
    <div class="cl">&nbsp;</div>
		<h1 id="logo"><a href="#">在线考试网</a></h1>
		
		<div class="cl">&nbsp;</div>
<ul id="navigation" class="nav-main">
	<li><a href="/">首页</a></li>
    
    <li class="list"><a href="/NewsList.aspx">新闻</a>
	
	</li>
    
    <li class="list"><a href="/PaperList.aspx">作业</a>
    
    
    
    

</ul>	
	</div>
	<!-- END Logo + Search + Navigation -->
	<!-- Header --><!-- END Header -->
	<!-- Main -->
	<div id="main">
    <div class="cols two-cols user">
		  <div class="cl">&nbsp;</div>
			
            <div class="left">
          <div id="my_menu" class="sdmenu">
        
         
          <div class="lmenucon">
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav1&quot;)">学员中心</span>
              <div id="leftNav1" style="display: block;"> 
           <a class="menu_l" href="JoinJob.aspx">我的作业</a>
             <a class="menu_l" href="JoinLianXi.aspx">我的练习</a>
              <a class="menu_l" href="MyLog.aspx" target="_blank">做题记录</a>
              </div>
            </div>
          </div>
          <div class="lmenucon">
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav2&quot;)">我的资料信息</span>
              <div id="leftNav2" style="display: block;"> <a class="menu_l" href="myPingLun.aspx">我的评论</a>
              <a class="menu_l" href="MyGroup.aspx">我的群组</a>
             <a class="menu_l" href="UserInfo.aspx">我的资料</a></div>
            </div>
          </div>
        
          <div class="mbd"> </div>
        </div>
        </div>
      <div class="right">
      <h3>做题记录</h3>
     
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0">
				<tr>
					<td height="6"></td>
				</tr>
				<tr>
					<td align="center">
						<!--内容开始-->
						<table style="BORDER-COLLAPSE: collapse"  cellSpacing="0"
							cellPadding="0" width="98%" align="center" border="0">
							
							<tr>
								<td width="40%" style="HEIGHT: 23px">&nbsp; 科目名称：<asp:DropDownList id="DDLSubjectName" runat="server" Width="115px" AutoPostBack="True" onselectedindexchanged="DDLSubjectName_SelectedIndexChanged">
										<asp:ListItem Value="0" Selected="True">--全部--</asp:ListItem>
									</asp:DropDownList>&nbsp;&nbsp;知识点：<asp:DropDownList id="DDLLoreName" runat="server" Width="115px" AutoPostBack="true" onselectedindexchanged="DDLLoreName_SelectedIndexChanged">
										<asp:ListItem Value="0" Selected="True">--全部--</asp:ListItem>
									</asp:DropDownList>
									</td>
								<td width="60%" style="HEIGHT: 23px"><asp:RadioButton id="RadioButAll" runat="server" Text="全部显示" GroupName="ShowTest" Checked="True"
										AutoPostBack="True" oncheckedchanged="RadioButAll_CheckedChanged"></asp:RadioButton>
									<asp:RadioButton id="RadioButWrong" runat="server" Text="错题显示" GroupName="ShowTest" AutoPostBack="True" oncheckedchanged="RadioButWrong_CheckedChanged"></asp:RadioButton></td>
							</tr>
							
						</table>
						<!--内容结束-->
					</td>
				</tr>
				<tr>
					<td bgColor="#cee7ff">
						<table id="tblPaper" cellSpacing="0" cellPadding="1" width="100%" align="center" bgColor="white"
							border="0">
							<%=strPaperContent%>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><input class="button" onClick="window.close();" type="button" value="关 闭" name="button1"></td>
				</tr>
			</table>
		</form>
		
      </div>
      <div class="cl">&nbsp;</div>
	  </div>
		<!-- END Two Column Content -->
	</div>
	<!-- END Main -->
	<!-- Footer DONT CHNAGE BELOW -->
    
    
	<div id="footer">
		
		
		<div class="cl">&nbsp;</div>
	</div>
	<!-- END Footer -->
	<br />
</div>
    
    
		
	</body>
</HTML>
