<%@ Page language="c#" Inherits="EasyExam.PersonInfo.QueryGrade" CodeFile="QueryGrade.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>�ɼ���ѯ</title>
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <LINK href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Calendar3.js" type="text/javascript"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
    
     <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
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
          <div id="my_menu" class="sdmenu">
        
         
          <div class="lmenucon">
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav1&quot;)">ѧԱ����</span>
              <div id="leftNav1" style="display: block;"> 
           <a class="menu_l" href="JoinJob.aspx">�ҵ���ҵ</a>
             <a class="menu_l" href="JoinLianXi.aspx">�ҵ���ϰ</a>
              <a class="menu_l" href="MyLog.aspx" target="_blank">�����¼</a>
              </div>
            </div>
          </div>
          <div class="lmenucon">
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav2&quot;)">�ҵ�������Ϣ</span>
              <div id="leftNav2" style="display: block;"> <a class="menu_l" href="myPingLun.aspx">�ҵ�����</a>
              <a class="menu_l" href="MyGroup.aspx">�ҵ�Ⱥ��</a>
             <a class="menu_l" href="UserInfo.aspx">�ҵ�����</a></div>
            </div>
          </div>
        
          <div class="mbd"> </div>
        </div>
        </div>
      <div class="right">
      <h3><asp:label id="labPaperType" runat="server" ForeColor="White"></asp:label>�ɼ���ѯ</h3>
      <form id="Form1" method="post" runat="server">
			<table height="540" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="40"></td>
				</tr>
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="500" cellSpacing="0"
							cellPadding="0" width="100%" align="center" border="1">
							
							<tr>
								<td style="HEIGHT: 22px">&nbsp; �Ծ����ƣ�<asp:textbox id="txtPaperName" runat="server" Width="152px" CssClass="text"></asp:textbox>&nbsp; 
									���ڣ���
									<asp:textbox id="txtStartTime" runat="server" Width="80px"
										CssClass="text" MaxLength="50" onclick="new Calendar().show(this);" ></asp:textbox></FONT>��
									<asp:textbox id="txtEndTime"  runat="server" Width="80px"
										CssClass="text" MaxLength="50" onclick="new Calendar().show(this);"></asp:textbox></FONT>&nbsp;
									<asp:button id="ButQuery" runat="server" CssClass="button" Text="�� ѯ" onclick="ButQuery_Click"></asp:button><asp:label id="LabCondition" runat="server" Visible="False">����</asp:label></td>
							</tr>
							<tr>
								<td vAlign="top" align="center"><asp:datagrid id="DataGridGrade" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
										BorderWidth="1px" CellPadding="0" PageSize="15" AllowSorting="True">
										<ItemStyle Height="23px"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Height="23px" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="UserScoreID" ReadOnly="True" HeaderText="UserScoreID">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="PaperID" ReadOnly="True" HeaderText="PaperID"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="���">
												<ItemTemplate>
													<%#RowNum++%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="PaperName" SortExpression="PaperName" HeaderText="�Ծ�����"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="����ʱ��">
												<ItemTemplate>
													<asp:Label id="labExamTime" runat="server">����ʱ��</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="TotalMark" HeaderText="�ɼ�">
												<ItemTemplate>
													<asp:Label id="LabTotalMark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TotalMark") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="PassState" HeaderText="ͨ��״̬">
												<ItemTemplate>
													<asp:Label id="LabPassState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PassState") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="JudgeState" SortExpression="JudgeState" HeaderText="����״̬"></asp:BoundColumn>
											<asp:BoundColumn DataField="JudgeLoginID" SortExpression="JudgeLoginID" HeaderText="������"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="����">
												<HeaderStyle Width="90px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton id="LinkButOrder" runat="server" Text="����" CommandName="Order" CausesValidation="false">����</asp:LinkButton>
													<asp:LinkButton id="LinkButAnswer" runat="server" Text="���" CommandName="Answer" CausesValidation="false">���</asp:LinkButton>
													<asp:LinkButton id="LinkButStatis" runat="server" Text="ͳ��" CommandName="Statis" CausesValidation="false">ͳ��</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="StartTime" ReadOnly="True" HeaderText="��ʼʱ��"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="EndTime" ReadOnly="True" HeaderText="����ʱ��"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="SeeResult" ReadOnly="True" HeaderText="�鿴���"></asp:BoundColumn>
										</Columns>
										<PagerStyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><FONT face="����">����<asp:label id="LabelRecord" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="����">0</asp:label>����¼&nbsp;<asp:label id="LabelCountPage" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="����">0</asp:label>ҳ&nbsp;��ǰ�ǵ�<asp:label id="LabelCurrentPage" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="����">0</asp:label>ҳ&nbsp;</FONT>
									<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">���ҳ</asp:linkbutton></td>
							</tr>
						</table>
						<!--���ݽ���--></td>
				</tr>
			</table>
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
