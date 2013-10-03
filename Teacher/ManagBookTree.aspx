<%@ Page Language="c#" Inherits="EasyExam.Teacher.ManagBookTree" CodeFile="ManagBookTree.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ManagBookTree</title>
    <link href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
     <link href="../CSS/STYLE3.CSS" type="text/css" rel="stylesheet">
<%--
        <script language="JavaScript" src="../JavaScript/Common.js"></script>--%>

</head>
<body>
  
    
       
    
     <div id="page" class="shell">
	<!-- Logo + Search + Navigation -->
	<div id="top">
    <div class="login"><iframe src="../PersonInfo/LoginSate.aspx" width="800" height="30" scrolling="no" frameborder="0"></iframe></div>
    <div class="cl">&nbsp;</div>
		<h1 id="logo"><a href="#">���߿�����</a></h1>
		
		<div class="cl">&nbsp;</div>
<ul id="navigation" class="nav-main">
	<li><a href="/">��ҳ</a></li>
    
    <li class="list"><a href="/NewsList.aspx">����</a>
	
	</li>
    
    <li class="list"><a href="/PaperList.aspx">��ҵ</a>
    
    
    
    

</ul>	
	</div>
	<!-- END Logo + Search + Navigation -->
	<!-- Header --><!-- END Header -->
	<!-- Main -->
	<div id="main">
    <div class="cols two-cols user">
		  <div class="cl">&nbsp;</div>
			
            <div class="left">
            <h2>��ʦ����</h2>
            <dl>
            <dt>��������</dt>
            <dd>
            <ul>
            <li><a href="ManagJobPaper.aspx">��ҵ����</a></li>
            <li><a href="ManagUserList.aspx">�ҵ�ѧ��</a></li>
            <li><a href="RubricManag.aspx">�������</a></li>
            <li><a href="LoreUserList.aspx">֪ʶ��</a></li>
            </ul>
            </dd>
            </dl>
            <dl>
            <dt>��������</dt>
            <dd>
            <ul>
            <li><a href="#">�ҵ�����</a></li>
            <li><a href="MyGroup.aspx">�ҵ�Ⱥ��</a></li>
             <li><a href="UserInfo.aspx">�ҵ�����</a></li>
            </ul>
            </dd>
            </dl>
        </div>
      <div class="right">
      <h3>�������</h3>
     
		
    
		

    <form id="Form1" runat="server">
        <table height="563" cellspacing="0" cellpadding="0" width="230"  border="0">
            <tr>
                <td height="40">
                </td>
            </tr>
            <tr>
                <td>
                    <!--���ݿ�ʼ-->
                    <table style="width: 220px; border-collapse: collapse; height: 523px" bordercolor="#6699ff"
                        height="523" cellspacing="0" cellpadding="0" width="220" border="1" >
                        <tr>
                            <td valign="top">
                                <%--<ie:TreeView id="TreeViewBook" runat="server" SystemImagesPath="../webctrl_client/1_0/treeimages/"
										ExpandedImageUrl="../webctrl_client/1_0/images/folderopen.gif" ImageUrl="../webctrl_client/1_0/images/folder.gif"
										SelectedImageUrl="../webctrl_client/1_0/images/folderopen.gif" Width="216px" Height="473px"></ie:TreeView>--%>
                                <asp:TreeView ID="TreeViewBook" runat="server" ShowLines="true" ExpandDepth="1" OnSelectedNodeChanged="TreeViewBook_SelectedNodeChanged">
                                    <SelectedNodeStyle BackColor="#E0E0E0" />
                                </asp:TreeView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="23">
                                <font face="����">�½�����</font>
                                <asp:TextBox ID="txtName" runat="server" Width="140px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" height="23">
                                <asp:Button ID="BubAdd" runat="server" Text="����" CssClass="button" OnClick="ButAdd_Click">
                                </asp:Button>
                                <asp:Button ID="ButEdit" runat="server" Text="�ޡ���" CssClass="button" OnClick="ButEdit_Click">
                                </asp:Button>
                                <asp:Button ID="ButDel" runat="server" Text="ɾ����" CssClass="button" OnClick="ButDel_Click">
                                </asp:Button></td>
                        </tr>
                    </table>
                    <!--���ݽ���-->
                </td>
            </tr>
        </table>
    </form>
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
</html>
