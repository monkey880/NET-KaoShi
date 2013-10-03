<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.ShowMyAnswer" CodeFile="ShowMyAnswer.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

		<title>查看答卷</title>
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <link href="../Css/images/ks_exam.css" rel="stylesheet" type="text/css" />
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
    
    
       <div class="ks_wrap">
  <div class="shijuancon">
    <div class="ks110_juan">
    
      <div class="e_j_left"> <a href="http://exam.kaoshi110.net/"> <img src="../Css/images/d_1.jpg" border="0" height="45" width="161"></a></div>
      <div class="e_j_center">老师：mango <span id="lblSubTitle">总共<%=strTestCount%>题</span></div>
    </div>
     <div class="ks110_zhong">
        <div class="ks110_list" id="tbody110608">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0">
				<tr>
					<td height="6"></td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0" style="LINE-HEIGHT: 200%">
							<tr>
								<td vAlign="bottom" width="20%"><FONT face="宋体"></FONT></td>
								<td vAlign="bottom" align="center" width="60%"><span id="lblTitle" style="FONT-WEIGHT: bold; FONT-SIZE: 14pt"><%=strPaperName%></span></td>
							<td vAlign="bottom" align="right" width="20%"><span id="lblSubTitle"></span></td>
								</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px" bgColor="#0000ff" height="2"></td>
				</tr>
				<tr>
					<td align="center" style="HEIGHT: 20px" height="20"></td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0" style="LINE-HEIGHT: 200%">
							<tr>
								<td vAlign="bottom" width="20%"><FONT face="宋体"></FONT></td>
								<td vAlign="bottom" align="center" width="60%">
									<asp:RadioButton id="RadioButAll" runat="server" Text="全部显示" GroupName="ShowTest" Checked="True"
										AutoPostBack="True" oncheckedchanged="RadioButAll_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:RadioButton id="RadioButWrong" runat="server" Text="错题显示" GroupName="ShowTest" AutoPostBack="True" oncheckedchanged="RadioButWrong_CheckedChanged"></asp:RadioButton></td>
								
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td  id="tblPaper">
					
							<%=strPaperContent%>
						
					</td>
				</tr>
				<tr>
					<td align="center"><input class="button" onClick="window.close();" type="button" value="关 闭" name="button1"></td>
				</tr>
			</table>
		</form>
           </div>
      </div>
		
		
		
		
		
         </div>
  <div class="clear"> </div>
</div>
    
    
    
		
	</body>
</HTML>
