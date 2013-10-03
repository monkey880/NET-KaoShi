<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.myPingLun" CodeFile="myPingLun.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<title>参加作业</title>
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
             <link href="../Css/style3.css" rel="stylesheet" type="text/css">

    <style type="text/css">
    td {
	padding: 10px;
}
    </style>
</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
    
    
       <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
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
      <h3><span>我的评价</span></h3>

		<form id="Form1" method="post" runat="server">
			
						
                                <asp:datagrid id="DataGridPaper" runat="server" Width="100%" PageSize="15" CellPadding="5" BorderWidth="0px"
										AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
										<ItemStyle Height="23px"></ItemStyle>
										
										<Columns>
                                            <asp:BoundColumn Visible="false" DataField="TestContent" ReadOnly="true"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="false" DataField="OptionContent" ReadOnly="true"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="false" DataField="TestTypeID" ReadOnly="true"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="false" DataField="OptionNum" ReadOnly="true"></asp:BoundColumn>
                                            
											
											<asp:TemplateColumn HeaderText="">
												<HeaderStyle Width="60px"></HeaderStyle>
												<ItemTemplate>
					<table width="100%" border="0" style="border:#06F 1px solid; margin-bottom:10px;">
  <tr>
    <td colspan="2" bgcolor="#C2E3F5">我发表于：<%# Eval("CreateDate")%></td>
  </tr>
  <tr>
    <td colspan="2" style="padding:10px;"><div style="border: dotted 1px #09F; padding:10px"><%# Eval("Contents")%></div></td>
  </tr>
  <tr>
    <td width="11%" valign="top">相关试题：</td>
    <td width="89%">
    
    <asp:Label ID="lblshiti" runat="server"></asp:Label></td>
  </tr>
</table>

												</ItemTemplate>
											</asp:TemplateColumn>
											
                                            
											
										</Columns>
										<PagerStyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><FONT face="宋体">共有<asp:label id="LabelRecord" runat="server" Font-Bold="True" Font-Names="宋体" ForeColor="Blue">0</asp:label>条记录&nbsp;<asp:label id="LabelCountPage" runat="server" Font-Bold="True" Font-Names="宋体" ForeColor="Blue">0</asp:label>页&nbsp;当前是第<asp:label id="LabelCurrentPage" runat="server" Font-Bold="True" Font-Names="宋体" ForeColor="Blue">0</asp:label>页&nbsp;</FONT>
									<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">第一页</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">上一页</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">下一页</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">最后页</asp:linkbutton>
						
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
