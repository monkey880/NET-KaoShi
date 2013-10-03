<%@ Page language="c#" Inherits="EasyExam.PersonInfo.PassWord" CodeFile="PassWord.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>修改密码</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="224" cellSpacing="0" cellPadding="0" width="520" align="center" border="0">
				<tr>
					<td height="40"></td>
				</tr>
				<tr>
					<td>
						<!--内容开始-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="184" cellSpacing="0"
							cellPadding="0" width="500" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="黑体" color="#ffffff">修改密码</font></td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="0" width="500" border="0">
										<TR>
											<TD style="WIDTH: 178px" align="right" colSpan="2" height="23">
											</TD>
										</TR>
										<TR>
											<td style="WIDTH: 178px" align="right" height="23">帐&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
											<td width="336" height="23"><asp:textbox id="txtLoginID" runat="server" CssClass="text" Enabled="False" Width="151px"></asp:textbox></td>
										</TR>
										<TR>
											<TD style="WIDTH: 178px; HEIGHT: 23px" align="right" height="24">旧&nbsp;密&nbsp;码：</TD>
											<TD width="336" height="24" style="HEIGHT: 23px"><asp:textbox id="txtOldPwd" runat="server" CssClass="text" Width="151px" Font-Size="9pt" TextMode="Password"></asp:textbox></TD>
										</TR>
										<TR>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right" height="17">新&nbsp;密&nbsp;码：</td>
											<td width="336" height="17" style="HEIGHT: 23px">
												<asp:textbox id="txtNewPwd" runat="server" CssClass="text" Width="151px" Font-Size="9pt" TextMode="Password"></asp:textbox></td>
										</TR>
										<tr>
											<td style="WIDTH: 178px; HEIGHT: 23px" align="right">确认密码：</td>
											<td style="HEIGHT: 23px" width="336">
												<asp:textbox id="txtSureNewPwd" runat="server" CssClass="text" Width="151px" Font-Size="9pt"
													TextMode="Password"></asp:textbox></td>
										</tr>
										<TR>
											<TD align="center" width="514" colSpan="2" height="23"><FONT face="宋体"></FONT></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td align="center" height="23"><asp:Button id="ButInput" runat="server" CssClass="button" Text="提 交" onclick="ButInput_Click"></asp:Button>&nbsp;
									<INPUT class="button" onclick="window.location='../MainFrm.aspx';" type="button" value="返 回"
										name="button1"></td>
							</tr>
						</table>
						<!--内容结束-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
