<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="EasyExam.Default" %>

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
    <!--<div id="header">
		<div id="featured" >
		  <ul class="ui-tabs-nav">
	        <li class="ui-tabs-nav-item ui-tabs-selected" id="nav-fragment-1"><a href="#fragment-1"><img src="images/image1-small.jpg" alt="" /><span>海量试题，免费在线测试</span></a></li>
	        <li class="ui-tabs-nav-item" id="nav-fragment-2"><a href="#fragment-2"><img src="images/image2-small.jpg" alt="" /><span>2013年一级建造师考试报名时间及网上报名入口汇总</span></a></li>
	        <li class="ui-tabs-nav-item" id="nav-fragment-3"><a href="#fragment-3"><img src="images/image3-small.jpg" alt="" /><span>2013年注册化工工程师报名时间及入口汇总</span></a></li>
	        <li class="ui-tabs-nav-item" id="nav-fragment-4"><a href="#fragment-4"><img src="images/image4-small.jpg" alt="" /><span>2013年下半年教师资格考试报名时间汇总</span></a></li>
	      </ul>

	   
	    <div id="fragment-1" class="ui-tabs-panel" style="">
			<img src="images/image1.jpg" alt="" />
			 <div class="info" >
				<h2><a href="#" >海量试题，免费在线测试</a></h2>
			   <p></p>
			 </div>
	    </div>

	   
	    <div id="fragment-2" class="ui-tabs-panel ui-tabs-hide" style="">
			<img src="images/image2.jpg" alt="" />
			 <div class="info" >
				<h2><a href="#" >2013年一级建造师考试报名时间及网上</a></h2>
			   <p></p>
			 </div>
	    </div>

	   
	    <div id="fragment-3" class="ui-tabs-panel ui-tabs-hide" style="">
			<img src="images/image3.jpg" alt="" />
			 <div class="info" >
				<h2><a href="#" >2013年注册化工工程师报名时间及入口汇总</a></h2>
				<p></a></p>
	         </div>
	    </div>

	   
	    <div id="fragment-4" class="ui-tabs-panel ui-tabs-hide" style="">
			<img src="images/image4.jpg" alt="" />
			 <div class="info" >
				<h2><a href="#" >2013年下半年教师资格考试报名时间汇总</a></h2>
			   <p></p>
	         </div>
	    </div>

		</div>
	</div>-->
    
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
<%=kemu%>
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
