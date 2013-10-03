<%@ Page language="c#" Inherits="EasyExam.Teacher.MyGroup" CodeFile="MyGroup.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
</script>

<HTML>
	<HEAD>
		<title>新建试题</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		   
		</script>
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <LINK href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
    
    
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
      <h3>试题管理</h3>
     
		<form id="Form1" method="post" runat="server">
			<table height="200" cellSpacing="0" cellPadding="0" width="670" align="center" border="0">
				<tr>
					<td height="0"></td>
				</tr>
				<tr>
				  <td>
                  <table width="100%" border="0">
  <tr>
    <td>群组名称</td>
    <td>
        <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td>群组描述</td>
    <td><ASP:TEXTBOX id="txtGroupContent" runat="server" Width="100%" Height="65px" TextMode="MultiLine"
													CssClass="Text"></ASP:TEXTBOX></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>
        <asp:Button ID="Button1" runat="server" Text="提交"  OnClick="Button1_Click1" />
      </td>
  </tr>
</table>

						
					</td>
					<td width="1" height="24"></td>
				</tr>
			</table>
			<!--内容结束--> </TD></TR></TABLE>
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
