<%@ Page language="c#" Inherits="EasyExam.NewsManag.SelectBrower" CodeFile="SelectBrower.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>选择浏览人员</title>
		<base target="_self">
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
				<tr height="25">
					<td style="WIDTH: 499px" align="center"><font style="FONT-SIZE: 16px" face="黑体" color="#0054a6">选择浏览人员</font></td>
				</tr>
				<tr>
					<td style="WIDTH: 499px" align="center">
						<table id="AutoNumber1" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
							cellPadding="0" width="400" border="0">
							<tr>
								<td style="HEIGHT: 19px" width="88">
									<p align="right">&nbsp;选择部门：</p>
								</td>
								<td style="HEIGHT: 19px" width="310"><asp:dropdownlist id="DDLDeptName" runat="server" AutoPostBack="True" Width="235px" onselectedindexchanged="DDLDept_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td width="88">
									<p align="right">&nbsp;人员查询：</p>
								</td>
								<td vAlign="bottom" width="310"><asp:textbox id="txtQuery" runat="server" Width="235px" ToolTip="可输入帐号或姓名进行查询" CssClass="text"
										MaxLength="20"></asp:textbox>
									<asp:button id="ButQuery" runat="server" CssClass="button" Text="查 询" onclick="ButQuery_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<td style="WIDTH: 499px" align="center">
						<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0" cellPadding="0"
							width="400" border="0">
							<tr>
								<td style="WIDTH: 173px" width="173" height="25">
									<p align="left">&nbsp;&nbsp;&nbsp; 待选部门/帐号</p>
								</td>
								<td align="center" width="36" colSpan="1" height="25" rowSpan="1"><FONT face="宋体"></FONT></td>
								<td width="174" height="25">
									<p align="left">已选部门/帐号</p>
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 173px" align="right" width="173"><asp:listbox id="LBSelect" runat="server" Width="150px" Height="250px" SelectionMode="Multiple"></asp:listbox></td>
								<td align="center" width="36"><asp:button id="butOneSelect" title="增加选择人员" style="FONT-WEIGHT: bold" runat="server" Width="32"
										Text=">" onclick="butOneSelect_Click"></asp:button><BR>
									<HR>
									<asp:button id="butAllSelect" title="增加所有人员" style="FONT-WEIGHT: bold" runat="server" Width="32"
										Text=">>" onclick="butAllSelect_Click"></asp:button><BR>
									<HR>
									<asp:button id="butOneDel" title="删除选择人员" style="FONT-WEIGHT: bold" runat="server" Width="32"
										Text="<" onclick="butOneDel_Click"></asp:button><BR>
									<HR>
									<asp:button id="butAllDel" title="删除所有人员" style="FONT-WEIGHT: bold" runat="server" Width="32"
										Text="<<" onclick="butAllDel_Click"></asp:button></td>
								<TD width="173"><asp:listbox id="LBSelected" runat="server" Width="150px" Height="250px" SelectionMode="Multiple"></asp:listbox></TD>
							</tr>
						</table>
					</td>
				</TR>
				<TR>
					<TD style="WIDTH: 499px" align="center">
						<asp:Button id="ButInput" runat="server" CssClass="button" Text="提 交" onclick="ButInput_Click"></asp:Button>&nbsp;
						<input name="Button" type="button" class="button" value="取 消" onClick="window.close();">
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
