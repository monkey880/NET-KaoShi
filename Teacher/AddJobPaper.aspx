<%@ Page language="c#" Inherits="EasyExam.Teacher.AddJobPaper" CodeFile="AddJobPaper.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>������</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <LINK href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
		<!-- -->
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
      
     <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="../PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
    <div class="cl">&nbsp;</div>
		<h1 id="logo"><a href="#">���߿�����</a></h1>
		
		<div class="cl">&nbsp;</div>
<ul id="navigation" class="nav-main">
	<li><a href="/">��ҳ</a></li>
    
    <li class="list"><a href="/NewsList.aspx">����</a>
	
	</li>
    
    <li class="list"><a href="/PaperList.aspx">��ҵ</a>
    
    
    
    

</ul>	
	</div>
	<!-- END Logo + Search + Navigation -->
	<!-- Header --><!-- END Header -->
	<!-- Main -->
	<div id="main">
    <div class="cols two-cols user">
		  <div class="cl">&nbsp;</div>
			
            <div class="left">
            <h2>��ʦ����</h2>
            <dl>
            <dt>��������</dt>
            <dd>
            <ul>
            <li><a href="ManagJobPaper.aspx">��ҵ����</a></li>
            <li><a href="ManagUserList.aspx">�ҵ�ѧ��</a></li>
            <li><a href="RubricManag.aspx">�������</a></li>
            <li><a href="LoreUserList.aspx">֪ʶ��</a></li>
            </ul>
            </dd>
            </dl>
            <dl>
            <dt>��������</dt>
            <dd>
            <ul>
            <li><a href="#">�ҵ�����</a></li>
            <li><a href="MyGroup.aspx">�ҵ�Ⱥ��</a></li>
             <li><a href="UserInfo.aspx">�ҵ�����</a></li>
            </ul>
            </dd>
            </dl>
        </div>
      <div class="right">
      <h3>�����ҵ</h3>
     
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
									height="24"><font color="#ffffff" face="����">�����ҵ</font></td>
							</tr>
							<tr>
								<td vAlign="top" align="center">
									<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#dadada" cellSpacing="0"
										borderColorDark="#dadada" cellPadding="0" width="680" borderColorLight="#dadada" border="0">
										<TR>
											<td style="WIDTH: 67px">��ҵ���ƣ�</td>
											<td width="991" colSpan="3"><asp:textbox id="txtPaperName" runat="server" CssClass="text" Width="402px" MaxLength="50"></asp:textbox></td>
										</TR>
										<TR bgColor="#ebf5fa" height="16">
											<TD align="center" colSpan="4" height="20"><STRONG>�������</STRONG></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4"><asp:button id="ButAddPolicy" runat="server" CssClass="text" Text="֪ʶ��" onclick="ButAddPolicy_Click"></asp:button></TD>
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
														<asp:TemplateColumn HeaderText="��">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff1" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="����">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff2" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="�е�">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff3" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="����">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff4" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="��">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff5" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
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
										<TR bgColor="#ebf5fa" height="16">
											<TD align="center" colSpan="4" height="20"><STRONG>���ͱ���</STRONG></TD>
										</TR>
										<TR>
											<td colSpan="4"><asp:datagrid id="DataGridTestType" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
													CellPadding="0" PageSize="5" Height="2px">
													<HeaderStyle HorizontalAlign="Center" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="PaperTestTypeID" ReadOnly="True" HeaderText="PaperTestTypeID"></asp:BoundColumn>
														<asp:BoundColumn DataField="TestTypeName" HeaderText="��������"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="���ͱ���">
															<ItemTemplate>
																<asp:textbox id="txtTestTypeTitle" runat="server" CssClass="text" Width="120px" MaxLength="50"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="ÿ�����">
															<ItemTemplate>
																<asp:textbox id="txtTestTypeMark" runat="server" CssClass="text" Width="40px" MaxLength="50"
																	ToolTip="ֻ�԰����Ͷ��������Ч"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="TestAmount" HeaderText="����"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="˳��">
															<HeaderStyle Width="60px"></HeaderStyle>
															<ItemTemplate>
																<asp:LinkButton id="LinkButMoveUp" runat="server" Text="����" CommandName="MoveUp" CausesValidation="false">����</asp:LinkButton>
																<asp:LinkButton id="LinkButMoveDown" runat="server" Text="����" CommandName="MoveDown" CausesValidation="false">����</asp:LinkButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="BaseTestType" ReadOnly="True" HeaderText="BaseTestType"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</TR>
										<tr bgColor="#ebf5fa" height="16">
											<td align="center" colSpan="4" style="HEIGHT: 20px"><strong>��Ա����</strong></td>
										</tr>
										<tr>
											<td style="HEIGHT: 23px" align="right" width="265"><FONT face="����">�ο���Ա��</FONT></td>
											<td style="HEIGHT: 23px" width="991" colSpan="3"><ASP:RADIOBUTTON id="rbAllAccount" runat="server" Checked="True" Text="�����ʺ�" GroupName="SelectExam"></ASP:RADIOBUTTON><FONT face="����">&nbsp;</FONT>&nbsp;<ASP:RADIOBUTTON id="rbSelectAccount" runat="server" Text=" " GroupName="SelectExam"></ASP:RADIOBUTTON><asp:button id="ButSelectExam" runat="server" CssClass="text" Width="54px" Text="ѡ��..." ToolTip="ѡ��ο���Ա" onclick="ButSelectExam_Click"></asp:button><asp:textbox id="txtSelectExam" runat="server" CssClass="text" Width="270px" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td align="right" width="265" style="HEIGHT: 25px"><FONT face="����">������Ա��</FONT>
											</td>
											<td width="991" colSpan="3" style="HEIGHT: 25px"><ASP:RADIOBUTTON id="rbAllManagerAccount" runat="server" Checked="True" Text="���й���Ա" GroupName="SelectManager"></ASP:RADIOBUTTON><ASP:RADIOBUTTON id="rbSelectManagerAccount" runat="server" Text=" " GroupName="SelectManager"></ASP:RADIOBUTTON><asp:button id="ButSelectManager" runat="server" CssClass="text" Width="54px" Text="ѡ��..." ToolTip="ѡ��������Ա" onclick="ButSelectManager_Click"></asp:button><asp:textbox id="txtSelectManager" runat="server" CssClass="text" Width="270px" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr height="30">
											<td align="center" colSpan="4" height="10">
											</td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td style="HEIGHT: 23px" align="center">
									<asp:Button id="ButInput" runat="server" CssClass="button" Text="�� ��" onclick="ButInput_Click"></asp:Button>&nbsp;
									<INPUT class="button" onclick="window.close();" type="button" value="ȡ ��" name="button1">
								</td>
							</tr>
						</table>
						<!--���ݽ���-->
					</td>
				</tr>
			</table>
		</form>
		<div id="submitexam1" style="Z-INDEX: 120;                                  ; LEFT: expression((document.body.clientWidth-300)/2);                                  VISIBILITY: hidden;                                  POSITION: absolute;                                  ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#33cccc" height="50">
						<div align="center">����������Ժ�...</div>
					</td>
				</tr>
			</table>
		</div>
		<script language="javascript">
		    TestTypeNameChange();
		    OptionNumChange();
		</script>
      </div>
      <div class="cl">&nbsp;</div>
	  </div>
		<!-- END Two Column Content -->
	</div>
	<!-- END Main -->
	<!-- Footer DONT CHNAGE BELOW -->
    
    
	<div id="footer">
		
		
		<div class="cl">&nbsp;</div>
	</div>
	<!-- END Footer -->
	<br />
</div> 
    
    
    
    
	  
	</body>
</HTML>
