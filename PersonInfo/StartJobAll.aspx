<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.StartJobAll" CodeFile="StartJobAll.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>������ҵ</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
        <link href="../Css/images/ks_exam.css" rel="stylesheet" type="text/css" />
		<script language="JavaScript" src="../JavaScript/MouseEvent.js"></script>
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
        <script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
		<script language="JavaScript">
			var time_minute=<%=intRemMinute%>;
			var time_second=<%=intRemSecond%>;
			var time_passed=0;
			var timeid=null;
			var timerun=false;
			var autosavetime=<%=intAutoSaveTime%>;
			function stoptime()
			{
  				if (timerun) clearTimeout(timeid);
				timerun=false;
			}
			function starttime()
			{
  				stoptime();
  				showtime();
			}
			function showtime()
			{
   				time_passed+=1;
  				if (time_passed%autosavetime==0)
  				{
    				save();//������
    				time_passed=0;
  				};
   				timeid=setTimeout("showtime()",1000);
   				timerun=true;
			}
			
			function textcheck()//�ı����
			{
			    var inputstr=window.event.srcElement.value;
                if (inputstr.indexOf(",")>0)
                {
					var reg=new RegExp(",","g");
                    inputstr=inputstr.replace(reg,"��");
                    //alert("ע�������������в��ܰ�����Ƕ��š�,�������Զ��滻Ϊȫ�Ƕ��š�������");
                    window.event.srcElement.value=inputstr;
                    window.event.keyCode=0;
                    window.event.srcElement.focus;
                    window.event.returnValue=0;
                }
			}
			function testcheck(TestNum)//������
			{
				var testcheck=false;
				var BaseTestType=$("#BaseTestType"+TestNum).val();
				var slen=$("#Answer"+TestNum).length;
				if (slen==undefined) slen=1;
				var icount=0;
				switch(BaseTestType)
				{
					case "��ѡ��":
						if (slen<=1)
						{
							if ($("#Answer"+TestNum).checked)
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{
							$('#Answer'+TestNum).each(function(){
								
								if($(this).sttr('checked')
								
								
								});
							for(j=0;j<=slen-1;j++)
							{
								if ($("#Answer"+TestNum).item(j).checked)
								{
									testcheck=true;
									return testcheck;
								}
							}
						};
						break;
					case "��ѡ��":
						if (slen<=1)
						{
							if ($("#Answer"+TestNum).checked)
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{
							for(j=0;j<=slen-1;j++)
							{
								if ($("#Answer"+TestNum).item(j).checked)
								{
									testcheck=true;
									return testcheck;
								}
							}
						};
						break;
					case "�ж���":
						if (slen<=1)
						{
							if ($("#Answer"+TestNum).checked)
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{
							for(j=0;j<=slen-1;j++)
							{
								if ($("#Answer"+TestNum).item(j).checked)
								{
									testcheck=true;
									return testcheck;
								}
							}
						};
						break;
					case "�����":
					    if (slen<=1)
					    {
					        if (trim($("#Answer"+TestNum).value)!="")
					        {
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{    
							for(j=0;j<=slen-1;j++)
							{
								if (trim($("#Answer"+TestNum).item(j).value)!="")	icount=icount+1;
							}
							if (icount==slen)
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;
					case "�ʴ���":
						if (slen<=1)
						{
							if (trim($("#Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else 
						{
							if (trim($("#Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;
					case "������":
						if (slen<=1)
						{
							if (trim($("#Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else 
						{
							if (trim($("#Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;
					case "������":
						if (slen<=1)
						{
							if (trim($("#Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else 
						{
							if (trim($("#Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;	
					case "������":
					    if (slen<=1)
					    {
					        if (trim($("#Answer"+TestNum).value)!="")
					        {
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{    
							for(j=0;j<=slen-1;j++)
							{
								if (trim($("#Answer"+TestNum).item(j).value)!="")	icount=icount+1;
							}
							if (icount==slen)
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;
				}
				return testcheck;
			}
			function checkanswer()//�����
			{
				total=document.all("irow").value;
				for(i=1;i<=total;i++)
				{
					if (testcheck(i)==false)
					{
						document.all("icon"+i+"1").style.display="block";
						document.all("icon"+i+"2").style.display="none";
					}
					else
					{
						document.all("icon"+i+"1").style.display="none";
						document.all("icon"+i+"2").style.display="block";
					}
				}
				submitexam.style.visibility="hidden";
				submitexam1.style.visibility="hidden";
				submitexam2.style.visibility="hidden";
				submitexam3.style.visibility="hidden";
				submitexam4.style.visibility="visible";
			}
			function trysubmit()//�����ύ
			{
				total=$("#irow").val();
				/*for(i=1;i<=total;i++)
				{
					if (testcheck(i)==false)
					{
						submitexam.style.visibility="hidden";
						submitexam1.style.visibility="hidden";
						submitexam2.style.visibility="hidden";
						submitexam3.style.visibility="visible";
						submitexam4.style.visibility="hidden";
						document.all.labmessage.innerHTML="��"+i+"������û�������Ƿ�ȷ������";
						return; 
					}
				}*/
				submitexam.style.visibility="hidden";
				submitexam1.style.visibility="hidden";
				submitexam2.style.visibility="hidden";
				submitexam3.style.visibility="visible";
				submitexam4.style.visibility="hidden";
				document.all.labmessage.innerHTML="������Ŀ�������Ƿ�ȷ������";
			}
			function cancel()//ȡ���ύ
			{
				total=document.all("irow").value;
				for(i=1;i<=total;i++)
				{
					if (testcheck(i)==false)
					{
						window.event.returnvalue=0;
						location="#l"+i;
						submitexam3.style.visibility="hidden";
						return;
					}
				}
				submitexam3.style.visibility="hidden";
			}
			function cancel1()//�رռ����
			{
				submitexam4.style.visibility="hidden";
			}
			function save()//������
			{
				submitexam.style.visibility="hidden";
				submitexam1.style.visibility="visible";
				submitexam2.style.visibility="hidden";
				submitexam3.style.visibility="hidden";
				submitexam4.style.visibility="hidden";
				form1.action="SaveJobAll.aspx";
				form1.target="iframe1";
				form1.submit();
				form1.target="";
				form1.action="";
			}
			function submit()//��ʽ�ύ
			{
				timediv.style.visibility="hidden";
				submitexam1.style.visibility="hidden";
				submitexam2.style.visibility="visible";
				submitexam3.style.visibility="hidden";
				submitexam4.style.visibility="hidden";
				submitexam.style.visibility="hidden";
				form1.target="";
				form1.action="SubmJobAll.aspx";
				form1.submit();
			}
			function timeend()//ʱ�����
			{
				timediv.style.visibility="hidden";
				submitexam.style.visibility="visible";
				submitexam1.style.visibility="hidden";
				submitexam2.style.visibility="hidden";
				submitexam3.style.visibility="hidden";
				submitexam4.style.visibility="hidden";
				form1.target="";
				form1.action="SubmJobAll.aspx";
				form1.submit();
			}
		</script>
    <link href="../Css/images/ks_exam.css" rel="stylesheet" type="text/css" />
	</HEAD>
	<body onselectstart="return false" onkeydown="onKeyDown();" leftMargin="0" topMargin="0"
		onload="starttime();" rightMargin="0">
        <div class="ks_wrap">
  <div class="shijuancon">
    <div class="ks110_juan">
    
      <div class="e_j_left"> <a href="http://exam.kaoshi110.net/"> <img src="../Css/images/d_1.jpg" border="0" height="45" width="161"></a></div>
      <div class="e_j_center">��ʦ��mango <span id="lblSubTitle">�ܹ�<%=strTestCount%>��</span></div>
    </div>
     <div class="ks110_zhong">
        <div class="ks110_list" id="tbody110608">
		<form id="form1" action="SubmJobAll.aspx" method="post">
			<input type=hidden size=4 value="<%=intPaperID%>" name=PaperID> <input type=hidden size=4 value="<%=intPassMark%>" name=PassMark>
			<input type=hidden size=4 value="<%=intFillAutoGrade%>" name=FillAutoGrade> <input type=hidden size=4 value="<%=intSeeResult%>" name=SeeResult>
			<input type=hidden size=4 value="<%=intAutoJudge%>" name=AutoJudge> <input type=hidden size=4 value="<%=intUserScoreID%>" name=UserScoreID>
			<input type="hidden" size="4" value="0" name="timeminute"> <input type="hidden" size="4" value="0" name="timesecond">
			<script language="JavaScript">
				document.all("timeminute").value=time_minute;
				document.all("timesecond").value=time_second;
			</script>
            
        <div class="shijuantitle">
        <h1><%=strPaperName%></h1>
      </div>    
            
            
            
            
			<table cellSpacing="0" cellPadding="1" width="100%" border="0">
				<tr>
					<td>
						<div id="tblPaper" >
							<%=strPaperContent%>
						</div>
					</td>
				</tr>
                <tr>
					<td align="center">
						<input class="button" onClick="trysubmit();" type="submit" value="�ύ���" name="submitbtn3">
					</td>
			  </tr>
			</table>
			<input id="irow" type=hidden size=4 value="<%=intTestNum%>" name=irow>
            
		</form>
           </div>
      </div>
		<!--<div id="timediv" style="Z-INDEX: 120;                    ; LEFT: expression(document.body.clientWidth-167);                    POSITION: absolute;                    ; TOP: expression(this.style.pixelHeight)">
			<table cellSpacing="0" cellPadding="0" width="160" border="0">
				<tr>
					<td class="tableheader" align="center">�ʺ�:<%=strLoginID%><br>
						����:<%=strUserName%><br>
						��<%=intExamTime%>
						����,ʣ��<label id="label_time">00��00��</label><br>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="center" height="30"><input class="button" onClick="save();" type="button" value="������" name="submitbtn1">
								</td>
							</tr>
							<tr>
								<td align="center" height="30"><input class="button" onClick="checkanswer();" type="button" value="�����" name="submitbtn2">
								</td>
							</tr>
							<tr>
								<td align="center" height="30"><input class="button" onClick="trysubmit();" type="button" value="�ύ���" name="submitbtn3">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</div>-->
		<div id="submitexam2" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-300)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#ff99cc" height="50">
						<div align="center">�����ύ������Ժ�...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam1" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-300)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#33cccc" height="50">
						<div align="center">���ڱ��������Ժ�...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-300)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-50)/2-20)">
			<table cellSpacing="1" cellPadding="0" width="300" bgColor="#666666" border="0">
				<tr>
					<td width="300" bgColor="#ff99cc" height="50">
						<div align="center">����ʱ���ѵ��������ύ������Ժ�...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam3" style="Z-INDEX: 120;           ; LEFT: expression((document.body.clientWidth-320)/2);           VISIBILITY: hidden;           POSITION: absolute;           ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-90)/2-20)">
			<table style="CURSOR: default" cellSpacing="0" borderColorDark="#ffffff" width="320" bgColor="#ffffff"
				borderColorLight="#000000" border="1">
				<tr bgColor="#336699">
					<td width="320"><span><font color="#ffffff">��ʾ��Ϣ</font></span></td>
					<td align="right" width="10"><IMG style="CURSOR: hand" onClick="cancel();" alt="�ر�" src="../images/close.gif" border="0"></td>
				</tr>
				<tr>
					<td vAlign="middle" align="center" width="320" bgColor="#cccccc" colSpan="2" height="90"><img src="../images/warning.gif" hspace="5" align="absMiddle"><label id="labmessage"></label></td>
				</tr>
				<tr>
					<td align="center" bgColor="#cccccc" colSpan="2" height="35"><input class="button" id="yes" onClick="submit();" type="button" value=" ȷ �� " name="yes">&nbsp;&nbsp;&nbsp;&nbsp;
						<input class="button" id="no" onClick="cancel();" type="button" value=" ȡ �� " name="no">
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam4" style="Z-INDEX: 120;                    ; LEFT: expression((document.body.clientWidth-425)/2);                    VISIBILITY: hidden;                    POSITION: absolute;                    ; TOP: expression(document.body.scrollTop+(window.screen.availHeight-190)/2-20)">
			<table style="CURSOR: default" cellSpacing="0" borderColorDark="#ffffff" width="435" bgColor="#ffffff"
				borderColorLight="#000000" border="1">
				<tr bgColor="#336699">
					<td width="435"><span><font color="#ffffff">��ʾ��Ϣ �Ѵ���:<img src="../images/finished.gif" align="absMiddle">δ����:<img src="../images/nofinished.gif" align="absMiddle"></font></span></td>
					<td align="right" width="10"><IMG style="CURSOR: hand" onClick="cancel1();" alt="�ر�" src="../images/close.gif" border="0"></td>
				</tr>
				<tr>
					<td vAlign="middle" align="center" width="435" colSpan="2" bgColor="#cccccc" height="190"><%=strtable%></td>
				</tr>
				<tr>
					<td align="center" bgColor="#cccccc" colSpan="2" height="35"><input class="button" id="close" onClick="cancel1();" type="button" value=" �� �� " name="no">
					</td>
				</tr>
			</table>
		</div>
         </div>
  <div class="clear"> </div>
</div>
		<iframe name="iframe1" src="SaveJobAll.aspx" frameBorder="0" width="0%" scrolling="yes"
			height="0%"></iframe>
		<SCRIPT language="javascript">//�����϶�����  
			function xytop() {  
			item=eval('document.all.timediv.style');  
			item.pixelLeft=document.body.scrollLeft+w_x-34;  
			item.pixelTop=w_y+document.body.scrollTop-64;  
			timediv.style.pixeltop=document.body.scrollTop+timediv.style.pixelHeight;  
			timediv.style.pixelLeft=document.body.clientWidth-167;  
			item.visibility='visible';  
			}  
		</SCRIPT>
		<SCRIPT language="javascript">//�����϶�����  
			self.onError=null;   
			currentX = currentY = 30;   
			whichIt = null;   
			lastScrollX = 0; lastScrollY = 0;   
			NS = (document.layers) ? 1 : 0;   
			IE = (document.all) ? 1: 0;   
			function heartBeat() {   
			if(IE) { diffY = document.body.scrollTop; diffX = document.body.scrollLeft; }   
			if(NS) { diffY = self.pageYOffset; diffX = self.pageXOffset; }   
			if(diffY != lastScrollY) {   
			percent = .1 * (diffY - lastScrollY);   
			if(percent > 0) percent = Math.ceil(percent);   
			else percent = Math.floor(percent);   
			if(IE) document.all.timediv.style.pixelTop += percent;   
			if(NS) document.timediv.top += percent;   
			lastScrollY = lastScrollY + percent;   
			}   
			if(diffX != lastScrollX) {   
			percent = .1 * (diffX - lastScrollX);   
			if(percent > 0) percent = Math.ceil(percent);   
			else percent = Math.floor(percent);   
			if(IE) document.all.timediv.style.pixelLeft += percent;   
			if(NS) document.timediv.left += percent;   
			lastScrollX = lastScrollX + percent;   
			}   
			}   
			function checkFocus(x,y) {   
			stalkerx = document.timediv.pageX;   
			stalkery = document.timediv.pageY;   
			stalkerwidth = document.timediv.clip.width;   
			stalkerheight = document.timediv.clip.height;   
			if( (x > stalkerx && x < (stalkerx+stalkerwidth)) && (y > stalkery && y < (stalkery+stalkerheight))) return true;   
			else return false;   
			}   
			function grabIt(e) {   
			if(IE) {   
			whichIt = event.srcElement;   
			  
			while (whichIt.id.indexOf("timediv") == -1) {   
			whichIt = whichIt.parentElement;   
			if (whichIt == null) { return true; }   
			}   
			whichIt.style.pixelLeft = whichIt.offsetLeft;   
			whichIt.style.pixelTop = whichIt.offsetTop;   
			currentX = (event.clientX + document.body.scrollLeft);   
			currentY = (event.clientY + document.body.scrollTop);   
			} else {   
			window.captureEvents(Event.MOUSEDOWN);   
			if(checkFocus (e.pageX,e.pageY)) {   
			whichIt = document.timediv;   
			StalkerTouchedX = e.pageX-document.timediv.pageX;   
			StalkerTouchedY = e.pageY-document.timediv.pageY;   
			}   
			}   
			return true;   
			}   
			function moveIt(e) {   
			if (whichIt == null) { return false; }   
			if(IE) {   
			newX = (event.clientX + document.body.scrollLeft);   
			newY = (event.clientY + document.body.scrollTop);   
			distanceX = (newX - currentX);    distanceY = (newY - currentY);   
			currentX = newX;    currentY = newY;   
			whichIt.style.pixelLeft += distanceX;   
			whichIt.style.pixelTop += distanceY;   
			if(whichIt.style.pixelTop < document.body.scrollTop) whichIt.style.pixelTop = document.body.scrollTop;   
			if(whichIt.style.pixelLeft < document.body.scrollLeft) whichIt.style.pixelLeft = document.body.scrollLeft;   
			if(whichIt.style.pixelLeft > document.body.offsetWidth - document.body.scrollLeft - whichIt.style.pixelWidth - 20) whichIt.style.pixelLeft = document.body.offsetWidth - whichIt.style.pixelWidth - 20;   
			if(whichIt.style.pixelTop > document.body.offsetHeight + document.body.scrollTop - whichIt.style.pixelHeight - 5) whichIt.style.pixelTop = document.body.offsetHeight + document.body.scrollTop - whichIt.style.pixelHeight - 5;   
			event.returnValue = false;   
			} else {   
			whichIt.moveTo(e.pageX-StalkerTouchedX,e.pageY-StalkerTouchedY);   
			if(whichIt.left < 0+self.pageXOffset) whichIt.left = 0+self.pageXOffset;   
			if(whichIt.top < 0+self.pageYOffset) whichIt.top = 0+self.pageYOffset;   
			if( (whichIt.left + whichIt.clip.width) >= (window.innerWidth+self.pageXOffset-17)) whichIt.left = ((window.innerWidth+self.pageXOffset)-whichIt.clip.width)-17;   
			if( (whichIt.top + whichIt.clip.height) >= (window.innerHeight+self.pageYOffset-17)) whichIt.top = ((window.innerHeight+self.pageYOffset)-whichIt.clip.height)-17;   
			return false;   
			}   
			return false;   
			}   
			function dropIt() {   
			whichIt = null;   
			if(NS) window.releaseEvents (Event.MOUSEDOWN);   
			return true;   
			}   
			if(NS) {   
			window.captureEvents(Event.MOUSEUP|Event.MOUSEDOWN);   
			window.onmousedown = grabIt;   
			window.onmousemove = moveIt;   
			window.onmouseup = dropIt;   
			}   
			if(IE) {   
			document.onmousedown = grabIt;   
			document.onmousemove = moveIt;   
			document.onmouseup = dropIt;   
			}   
			if(NS || IE) action = window.setInterval("heartBeat()",1);  
			timediv.style.visibility="visible";  
			timediv.style.pixeltop=document.body.scrollTop+timediv.style.pixelHeight;  
			timediv.style.pixelLeft=document.body.clientWidth-167;  
		</SCRIPT>
	</body>
</HTML>
