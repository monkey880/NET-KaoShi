<%@ Page language="c#" Inherits="EasyExam.SystemSet.NewMoreSubject" CodeFile="NewMoreSubject.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>�����½���Ŀ</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="100" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
				<tr>
					<td height="0"></td>
				</tr>
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="100" cellSpacing="0"
							cellPadding="0" width="100%" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="����" color="#ffffff">�����½���Ŀ</font></td>
							</tr>
							<tr>
								<td>
									<!--����-->
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<tr>
											<td colspan="2" height="23"><br>
											</td>
										</tr>
										<TR>
											<td style="WIDTH: 137px" align="right">��Ŀ���ƣ�</td>
											<td><asp:textbox id="txtSubjectName" runat="server" CssClass="text" Width="256px" TextMode="MultiLine"
													Height="182px"></asp:textbox></td>
										</TR>
										<tr>
											<td colspan="2" align="center" height="23"><font color="red">ע����Ŀ����֮���ð�Ƕ��ţ�,���ָ���</font><br>
											</td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td align="center" height="23"><asp:Button id="ButInput" runat="server" CssClass="button" Text="�� ��" onclick="ButInput_Click"></asp:Button>&nbsp;
									<INPUT class="button" onclick="window.close();" type="button" value="�� ��" name="button1"></td>
							</tr>
						</table>
						<!--���ݽ���-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>