<%@ Page language="c#" Inherits="EasyExam.GradeManag.StatisGrade" CodeFile="StatisGrade.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>�ɼ�ͳ��</title>
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
					<td align="center"><FONT style="FONT-SIZE: 16px" face="����" color="#0054a6">��<asp:label id="labPaperName" runat="server" ForeColor="#0054a6"></asp:label>���ɼ�ͳ��</FONT></td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px" bgColor="#0000ff" height="2"><FONT face="����"></FONT></td>
				</tr>
				<tr>
					<td style="HEIGHT: 20px" align="center" height="20"><span id="lblMessage"><FONT face="����">���ţ�
								<asp:dropdownlist id="DDLDept" runat="server" Width="78px"></asp:dropdownlist>�ʺţ�
								<asp:textbox id="txtLoginID" runat="server" Width="80px" CssClass="text"></asp:textbox>������
								<asp:textbox id="txtUserName" runat="server" Width="54px" CssClass="text"></asp:textbox>�ɼ���
								<asp:dropdownlist id="DDLCondition" runat="server" Width="64px">
									<asp:ListItem Value="-1">-ȫ��-</asp:ListItem>
									<asp:ListItem Value="=">=</asp:ListItem>
									<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
									<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
									<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
									<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
								</asp:dropdownlist><asp:textbox id="txtTotalMark" runat="server" Width="42px" CssClass="text"></asp:textbox>
								<asp:button id="ButQuery" runat="server" CssClass="button" Text="�� ѯ" onclick="ButQuery_Click"></asp:button><asp:label id="LabCondition" runat="server" Visible="False">����</asp:label></FONT></span></td>
				</tr>
				<tr>
					<td align="center"><FONT face="����"><asp:datagrid id="DataGridGrade" runat="server" Width="100%" PageSize="20" CellPadding="0" BorderWidth="1px"
								AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
								<ItemStyle Height="23px"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="���">
										<ItemTemplate>
											<%#RowNum++%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="LoginID" SortExpression="LoginID" HeaderText="�ʺ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="UserName" SortExpression="UserName" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="UserSex" SortExpression="UserSex" HeaderText="�Ա�"></asp:BoundColumn>
									<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="JobName" SortExpression="JobName" HeaderText="ְ��"></asp:BoundColumn>
									<asp:BoundColumn DataField="UserType" SortExpression="UserType" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="UserState" SortExpression="UserState" HeaderText="״̬"></asp:BoundColumn>
									<asp:BoundColumn DataField="TotalMark" SortExpression="TotalMark" HeaderText="�ɼ�"></asp:BoundColumn>
								</Columns>
								<PagerStyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></FONT><FONT face="����">����
							<asp:label id="LabelRecord" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="����">0</asp:label>����¼&nbsp;
							<asp:label id="LabelCountPage" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="����">0</asp:label>ҳ&nbsp;��ǰ�ǵ�
							<asp:label id="LabelCurrentPage" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="����">0</asp:label>ҳ&nbsp;</FONT>
						<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">��һҳ</asp:linkbutton>&nbsp;
						<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">��һҳ</asp:linkbutton>&nbsp;
						<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">��һҳ</asp:linkbutton>&nbsp;
						<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">���ҳ</asp:linkbutton></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="ButExport" runat="server" CssClass="button" Text="�� ��" onclick="ButExport_Click"></asp:button>&nbsp;
						<INPUT class="button" onclick="window.close();" type="button" value="�� ��" name="button1"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
