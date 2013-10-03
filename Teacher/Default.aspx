<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="EasyExam.Teacher.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../Css/style3.css" rel="stylesheet" type="text/css">
        <link href="../Css/style.css" rel="stylesheet" type="text/css">
</head>
<body>

     <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="../PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
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
            <h2>教师中心</h2>
            <dl>
            <dt>考试中心</dt>
            <dd>
            <ul>
            <li><a href="ManagJobPaper.aspx">作业管理</a></li>
            <li><a href="ManagUserList.aspx">我的学生</a></li>
            <li><a href="RubricManag.aspx">试题管理</a></li>
            <li><a href="LoreUserList.aspx">知识点</a></li>
            </ul>
            </dd>
            </dl>
            <dl>
            <dt>个人中心</dt>
            <dd>
            <ul>
            <li><a href="#">我的评论</a></li>
            <li><a href="MyGroup.aspx">我的群组</a></li>
             <li><a href="UserInfo.aspx">我的资料</a></li>
            </ul>
            </dd>
            </dl>
        </div>
      <div class="right">
      <h3>会员中心</h3>
      <table width="100%" border="0">
  <tr>
    <td width="19%" rowspan="3"><img name="" src="" width="120" height="120" alt=""></td>
    <td width="81%" height="42">monkey学员，欢迎您登录在线考试</td>
  </tr>
  <tr>
    <td height="41">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>

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
</div></body>
</html>
