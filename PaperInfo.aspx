<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaperInfo.aspx.cs" Inherits="EasyExam.PaperInfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <title></title>
   <LINK href="CSS/STYLE.CSS" type="text/css" rel="stylesheet">
<link href="Css/style3.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" ></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.5.3/jquery-ui.min.js" ></script>
<script type="text/javascript">
	$(document).ready(function(){
		$("#featured > ul").tabs({fx:{opacity: "toggle"}}).tabs("rotate", 5000, true);
	});
	
</script>

<style type="text/css">
#tblPaper2 ul{
	border: 2px solid #DBE4FF;
	margin-top: 5px;
	margin-bottom: 5px;
	padding-top: 20px;
	padding-right: 10px;
	padding-bottom: 20px;
	padding-left: 10px;
}
#tblPaper2 ul .timu{
	line-height: 40px;
	
	color: #06F;
	font-size: 16px;
}
#tblPaper2 ul .xuanxiang,#tblPaper ul .xuanxiang2{
	line-height: 30px;
	margin-left: 10px;	
}

.shuoming .sm_crde {
	line-height: 25px;
	background-color: #D1D1D1;
	padding-left: 10px;
	font-weight: bold;
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
<div style="border:#b9d1f0 1px solid;" class="leftcon">
<table width="90%" border="0">
  <tr>
    <td colspan="2"><h2><%=PaperName%></h2></td>
    </tr>
  <tr>
    <td width="48%" height="382"><img alt="试卷图标" src="/Images/img_sjzd.gif"></td>
    <td width="52%"><div class="rt_msg">
                        <table width="99%" height="380" cellspacing="0" cellpadding="0" border="0" style="text-indent: 5px; font-size: 12px; font-family: Arial, Helvetica, sans-serif">
                            <tbody>
                                <tr>
                                  <td height="20" bgcolor="#ffffff" align="left" style="border-bottom:#ddd 1px dotted;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="20" bgcolor="#ffffff" align="left" style="border-bottom:#ddd 1px dotted;">出题人：<span class="cRed"><%=UserName%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" bgcolor="#ffffff" align="left" style="border-bottom:#ddd 1px dotted;">
                                        出题日期：<%=CreateDate%>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" bgcolor="#ffffff" align="left" style="border-bottom:#ddd 1px dotted;"><%=Content%></td>
                                </tr>
                                <tr id="RoleRow">
                                    <td height="30" bgcolor="#ffffff" align="center" style="border-bottom:#ddd 1px dotted;">&nbsp;</td>
                                </tr>
                                <tr id="nextRoleRow">
                                    <td align="left" bgcolor="#ffffff" style="border-bottom:#ddd 1px dotted;">&nbsp;</td>
                                </tr>
                            </tbody>
                        </table>
                    </div></td>
  </tr>
</table>

                
                <div class="cont">
                
     
                    
    <div class="shuoming">
            <div class="sm_crde"></div>
</div>
                <div class="shuoming">
                  <div class="sm_crde"></div>
</div>
                    <div class="shuoming">
                  <div class="sm_crde">
                            作业预览：</div>
                      <div id="tblPaper2" class="ks110_list">
                        
                        <%=strPaperContent%>
                      </div>
                    </div>
                    <div class="shuoming">
                      <table width="99%" cellspacing="0" cellpadding="0" border="0" style="text-indent: 5px; font-size: 12px; font-family: Arial, Helvetica, sans-serif">
                            <tbody>
                                <tr id="RoleRow">
                                    <td height="30" bgcolor="#ffffff" align="center">&nbsp;</td>
                                </tr>
                           </tbody>
                      </table>
                    </div>
            </div>
            </div>

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
