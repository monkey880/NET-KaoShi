<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.JoinExam" CodeFile="JoinExam.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>�μӿ���</title>
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
      <h3>��Ա����</h3>
<form id="Form1" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" bordercolor="#6699ff" cellspacing="0"
							cellpadding="5" align="center" border="0">
			  
			  <tr>
			    <td valign="top" align="center"><asp:DataGrid ID="DataGridPaper" runat="server" AutoGenerateColumns="False" AllowPaging="True"
										BorderWidth="1px" CellPadding="0" PageSize="15" Width="100%" AllowSorting="True">
			      <itemstyle Height="23px"></itemstyle>
			      <headerstyle HorizontalAlign="Center" Height="23px" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></headerstyle>
			      <columns>
			        <asp:BoundColumn Visible="False" DataField="PaperID" ReadOnly="True" HeaderText="PaperID">
			          <itemstyle HorizontalAlign="Center"></itemstyle>
		          </asp:BoundColumn>
			        <asp:TemplateColumn HeaderText="���">
			          <itemtemplate> <%#RowNum++%> </itemtemplate>
		          </asp:TemplateColumn>
			        <asp:BoundColumn DataField="PaperName" SortExpression="PaperName" HeaderText="�Ծ�����"></asp:BoundColumn>
			        <asp:BoundColumn DataField="ProduceWay" SortExpression="ProduceWay" HeaderText="���ⷽʽ"></asp:BoundColumn>
			        <asp:BoundColumn DataField="ExamTime" SortExpression="ExamTime" HeaderText="����ʱ��(����)"></asp:BoundColumn>
			        <asp:TemplateColumn HeaderText="��Чʱ��">
			          <itemtemplate>
			            <asp:Label ID="labAvaiTime" runat="server">��Чʱ��</asp:Label>
		              </itemtemplate>
		          </asp:TemplateColumn>
			        <asp:BoundColumn DataField="TestCount" SortExpression="TestCount" HeaderText="����"></asp:BoundColumn>
			        <asp:BoundColumn DataField="PaperMark" SortExpression="PaperMark" HeaderText="�ܷ�"></asp:BoundColumn>
			        <asp:BoundColumn DataField="CreateLoginID" SortExpression="CreateLoginID" HeaderText="������"></asp:BoundColumn>
			        <asp:TemplateColumn HeaderText="����">
			          <headerstyle Width="60px"></headerstyle>
			          <itemtemplate>
			            <asp:HyperLink ID="LinkButStartExam" runat="server" Text="��ʼ����" CommandName="StartExam" CausesValidation="false">��ʼ����</asp:HyperLink>
                          
		              </itemtemplate>
		          </asp:TemplateColumn>
			        <asp:BoundColumn Visible="False" DataField="PaperType" ReadOnly="True" HeaderText="�Ծ�����"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="StartTime" ReadOnly="True" HeaderText="��ʼʱ��"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="EndTime" ReadOnly="True" HeaderText="����ʱ��"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="CreateWay" ReadOnly="True" HeaderText="���ʽ"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="ShowModal" ReadOnly="True" HeaderText="��ʾģʽ"></asp:BoundColumn>
		          </columns>
			      <pagerstyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></pagerstyle>
			      </asp:DataGrid>
			      <font face="����">����
			        <asp:Label ID="LabelRecord" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>
			        ����¼&nbsp;
			        <asp:Label ID="LabelCountPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>
			        ҳ&nbsp;��ǰ�ǵ�
			        <asp:Label ID="LabelCurrentPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>
			        ҳ&nbsp;</font>
			      <asp:LinkButton ID="LinkButFirstPage" runat="server" OnClick="LinkButFirstPage_Click">��һҳ</asp:LinkButton>
			      &nbsp;
			      <asp:LinkButton ID="LinkButPirorPage" runat="server" OnClick="LinkButPirorPage_Click">��һҳ</asp:LinkButton>
			      &nbsp;
			      <asp:LinkButton ID="LinkButNextPage" runat="server" OnClick="LinkButNextPage_Click">��һҳ</asp:LinkButton>
			      &nbsp;
			      <asp:LinkButton ID="LinkButLastPage" runat="server" OnClick="LinkButLastPage_Click">���ҳ</asp:LinkButton></td>
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
