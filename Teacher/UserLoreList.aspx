<%@ Page language="c#" Inherits="EasyExam.Teacher.UserLoreList" CodeFile="UserLoreList.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>�ʻ�����</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <LINK href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
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
      <h3>�������</h3>
     
		<form id="Form1" method="post" runat="server">
			<table height="540" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="40"><FONT face="����"></FONT></td>
				</tr>
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="500" cellSpacing="0"
							cellPadding="0" width="98%" align="center" border="1" class="pad52">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="����" color="#ffffff">ѧ��֪ʶ�����ճ���</font></td>
							</tr>
							<tr>
								<td style="HEIGHT: 22px">
									</td>
							</tr>
							<tr>
								<td vAlign="top" align="center"><asp:datagrid id="DataGridUser" runat="server" Width="100%" PageSize="15" CellPadding="0" BorderWidth="1px"
										AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" ForeColor="Transparent">
										<ItemStyle Height="23px"  ForeColor="Black"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Height="23px" ForeColor="Black" BorderColor="White" CssClass="HeadRow"
											BackColor="#076AA3"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="LoreID" HeaderText="LoreID"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="Score" HeaderText="Score"></asp:BoundColumn>
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
											
											<asp:BoundColumn DataField="LoreName" SortExpression="LoreName" HeaderText="֪ʶ��"></asp:BoundColumn>
                                            <asp:TemplateColumn HeaderText="���ճ̶�">
												<ItemTemplate>
													<asp:Label ID="lblLoreScore" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											
											
										</Columns>
										<PagerStyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><FONT face="����">����<asp:label id="LabelRecord" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:label>����¼&nbsp;<asp:label id="LabelCountPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:label>ҳ&nbsp;��ǰ�ǵ�<asp:label id="LabelCurrentPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:label>ҳ&nbsp;</FONT>
									<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">���ҳ</asp:linkbutton></td>
							</tr>
							<tr>
								<td style="HEIGHT: 23px" align="center"></td>
							</tr>
						</table>
						<!--���ݽ���--></td>
				</tr>
			</table>
			<input type="hidden" size="4" name="hidcommand">
		</form>
		
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
