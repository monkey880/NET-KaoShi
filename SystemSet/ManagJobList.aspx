<%@ Page language="c#" Inherits="EasyExam.SystemSet.ManagJobList" CodeFile="ManagJobList.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>ְ������</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
		<script language="JavaScript">
			function RefreshForm()
			{
				document.all("hidcommand").value="RefreshForm";
				Form1.submit();
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="540" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="40"></td>
				</tr>
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="500" cellSpacing="0"
							cellPadding="0" width="98%" align="center" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="����" color="#ffffff">��Ա��������</font></td>
							</tr>
							<tr>
								<td height="23">&nbsp;��Ա�������ƣ�<asp:textbox id="txtJobName" runat="server" CssClass="text" Width="136px"></asp:textbox>
									<asp:button id="ButNewDept" runat="server" CssClass="button" Text="����" onclick="ButNewDept_Click"></asp:button>&nbsp;
									<asp:button id="ButQuery" runat="server" CssClass="button" Text="�� ѯ" onclick="ButQuery_Click"></asp:button>
									<asp:Label id="LabCondition" runat="server" Visible="False">����</asp:Label></td>
							</tr>
							<TR>
								<td vAlign="top" align="center"><asp:datagrid id="DataGridJob" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
										BorderWidth="1px" CellPadding="0" PageSize="15" AllowSorting="True">
										<ItemStyle Height="23px"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="JobID" ReadOnly="True" HeaderText="JobID"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="&lt;input type='checkbox' id='chkSelectAll' name='chkSelectAll' onclick='jcomSelectAllRecords()' title='ȫѡ��ȫ��ȡ��' &gt;">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<INPUT id=chkSelect type=checkbox value='<%#LinNum++%>' name=chkSelect>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="���">
												<ItemTemplate>
													<%#RowNum++%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="JobName" SortExpression="JobName" HeaderText="ְ������"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="����">
												<HeaderStyle Width="60px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="LinkButUser" runat="server" Text="�ʺ�����" CommandName="User" CausesValidation="false">�ʺ�����</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="����" HeaderText="�༭" CancelText="ȡ��" EditText="�༭">
												<HeaderStyle Width="60px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:EditCommandColumn>
											<asp:TemplateColumn HeaderText="ɾ��">
												<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="LinkButDel" runat="server" CausesValidation="false" CommandName="Delete" Text="ɾ��">ɾ��</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><FONT face="����">����<asp:Label id="LabelRecord" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>����¼&nbsp;<asp:Label id="LabelCountPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>ҳ&nbsp;��ǰ�ǵ�<asp:Label id="LabelCurrentPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>ҳ&nbsp;</FONT>
									<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">���ҳ</asp:linkbutton></td>
							</TR>
							<tr>
								<td style="HEIGHT: 23px" align="center"><FONT face="����"><asp:button id="ButNewMoreJob" runat="server" CssClass="button" Text="��������"></asp:button>&nbsp;
										<asp:button id="ButDelete" runat="server" CssClass="button" Text="ɾ��ְ��" onclick="ButDelete_Click"></asp:button></FONT></td>
							</tr>
						</table>
						<!--���ݽ���--></td>
				</tr>
			</table>
			<input type="hidden" size="4" name="hidcommand">
		</form>
	</body>
</HTML>