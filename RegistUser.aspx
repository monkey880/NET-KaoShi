<%@ Page language="c#" Inherits="EasyExam.RegistUser" CodeFile="RegistUser.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>����</title>
		<base target="_self">
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		
        <link href="Css/style3.css" rel="stylesheet" type="text/css">
        <link href="Css/style.css" rel="stylesheet" type="text/css">

		
        
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" ></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.5.3/jquery-ui.min.js" ></script>
<script type="text/javascript">
	$(document).ready(function(){
		$("#featured > ul").tabs({fx:{opacity: "toggle"}}).tabs("rotate", 5000, true);
		$('#RBLUserType_0').click(
		function(){
			$('#laoshicon').hide()
		}
		);
		$('#RBLUserType_1').click(
		function(){
			$('#laoshicon').show()
		}
		);
	});
	
	
</script>
</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
    
     <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
    <div class="cl">&nbsp;</div>
		<h1 id="logo"><a href="#">���߿�����</a></h1>
		
		<div class="cl">&nbsp;</div>
<ul id="navigation" class="nav-main">
	<li><a href="/">��ҳ</a></li>
    
    <li class="list"><a href="/NewsList.aspx">����</a>
	
	</li>
    
    <li class="list"><a href="/PaperList.aspx">��ҵ</a>
    
    
    
    

</ul>	
	</div>
	<!-- END Logo + Search + Navigation -->
	<!-- Header --><!-- END Header -->
	<!-- Main -->
	<div id="main">
		<div class="cols two-cols">
			<div class="cl">&nbsp;</div>
			
            <form id="Form1" method="post" runat="server">
			
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" height="392" cellSpacing="0"
							cellPadding="0" width="100%" border="0">
							
							<tr>
								<td align="center" valign="top">
									<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="0" width="500" border="0">
										<tr height="25">
											<td align="center" colSpan="2" height="23">
											</td>
										</tr>
										<TR>
										  <td style="WIDTH: 178px" align="right" height="23">&nbsp;</td>
										  <td height="23"><asp:radiobuttonlist id="RBLUserType" runat="server" Width="202px" RepeatDirection="Horizontal">
													<asp:ListItem Value="0" Selected="True">����ѧ��</asp:ListItem>
													<asp:ListItem Value="2" onclick="UserTypeChange">������ʦ</asp:ListItem>
										  </asp:radiobuttonlist></td>
									  </TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">��&nbsp;&nbsp;&nbsp;&nbsp;�ţ�</td>
											<td width="520" height="23"><asp:textbox id="txtLoginID" runat="server" CssClass="text"></asp:textbox><asp:button id="ButCheck" runat="server" CssClass="text" Text="����ظ�" onclick="ButCheck_Click"></asp:button>(<FONT face="����" color="#ff0033">*</FONT>)</td>
										</TR>
										
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">��¼���룺</td>
											<td width="520" height="23"><asp:textbox id="txtNewUserPwd" runat="server" CssClass="text" TextMode="Password" Font-Size="9pt"></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">ȷ�����룺</td>
											<td width="520" height="23"><asp:textbox id="txtSureUserPwd" runat="server" CssClass="text" TextMode="Password" Font-Size="9pt"></asp:textbox></td>
										</TR>

										<tr>
											<td align="center" colSpan="2" width="520" height="23">
                                            <table style="display:none" id="laoshicon">
                                             <TR>
                                          <td style="WIDTH: 178px; HEIGHT: 23px" align="right">��ʦ��֤��������
                                          <!-- MENU-LOCATION=NONE --><!-- MENU-LOCATION=NONE --></td>
                                          <td style="HEIGHT: 23px">&nbsp;</td>
                                        </TR>
                                        <TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">��ʵ������</td>
											<td style="HEIGHT: 23px" width="520"><asp:textbox id="txtUserName" runat="server" CssClass="text"></asp:textbox></td>
										</TR>
                                        <TR>
											<td style="WIDTH: 178px" align="right" height="23">���֤�ţ�</td>
											<td width="520" height="23"><asp:textbox id="txtCertNum" runat="server" CssClass="text"></asp:textbox></td>
										</TR>
										<tr>
											<td style="WIDTH: 178px" vAlign="bottom" align="right" height="23">��Ƭ��</td>
											<td width="520" height="23"><INPUT class="text" id="UpUserPhoto" type="file" size="20" name="File1" runat="server"></td>
										</tr>
										<TR>
										  <td style="WIDTH: 178px; HEIGHT: 23px" align="right">�����ϴ���</td>
										  <td style="HEIGHT: 23px"><INPUT class="text" id="UpUserPhoto2" type="file" size="20" name="File2" runat="server"></td>
									  </TR>
										<TR>
										  <td style="WIDTH: 178px; HEIGHT: 23px" align="right">�������䣺</td>
										  <td style="HEIGHT: 23px"><asp:textbox id="txtEmail" runat="server" CssClass="text"></asp:textbox></td>
									  </TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">��&nbsp;&nbsp;&nbsp;&nbsp;����</td>
											<td style="HEIGHT: 23px" width="520"><asp:textbox id="txtTelephone" runat="server" CssClass="text"></asp:textbox></td>
										</TR>
										<TR>
										  <td style="WIDTH: 178px; HEIGHT: 23px" align="right">QQ:</td>
										  <td style="HEIGHT: 23px"><asp:textbox id="txtQQ" runat="server" CssClass="text"></asp:textbox></td>
									  </TR>
                                            </table>
                                            
											</td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td align="center" height="23">
									<asp:Button id="ButInput" runat="server" CssClass="button" Text="�� ��" onclick="ButInput_Click"></asp:Button>&nbsp;
									<input name="Button" type="button" class="button" value="ȡ ��" onClick="window.close();"></td>
							</tr>
						</table>
						
		</form>
			
            
            
			<div class="cl">&nbsp;</div>
	  </div>
		<!-- END Two Column Content -->
	</div>
	<!-- END Main -->
	<!-- Footer DONT CHNAGE BELOW -->
    
    
	<div id="footer">
		<p class="right">&copy; 2011 - CompanyName &nbsp; Designed by Collect from <a href="http://www.cssmoban.com/" title="��ҳģ��" target="_blank">��ҳģ��</a></p>
		<p><a href="#">Home</a><span>&nbsp;</span><a href="#">About Us</a><span>&nbsp;</span><a href="#">Services</a><span>&nbsp;</span><a href="#">Solutions</a><span>&nbsp;</span><a href="#">Support</a><span>&nbsp;</span><a href="#">Partners</a><span>&nbsp;</span><a href="#">Contact</a></p>
		<div class="cl">&nbsp;</div>
	</div>
	<!-- END Footer -->
	<br />
</div>
    
		
	</body>
</HTML>
