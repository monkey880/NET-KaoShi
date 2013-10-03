<%@ Page language="c#" Inherits="EasyExam.PersonInfo.BrowBook" CodeFile="BrowBook.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

		<title>浏览内容</title>
		<base target="_self">
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
				<TR>
					<TD align="center" height="10" colSpan="1" rowSpan="1"></TD>
				</TR>
				<TR>
					<TD style="WORD-BREAK: break-all" align="center" colSpan="1" height="25" rowSpan="1">
						<asp:Label id="labSectionName" runat="server" Font-Bold="True"></asp:Label><hr color="#6699ff">
					</TD>
				</TR>
				<tr>
					<td style="HEIGHT: 25px" align="center">
						浏览次数：
						<asp:Label id="labBrowNumber" runat="server">****</asp:Label>&nbsp;&nbsp; 发布人：
						<asp:Label id="labCreateLoginID" runat="server">****</asp:Label>&nbsp;&nbsp; 
						发布日期：
						<asp:Label id="labCreateDate" runat="server">****</asp:Label>
					</td>
				</tr>
				<TR>
					<TD style="WORD-BREAK: break-all"><%=strSectionContent%></TD>
				</TR>
				<TR>
					<TD align="center" height="23"><input class="button" onclick="window.close();" type="button" value="关 闭" name="button1">
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
