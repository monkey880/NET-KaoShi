<%@ Page language="c#" Inherits="EasyExam.UserManag.NewOneUser" CodeFile="NewOneUser.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>新建帐户</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="../JavaScript/Calendar.js"></script>
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="392" cellSpacing="0" cellPadding="0" width="550" align="center" border="0">
				<tr>
					<td height="0"></td>
				</tr>
				<tr>
					<td>
						<!--内容开始-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="392" cellSpacing="0"
							cellPadding="0" width="100%" align="center" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="黑体" color="#ffffff">新建帐户</font></td>
							</tr>
							<tr>
								<td align="center">
									<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="0" width="500" border="0">
										<tr height="25">
											<td align="center" colSpan="2" height="23"></td>
										</tr>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">帐&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
											<td width="336" height="23"><asp:textbox id="txtLoginID" runat="server" CssClass="text"></asp:textbox><asp:button id="ButCheck" runat="server" CssClass="text" Text="检测重复" onclick="ButCheck_Click"></asp:button>(<FONT face="宋体" color="#ff0033">*</FONT>)</td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">姓&nbsp;&nbsp;&nbsp;&nbsp;名：</td>
											<td style="HEIGHT: 23px" width="336"><asp:textbox id="txtUserName" runat="server" CssClass="text"></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">登录密码：</td>
											<td width="336" height="23"><asp:textbox id="txtNewUserPwd" runat="server" CssClass="text" Font-Size="9pt" TextMode="Password"></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">确认密码：</td>
											<td width="336" height="23"><asp:textbox id="txtSureUserPwd" runat="server" CssClass="text" Font-Size="9pt" TextMode="Password"></asp:textbox></td>
										</TR>
										<tr>
											<td style="WIDTH: 178px" align="right" height="23">性&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
											<td width="336" height="23"><asp:radiobuttonlist id="RBLUserSex" runat="server" RepeatDirection="Horizontal" Width="56px">
													<asp:ListItem Value="男" Selected="True">男</asp:ListItem>
													<asp:ListItem Value="女">女</asp:ListItem>
												</asp:radiobuttonlist></td>
										</tr>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">出生年月：</td>
											<td width="336" height="23"><asp:textbox id="txtBirthday" onclick="jcomOpenCalender('txtBirthday');" runat="server" CssClass="text"
													Font-Size="9pt" Width="123px"></asp:textbox><A onclick="jcomOpenCalender('txtBirthday');" href="#"><IMG height="18" alt="选择" src="../images/Calendar.gif" width="22" border="0"></A></td>
										</TR>
										<tr>
											<td style="WIDTH: 178px" vAlign="bottom" align="right" height="23">上传照片：</td>
											<td width="336" height="23"><INPUT class="text" id="UpUserPhoto" type="file" size="20" name="File1" runat="server"></td>
										</tr>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">所属部门：</td>
											<td style="HEIGHT: 23px" width="336"><asp:dropdownlist id="DDLDept" runat="server" Width="88px"></asp:dropdownlist></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">职&nbsp;&nbsp;&nbsp;&nbsp;务：</td>
											<td style="HEIGHT: 23px" width="336"><asp:dropdownlist id="DDLJob" runat="server" Width="88px"></asp:dropdownlist></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">电&nbsp;&nbsp;&nbsp;&nbsp;话：</td>
											<td style="HEIGHT: 23px" width="336"><asp:textbox id="txtTelephone" runat="server" CssClass="text"></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">证件类型：</td>
											<td style="HEIGHT: 23px" width="336"><asp:textbox id="txtCertType" runat="server" CssClass="text"></asp:textbox></td>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">证件号码：</td>
											<td width="336" height="23"><asp:textbox id="txtCertNum" runat="server" CssClass="text"></asp:textbox></td>
										</TR>
										<TR>
											<TD style="WIDTH: 178px" align="right" height="23">登&nbsp;录&nbsp;IP：</TD>
											<TD width="336" height="23"><FONT face="宋体"><asp:textbox id="txtLoginIP" runat="server" CssClass="text"></asp:textbox></FONT></TD>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">类&nbsp;&nbsp;&nbsp;&nbsp;型：</td>
											<td width="336" height="23"><asp:dropdownlist id="DDLUserType" runat="server" Width="80px">
													<asp:ListItem Value="0">普通帐户</asp:ListItem>
													<asp:ListItem Value="1">管理帐户</asp:ListItem>
												</asp:dropdownlist></td>
										</TR>
										<tr>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">状&nbsp;&nbsp;&nbsp;&nbsp;态：</td>
											<td style="HEIGHT: 23px" width="336"><asp:dropdownlist id="DDLUserState" runat="server" Width="80px">
													<asp:ListItem Value="1">正常</asp:ListItem>
													<asp:ListItem Value="0">禁止</asp:ListItem>
												</asp:dropdownlist></td>
										</tr>
										<tr>
											<td align="center" width="514" colSpan="2" height="23"><FONT face="宋体"></FONT></td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td align="center" height="23"><asp:button id="ButInput" runat="server" CssClass="button" Text="提 交" onclick="ButInput_Click"></asp:button>&nbsp;
									<input class="button" onclick="window.close();" type="button" value="取 消" name="Button"></td>
							</tr>
						</table>
						<!--内容结束--></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
