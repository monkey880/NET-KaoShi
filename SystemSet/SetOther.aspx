<%@ Page language="c#" Inherits="EasyExam.SystemSet.SetOther" CodeFile="SetOther.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <HEAD>
		<title>综合设置</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="../JavaScript/Calendar.js"></script>
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="100" cellSpacing="0" cellPadding="0" width="520" align="center" border="0">
				<tr>
					<td height="40"></td>
				</tr>
				<tr>
					<td>
						<!--内容开始-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="100" cellSpacing="0"
							cellPadding="0" width="500" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24" colspan="3">
								<font face="黑体" style="FONT-SIZE: 16px" color="#ffffff">
								综合设置</font></td>
							</tr>
							<tr>
							  <TD style="WIDTH: 161px" align="right" height="34">网站标题：</TD>
							  <TD height="34" colspan="2"><asp:textbox id="txtSiteName" runat="server" ToolTip="点击选择时间" CssClass="text" Width="104px"></asp:textbox></TD>
						  </tr>
							<tr>
							  <TD style="WIDTH: 161px" align="right" height="34">网站描述：</TD>
							  <TD height="34" colspan="2"><asp:textbox id="txtDescription" runat="server" ToolTip="点击选择时间" CssClass="text" Width="104px"></asp:textbox></TD>
						  </tr>
							<tr>
							  <TD style="WIDTH: 161px" align="right" height="34">网站关键字：</TD>
							  <TD height="34" colspan="2"><asp:textbox id="txtKeywords" runat="server" ToolTip="点击选择时间" CssClass="text" Width="104px"></asp:textbox></TD>
						  </tr>
							<tr>
							  <TD style="WIDTH: 161px" align="right" height="34">网站URL：</TD>
							  <TD height="34" colspan="2"><asp:textbox id="txtUrl" runat="server" ToolTip="点击选择时间" CssClass="text" Width="104px"></asp:textbox></TD>
						  </tr>
							<tr>
							  <TD style="WIDTH: 161px" align="right" height="34">统计代码：</TD>
							  <TD height="34" colspan="2"><asp:textbox id="txtTongji" runat="server" ToolTip="点击选择时间" CssClass="text" Width="104px" TextMode="MultiLine"></asp:textbox></TD>
						  </tr>
							<tr>
											<TD style="WIDTH: 161px" align="right" height="34">登录时间范围：</TD>
											<TD width="408" height="34" colspan="2"><asp:textbox id="txtStartTime" runat="server" ToolTip="点击选择时间" CssClass="text" Width="104px"
													onclick="jcomSelectTime('txtStartTime',0);"></asp:textbox>-
												<asp:textbox id="txtEndTime" runat="server" ToolTip="点击选择时间" CssClass="text" Width="104px" onclick="jcomSelectTime('txtEndTime',0);"></asp:textbox></TD>
										</tr>
										<TR>
											<td style="WIDTH: 161px" align="right" height="34"><FONT face="宋体">登&nbsp;录&nbsp;IP范围：</FONT></td>
											<td width="408" height="34" colspan="2"><asp:textbox id="txtStartIP" runat="server" CssClass="text" Width="104px"></asp:textbox>-
												<asp:textbox id="txtEndIP" runat="server" CssClass="text" Width="104px"></asp:textbox></td>
										</TR>
										<TR>
											<TD style="WIDTH: 161px; HEIGHT: 68px" align="right" rowSpan="2">
												<p><FONT face="宋体"><asp:checkbox id="chkRegistUser" runat="server" Text="允许帐户注册："></asp:checkbox></FONT></p>
											</TD>
											<TD width="128" height="68" rowspan="2" style="WIDTH: 128px">
												<p><FONT face="宋体">
														<asp:checkbox id="chkRegistManag" runat="server" Text="允许注册管理帐户"></asp:checkbox></FONT></p>
											</TD>
											<TD width="223" height="34">
												<ASP:RADIOBUTTON id="rbRegistDefine1" runat="server" Text="注册后立即生效" Checked="True" GroupName="RegistDefine"></ASP:RADIOBUTTON></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 34px" width="223">
												<P><FONT face="宋体">
														<ASP:RADIOBUTTON id="rbRegistDefine2" runat="server" Text="注册审核后生效" GroupName="RegistDefine"></ASP:RADIOBUTTON></FONT></P>
											</TD>
										</TR>
										<tr height="30">
											<td align="center" width="518" colSpan="3" height="23"><asp:Button id="ButInput" runat="server" CssClass="button" Text="提 交" onclick="ButInput_Click"></asp:Button>&nbsp;
									<INPUT class="button" onClick="window.location='../MainFrm.aspx';" type="button" value="返 回"
										name="button1"></td>
										</tr>
						</table>
						<!--内容结束-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
