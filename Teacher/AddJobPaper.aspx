<%@ Page language="c#" Inherits="EasyExam.Teacher.AddJobPaper" CodeFile="AddJobPaper.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>随机组卷</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <LINK href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
		<!-- -->
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
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
      <h3>添加作业</h3>
     
	<form id="Form1" method="post" runat="server">
			<table height="300" cellSpacing="0" cellPadding="0" width="680" align="center" border="0">
				<tr>
					<td height="0"></td>
				</tr>
				<tr>
					<td>
						<!--内容开始-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="300" cellSpacing="0"
							cellPadding="0" width="100%" align="center" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font color="#ffffff" face="黑体">添加作业</font></td>
							</tr>
							<tr>
								<td vAlign="top" align="center">
									<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#dadada" cellSpacing="0"
										borderColorDark="#dadada" cellPadding="0" width="680" borderColorLight="#dadada" border="0">
										<TR>
											<td style="WIDTH: 67px">作业名称：</td>
											<td width="991" colSpan="3"><asp:textbox id="txtPaperName" runat="server" CssClass="text" Width="402px" MaxLength="50"></asp:textbox></td>
										</TR>
										<TR bgColor="#ebf5fa" height="16">
											<TD align="center" colSpan="4" height="20"><STRONG>试题策略</STRONG></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4"><asp:button id="ButAddPolicy" runat="server" CssClass="text" Text="知识点" onclick="ButAddPolicy_Click"></asp:button></TD>
										</TR>
										<TR>
											<td colSpan="4"><asp:datagrid id="DataGridPolicy" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
													CellPadding="0" PageSize="5" Height="6px">
													<HeaderStyle HorizontalAlign="Center" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="PaperPolicyID" ReadOnly="True" HeaderText="PaperPolicyID"></asp:BoundColumn>
														<asp:BoundColumn DataField="SubjectName" HeaderText="科目名称"></asp:BoundColumn>
														<asp:BoundColumn DataField="LoreName" HeaderText="知识点"></asp:BoundColumn>
														<asp:BoundColumn DataField="TestTypeName" HeaderText="题型名称"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="易">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff1" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="较易">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff2" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="中等">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff3" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="较难">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff4" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="难">
															<ItemTemplate>
																<asp:textbox id="txtTestDiff5" runat="server" CssClass="text" Width="24px" MaxLength="5" ReadOnly="True"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="操作">
															<HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:LinkButton id="LinkButEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="修改">修改</asp:LinkButton>
																<asp:LinkButton id="LinkButDel" runat="server" CausesValidation="false" CommandName="Delete" Text="删除">删除</asp:LinkButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="SubjectID" ReadOnly="True" HeaderText="SubjectID"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="LoreID" ReadOnly="True" HeaderText="LoreID"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="TestTypeID" ReadOnly="True" HeaderText="TestTypeID"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</TR>
										<TR bgColor="#ebf5fa" height="16">
											<TD align="center" colSpan="4" height="20"><STRONG>题型标题</STRONG></TD>
										</TR>
										<TR>
											<td colSpan="4"><asp:datagrid id="DataGridTestType" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
													CellPadding="0" PageSize="5" Height="2px">
													<HeaderStyle HorizontalAlign="Center" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="PaperTestTypeID" ReadOnly="True" HeaderText="PaperTestTypeID"></asp:BoundColumn>
														<asp:BoundColumn DataField="TestTypeName" HeaderText="题型名称"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="题型标题">
															<ItemTemplate>
																<asp:textbox id="txtTestTypeTitle" runat="server" CssClass="text" Width="120px" MaxLength="50"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="每题分数">
															<ItemTemplate>
																<asp:textbox id="txtTestTypeMark" runat="server" CssClass="text" Width="40px" MaxLength="50"
																	ToolTip="只对按题型定义分数有效"></asp:textbox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="TestAmount" HeaderText="题量"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="顺序">
															<HeaderStyle Width="60px"></HeaderStyle>
															<ItemTemplate>
																<asp:LinkButton id="LinkButMoveUp" runat="server" Text="上移" CommandName="MoveUp" CausesValidation="false">上移</asp:LinkButton>
																<asp:LinkButton id="LinkButMoveDown" runat="server" Text="下移" CommandName="MoveDown" CausesValidation="false">下移</asp:LinkButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="BaseTestType" ReadOnly="True" HeaderText="BaseTestType"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</TR>
										<tr bgColor="#ebf5fa" height="16">
											<td align="center" colSpan="4" style="HEIGHT: 20px"><strong>人员安排</strong></td>
										</tr>
										<tr>
											<td style="HEIGHT: 23px" align="right" width="265"><FONT face="宋体">参考人员：</FONT></td>
											<td style="HEIGHT: 23px" width="991" colSpan="3"><ASP:RADIOBUTTON id="rbAllAccount" runat="server" Checked="True" Text="所有帐号" GroupName="SelectExam"></ASP:RADIOBUTTON><FONT face="宋体">&nbsp;</FONT>&nbsp;<ASP:RADIOBUTTON id="rbSelectAccount" runat="server" Text=" " GroupName="SelectExam"></ASP:RADIOBUTTON><asp:button id="ButSelectExam" runat="server" CssClass="text" Width="54px" Text="选择..." ToolTip="选择参考人员" onclick="ButSelectExam_Click"></asp:button><asp:textbox id="txtSelectExam" runat="server" CssClass="text" Width="270px" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td align="right" width="265" style="HEIGHT: 25px"><FONT face="宋体">评卷人员：</FONT>
											</td>
											<td width="991" colSpan="3" style="HEIGHT: 25px"><ASP:RADIOBUTTON id="rbAllManagerAccount" runat="server" Checked="True" Text="所有管理员" GroupName="SelectManager"></ASP:RADIOBUTTON><ASP:RADIOBUTTON id="rbSelectManagerAccount" runat="server" Text=" " GroupName="SelectManager"></ASP:RADIOBUTTON><asp:button id="ButSelectManager" runat="server" CssClass="text" Width="54px" Text="选择..." ToolTip="选择评卷人员" onclick="ButSelectManager_Click"></asp:button><asp:textbox id="txtSelectManager" runat="server" CssClass="text" Width="270px" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr height="30">
											<td align="center" colSpan="4" height="10">
											</td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td style="HEIGHT: 23px" align="center">
									<asp:Button id="ButInput" runat="server" CssClass="button" Text="提 交" onclick="ButInput_Click"></asp:Button>&nbsp;
									<INPUT class="button" onclick="window.close();" type="button" value="取 消" name="button1">
								</td>
							</tr>
						</table>
						<!--内容结束-->
					</td>
				</tr>
			</table>
		</form>
		<div id="submitexam1" style="Z-INDEX: 120;                                  ; LEFT: expression((document.body.clientWidth-300)/2);                                  VISIBILITY: hidden;                                  POSITION: absolute;                                  ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#33cccc" height="50">
						<div align="center">正在组卷，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
		<script language="javascript">
		    TestTypeNameChange();
		    OptionNumChange();
		</script>
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
