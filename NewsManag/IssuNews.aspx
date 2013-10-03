<%@ Page language="c#" Inherits="EasyExam.NewsManag.IssuNews" CodeFile="IssuNews.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>发布新闻</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script type="text/javascript" src="/JavaScript/ueditor/ueditor.config.js"></script>
	<script type="text/javascript" src="/JavaScript/ueditor/ueditor.all.js"></script>

		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="/JavaScript/Common.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="300" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="0"></td>
				</tr>
				<tr>
					<td colspan="2">
						<!--内容开始-->
						<table style="BORDER-COLLAPSE: collapse"  height="336" cellSpacing="0"
							cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td style="COLOR: #990000" align="center" background="bg_dh_middle.gif" bgColor="#ffffff"
									height="24" colspan="2"><font style="FONT-SIZE: 16px" face="黑体" color="#ffffff">发布新闻</font></td>
							</tr>
							<TR>
								<TD style="WIDTH: 74px; HEIGHT: 23px" align="right">新闻标题：</TD>
								<TD style="HEIGHT: 23px" width="408"><asp:textbox id="txtNewsTitle" runat="server" Width="344px" CssClass="text" ToolTip="最多可输入100个字符"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<td style="WIDTH: 74px; HEIGHT: 219px" align="right">新闻内容：</td>
								<td style="HEIGHT: 219px" width="408" colSpan="5"><FONT face="宋体"><asp:TextBox runat="server" Height="500px" TextMode="MultiLine" ToolTip="最多可输入800个字符" Width="800px"
											CssClass="text" ID="txtNewsContent" MaxLength="800"></asp:TextBox>
                                            <script type="text/javascript">
 var editor = new UE.ui.Editor();
    editor.render("txtNewsContent");
</script>
									</FONT>
								</td>
							</TR>
							<TR>
								<TD style="WIDTH: 74px" align="right" height="26"><FONT face="宋体">新闻分类：</FONT></TD>
								<TD width="408" colSpan="5">
                                   <asp:DropDownList ID="ddlNewClass" runat="server">
                                       <asp:ListItem Text="公告" Value="1"></asp:ListItem>
                                       <asp:ListItem Text="新闻" Value="2"></asp:ListItem>
                                   </asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<td style="WIDTH: 74px" align="right" height="24"><FONT face="宋体">发布日期：</FONT></td>
								<td width="408" colSpan="5"><asp:textbox id="txtCreateDate" runat="server" Width="80px" Enabled="False"></asp:textbox></td>
							</TR>
							<tr height="30">
								<td align="center" width="518" colSpan="6" height="24">
									<asp:Button id="ButInput" runat="server" CssClass="button" Text="提 交" onclick="ButInput_Click"></asp:Button>&nbsp;
									<input name="Button" type="button" class="button" value="取 消" onClick="window.close();"></td>
							</tr>
						</table>
						<!--内容结束-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
