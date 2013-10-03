<%@ Page Language="c#" Inherits="EasyExam.Login" CodeFile="Login.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="css/style3.css" rel="stylesheet" type="text/css">
<title>�ޱ����ĵ�</title>
</head>

<body>
 <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
    <div class="cl">&nbsp;</div>
		<h1 id="logo"><a href="#">���߿�����</a></h1>
		
		<div class="cl">&nbsp;</div>
<ul id="navigation" class="nav-main">
	<li><a href="#">��ҳ</a></li>
    
    <li class="list"><a href="#">����</a>
	
	</li>
    
    <li class="list"><a href="#">���߿���</a>
	
	</li>
    
    
    

</ul>	
	</div>
	<!-- END Logo + Search + Navigation -->
	<!-- Header --><!-- END Header -->
	<!-- Main -->
	<div id="main">
		<div class="cols two-cols">
			<div class="cl">&nbsp;</div>
			<h2>�û���¼</h2>
            <FORM id="login" method="post" runat="server">
			<TABLE  cellSpacing="0" cellPadding="0" width="400" border="0" align="center">
				<TR>
					<TD valign="top">
						<TABLE height="238" cellSpacing="0" cellPadding="0" align="center" border="0" 
							width="400">
							
							<TR>
								<TD align="right" width="159" height="25">
									<span style="FONT-SIZE: 9pt">��&nbsp;�ţ�</span>
								</TD>
								<TD width="254" height="28"><asp:textbox id="LoginID" runat="server" Width="128px" Font-Size="9pt"></asp:textbox><asp:requiredfieldvalidator id="LoginIDRequiredFieldValidator" runat="server" Width="88px" controlToValidate="LoginID"
										errormessage="�ʺŲ���Ϊ�գ�" display="None" Font-Size="9pt">
                                �ʺŲ���Ϊ�գ�</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD align="right" width="159" colSpan="1" height="25" rowSpan="1">
									<span style="FONT-SIZE: 9pt">��&nbsp;�룺</span>
								</TD>
								<TD width="254" height="25"><asp:textbox id="UserPwd" runat="server" Width="128px" TextMode="Password" Font-Size="9pt"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" width="400" colSpan="2" height="47"><asp:button id="ButLogin" runat="server" Text="�� ¼" Font-Size="9pt" CssClass="button" onclick="ButLogin_Click"></asp:button>
								  &nbsp;&nbsp;<a href="RegistUser.aspx">ע��</a></TD>
							</TR>
							<TR>
								<TD align="center" width="400" colSpan="2" height="58"><FONT face="����">��ʾ��Ϊʹϵͳ�������У�����ʱ�ر����ص������ڹ��ߡ�</FONT></TD>
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
