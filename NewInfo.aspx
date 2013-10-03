<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewInfo.aspx.cs" Inherits="EasyExam.NewInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title><%=title %> 在线考试</title>
<link href="Css/style3.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" ></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.5.3/jquery-ui.min.js" ></script>
<script type="text/javascript">
	$(document).ready(function(){
		$("#featured > ul").tabs({fx:{opacity: "toggle"}}).tabs("rotate", 5000, true);
	});
	
</script>

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
<table width="80%" border="0" align="center">
  <tr>
    <td align="center"><h2><%=title %></h2></td>
  </tr>
  <tr>
    <td><%=newContent %></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>


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
