<%@ Page language="c#" Inherits="EasyExam.RubricManag.ImportTest" CodeFile="ImportTest.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>������������</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="224" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="40"></td>
				</tr>
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="184" cellSpacing="0"
							cellPadding="0" width="98%" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="����" color="#ffffff">��������</font></td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table2" height="150" cellSpacing="0" cellPadding="0" width="98%" border="0"
										style="BORDER-COLLAPSE: collapse" bordercolor="#111111">
										<tr>
											<td align="center" colSpan="2" height="23">
											</td>
										</tr>
                                        <tr>
								<td style="HEIGHT: 23px" align="center">&nbsp; ��Ŀ���ƣ�<asp:DropDownList id="DDLSubjectName" runat="server" Width="115px" AutoPostBack="True" onselectedindexchanged="DDLSubjectName_SelectedIndexChanged">
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:DropDownList>&nbsp;&nbsp;֪ʶ�㣺<asp:DropDownList id="DDLLoreName" runat="server" Width="115px">
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:DropDownList>�������ƣ�<asp:DropDownList id="DDLTestTypeName" runat="server" Width="115px">
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:DropDownList>�����Ѷȣ�
									<asp:dropdownlist id="DDLTestDiff" runat="server" Width="115px">
										<asp:ListItem Value="��">��</asp:ListItem>
										<asp:ListItem Value="����">����</asp:ListItem>
										<asp:ListItem Value="�е�">�е�</asp:ListItem>
										<asp:ListItem Value="����">����</asp:ListItem>
										<asp:ListItem Value="��">��</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:Label id="LabCondition" runat="server" Visible="False">����</asp:Label></td>
							</tr>
										<tr>
											<td align="center" colSpan="2" height="23"><FONT face="����">�ļ���</FONT><INPUT class="text" id="UpLoadFile" style="WIDTH: 221px; HEIGHT: 20px" type="file" size="17"
													name="File1" runat="server"><FONT face="����">&nbsp;</FONT><asp:Button id="ButInput" runat="server" CssClass="button" Text="�� ��" onclick="ButInput_Click"></asp:Button>&nbsp;
												<INPUT class="button" onClick="window.location='../MainFrm.aspx';" type="button" value="�� ��"
													name="button1"></td>
										</tr>
										<tr>
											<td align="center" colSpan="2" height="23">&nbsp;</td>
										</tr>
										<TR>
											<TD align="center" colSpan="2" height="23"><FONT face="����"><asp:label id="LabelMessage" runat="server" ForeColor="Red"></asp:label></FONT></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">
												<asp:DataGrid id="DataGridErr" runat="server" Width="486px" Visible="False" HorizontalAlign="Center"
													Height="62px" AutoGenerateColumns="False">
													<ItemStyle Height="23px"></ItemStyle>
													<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="23px" ForeColor="Black" CssClass="HeadRow"
														BackColor="SteelBlue"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="ErrID" HeaderText="���">
															<HeaderStyle Width="60px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="RowNum" HeaderText="�к�">
															<HeaderStyle Width="60px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ErrInfo" HeaderText="��������"></asp:BoundColumn>
													</Columns>
												</asp:DataGrid></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
						<!--���ݽ���-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
