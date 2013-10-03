<%@ Page Language="c#" Inherits="EasyExam.Login" CodeFile="Login.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="css/style3.css" rel="stylesheet" type="text/css">
<title>无标题文档</title>
</head>

<body>
 <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
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
		<div class="cols two-cols">
			<div class="cl">&nbsp;</div>
			<h2>用户登录</h2>
            <FORM id="login" method="post" runat="server">
			<TABLE  cellSpacing="0" cellPadding="0" width="400" border="0" align="center">
				<TR>
					<TD valign="top">
						<TABLE height="238" cellSpacing="0" cellPadding="0" align="center" border="0" 
							width="400">
							
							<TR>
								<TD align="right" width="159" height="25">
									<span style="FONT-SIZE: 9pt">帐&nbsp;号：</span>
								</TD>
								<TD width="254" height="28"><asp:textbox id="LoginID" runat="server" Width="128px" Font-Size="9pt"></asp:textbox><asp:requiredfieldvalidator id="LoginIDRequiredFieldValidator" runat="server" Width="88px" controlToValidate="LoginID"
										errormessage="帐号不能为空！" display="None" Font-Size="9pt">
                                帐号不能为空！</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD align="right" width="159" colSpan="1" height="25" rowSpan="1">
									<span style="FONT-SIZE: 9pt">密&nbsp;码：</span>
								</TD>
								<TD width="254" height="25"><asp:textbox id="UserPwd" runat="server" Width="128px" TextMode="Password" Font-Size="9pt"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" width="400" colSpan="2" height="47"><asp:button id="ButLogin" runat="server" Text="登 录" Font-Size="9pt" CssClass="button" onclick="ButLogin_Click"></asp:button>
								  &nbsp;&nbsp;<a href="RegistUser.aspx">注册</a></TD>
							</TR>
                            <TR>
							  <TD align="center" colSpan="2" height="47"><a href="UserManag/QQLogin.aspx"><img src="Images/Connect_logo_3.png" width="120" height="24" /></a><a href="#"><img src="Images/240.png" width="126" height="24" /></a>   <a href="#">忘记密码</a></TD>
						  </TR>
							<TR>
								<TD align="center" width="400" colSpan="2" height="58"><FONT face="宋体">提示：为使系统正常运行，请暂时关闭拦截弹出窗口工具。</FONT></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ErrorSummary" Width="93px" DisplayMode="List" Height="32px" ForeColor="Black"
							ShowMessageBox="True" Font-Bold="True" ShowSummary="False" Runat="server" HeaderText=""></asp:validationsummary>
					</TD>
				</TR>
			</TABLE>
		</FORM>
			
            
            
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
</html>
