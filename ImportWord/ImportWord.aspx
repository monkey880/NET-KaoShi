﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ImportWord.aspx.cs"  Inherits="fckeditor.editor.dialog.ImportWord.ImportWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
        <script src="../common/fck_dialog_common.js" type="text/javascript"></script>

<script type="text/javascript">

var oEditor = window.parent.InnerDialogLoaded() ;
var FCK = oEditor.FCK;
// Gets the document DOM
var oDOM = oEditor.FCK.EditorDocument ;

// Fired when the window loading process is finished. It sets the fields with the
// actual values if a table is selected in the editor.
window.onload = function()
{
	//oEditor.FCKLanguageManager.TranslatePage(document);


	window.parent.SetOkButton( true ) ;
	window.parent.SetAutoSize( true ) ;
}

// Fired when the user press the OK button
function Ok()
{ 
    var oActiveEl = oEditor.FCK.EditorDocument.createElement( 'SPAN' ) ; 
    oActiveEl.innerHTML =     "<span>"+GetE('TextArea1').value +" "+  GetE('Textarea2').value+"</span>";    
    oEditor.FCKUndo.SaveUndoStep(); 
   oActiveEl = oEditor.FCK.InsertElement( oActiveEl ) ;  
	return true;
}
</script>

</head>
<body>
    <form id="form2" method="post" runat="server">
    <div>
        <input id="fileWord" runat="server" type="file"/>&nbsp;
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="导入" /><br />
        <textarea id="TextArea1" style="width: 648px; height: 220px" runat="server"></textarea><br />
        <br />
        <br />
        <textarea id="Textarea2" style="width: 648px; height: 201px" runat="server"></textarea>
    </div>
        
    </form>
</body>
</html>
