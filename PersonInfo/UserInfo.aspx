<%@ Page language="c#" Inherits="EasyExam.PersonInfo.UserInfo" CodeFile="UserInfo.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>�ʻ���Ϣ</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <LINK href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
      <div id="page" class="shell"> 
        <!-- Logo + Search + Navigation -->
  <div id="top">
    <div class="login">
      <iframe src="LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe>
    </div>
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
    <div class="cols two-cols user">
      <div class="cl">&nbsp;</div>
      <div class="left">
        <div id="my_menu" class="sdmenu">
        
         
          <div class="lmenucon">
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav1&quot;)">ѧԱ����</span>
              <div id="leftNav1" style="display: block;"> 
           <a class="menu_l" href="JoinJob.aspx">�ҵ���ҵ</a>
             <a class="menu_l" href="JoinLianXi.aspx">�ҵ���ϰ</a>
              <a class="menu_l" href="MyLog.aspx" target="_blank">�����¼</a>
              </div>
            </div>
          </div>
          <div class="lmenucon">
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav2&quot;)">�ҵ�������Ϣ</span>
              <div id="leftNav2" style="display: block;"> <a class="menu_l" href="myPingLun.aspx">�ҵ�����</a>
              <a class="menu_l" href="MyGroup.aspx">�ҵ�Ⱥ��</a>
             <a class="menu_l" href="UserInfo.aspx">�ҵ�����</a></div>
            </div>
          </div>
        
          <div class="mbd"> </div>
        </div>
        
        
        
       
      </div>
      <div class="right">
        <h3><span>��Ա����</span></h3>
        <form id="Form1" method="post" runat="server">
			<table height="408" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="368" cellSpacing="0"
							cellPadding="0" width="100%" align="center" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="����" color="#ffffff">�ʻ���Ϣ</font></td>
							</tr>
							<tr>
								<td valign="top">
									<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="0" width="500" border="0">
										<TR>
											<TD align="center" colSpan="3" height="23">
											</TD>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">��&nbsp;&nbsp;&nbsp;&nbsp;�ţ�</td>
											<td width="336" height="23" colspan="2"><asp:textbox id="txtLoginID" runat="server" CssClass="text" ></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">��&nbsp;&nbsp;&nbsp;&nbsp;����</td>
											<td style="HEIGHT: 23px" width="248"><asp:textbox id="txtUserName" runat="server" CssClass="text" ></asp:textbox></td>
											<td style="HEIGHT: 23px" width="81" rowspan="4"><asp:image id="ImageUser" runat="server" Width="60px" Height="90px" ImageUrl="../Images/UserImage.gif"
													ToolTip="�ʻ���Ƭ"></asp:image></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">��&nbsp;&nbsp;&nbsp;&nbsp;��</td>
											<td width="248" height="23"><asp:radiobuttonlist id="RBLUserSex" runat="server" Width="56px" RepeatDirection="Horizontal" 
													Height="2px">
													<asp:ListItem Value="��" Selected="True">��</asp:ListItem>
													<asp:ListItem Value="Ů">Ů</asp:ListItem>
												</asp:radiobuttonlist></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23"><FONT face="����">�������£�</FONT></td>
											<td width="248" height="23"><asp:textbox id="txtBirthday" runat="server" CssClass="text" Font-Size="9pt" Width="123px" ReadOnly="True"
													></asp:textbox></td>
										</TR>
										<tr>
											<td style="WIDTH: 178px" align="right" height="23"><FONT face="����">�������ţ�</FONT></td>
											<td width="248" height="23">
												<asp:textbox id="txtDept" runat="server" CssClass="text" Width="88px" Font-Size="9pt" ReadOnly="True"
													></asp:textbox></td>
										</tr>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">ְ&nbsp;&nbsp;&nbsp;&nbsp;��</td>
											<td width="336" height="23" colspan="2">
												<asp:textbox id="txtJob" runat="server" CssClass="text" Width="88px" Font-Size="9pt" ReadOnly="True"
													></asp:textbox><A onclick="jcomOpenCalender('txtBirthday');" href="#"></A></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">��&nbsp;&nbsp;&nbsp;&nbsp;����</td>
											<td style="HEIGHT: 23px" width="336" colspan="2"><asp:textbox id="txtTelephone" runat="server" CssClass="text" ></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">֤�����ͣ�</td>
											<td style="HEIGHT: 23px" width="336" colspan="2"><asp:textbox id="txtCertType" runat="server" CssClass="text" ></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right" height="21">֤�����룺</td>
											<td width="336" height="21" colspan="2" style="HEIGHT: 23px"><asp:textbox id="txtCertNum" runat="server" CssClass="text" ></asp:textbox></td>
										</TR>
										<TR>
											<TD style="WIDTH: 178px" align="right" height="23">��&nbsp;¼&nbsp;IP��</TD>
											<TD width="336" height="23" colspan="2"><FONT face="����"><asp:textbox id="txtLoginIP" runat="server" CssClass="text" ></asp:textbox></FONT></TD>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right" height="17">��&nbsp;&nbsp;&nbsp;&nbsp;�ͣ�</td>
											<td width="336" height="17" colspan="2" style="HEIGHT: 23px">
												<asp:textbox id="txtUserType" runat="server" CssClass="text" Width="88px" Font-Size="9pt" ReadOnly="True"
													></asp:textbox></td>
										</TR>
										<tr>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">״&nbsp;&nbsp;&nbsp;&nbsp;̬��</td>
											<td style="HEIGHT: 23px" width="336" colspan="2">
												<asp:textbox id="txtUserState" runat="server" CssClass="text" Width="88px" Font-Size="9pt" ReadOnly="True"
													></asp:textbox></td>
										</tr>
										<TR>
											<TD align="center" width="514" colSpan="3" height="23"><FONT face="����"></FONT></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td align="center" height="23"><INPUT class="button" onclick="window.location='../MainFrm.aspx';" type="button" value="�� ��"
										name="button1"></td>
							</tr>
						</table>
						<!--���ݽ���-->
					</td>
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
