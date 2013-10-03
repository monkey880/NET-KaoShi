<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="EasyExam.NewsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
<link href="Css/style3.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" ></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.5.3/jquery-ui.min.js" ></script>
<script type="text/javascript">
	$(document).ready(function(){
		$("#featured > ul").tabs({fx:{opacity: "toggle"}}).tabs("rotate", 5000, true);
	});
	
</script>

<style type="text/css">
#DataGridNews,#DataGridNews td {
	border-top-style: none;
	border-right-style: none;
	border-bottom-style: none;
	border-left-style: none;
	padding: 5px;
}

</style>
</head>
<body>
  <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="PersonInfo/LoginSate.aspx" width="800" height="40" scrolling="no" frameborder="0"></iframe></div>
    <div class="cl">&nbsp;</div>
		<h1 id="logo"><a href="#" >在线考试网</a></h1>
		
		<div class="cl">&nbsp;</div>
<ul id="navigation" class="nav-main">
	<li><a href="/">首页</a></li>
    
    <li class="list"><a href="/NewsList.aspx">新闻</a>
	
	</li>
    
    <li class="list"><a href="/PaperList.aspx">作业</a>
    
    
    
    

</ul>	
	</div>

    
    <!-- END Header -->
	<!-- Main -->
	<div id="main" class="index">
    <div class="right">
    <h3>最新公告</h3>
   
       <asp:DataList runat="server" ID="indexNewList">

           <ItemTemplate>
               <a href="NewInfo.aspx?id=<%# Eval("NewsID") %>"><%# Eval("NewsTitle") %></a>

           </ItemTemplate>
       </asp:DataList>



                        
      <h3 style="margin-top:10px">新闻动态</h3>
   
       <asp:DataList runat="server" ID="indexNewList2">

           <ItemTemplate>
               <a href="NewInfo.aspx?id=<%# Eval("NewsID") %>"><%# Eval("NewsTitle") %></a>

           </ItemTemplate>
       </asp:DataList>



    </div>
<div class="left">
<form id="Form1" method="post" runat="server">
<asp:datagrid id="DataGridNews" runat="server" Width="100%" AllowSorting="True" PageSize="15"
											CellPadding="0" BorderWidth="0px"  BorderStyle="None" AllowPaging="True" AutoGenerateColumns="False">
											<ItemStyle Height="30px" BorderStyle="None"></ItemStyle>
											
											<Columns>
												<asp:BoundColumn Visible="False" DataField="NewsID" ReadOnly="True" HeaderText="NewsID"></asp:BoundColumn>
												
												
												<asp:TemplateColumn SortExpression="NewsTitle" HeaderText="新闻标题">
													<ItemTemplate>
													   <a href="NewInfo.aspx?id=<%# Eval("NewsID") %>"><%# Eval("NewsTitle") %></a>
													</ItemTemplate>
												</asp:TemplateColumn>
												
												<asp:BoundColumn DataField="CreateDate" SortExpression="CreateDate" HeaderText="发布日期"></asp:BoundColumn>
												
											</Columns>
											<PagerStyle Height="23px" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
										</asp:datagrid><FONT face="宋体">共有<asp:label id="LabelRecord" runat="server" Font-Bold="True" Font-Names="宋体" ForeColor="Blue">0</asp:label>条记录&nbsp;<asp:label id="LabelCountPage" runat="server" Font-Bold="True" Font-Names="宋体" ForeColor="Blue">0</asp:label>页&nbsp;当前是第<asp:label id="LabelCurrentPage" runat="server" Font-Bold="True" Font-Names="宋体" ForeColor="Blue">0</asp:label>页&nbsp;</FONT>
										<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">第一页</asp:linkbutton>&nbsp;
										<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">上一页</asp:linkbutton>&nbsp;
										<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">下一页</asp:linkbutton>&nbsp;
										<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">最后页</asp:linkbutton>
                                        </form>
        </div>
        <div  class="cl">&nbsp;</div>
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
</html>
