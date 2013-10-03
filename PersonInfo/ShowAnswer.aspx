<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.ShowAnswer" CodeFile="ShowAnswer.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
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
			<table cellSpacing="0" cellPadding="1" width="960" align="center" border="0">
				<tr>
					<td height="6"></td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0" style="LINE-HEIGHT: 200%">
							<tr>
								<td vAlign="bottom" width="20%"><FONT face="宋体"></FONT></td>
								<td vAlign="bottom" align="center" width="60%"><span id="lblTitle" style="FONT-WEIGHT: bold; FONT-SIZE: 14pt"><%=strPaperName%></span></td>
								<td vAlign="bottom" align="right" width="20%"><span id="lblSubTitle">总共<%=strTestCount%>
										题共<%=strPaperMark%>分</span></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px" bgColor="#0000ff" height="2"></td>
				</tr>
				<tr>
					<td align="center" style="HEIGHT: 20px" height="20"><span id="lblMessage">帐号:<%=strLoginID%>&nbsp;&nbsp;姓名:<%=strUserName%>&nbsp;&nbsp;答题时间:<%=strExamTime%>&nbsp;&nbsp;通过分数:<%=strPassMark%>&nbsp;&nbsp;考生得分:<%=strTotalMark%></span></td>
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
								<td vAlign="bottom" align="right" width="20%"><INPUT class="lenButton" onClick="jscomExportTableToWord('tblPaper')" type="button" value="导出到Word">&nbsp;&nbsp;<INPUT class="button" onClick="window.print();" type="button" value="打 印"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#cee7ff">
						<table id="tblPaper" cellSpacing="0" cellPadding="1" width="100%" align="center" bgColor="white"
							border="0">
							<%=strPaperContent%>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><input class="button" onClick="window.close();" type="button" value="关 闭" name="button1"></td>
				</tr>
			</table>
		</form>
           </div>
      </div>
		<div id="submitexam2" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-300)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#ff99cc" height="50">
						<div align="center">正在提交答卷，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam1" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-300)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#33cccc" height="50">
						<div align="center">正在保存答卷，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-300)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#ff99cc" height="50">
						<div align="center">考试时间已到，正在提交答卷，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam3" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-320)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-90)/2-20)">
			<table style="CURSOR: default" cellSpacing="0" borderColorDark="#ffffff" width="320" bgColor="#ffffff"
				borderColorLight="#000000" border="1">
				<tr bgColor="#336699">
					<td width="320"><span><font color="#ffffff">提示信息</font></span></td>
					<td align="right" width="10"><IMG style="CURSOR: hand" onClick="cancel();" alt="关闭" src="../images/close.gif" border="0"></td>
				</tr>
				<tr>
					<td vAlign="middle" align="center" width="320" bgColor="#cccccc" colSpan="2" height="90"><img src="../images/warning.gif" hspace="5" align="absMiddle"><label id="labmessage"></label></td>
				</tr>
				<tr>
					<td align="center" bgColor="#cccccc" colSpan="2" height="35"><input class="button" id="yes" onClick="submit();" type="button" value=" 确 定 " name="yes">&nbsp;&nbsp;&nbsp;&nbsp;
						<input class="button" id="no" onClick="cancel();" type="button" value=" 取 消 " name="no">
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam4" style="Z-INDEX: 120;                    ; LEFT: expression((document.body.clientWidth-425)/2);                    VISIBILITY: hidden;                    POSITION: absolute;                    ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-190)/2-20)">
			<table style="CURSOR: default" cellSpacing="0" borderColorDark="#ffffff" width="435" bgColor="#ffffff"
				borderColorLight="#000000" border="1">
				<tr bgColor="#336699">
					<td width="435"><span><font color="#ffffff">提示信息 已答题:<img src="../images/finished.gif" align="absMiddle">未答题:<img src="../images/nofinished.gif" align="absMiddle"></font></span></td>
					<td align="right" width="10"><IMG style="CURSOR: hand" onClick="cancel1();" alt="关闭" src="../images/close.gif" border="0"></td>
				</tr>
				<tr>
					<td vAlign="middle" align="center" width="435" colSpan="2" bgColor="#cccccc" height="190"><%=strtable%></td>
				</tr>
				<tr>
					<td align="center" bgColor="#cccccc" colSpan="2" height="35"><input class="button" id="close" onClick="cancel1();" type="button" value=" 关 闭 " name="no">
					</td>
				</tr>
			</table>
		</div>
         </div>
  <div class="clear"> </div>
</div>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
		
	</body>
</HTML>
