<%@ Page language="c#" Inherits="EasyExam.Teacher.EditCustomPaper" CodeFile="EditCustomPaper.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>�޸��ֹ���ҵ</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
		<!-- -->
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="300" cellSpacing="0" cellPadding="0" width="680" align="center" border="0">
				<tr>
					<td height="0"></td>
				</tr>
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="300" cellSpacing="0"
							cellPadding="0" width="100%" align="center" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24">
									<font face="����" style="FONT-SIZE: 16px" color="#ffffff">�޸��ֹ���ҵ</font></td>
							</tr>
							<tr>
								<td vAlign="top" align="center">
									<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#dadada" cellSpacing="0"
										borderColorDark="#dadada" cellPadding="0" width="680" borderColorLight="#dadada" border="0">
										<tr bgColor="#ebf5fa" height="16">
											<td align="center" colSpan="4" style="HEIGHT: 20px"><STRONG>��������</STRONG></td>
										</tr>
										<TR>
											<td style="WIDTH: 67px" align="right">��ҵ���ƣ�</td>
											<td width="483" colSpan="3"><asp:textbox id="txtPaperName" runat="server" CssClass="text" Width="402px" MaxLength="50"></asp:textbox></td>
										</TR>
										
										<TR bgColor="#ebf5fa" height="16">
											<TD align="center" colSpan="4" height="20"><STRONG>�������</STRONG></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4"><FONT face="����"><asp:button id="ButAddPolicy" runat="server" CssClass="text" Text="��Ӳ���" onclick="ButAddPolicy_Click"></asp:button></FONT></TD>
										</TR>
										<TR>
											<td colSpan="4"><asp:datagrid id="DataGridPolicy" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
													CellPadding="0" PageSize="5" Height="6px">
													<HeaderStyle HorizontalAlign="Center" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="PaperPolicyID" ReadOnly="True" HeaderText="PaperPolicyID"></asp:BoundColumn>
														<asp:BoundColumn DataField="SubjectName" HeaderText="��Ŀ����"></asp:BoundColumn>
														<asp:BoundColumn DataField="LoreName" HeaderText="֪ʶ��"></asp:BoundColumn>
														<asp:BoundColumn DataField="TestTypeName" HeaderText="��������"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="����ID">
															<ItemTemplate>
																<asp:textbox id="txtSelectTest" runat="server" CssClass="text" Width="180px" MaxLength="800"
																	ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="����">
															<HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:LinkButton id="LinkButEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="�޸�">�޸�</asp:LinkButton>
																<asp:LinkButton id="LinkButDel" runat="server" CausesValidation="false" CommandName="Delete" Text="ɾ��">ɾ��</asp:LinkButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="SubjectID" ReadOnly="True" HeaderText="SubjectID"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="LoreID" ReadOnly="True" HeaderText="LoreID"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="TestTypeID" ReadOnly="True" HeaderText="TestTypeID"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</TR>
										
									</TABLE>
								</td>
							</tr>
							<tr>
								<td style="HEIGHT: 23px" align="center"><asp:Button id="ButInput" runat="server" CssClass="button" Text="�� ��" onclick="ButInput_Click"></asp:Button>&nbsp;
									<INPUT class="button" onClick="window.close();" type="button" value="ȡ ��" name="button1"></td>
							</tr>
						</table>
						<!--���ݽ���-->
					</td>
				</tr>
			</table>
		</form>
		<div id="submitexam1" style="Z-INDEX: 120;                               ; LEFT: expression((document.body.clientWidth-300)/2);                               VISIBILITY: hidden;                               POSITION: absolute;                               ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#33cccc" height="50">
						<div align="center">����������Ժ�...</div>
					</td>
				</tr>
			</table>
		</div>
	</body>
</HTML>
