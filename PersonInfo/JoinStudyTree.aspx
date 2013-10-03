<%@ Page Language="c#" Inherits="EasyExam.PersonInfo.JoinStudyTree" CodeFile="JoinStudyTree.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>JoinStudyTree</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">

    <script language="JavaScript" src="../JavaScript/Common.js"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table height="563" cellspacing="0" cellpadding="0" width="230" align="right" border="0">
            <tr>
                <td height="40">
                </td>
            </tr>
            <tr>
                <td>
                    <!--内容开始-->
                    <table style="width: 220px; border-collapse: collapse; height: 523px" bordercolor="#6699ff"
                        height="523" cellspacing="0" cellpadding="0" width="220" border="1" align="right">
                        <tr>
                            <td valign="top">
                                <%--<ie:TreeView id="TreeViewBook" runat="server" SystemImagesPath="../webctrl_client/1_0/treeimages/"
										ExpandedImageUrl="../webctrl_client/1_0/images/folderopen.gif" ImageUrl="../webctrl_client/1_0/images/folder.gif"
										SelectedImageUrl="../webctrl_client/1_0/images/folderopen.gif" Width="216px" Height="519px"></ie:TreeView>
										--%>
                                <asp:TreeView ID="TreeViewBook" ExpandedImageUrl="images/folderopen.gif"  runat="server" ShowLines="true" ExpandDepth="1" OnSelectedNodeChanged="TreeViewBook_SelectedNodeChanged">
                                    <SelectedNodeStyle BackColor="#E0E0E0" />
                                </asp:TreeView>
                            </td>
                        </tr>
                    </table>
                    <!--内容结束-->
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
