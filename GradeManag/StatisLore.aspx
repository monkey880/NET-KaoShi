<%@ Page language="c#" Inherits="EasyExam.GradeManag.StatisLore" CodeFile="StatisLore.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>֪ʶ��ͳ��</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="1" width="95%" align="center" border="0">
				<TR>
					<TD align="center" height="6"><FONT face="����"></FONT></TD>
				</TR>
				<tr>
					<td align="center"><FONT style="FONT-SIZE: 16px" face="����" color="#0054a6">��<asp:label id="labPaperName" runat="server" ForeColor="#0054a6"></asp:label>��֪ʶ��ͳ��</FONT></td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px" bgColor="#0000ff" height="2"><FONT face="����"></FONT></td>
				</tr>
				<tr>
					<td align="center"><FONT face="����"><asp:datagrid id="DataGridLore" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
								CellPadding="0" PageSize="20" AllowSorting="True">
								<ItemStyle Height="23px"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="���">
										<ItemTemplate>
											<%#RowNum++%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SubjectName" SortExpression="SubjectName" HeaderText="��Ŀ����"></asp:BoundColumn>
									<asp:BoundColumn DataField="LoreName" SortExpression="LoreName" HeaderText="֪ʶ��"></asp:BoundColumn>
									<asp:BoundColumn DataField="TestCount" SortExpression="TestCount" HeaderText="��������"></asp:BoundColumn>
									<asp:BoundColumn DataField="TestMark" SortExpression="TestMark" HeaderText="�������"></asp:BoundColumn>
									<asp:BoundColumn DataField="TotalMark" SortExpression="TotalMark" HeaderText="�����÷�"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="Rate" HeaderText="�÷���">
										<HeaderStyle Width="200px"></HeaderStyle>
										<ItemTemplate>
											<asp:image id="ImgRate" runat="server" Width="50px" Height="15px" ImageUrl="../Images/Percent.gif"
												ToolTip=""></asp:image>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></FONT></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="ButExport" runat="server" CssClass="button" Text="�� ��" onclick="ButExport_Click"></asp:button>&nbsp;
						<INPUT class="button" onclick="window.close();" type="button" value="�� ��" name="button1"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
