<%@ Page language="c#" Inherits="EasyExam.PersonalInfo.StartExamOne" CodeFile="StartExamOne.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>正在考试</title>
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/STYLE.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../JavaScript/MouseEvent.js"></script>
		<script language="JavaScript" src="../JavaScript/Common.js"></script>
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
  				if (time_passed%autosavetime==0)
  				{
    				save();//保存答卷
    				time_passed=0;
  				};
  				if (time_minute<0)//考试时间到，自动提交答卷
  				{ 
    				submitexam.style.visibility="visible"
	   				submitexam1.style.visibility="hidden";
    				submitexam2.style.visibility="hidden";
    				submitexam3.style.visibility="hidden";
    				submitexam4.style.visibility="hidden";
    				timeend();
  				}
  				else
  				{
    				document.all.label_time.innerHTML=time_minute+"分"+time_second+"秒";
    				timeid=setTimeout("showtime()",1000);
    				timerun=true;
    				document.all("timeminute").value=time_minute;                                                
    				document.all("timesecond").value=time_second;
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
				var BaseTestType=document.all("BaseTestType"+TestNum).value;
				var slen=document.all("Answer"+TestNum).length;
				if (slen==undefined) slen=1;
				var icount=0;
				switch(BaseTestType)
				{
					case "单选类":
						if (slen<=1)
						{
							if (document.all("Answer"+TestNum).checked)
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{
							for(j=0;j<=slen-1;j++)
							{
								if (document.all("Answer"+TestNum).item(j).checked)
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
							if (document.all("Answer"+TestNum).checked)
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{
							for(j=0;j<=slen-1;j++)
							{
								if (document.all("Answer"+TestNum).item(j).checked)
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
							if (document.all("Answer"+TestNum).checked)
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{
							for(j=0;j<=slen-1;j++)
							{
								if (document.all("Answer"+TestNum).item(j).checked)
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
					        if (trim(document.all("Answer"+TestNum).value)!="")
					        {
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{    
							for(j=0;j<=slen-1;j++)
							{
								if (trim(document.all("Answer"+TestNum).item(j).value)!="")	icount=icount+1;
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
							if (trim(document.all("Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else 
						{
							if (trim(document.all("Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;
					case "作文类":
						if (slen<=1)
						{
							if (trim(document.all("Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else 
						{
							if (trim(document.all("Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;
					case "操作类":
						if (slen<=1)
						{
							if (trim(document.all("Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						}	
						else 
						{
							if (trim(document.all("Answer"+TestNum).value)!="")
							{
								testcheck=true;
								return testcheck;
							}
						};
						break;	
					case "打字类":
					    if (slen<=1)
					    {
					        if (trim(document.all("Answer"+TestNum).value)!="")
					        {
								testcheck=true;
								return testcheck;
							}
						}	
						else
						{    
							for(j=0;j<=slen-1;j++)
							{
								if (trim(document.all("Answer"+TestNum).item(j).value)!="")	icount=icount+1;
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
				form1.action="StartExamOne.aspx?PaperID="+document.all("PaperID").value+"&UserScoreID="+document.all("UserScoreID").value+"&TestNum="+document.all("irow").value+"&CheckAnswer=yes";
				form1.submit();
			}
			function trysubmit()//尝试提交
			{
				form1.target="";
				form1.action="StartExamOne.aspx?PaperID="+document.all("PaperID").value+"&UserScoreID="+document.all("UserScoreID").value+"&TestNum="+document.all("irow").value+"&TrySubmit=yes";
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
				form1.target="";
				form1.action="SubmExamOne.aspx";
				form1.submit();
			}

			function seltestnum()//选择题号
			{
				submitexam0.style.visibility="visible";
				form1.target="";
				form1.action="StartExamOne.aspx?PaperID="+document.all("PaperID").value+"&UserScoreID="+document.all("UserScoreID").value+"&TestNum="+document.all("irow").value+"&SelTestNum="+document.all("select1").value+"&SelectTest=yes";
				form1.submit()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
			}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
			function priobtnclick()//选择上一题
			{
				submitexam0.style.visibility="visible";
				form1.target=""                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
				form1.action="StartExamOne.aspx?PaperID="+document.all("PaperID").value+"&UserScoreID="+document.all("UserScoreID").value+"&TestNum="+document.all("irow").value+"&PriorTest=yes";
				form1.submit()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
			}
			function nextbtnclick()//选择下一题
			{
				submitexam0.style.visibility="visible";
				form1.target="";
				form1.action="StartExamOne.aspx?PaperID="+document.all("PaperID").value+"&UserScoreID="+document.all("UserScoreID").value+"&TestNum="+document.all("irow").value+"&NextTest=yes";
				form1.submit();
			}
			function selecttest(intTestNum)//跳转题号
			{
				submitexam0.style.visibility="visible";
				form1.target="";
				form1.action="StartExamOne.aspx?PaperID="+document.all("PaperID").value+"&UserScoreID="+document.all("UserScoreID").value+"&TestNum="+document.all("irow").value+"&SelTestNum="+intTestNum+"&SelectTest=yes";
				form1.submit()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
			}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
		</script>
	</HEAD>
	<body onselectstart="return false" onkeydown="onKeyDown();" leftMargin="0" topMargin="0"
		onload="starttime();" rightMargin="0">
		<form name="form1" action="SubmExamOne.aspx" method="post">
			<input type=hidden size=4 value="<%=intPaperID%>" name=PaperID> <input type=hidden size=4 value="<%=intPassMark%>" name=PassMark>
			<input type=hidden size=4 value="<%=intFillAutoGrade%>" name=FillAutoGrade> <input type=hidden size=4 value="<%=intSeeResult%>" name=SeeResult>
			<input type=hidden size=4 value="<%=intAutoJudge%>" name=AutoJudge> <input type=hidden size=4 value="<%=intUserScoreID%>" name=UserScoreID>
			<input type="hidden" size="4" value="0" name="timeminute"> <input type="hidden" size="4" value="0" name="timesecond">
			<script language="JavaScript">
				document.all("timeminute").value=time_minute;
				document.all("timesecond").value=time_second;
			</script>
			<table cellSpacing="0" cellPadding="1" width="960" align="center" border="0">
				<tr>
					<td height="6"></td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="1" width="100%" align="center" border="0" style="LINE-HEIGHT: 200%">
							<tr>
								<td vAlign="bottom"><FONT face="宋体"></FONT><span id="lblTitle" style="FONT-WEIGHT: bold; FONT-SIZE: 14pt"><%=strPaperName%></span></td>
							  <td vAlign="bottom" align="right" width="20%"><span id="lblSubTitle">总共<%=strTestCount%>
										题共<%=strPaperMark%>分</span></td>
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
					<TD height="46"  colSpan="2" bgcolor="#CCCCCC"><font color="#ffffff">帐号:<%=strLoginID%>&nbsp;&nbsp;姓名:<%=strUserName%>&nbsp;&nbsp;</font>
					</TD>
			  </TR>
				<TR>
					<TD align="left" bgColor="#cee7ff" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="left" width="50%" height="40"><%=strTestTypeMark%></td>
								<td align="right" width="50%" height="40"><strong>进度:</strong><%=strPlan%>&nbsp;</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD style="WORD-BREAK: break-all" bgColor="#ffffff" colSpan="2" height="400" class="shitibox">
						<div >
							<%=strPaperContent%>
						</div>
                    <div id="kaoshitime">考试时间:<%=intExamTime%>
							分钟<br>
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
					<td width="300" height="50" bgcolor="#ff99cc"><div align="center">考试时间已到，正在提交答卷，请稍候...</div>
					</td>
				</tr>
			</table>
		</div>
</TD>
				</TR>
				<TR align="center">
					<TD class="tablebody" align="center" colSpan="2" height="32">&nbsp;<span>选择题号:</span><%=strSelectOption%>&nbsp;&nbsp;
						<INPUT class="button" id="priobtn" onClick="priobtnclick();" type="button" value=" 上一题 "
							name="priobtn">&nbsp; <INPUT class="button" id="nextbtn" onClick="nextbtnclick();" type="button" value=" 下一题 "
							name="nextbtn">&nbsp;&nbsp; <input class="button" onClick="save();" type="button" value="保存答卷" name="submitbtn1">&nbsp;
						<input class="button" onClick="checkanswer();" type="button" value="检查答卷" name="submitbtn2">&nbsp;
						<input class="button" onClick="trysubmit();" type="button" value="提交答卷" name="submitbtn3">
					</TD>
				</TR>
			</TABLE>
			<input type=hidden size=4 value="<%=intTestNum%>" name=irow>
		</form>
		
		<%=strSubmitExam%>
		<%=strCheckAnswer%>
		<iframe name="iframe1" src="SaveExamOne.aspx" frameBorder="0" width="0%" scrolling="yes"
			height="0%"></iframe>
		<%=strJavaScript%>
	</body>
</HTML>
