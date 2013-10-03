<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.JoinExam" CodeFile="JoinExam.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>参加考试</title>
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
		<h1 id="logo"><a href="#">在线考试网</a></h1>
		
		<div class="cl">&nbsp;</div>
<ul id="navigation" class="nav-main">
	<li><a href="/">首页</a></li>
    
    <li class="list"><a href="/NewsList.aspx">新闻</a>
	
	</li>
    
    <li class="list"><a href="/PaperList.aspx">作业</a>
    
    
    
    

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
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav1&quot;)">学员中心</span>
              <div id="leftNav1" style="display: block;"> 
           <a class="menu_l" href="JoinJob.aspx">我的作业</a>
             <a class="menu_l" href="JoinLianXi.aspx">我的练习</a>
              <a class="menu_l" href="MyLog.aspx" target="_blank">做题记录</a>
              </div>
            </div>
          </div>
          <div class="lmenucon">
            <div class="collapsed"> <span onclick="ShowMenu(&quot;leftNav2&quot;)">我的资料信息</span>
              <div id="leftNav2" style="display: block;"> <a class="menu_l" href="myPingLun.aspx">我的评论</a>
              <a class="menu_l" href="MyGroup.aspx">我的群组</a>
             <a class="menu_l" href="UserInfo.aspx">我的资料</a></div>
            </div>
          </div>
        
          <div class="mbd"> </div>
        </div>
        </div>
      <div class="right">
      <h3>会员中心</h3>
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
			        <asp:TemplateColumn HeaderText="序号">
			          <itemtemplate> <%#RowNum++%> </itemtemplate>
		          </asp:TemplateColumn>
			        <asp:BoundColumn DataField="PaperName" SortExpression="PaperName" HeaderText="试卷名称"></asp:BoundColumn>
			        <asp:BoundColumn DataField="ProduceWay" SortExpression="ProduceWay" HeaderText="出题方式"></asp:BoundColumn>
			        <asp:BoundColumn DataField="ExamTime" SortExpression="ExamTime" HeaderText="答题时间(分钟)"></asp:BoundColumn>
			        <asp:TemplateColumn HeaderText="有效时间">
			          <itemtemplate>
			            <asp:Label ID="labAvaiTime" runat="server">有效时间</asp:Label>
		              </itemtemplate>
		          </asp:TemplateColumn>
			        <asp:BoundColumn DataField="TestCount" SortExpression="TestCount" HeaderText="题量"></asp:BoundColumn>
			        <asp:BoundColumn DataField="PaperMark" SortExpression="PaperMark" HeaderText="总分"></asp:BoundColumn>
			        <asp:BoundColumn DataField="CreateLoginID" SortExpression="CreateLoginID" HeaderText="出卷人"></asp:BoundColumn>
			        <asp:TemplateColumn HeaderText="操作">
			          <headerstyle Width="60px"></headerstyle>
			          <itemtemplate>
			            <asp:HyperLink ID="LinkButStartExam" runat="server" Text="开始考试" CommandName="StartExam" CausesValidation="false">开始考试</asp:HyperLink>
                          
		              </itemtemplate>
		          </asp:TemplateColumn>
			        <asp:BoundColumn Visible="False" DataField="PaperType" ReadOnly="True" HeaderText="试卷类型"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="StartTime" ReadOnly="True" HeaderText="开始时间"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="EndTime" ReadOnly="True" HeaderText="结束时间"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="CreateWay" ReadOnly="True" HeaderText="组卷方式"></asp:BoundColumn>
			        <asp:BoundColumn Visible="False" DataField="ShowModal" ReadOnly="True" HeaderText="显示模式"></asp:BoundColumn>
		          </columns>
			      <pagerstyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></pagerstyle>
			      </asp:DataGrid>
			      <font face="宋体">共有
			        <asp:Label ID="LabelRecord" runat="server" ForeColor="Blue" Font-Names="宋体" Font-Bold="True">0</asp:Label>
			        条记录&nbsp;
			        <asp:Label ID="LabelCountPage" runat="server" ForeColor="Blue" Font-Names="宋体" Font-Bold="True">0</asp:Label>
			        页&nbsp;当前是第
			        <asp:Label ID="LabelCurrentPage" runat="server" ForeColor="Blue" Font-Names="宋体" Font-Bold="True">0</asp:Label>
			        页&nbsp;</font>
			      <asp:LinkButton ID="LinkButFirstPage" runat="server" OnClick="LinkButFirstPage_Click">第一页</asp:LinkButton>
			      &nbsp;
			      <asp:LinkButton ID="LinkButPirorPage" runat="server" OnClick="LinkButPirorPage_Click">上一页</asp:LinkButton>
			      &nbsp;
			      <asp:LinkButton ID="LinkButNextPage" runat="server" OnClick="LinkButNextPage_Click">下一页</asp:LinkButton>
			      &nbsp;
			      <asp:LinkButton ID="LinkButLastPage" runat="server" OnClick="LinkButLastPage_Click">最后页</asp:LinkButton></td>
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
