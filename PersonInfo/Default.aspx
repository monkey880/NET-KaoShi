<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="EasyExam.PersonInfo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<link href="../Css/style3.css" rel="stylesheet" type="text/css">
<link href="../Css/style.css" rel="stylesheet" type="text/css">
</head>
<body>
<div id="page" class="shell"> 
  <!-- Logo + Search + Navigation -->
  <div id="top">
    <div class="login">
      <iframe src="LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe>
    </div>
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
              <div id="leftNav2" style="display: block;"> 
              <a class="menu_l" href="myPingLun.aspx">我的评论</a>
              <a class="menu_l" href="MyGroup.aspx">我的群组</a>
             <a class="menu_l" href="UserInfo.aspx">我的资料</a></div>
            </div>
          </div>
        
          <div class="mbd"> </div>
        </div>
        
        
        
       
      </div>
      <div class="right">
        <h3><span>会员中心</span></h3>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tabwz">
            <tbody>
                <tr>
                    <!--左上角小图标-->
                    <td valign="top" align="left" class="td_form">
                        <table width="93%" height="60" cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td height="30" colspan="2" style="border-bottom: #efefef 1px solid" class="Pswgary">
                                        登录名称：
                                        monkey880
                                    </td>
                                    <td width="41%" height="30" class="Pswgary" style="border-bottom: #efefef 1px solid">
                                        <span style="border-bottom: #efefef 1px solid" class="Pswgary"><a href="/usercenter/StudentInfo.aspx"></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="17" height="30" align="left" class="mkaoshi110_3"><img width="24" height="15" alt="修改个人信息" src="/Css/images/kszxgrxx.gif"><a href="/PersonInfo/UserInfo.aspx"><u>修改个人信息</u></a></td>
                                    <td width="27%" align="left" class="mkaoshi110_3">&nbsp;</td>
                                    <td align="left" class="mkaoshi110_3">&nbsp;</td>
                                </tr>
                            </tbody>
                        </table>
                        <div>
                          
  <!-- AspNetPager V6.0.0 for VS2005  Copyright:2003-2006 Webdiyer (www.webdiyer.com) -->
  <!--记录总数只有一页，AspNetPager已自动隐藏，若需在只有一页数据时显示AspNetPager，请将AlwaysShow属性值设为true！-->
  <!-- AspNetPager V6.0.0 for VS2005 End -->
                          
                          
                        </div>
                    </td>
                </tr>
            </tbody>
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
</div>
</body>
</html>
