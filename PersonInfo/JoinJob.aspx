<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.JoinJob" CodeFile="JoinJob.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<title>�μ���ҵ</title>
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
             <link href="../Css/style3.css" rel="stylesheet" type="text/css">

	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
    
    
       <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
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
      <h3><span>�ҵ���ҵ</span></h3>

		<form id="Form1" method="post" runat="server">
			
						
                                <asp:datagrid id="DataGridPaper" runat="server" Width="100%" PageSize="15" CellPadding="5" BorderWidth="0px"
										AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
										<ItemStyle Height="23px"></ItemStyle>
										<HeaderStyle HorizontalAlign="Left" Height="23px"  CssClass="HeadRow" ></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="PaperID" ReadOnly="True" HeaderText="PaperID">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											
											<asp:BoundColumn DataField="PaperName" SortExpression="PaperName" HeaderText="��ҵ����"></asp:BoundColumn>
											
											<asp:BoundColumn DataField="TestCount" SortExpression="TestCount" HeaderText="����"></asp:BoundColumn>
											
											<asp:BoundColumn DataField="CreateLoginID" SortExpression="CreateLoginID" HeaderText="������"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="����">
												<HeaderStyle Width="60px"></HeaderStyle>
												<ItemTemplate>
													<asp:HyperLink ID="LinkButStartExam2" runat="server" Text="����ģʽ" CommandName="StartExam" CausesValidation="false">����ģʽ</asp:HyperLink>
                                                    <asp:HyperLink ID="LinkButStartExam3" runat="server" Text="����ģʽ" CommandName="StartExam3" CausesValidation="false">����ģʽ</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="PaperType" ReadOnly="True" HeaderText="�Ծ�����"></asp:BoundColumn>
                                            
											
										</Columns>
										<PagerStyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><FONT face="����">����<asp:label id="LabelRecord" runat="server" Font-Bold="True" Font-Names="����" ForeColor="Blue">0</asp:label>����¼&nbsp;<asp:label id="LabelCountPage" runat="server" Font-Bold="True" Font-Names="����" ForeColor="Blue">0</asp:label>ҳ&nbsp;��ǰ�ǵ�<asp:label id="LabelCurrentPage" runat="server" Font-Bold="True" Font-Names="����" ForeColor="Blue">0</asp:label>ҳ&nbsp;</FONT>
									<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">���ҳ</asp:linkbutton>
						
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
