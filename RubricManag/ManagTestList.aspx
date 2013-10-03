<%@ Page Language="c#" Inherits="EasyExam.RubricManag.ManagTestList" CodeFile="ManagTestList.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>������</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <script type="text/javascript" src="../Images/js/bootstrap.min.js"></script>

<link href="../Images/css/bootstrap.css" rel="stylesheet" type="text/css" />

<link href="../Images/css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
		<script language="JavaScript">
			function RefreshForm()
			{
				document.all("hidcommand").value="RefreshForm";
				Form1.submit();
			}
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="563" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="40"></td>
				</tr>
				<tr>
					<td>
						<!--���ݿ�ʼ-->
						<table style="BORDER-COLLAPSE: collapse" borderColor="#6699ff" height="523" cellSpacing="0"
							cellPadding="0" width="98%" align="center" border="1">
							<tr>
								<td style="COLOR: #990000" align="center" background="../Images/bg_dh_middle.gif" bgColor="#ffffff"
									height="24"><font style="FONT-SIZE: 16px" face="����" color="#ffffff">������</font></td>
							</tr>
							<tr>
								<td style="HEIGHT: 23px">&nbsp; ��Ŀ���ƣ�<asp:DropDownList id="DDLSubjectName" runat="server" Width="115px" AutoPostBack="True" onselectedindexchanged="DDLSubjectName_SelectedIndexChanged">
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:DropDownList>&nbsp;&nbsp;֪ʶ�㣺<asp:DropDownList id="DDLLoreName" runat="server" Width="115px">
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:DropDownList>�������ƣ�<asp:DropDownList id="DDLTestTypeName" runat="server" Width="115px">
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:DropDownList>�����Ѷȣ�
									<asp:dropdownlist id="DDLTestDiff" runat="server" Width="115px">
										<asp:ListItem Value="��">��</asp:ListItem>
										<asp:ListItem Value="����">����</asp:ListItem>
										<asp:ListItem Value="�е�">�е�</asp:ListItem>
										<asp:ListItem Value="����">����</asp:ListItem>
										<asp:ListItem Value="��">��</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">--ȫ��--</asp:ListItem>
									</asp:dropdownlist>&nbsp; �������ݣ�<asp:TextBox id="txtTestContent" runat="server" Width="290px"></asp:TextBox>
									<asp:button id="ButQuery" runat="server" Text="�� ѯ" CssClass="button" onclick="ButQuery_Click"></asp:button>
									<asp:Label id="LabCondition" runat="server" Visible="False">����</asp:Label></td>
							</tr>
							<tr>
								<td vAlign="top" align="left"><asp:datagrid id="DataGridTest" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
										BorderWidth="0px" CellPadding="0" PageSize="15" AllowSorting="True">
										<ItemStyle Height="23px"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Height="23px" ForeColor="Black" CssClass="HeadRow" BackColor="#076AA3"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="RubricID" ReadOnly="True" HeaderText="RubricID"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="OptionContent" ReadOnly="True" HeaderText="OptionContent"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="OptionNum" ReadOnly="True" HeaderText="OptionNum"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="SubjectName" SortExpression="SubjectName" HeaderText="��Ŀ����"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="LoreName" SortExpression="LoreName" HeaderText="֪ʶ��"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="TestTypeName" SortExpression="TestTypeName" HeaderText="��������"></asp:BoundColumn>
											<asp:TemplateColumn Visible="False" SortExpression="TestContent" HeaderText="��������">
												<ItemTemplate>
													<asp:Label id="labTestContent" runat="server" Text=''>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="CreateLoginID" SortExpression="CreateLoginID" HeaderText="������"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CreateDate" SortExpression="CreateDate" HeaderText="��������"></asp:BoundColumn>
											
                                            <asp:TemplateColumn HeaderText="">
                                            <ItemTemplate>
                                            <table width="100%" border="0" class="table table-bordered" align="left" style="margin-bottom:10px">
  <tr>
    <td width="10%" bgcolor="#FFFFFF"><INPUT id=chkSelect type=checkbox value='<%#LinNum++%>' name=chkSelect></td>
    <td width="32%" bgcolor="#FFFFFF">��Ŀ��<%# DataBinder.Eval(Container.DataItem,"SubjectName") %></td>
    <td width="58%" bgcolor="#FFFFFF">֪ʶ�㣺<%# DataBinder.Eval(Container.DataItem,"LoreName") %></td>
  </tr>
  <tr>
    <td bgcolor="#FFFFFF">&nbsp;</td>
    <td bgcolor="#FFFFFF">�����ˣ�<%# DataBinder.Eval(Container.DataItem,"CreateLoginID") %></td>
    <td bgcolor="#FFFFFF">�������ڣ�<%# DataBinder.Eval(Container.DataItem,"CreateDate") %></td>
  </tr>
  <tr>
    <td colspan="3" bgcolor="#FFFFFF"><div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title"><span class="label label-warning"><%#RowNum++%></span>(<%# DataBinder.Eval(Container.DataItem,"TestTypeName") %>)<%# DataBinder.Eval(Container.DataItem,"TestContent") %></h3>
  </div>
  <div class="panel-body">
    <asp:Label ID="TestOption" runat="server"></asp:Label>
  </div>
</div></td>
  </tr>
  <tr>
    <td bgcolor="#FFFFFF">&nbsp;</td>
    <td bgcolor="#FFFFFF">&nbsp;</td>
    <td bgcolor="#FFFFFF"><asp:LinkButton id="LinkButEditTest" runat="server">�޸�</asp:LinkButton>&nbsp;
													<asp:LinkButton id="LinkButDel" runat="server" CausesValidation="false" CommandName="Delete" Text="ɾ��">ɾ��</asp:LinkButton></td>
  </tr>
</table></ItemTemplate>
                  </asp:TemplateColumn>                          
                                            
										</Columns>
										
									</asp:datagrid><FONT face="����">����<asp:Label id="LabelRecord" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>����¼&nbsp;<asp:Label id="LabelCountPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>ҳ&nbsp;��ǰ�ǵ�<asp:Label id="LabelCurrentPage" runat="server" ForeColor="Blue" Font-Names="����" Font-Bold="True">0</asp:Label>ҳ&nbsp;</FONT>
									<asp:linkbutton id="LinkButFirstPage" runat="server" onclick="LinkButFirstPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButPirorPage" runat="server" onclick="LinkButPirorPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButNextPage" runat="server" onclick="LinkButNextPage_Click">��һҳ</asp:linkbutton>&nbsp;
									<asp:linkbutton id="LinkButLastPage" runat="server" onclick="LinkButLastPage_Click">���ҳ</asp:linkbutton></td>
							</tr>
							<tr>
								<td style="HEIGHT: 23px" align="center"><FONT face="����">
										<asp:button id="ButNewTest" runat="server" CssClass="button" Text="�½�����"></asp:button>&nbsp;
										<asp:button id="ButDelete" runat="server" CssClass="button" Text="ɾ������" onclick="ButDelete_Click"></asp:button>&nbsp;
										<asp:button id="ButExport" runat="server" CssClass="button" Text="��������" onclick="ButExport_Click" Visible="false"></asp:button></FONT></td>
							</tr>
						</table>
						<!--���ݽ���--></td>
				</tr>
			</table>
			<input type="hidden" size="4" name="hidcommand">
		</form>
	</body>
</HTML>
