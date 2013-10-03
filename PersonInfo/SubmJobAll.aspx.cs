using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text;

namespace EasyExam.PersonalInfo
{
	/// <summary>
	/// SubmJobAll ��ժҪ˵����
	/// </summary>
	public partial class SubmJobAll : System.Web.UI.Page
	{
		protected string strMessage="";
		PublicFunction ObjFun=new PublicFunction();
		int intPaperID=0,intUserScoreID=0,intRemTime=0,intRemMinute=0,intRemSecond=0,intTestAmount=0;
		int intPassMark=0,intFillAutoGrade=0,intSeeResult=0,intPassState=0,intAutoJudge=0,intJudgeState=0,intJudgeUserID=0;
		string strRubricID="",strBaseTestType="",strUserAnswer="",strMsg="";
		double dblUserScore=0,dblImpScore=0,dblSubScore=0;
		string[] strArrTypeStandardAnswer,strArrTypeUserAnswer;
		string[] strArrUserAnswer,strArrStandardAnswer;
        string myUserID, myLoginID, myUserName;
        int cornum = 0;

		#region//*********��ʼ��Ϣ*******
		protected void Page_Load(object sender, System.EventArgs e)
		{
			intPaperID=Convert.ToInt32(Request["PaperID"]);
			intUserScoreID=Convert.ToInt32(Request["UserScoreID"]);
			intRemMinute=Convert.ToInt32(Request["timeminute"]);
			intRemSecond=Convert.ToInt32(Request["timesecond"]);
			intRemTime=intRemMinute*60+intRemSecond;//��ҵʣ��ʱ��
			intTestAmount=Convert.ToInt32(Request["irow"]);//��������

			intPassMark=Convert.ToInt32(Request["PassMark"]);
			intFillAutoGrade=Convert.ToInt32(Request["FillAutoGrade"]);
			intSeeResult=Convert.ToInt32(Request["SeeResult"]);
			intAutoJudge=Convert.ToInt32(Request["AutoJudge"]);

            myUserID = Session["UserID"].ToString();
            myLoginID = Session["LoginID"].ToString();
            myUserName = Session["UserName"].ToString();

			if (intPaperID!=0)
			{
                

                    SqlDataAdapter SqlCmdTest=null;
                    DataSet SqlDSTest=null;

					

					StringBuilder BuilderRubricID=new StringBuilder();    //����ID
					StringBuilder BuilderUserAnswer=new StringBuilder();  //��
					StringBuilder BuilderUserScore=new StringBuilder();   //�÷�

                  

                    SqlDSTest = AccessDateHelper.ExecuteDataset("select a.TestMark,b.StandardAnswer,a.RubricID from PaperTest a,RubricInfo b,PaperTestType c where a.RubricID=b.RubricID and b.TestTypeID=c.TestTypeID and  a.PaperID=" + intPaperID + "");
					dblImpScore=0;dblSubScore=0;
					for(int i=0;i<SqlDSTest.Tables[0].Rows.Count;i++)
					{
						dblUserScore=0;
						strRubricID=Convert.ToString(Request["RubricID"+SqlDSTest.Tables[0].Rows[i]["RubricID"].ToString()]);
						strBaseTestType=Convert.ToString(Request["BaseTestType"+SqlDSTest.Tables[0].Rows[i]["RubricID"].ToString()]);
						strUserAnswer=Convert.ToString(Request["Answer"+SqlDSTest.Tables[0].Rows[i]["RubricID"].ToString()]);
						if (strUserAnswer==null)
						{
							strUserAnswer="";
						}
						if (strUserAnswer.Length>2000)
						{
							strUserAnswer=strUserAnswer.Substring(0,2000);
						}
						strUserAnswer=strUserAnswer.Replace("|","��");
						switch(strBaseTestType)
						{
							case "��ѡ��":
								strUserAnswer=strUserAnswer.Trim().Replace(",","");
								strUserAnswer=strUserAnswer.Trim().Replace(" ","");
								if (strUserAnswer.ToUpper()==SqlDSTest.Tables[0].Rows[i]["StandardAnswer"].ToString().Replace(" ","").ToUpper())
								{
									dblUserScore=1;
									dblImpScore=dblImpScore+dblUserScore;
								}
								break;
							case "��ѡ��":
								strUserAnswer=strUserAnswer.Trim().Replace(",","");
								strUserAnswer=strUserAnswer.Trim().Replace(" ","");
								if (strUserAnswer.ToUpper()==SqlDSTest.Tables[0].Rows[i]["StandardAnswer"].ToString().Replace(" ","").ToUpper())
								{
									dblUserScore=1;
									dblImpScore=dblImpScore+dblUserScore;
								}
								break;
							case "�ж���":
								strUserAnswer=strUserAnswer.Trim().Replace(",","");
								strUserAnswer=strUserAnswer.Trim().Replace(" ","");
								if (strUserAnswer.ToUpper()==SqlDSTest.Tables[0].Rows[i]["StandardAnswer"].ToString().Replace(" ","").ToUpper())
								{
									dblUserScore=1;
									dblImpScore=dblImpScore+dblUserScore;
								}
								break;
							case "�����":
								strUserAnswer=strUserAnswer.Trim().Replace(" ","");
								if (intFillAutoGrade==1)
								{
									strArrUserAnswer=strUserAnswer.ToUpper().Split(',');
									strArrStandardAnswer=SqlDSTest.Tables[0].Rows[i]["StandardAnswer"].ToString().Replace(" ","").ToUpper().Split(',');
									for(int j=1;j<=Math.Min(strArrUserAnswer.Length,strArrStandardAnswer.Length);j++)
									{
										if (strArrUserAnswer[j-1]==strArrStandardAnswer[j-1])
										{
											dblUserScore=1;
										}
									}
									dblSubScore=dblSubScore+dblUserScore;
								}
								break;
							case "�ʴ���":
								break;
							case "������":
								break;
							case "������":
								strArrTypeStandardAnswer=SqlDSTest.Tables[0].Rows[i]["StandardAnswer"].ToString().Split(',');
								if (strUserAnswer.ToString().IndexOf(",")>=0)
								{
									strArrTypeUserAnswer=strUserAnswer.Trim().Split(',');
								}
								else
								{
									strArrTypeUserAnswer="0,0".Split(',');
								}
								dblUserScore=System.Math.Round(Convert.ToDouble(SqlDSTest.Tables[0].Rows[i]["TestMark"])*System.Math.Min(1,Convert.ToDouble(strArrTypeUserAnswer[0])/Convert.ToDouble(strArrTypeStandardAnswer[1]))*(Convert.ToDouble(strArrTypeUserAnswer[1])/100),1);
								dblImpScore=dblImpScore+dblUserScore;
								break;
							case "������":
								break;
						}
                        
                        if (AccessDateHelper.ExecuteNonQuery("select RubricID from PractiseRecord where UserID=" + myUserID + " and PaperID=" + intPaperID + " and RubricID=" + SqlDSTest.Tables[0].Rows[i]["RubricID"].ToString() + "") == null)
                        {
                            AccessDateHelper.ExecuteNonQuery("insert into PractiseRecord (UserID,PaperID,RubricID,Answer,IsCorrect,PractiseTime) values("+Convert.ToInt32(myUserID)+","+intPaperID+","+Convert.ToInt32(SqlDSTest.Tables[0].Rows[i]["RubricID"])+",'" + ObjFun.getStr(strUserAnswer, 2000) + "',"+dblUserScore+","+DateTime.Now+")");
                        }

                        AccessDateHelper.ExecuteNonQuery("Update PractiseRecord set Answer='" + ObjFun.getStr(strUserAnswer, 2000) + "',IsCorrect=" + dblUserScore + ",PractiseTime='" + DateTime.Now + "'  where UserID=" + myUserID + " and PaperID=" + intPaperID + " and RubricID=" + SqlDSTest.Tables[0].Rows[i]["RubricID"].ToString() + "");

                        cornum =cornum+ Convert.ToInt16(dblUserScore);
						BuilderRubricID.Append(strRubricID+"|");
						BuilderUserAnswer.Append(strUserAnswer+"|");
						BuilderUserScore.Append(dblUserScore.ToString()+"|");
					}
                   
                int testnum = Convert.ToInt16( AccessDateHelper.ExecuteScalar("select count(RubricID) from PaperTest where PaperID="+intPaperID+""));
                int testrennum = Convert.ToInt16(AccessDateHelper.ExecuteScalar("select count(*) from (select distinct UserID from PractiseRecord where PaperID=" + intPaperID + ") "));
                int type_dx = Convert.ToInt16(AccessDateHelper.ExecuteScalar("select count(r.RubricID) from PaperTest p left join RubricInfo r on p.RubricID=r.RubricID where r.TestTypeID=27 and p.PaperID="+intPaperID+""));
                int type_dx2 = Convert.ToInt16(AccessDateHelper.ExecuteScalar("select count(r.RubricID) from PaperTest p left join RubricInfo r on p.RubricID=r.RubricID where r.TestTypeID=28 and p.PaperID=" + intPaperID + ""));
                int type_dx3 = Convert.ToInt16(AccessDateHelper.ExecuteScalar("select count(r.RubricID) from PaperTest p left join RubricInfo r on p.RubricID=r.RubricID where r.TestTypeID=29 and p.PaperID=" + intPaperID + ""));
                int type_dx4 = Convert.ToInt16(AccessDateHelper.ExecuteScalar("select count(r.RubricID) from PaperTest p left join RubricInfo r on p.RubricID=r.RubricID where r.TestTypeID=30 and p.PaperID=" + intPaperID + ""));


					strMessage+="<table width='100%' border='0' cellpadding='10' cellspacing='1' bgcolor='#52D6E9'><tr><td height='51' colspan='2' align='center' valign='middle' bgcolor='#CDF1FC' style='font-size:24px; font-family:'Microsoft YaHei UI', Arial'>��ҵ���ͳ��</td></tr><tr>";
    strMessage+="<td width='46%' bgcolor='#FFFFFF'>����������"+testnum+"��<br />";
    strMessage+="��ѡ�⣺"+type_dx+"��<br />";
    strMessage += " ��ѡ�⣺" + type_dx2 + "��<br />";
    strMessage += " ����⣺" + type_dx4 + "��<br />";
    strMessage += "�ж��⣺" + type_dx3 + "��</td>";
    strMessage += "<td width='54%' bgcolor='#FFFFFF'>�����ԣ�" + cornum + "��</td>";
  strMessage+="</tr>";
  strMessage+="<tr>";
    strMessage+="<td bgcolor='#FFFFFF'>�μ�������"+testrennum+"</td>";
    strMessage += "<td bgcolor='#FFFFFF'>������" + (testnum-cornum) + "��</td>";
  strMessage+="</tr>";
  strMessage += "<tr>";
  strMessage = strMessage + "<td align'right'><input class='button' type='button' name='cancel'  value='�鿴���' onclick=javascript:{NewWin=window.open('ShowMyAnswer.aspx?PaperID=" + intPaperID + "','ShowAnswer','titlebar=yes,menubar=no,toolbar=no,location=no,directories=no,status=yes,scrollbars=yes,resizable=no,copyhistory=yes,top=0,left=0,width=screen.availWidth,height=screen.availHeight');NewWin.moveTo(0,0);NewWin.resizeTo(screen.availWidth,screen.availHeight);}></td>";
    strMessage=strMessage+"<td align='left'></td>";
  
  strMessage += "</tr>";
  strMessage += "</table>";
					
					
                   

					
                    //strMsg="���Ѿ��ɹ��ύ���";
					
                    ////��ʾ��Ϣ
                    //strMessage=strMessage+"<form id='form1' method='post'>";
                    //strMessage=strMessage+"<table width='100%' border='0' height='100%'>";
                    //strMessage=strMessage+"<tr align='center'><td>";
                    //strMessage=strMessage+"<table border='1' bordercolorlight='#000000' bordercolordark='#FFFFFF' cellspacing='0' bgcolor='#99CCFF'>";
                    //strMessage=strMessage+"<tr><td><table border='0' bgcolor='#0033CC' cellspacing='0' cellpadding='2' width='700'>";
                    //strMessage=strMessage+"<tr><td style='font-size: 12pt; color: #FFFFFF' width='423'>����ҵ���</td>";
                    //strMessage=strMessage+"</tr></table>";
                    //strMessage=strMessage+"<table border='0' width='700' cellpadding='4'>";
                    //strMessage=strMessage+"<tr>";
                    //strMessage=strMessage+"<td style='font-size: 36pt; color: black' align=center width='700' height=300><p style='line-height: 100%'><B>"+strMsg+"</B></td></tr><tr><td colspan='2' align='center' valign='top'>";
                    //strMessage=strMessage+"<input class='button' type='button' name='cancel'  value='������ҵ' onclick='window.close()'>";
                    //if (intSeeResult==1)
                    //{
                    //    strMessage=strMessage+"<input class='button' type='button' name='cancel'  value='�鿴���' onclick=javascript:{NewWin=window.open('ShowAnswer.aspx?UserScoreID="+intUserScoreID+"','ShowAnswer','titlebar=yes,menubar=no,toolbar=no,location=no,directories=no,status=yes,scrollbars=yes,resizable=no,copyhistory=yes,top=0,left=0,width=screen.availWidth,height=screen.availHeight');NewWin.moveTo(0,0);NewWin.resizeTo(screen.availWidth,screen.availHeight);}>";
                    //    strMessage=strMessage+"<input class='button' type='button' name='cancel'  value='���ͳ��' onclick=javascript:{NewWin=window.open('ShowStatis.aspx?UserScoreID="+intUserScoreID+"','ShowStatis','titlebar=yes,menubar=no,toolbar=no,location=no,directories=no,status=yes,scrollbars=yes,resizable=no,copyhistory=yes,top=0,left=0,width=screen.availWidth,height=screen.availHeight');NewWin.moveTo(0,0);NewWin.resizeTo(screen.availWidth,screen.availHeight);}>";
                    //}
                    //strMessage=strMessage+"</td></tr></table></td></tr></table>";
                    //strMessage=strMessage+"</td></tr></table>";
                    //strMessage=strMessage+"</form>";
                //}
                //catch
                //{
                //    //��ʾ��Ϣ
                //    strMessage=strMessage+"<form id='form1' method='post' action='SubmJobAll.aspx'>";
                //    foreach(string item in Request.Form)
                //    {
                //        strMessage=strMessage+"<input type='hidden' name='"+item+"' value='"+Request.Form[item].ToString()+"'>";
                //    }
                //    strMessage=strMessage+"<table width='100%' border='0' height='100%'>";
                //    strMessage=strMessage+"<tr align='center'><td align='center'>";
                //    strMessage=strMessage+"<table border='1' bordercolorlight='#000000' bordercolordark='#FFFFFF' cellspacing='0' bgcolor='#99CCFF'>";
                //    strMessage=strMessage+"<tr><td><table border='0' bgcolor='#0033CC' cellspacing='0' cellpadding='2' width='350'>";
                //    strMessage=strMessage+"<tr><td style='font-size:12pt; color:#FFFFFF' width='360'>����ʾ��Ϣ</td>";
                //    strMessage=strMessage+"</tr></table>";
                //    strMessage=strMessage+"<table border='0' width='350' cellpadding='4'>";
                //    strMessage=strMessage+"<tr><td width='59' align='center' valign='top'><img border='0' src='../images/Information.gif'></td>";
                //    strMessage=strMessage+"<td style='font-size: 12pt; color: black' width='269'>�ύ���ʧ�ܣ������Ա������ݿ�������������Ƿ��������������������ύһ�Ρ�</td></tr><tr><td colspan='2' align='center' valign='top'>";
                //    strMessage=strMessage+"<input class='button' type='submit' name='ok' id='ok' value='�����ύ'>";
                //    strMessage=strMessage+"<input class='button' type='button' name='cancel'  value='�رմ���' onclick='window.close()'>";
                //    strMessage=strMessage+"</td></tr></table></td></tr></table>";
                //    strMessage=strMessage+"</td></tr></table>";
                //    strMessage=strMessage+"</form>";
                //}
			}
		}
		#endregion

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}
