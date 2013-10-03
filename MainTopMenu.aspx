<%@ Page Language="c#" Inherits="EasyExam.MainTopMenu" CodeFile="MainTopMenu.aspx.cs" %>
<HTML>
	<HEAD>
		<TITLE>网络考试系统</TITLE>
		<meta http-equiv="Content-Language" content="zh-cn">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="JavaScript/MouseEvent.js"></script>
		<SCRIPT LANGUAGE="JAVASCRIPT">
          function LogOut()
          {
            if (confirm('您确定要注销考试系统吗？'))
            {
    		  NWH=window.open('Login.aspx','Login','titlebar=yes,menubar=yes,toolbar=yes,location=yes,directories=yes,status=yes,scrollbars=yes,resizable=yes,copyhistory=yes,top=0,left=0,width=screen.availWidth,height=screen.availHeight');
			  NWH.moveTo(0,0);
        	  NWH.resizeTo(screen.availWidth,screen.availHeight);
			  window.opener=null;
			  window.open('','_self');
			  window.close();
			  window.parent.close();
            }
          }
		</SCRIPT>
	</HEAD>
	<body onselectstart="return false" aLink="#333333" bgColor="#5cbcee" leftMargin="0" link="#333333"
		topMargin="0" vLink="#333333">
		<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111"
			width="100%" id="AutoNumber1" height="60" align="center">
			<tr>
				<td width="100%" background="Css/images/top_bg.gif"><img src="Css/images/logo.jpg" width="301" height="62">
				</td>
			</tr>
		</table>
		<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111"
			width="100%" id="AutoNumber4"  height="30">
			<tr>
				<td width="6%" align="right">
					<font style="FONT-SIZE: 10pt" color="#ffffff">帐号：</font></td>
				<td width="10%" align="left">
					<asp:Label id="LoginID" runat="server" Width="72px" Font-Size="9pt" ForeColor="White"></asp:Label></td>
				<td width="6%" align="right">
					<font style="FONT-SIZE: 10pt" color="#ffffff">姓名：</font></td>
				<td width="10%" align="left">
					<asp:Label id="UserName" runat="server" Width="72px" Font-Size="9pt" ForeColor="White"></asp:Label></td>
				<td width="44%"><FONT face="宋体"></FONT>
				</td>
				<td width="18%" align="center">
					<font style="FONT-SIZE: 10pt" color="#ffffff"><a style="TEXT-DECORATION: none" target="main" href="MainFrm.aspx">
							<font color="#ffffff">首页</font></a>┊<a href="#" style="TEXT-DECORATION: none" onClick="showModalDialog('Help/About.aspx',0,'dialogWidth:306px;dialogHeight:224px;help:no;center:yes;resizable:no;status:no;scroll:no');"><font color="#ffffff">关于</font></a>┊<a href="#" style="TEXT-DECORATION: none" onClick="LogOut();"><font color="#ffffff">注销</font></a></font></td>
				<td width="6%"></td>
			</tr>
		</table>
	</body>
</HTML>
