<%@ Page language="c#" Inherits="EasyExam.NewsManag.EditNews" CodeFile="EditNews.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>�޸�����</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <script type="text/javascript" src="../JavaScript/ueditor/ueditor.all.js"></script>
<script type="text/javascript" src="../JavaScript/ueditor/ueditor.config.js"></script>

	<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="300" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="0"></td>
				</tr>
				<tr>
					<td colspan="2">
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse"  height="377" cellSpacing="0"
							cellPadding="0" width="100%" class="pad52" >
							<tr>
								<td style="COLOR: #990000" align="center" background="bg_dh_middle.gif" bgColor="#ffffff"
									height="24" colspan="2"><font style="FONT-SIZE: 16px" face="����" color="#000">�޸�����</font></td>
							</tr>
							<TR>
								<TD height="41" align="right" style="WIDTH: 74px; HEIGHT: 23px">���ű��⣺</TD>
								<TD style="HEIGHT: 23px" width="518"><asp:textbox id="txtNewsTitle" runat="server" Width="344px" CssClass="text" ToolTip="��������100���ַ�"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<td style="WIDTH: 74px; HEIGHT: 219px" align="right">�������ݣ�</td>
								<td style="HEIGHT: 219px" width="518" colSpan="5"><FONT face="����"><asp:TextBox runat="server"  TextMode="MultiLine" ToolTip="��������800���ַ�" 
											CssClass="text" ID="txtNewsContent" MaxLength="800" Width="800" Height="300"></asp:TextBox>
									</FONT>
                                  <script type="text/javascript">
								  var editor = UE.getEditor('txtNewsContent')
                                  </script>
								</td>
							</TR>
							<TR>
								<td style="WIDTH: 74px" align="right" height="24"><FONT face="����">�������ڣ�</FONT></td>
								<td width="518" colSpan="5"><asp:textbox id="txtCreateDate" runat="server" Width="80px" Enabled="False"></asp:textbox></td>
							</TR>
							<tr height="30">
								<td align="center" width="518" colSpan="6" height="24">
									<asp:Button id="ButInput" runat="server" CssClass="button" Text="�� ��" onclick="ButInput_Click"></asp:Button><FONT face="����">&nbsp;
										<input name="Button" type="button" class="button" value="ȡ ��" onClick="window.close();"></FONT></td>
							</tr>
						</table>
						<!--���ݽ���-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
