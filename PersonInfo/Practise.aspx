<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.Practise" CodeFile="Practise.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

		<title>正在考试</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
       <link href="../Css/images/ks_exam.css" rel="stylesheet" type="text/css" />
		<script language="JavaScript" src="../JavaScript/MouseEvent.js"></script>
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
		<script language="JavaScript">
		  
			var time_minute=0;
			var time_second=30;
			var time_passed=0;
			var timeid=null;
			var timerun=false;
			var autosavetime=0;
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
  				if (time_second==0)
  				{
    				time_second=59;
    				time_minute-=1;
    				time_passed+=1;
  				} 
  				else
  				{
    				time_second-=1;
    				time_passed+=1;
  				};
  				
  				if (time_minute<0)//考试时间到，自动提交答卷
  				{ 
    				
    				nextbtnclick();
  				}
  				else
  				{
    				document.getElementById("label_time").innerHTML=time_minute+"分"+time_second+"秒";
    				timeid=setTimeout("showtime()",1000);
    				timerun=true;
    				document.getElementById("timeminute").value=time_minute;                                                
    				document.getElementById("timesecond").value=time_second;
  				}
			}
			
			function textcheck()//文本检查
			{
			    var inputstr=window.event.srcElement.value;
			    if (inputstr.indexOf(",")>0)
			    {
			        var reg=new RegExp(",","g");
			        inputstr=inputstr.replace(reg,"，");
			        //alert("注：填空类试题答案中不能包含半角逗号“,”，将自动替换为全角逗号“，”。");
			        window.event.srcElement.value=inputstr;
			        window.event.keyCode=0;
			        window.event.srcElement.focus;
			        window.event.returnValue=0;
			    }
			}
			function testcheck(TestNum)//试题检查
			{
			    var testcheck=false;
			    var BaseTestType=document.getElementById("BaseTestType"+TestNum).value;
			    var slen=document.getElementById("Answer"+TestNum).length;
			    if (slen==undefined) slen=1;
			    var icount=0;
			    switch(BaseTestType)
			    {
			        case "单选类":
			            if (slen<=1)
			            {
			                if (document.getElementById("Answer"+TestNum).checked)
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else
			            {
			                for(j=0;j<=slen-1;j++)
			                {
			                    if (document.getElementById("Answer"+TestNum).item(j).checked)
			                    {
			                        testcheck=true;
			                        return testcheck;
			                    }
			                }
			            };
			            break;
			        case "多选类":
			            if (slen<=1)
			            {
			                if (document.getElementById("Answer"+TestNum).checked)
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else
			            {
			                for(j=0;j<=slen-1;j++)
			                {
			                    if (document.getElementById("Answer"+TestNum).item(j).checked)
			                    {
			                        testcheck=true;
			                        return testcheck;
			                    }
			                }
			            };
			            break;
			        case "判断类":
			            if (slen<=1)
			            {
			                if (document.getElementById("Answer"+TestNum).checked)
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else
			            {
			                for(j=0;j<=slen-1;j++)
			                {
			                    if (document.getElementById("Answer"+TestNum).item(j).checked)
			                    {
			                        testcheck=true;
			                        return testcheck;
			                    }
			                }
			            };
			            break;
			        case "填空类":
			            if (slen<=1)
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else
			            {    
			                for(j=0;j<=slen-1;j++)
			                {
			                    if (trim(document.getElementById("Answer"+TestNum).item(j).value)!="")	icount=icount+1;
			                }
			                if (icount==slen)
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            };
			            break;
			        case "问答类":
			            if (slen<=1)
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else 
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            };
			            break;
			        case "作文类":
			            if (slen<=1)
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else 
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            };
			            break;
			        case "操作类":
			            if (slen<=1)
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else 
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            };
			            break;	
			        case "打字类":
			            if (slen<=1)
			            {
			                if (trim(document.getElementById("Answer"+TestNum).value)!="")
			                {
			                    testcheck=true;
			                    return testcheck;
			                }
			            }	
			            else
			            {    
			                for(j=0;j<=slen-1;j++)
			                {
			                    if (trim(document.getElementById("Answer"+TestNum).item(j).value)!="")	icount=icount+1;
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
			function checkanswer()//检查答卷
			{
			    form1.target="";
			    form1.action="StartExamOne.aspx?PaperID="+document.getElementById("PaperID").value+"&UserScoreID="+document.getElementById("UserScoreID").value+"&TestNum="+document.getElementById("irow").value+"&CheckAnswer=yes";
			    form1.submit();
			}
			function trysubmit()//尝试提交
			{
			    form1.target="";
			    form1.action="StartExamOne.aspx?PaperID="+document.getElementById("PaperID").value+"&UserScoreID="+document.getElementById("UserScoreID").value+"&TestNum="+document.getElementById("irow").value+"&TrySubmit=yes";
			    form1.submit();
			}
			function cancel()//取消提交
			{
			    submitexam3.style.visibility="hidden";
			}
			function cancel1()//关闭检查答卷
			{
			    submitexam4.style.visibility="hidden";
			}
			function save()//保存答卷
			{
			    submitexam.style.visibility="hidden";
			    submitexam1.style.visibility="visible";
			    submitexam2.style.visibility="hidden";
			    submitexam3.style.visibility="hidden";
			    submitexam4.style.visibility="hidden";
			    form1.action="SaveExamOne.aspx";
			    form1.target="iframe1";
			    form1.submit();
			    form1.target="";
			    form1.action="";
			}
			function submit()//正式提交
			{
			    submitexam1.style.visibility="hidden";
			    submitexam2.style.visibility="visible";
			    submitexam3.style.visibility="hidden";
			    submitexam4.style.visibility="hidden";
			    submitexam.style.visibility="hidden";
			    form1.target="";
			    form1.action="SubmExamOne.aspx";
			    form1.submit();
			}
			function timeend()//时间结束
			{
			    submitexam.style.visibility="visible";
			    submitexam1.style.visibility="hidden";
			    submitexam2.style.visibility="hidden";
			    submitexam3.style.visibility="hidden";
			    submitexam4.style.visibility="hidden";
			    nextbtnclick();
			}

			function seltestnum()//选择题号
			{
			    submitexam0.style.visibility="visible";
			    form1.target="";
			    form1.action="StartExamOne.aspx?PaperID="+document.getElementById("PaperID").value+"&UserScoreID="+document.getElementById("UserScoreID").value+"&TestNum="+document.getElementById("irow").value+"&SelTestNum="+document.getElementById("select1").value+"&SelectTest=yes";
			    form1.submit()                                                                                                                                                                    
			}                     
			function priobtnclick()//选择上一题
			{
			    submitexam0.style.visibility="visible";
			    form1.target=""                                                                               
			    form1.action="StartExamOne.aspx?PaperID="+document.getElementById("PaperID").value+"&UserScoreID="+document.getElementById("UserScoreID").value+"&TestNum="+document.getElementById("irow").value+"&PriorTest=yes";
			    form1.submit()        
			}
			function nextbtnclick()//选择下一题
			{
				
			    submitexam0.style.visibility="visible";
			    form1.target="";
			    form1.action="Practise.aspx?PaperID="+document.getElementById("PaperID").value;
			    form1.submit();
			}
			function selecttest(intTestNum)//跳转题号
			{
			    submitexam0.style.visibility="visible";
			    form1.target="";
			    form1.action="StartExamOne.aspx?PaperID="+document.getElementById("PaperID").value+"&UserScoreID="+document.getElementById("UserScoreID").value+"&TestNum="+document.getElementById("irow").value+"&SelTestNum="+intTestNum+"&SelectTest=yes";
			    form1.submit()                                                                                                                                            
			}                                                                                  
		</script>
	</HEAD>
	<body onselectstart="return false" onkeydown="onKeyDown();" leftMargin="0" topMargin="0"
		onload="starttime();" rightMargin="0">
          <div id="page" class="shell">
          
           <div class="ks_wrap">
  <div class="shijuancon">
    <div class="ks110_juan">
    
      <div class="e_j_left"> <a href="http://exam.kaoshi110.net/"> <img src="../Css/images/d_1.jpg" border="0" height="45" width="161"></a></div>
      <div class="e_j_center">老师：mango <span id="lblSubTitle">总共<%=strTestCount%>题</span></div>
    </div>
     <div class="ks110_zhong">
        <div class="ks110_list" id="tbody110608">
		<div id="main">
    <form name="form1" action="Practise.aspx" method="post">
			<input type=hidden size=4 value="<%=intPaperID%>" name=PaperID id="PaperID">
            
            <input type=hidden size=4 value="<%=intTestTypeID%>" name=TestTypeID id="TestTypeID">

            <input type=hidden size=4 value="<%=strLoreID%>" name=LoreID id="LoreID">
           
            <input type=hidden size=4 value="<%=strPractiseTime%>" name=PractiseTime id="PractiseTime">  
            
             <input type=hidden size=4 value="<%=strTempRubricID%>" name=strTempRubricID id="strTempRubricID">    
            
	
		
			<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0">
				<tr>
					<td height="6"></td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0" style="LINE-HEIGHT: 200%">
							<tr>
								<td vAlign="bottom"><FONT face="宋体"></FONT><span id="lblTitle" style="FONT-WEIGHT: bold; FONT-SIZE: 14pt"><%=strPaperName%></span></td>
							  <td vAlign="bottom" align="right" width="20%"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px" bgColor="#F1F1EF" height="2"></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 20px" height="20"><span id="lblMessage" style="COLOR: red"></span></TD>
				</TR>
			</table>
			<TABLE align="center" cellSpacing="0" id="eaxmbox">
				
				<TR>
					<TD align="left" bgColor="#E0E0E0" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr class="tableheader">
								<td align="left" width="50%" height="40">&nbsp;</td>
								<td align="right" width="50%" height="40"><strong>进度:</strong><%=strPlan%>&nbsp;</td>
							</tr>
						</table>
					</TD>
			  </TR>
				<TR>
					<TD style="WORD-BREAK: break-all" bgColor="#ffffff" colSpan="2"  class="shitibox" >
						<div >
							<%=strPaperContent%>
						</div>
                   
 <div id="kaoshitime">
剩余时间:<label id="label_time">00分00秒</label></div>
<div id="submitexam2" class="tishibox" >
			<table width="300" border="0" cellpadding="0" cellspacing="1" bgcolor="#666666">
				<tr>
					<td width="300" height="50" bgcolor="#ff99cc">
						<div align="center">正在提交答卷，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam1" class="tishibox" >
			<table width="300" border="0" cellpadding="0" cellspacing="1" bgcolor="#666666">
				<tr>
					<td width="300" height="50" bgcolor="#33cccc"><div align="center">正在保存答卷，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam0" class="tishibox"  >
			<table width="300" height="50" border="0" cellpadding="0" cellspacing="1" bgcolor="#666666">
				<tr>
					<td width="300" height="50" bgcolor="#3333cc"><div align="center"><font color="#ffffff">正在载入试题，请稍候...</font></div>
					</td>
				</tr>
			</table>
		</div>
		<div id="submitexam" class="tishibox" >
			<table width="300" border="0" cellpadding="0" cellspacing="1" bgcolor="#666666">
				<tr>
					<td width="300" height="50" bgcolor="#ff99cc"><div align="center">考试时间已到，转到下一题，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
</TD>
				</TR>
				<TR align="center">
					<TD class="tableheader" align="center" colSpan="2" height="32"><INPUT class="button" id="nextbtn" onClick="nextbtnclick();" type="button" value=" 下一题 "
							name="nextbtn">
						
					</TD>
				</TR>
			</TABLE>
			<input type=hidden size=4 value="<%=intTestNum%>" name=irow id="irow">
		</form>
		
		<%=strSubmitExam%>
		<%=strCheckAnswer%>
		<iframe name="iframe1" src="SaveExamOne.aspx" frameBorder="0" width="0%" scrolling="yes"
			height="0%"></iframe>
		<%=strJavaScript%>
		<!-- END Two Column Content -->
	</div>
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
		
         </div>
  <div class="clear"> </div>
</div>
		<iframe name="iframe1" src="SaveJobAll.aspx" frameBorder="0" width="0%" scrolling="yes"
			height="0%"></iframe>
          
          
          
   
	</body>
</HTML>
