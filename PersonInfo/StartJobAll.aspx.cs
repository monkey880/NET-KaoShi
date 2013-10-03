using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;


namespace EasyExam.PersonalInfo
{
	/// <summary>
	/// StartJobAll ��ժҪ˵����
	/// </summary>
	public partial class StartJobAll : System.Web.UI.Page
	{
		protected string strPaperName="";
		protected string strTestCount="";
		protected string strPaperMark="";
		protected string strPaperContent="";

		protected int intRemTime=0;
		protected int intRemMinute=0;
		protected int intRemSecond=0;
		protected int intAutoSaveTime=0;

		protected string strLoginID="";
		protected string strUserName="";
		protected int intExamTime=0;

		protected int intPaperID=0;
		protected int intPassMark=0;
		protected int intFillAutoGrade=0;
		protected int intSeeResult=0; 
		protected int intAutoJudge=0; 
		protected int intUserID=0;
		protected int intUserScoreID=0;
		protected int intTestNum=0;
		protected string strtable="";

		string myUserID="";
		string myLoginID="";
		string myUserName="";
		PublicFunction ObjFun=new PublicFunction();
		int k=0,intProduceWay=0,intOptionNum=0;
		double dblTotalMark=0;
		string strTestContent="";
		string[] strArrOptionContent,strArrTypeUserAnswer;

		#region//*********��ʼ��Ϣ*******
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				myUserID=Session["UserID"].ToString();
				myLoginID=Session["LoginID"].ToString();
				myUserName=Session["UserName"].ToString();
			}
			catch
			{
			}
			if (myLoginID=="")
			{
				Response.Redirect("../Login.aspx");
			}
			//�������
			Response.Expires=0;
			Response.Buffer=true;
			Response.Clear();

			intPaperID=Convert.ToInt32(Request["PaperID"]);
			intUserID=Convert.ToInt32(myUserID);

            if (!IsPostBack)
            {
                if (intPaperID != 0)
                {

                    DataSet SqlDS = null, SqlDSTestType = null, SqlDSTest = null;

                    strLoginID = Convert.ToString(myLoginID);
                    strUserName = Convert.ToString(myUserName);



                    SqlDS = AccessDateHelper.ExecuteDataset("select PaperName,ProduceWay,TestCount,PaperMark,ExamTime,AutoSave,PassMark,FillAutoGrade,SeeResult,AutoJudge from PaperInfo where PaperID=" + intPaperID + " order by PaperID asc");

                    strPaperName = SqlDS.Tables[0].Rows[0]["PaperName"].ToString();
                    intProduceWay = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["ProduceWay"]);
                    strTestCount = SqlDS.Tables[0].Rows[0]["TestCount"].ToString();
                    strPaperMark = SqlDS.Tables[0].Rows[0]["PaperMark"].ToString();
                    intExamTime = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["ExamTime"]);
                    intAutoSaveTime = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["AutoSave"]) * 60;
                    intPassMark = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["PassMark"]);
                    intFillAutoGrade = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["FillAutoGrade"]);
                    intSeeResult = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["SeeResult"]);
                    intAutoJudge = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["AutoJudge"]);

                    intRemMinute = intRemTime / 60;
                    intRemSecond = intRemTime % 60;

                    intTestNum = 0;
                  

                    SqlDSTestType = AccessDateHelper.ExecuteDataset("select a.TestTypeID,b.BaseTestType,a.TestTypeTitle,a.TestAmount,a.TestTotalMark from PaperTestType a,TestTypeInfo b where a.TestTypeID=b.TestTypeID and a.PaperID=" + intPaperID + " order by a.PaperTestTypeID asc");
                    for (int i = 0; i < SqlDSTestType.Tables[0].Rows.Count; i++)
                    {
                        if (intProduceWay == 3)//�������
                        {
                            dblTotalMark = System.Math.Round(Convert.ToDouble(AccessDateHelper.GetValues("select sum(a.TestMark) as TotalMark from UserAnswer a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID=" + SqlDSTestType.Tables[0].Rows[i]["TestTypeID"] + " and a.UserScoreID=" + intUserScoreID + "", "TotalMark")), 2);
                        }
                        else//����̶����������
                        {
                            dblTotalMark = System.Math.Round(Convert.ToDouble(SqlDSTestType.Tables[0].Rows[i]["TestTotalMark"].ToString()), 2);
                        }

                        strPaperContent = strPaperContent + "<div class='testtype' onclick='jscomFlexObject(trTestTypeContent" + Convert.ToString(i + 1) + ")' title='��������ô���'>" + ObjFun.convertint(Convert.ToString(i + 1)) + "." + SqlDSTestType.Tables[0].Rows[i]["TestTypeTitle"].ToString() + "����" + SqlDSTestType.Tables[0].Rows[i]["TestAmount"].ToString() + "�⣩</div>";



                        SqlDSTest = AccessDateHelper.ExecuteDataset("select a.RubricID,b.TestTypeID,b.OptionNum,a.TestMark,b.TestContent,b.OptionContent from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID=" + SqlDSTestType.Tables[0].Rows[i]["TestTypeID"] + " and a.PaperID=" + intPaperID + " order by Rnd(a.RubricID) asc");
                        for (int j = 0; j < SqlDSTest.Tables[0].Rows.Count; j++)
                        {
                            strPaperContent = strPaperContent + "<ul id='trTestTypeContent" + Convert.ToString(j + 1) + "'>";
                            intTestNum = intTestNum + 1;
                            strTestContent = SqlDSTest.Tables[0].Rows[j]["TestContent"].ToString();

                            if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "�����")
                            {
                                intOptionNum = 0;
                                Regex Reg = new Regex("___", RegexOptions.IgnoreCase);
                                while (strTestContent.IndexOf("___") >= 0)
                                {
                                    strTestContent = Reg.Replace(strTestContent, "", 1);
                                    intOptionNum = intOptionNum + 1;
                                }
                                strTestContent = SqlDSTest.Tables[0].Rows[j]["TestContent"].ToString();

                                for (k = 1; k <= intOptionNum; k++)
                                {

                                    strTestContent = Reg.Replace(strTestContent, "<input type='text' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' size='16' class=filltext value='' onBlur='textcheck()' title='������в��ܰ�����Ƕ��š�,��'>", 1);

                                }
                            }
                            strPaperContent = strPaperContent + "<li class='timu'><input type='hidden' id='TestTypeTitle" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='TestTypeTitle" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='" + SqlDSTestType.Tables[0].Rows[i]["TestTypeTitle"].ToString() + "'><input type='hidden' id='RubricID" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='RubricID" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "'><input type='hidden' id='BaseTestType" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='BaseTestType" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='" + SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() + "'><a id='l" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "'>��" + intTestNum.ToString() + "��</a>." + strTestContent + "</li>";

                            if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "��ѡ��")
                            {
                                intOptionNum = Convert.ToInt32(SqlDSTest.Tables[0].Rows[j]["OptionNum"]);
                                strArrOptionContent = SqlDSTest.Tables[0].Rows[j]["OptionContent"].ToString().Split('|');
                                for (k = 1; k <= intOptionNum; k++)
                                {


                                    strPaperContent = strPaperContent + "<li class='xuanxiang'><input type='radio' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='" + Convert.ToChar(64 + k) + "'>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</li>";

                                   
                                }
                            }
                            if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "��ѡ��")
                            {
                                intOptionNum = Convert.ToInt32(SqlDSTest.Tables[0].Rows[j]["OptionNum"]);
                                strArrOptionContent = SqlDSTest.Tables[0].Rows[j]["OptionContent"].ToString().Split('|');
                                for (k = 1; k <= intOptionNum; k++)
                                {


                                    strPaperContent = strPaperContent + "<li class='xuanxiang'><input type='checkbox' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='" + Convert.ToChar(64 + k) + "'>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</li>";


                                }
                            }
                            if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "�ж���")
                            {

                                strPaperContent = strPaperContent + "<li class='xuanxiang'><input type='radio' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='��ȷ'>��ȷ</li>";

                                strPaperContent = strPaperContent + "<li class='xuanxiang2'><input type='radio' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='����'>����</li>";


                            }
                            if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "�����")
                            {
                            }
                            if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "�ʴ���")
                            {

                                strPaperContent = strPaperContent + "<li class='xuanxiang'><TEXTAREA rows=6 cols=40 id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' style='width:100%' class=Text></TEXTAREA></li>";

                                if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "������")
                                {

                                    strPaperContent = strPaperContent + "<li class='xuanxiang'><TEXTAREA rows=10 cols=40 id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' style='width:100%' class=Text></TEXTAREA></li>";

                                }
                                if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "������")
                                {

                                    strArrTypeUserAnswer = "0,0".Split(',');


                                    strPaperContent = strPaperContent + "<li class='xuanxiang'><a href='#'onclick=window.showModelessDialog('TypeWord.aspx?TestNum=" + intTestNum + "&UserScoreID=" + intUserScoreID + "&RubricID=" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "',window,'dialogHeight:430px;dialogWidth:570px;edge:Raised;center:Yes;help:Yes;resizable:No;status:No;'); title='�����ʼ����'>��ʼ����</a>&nbsp;�����ٶȣ�<input type='text' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' class=Text size='3' ReadOnly='true' value='" + strArrTypeUserAnswer[0] + "'>����/����&nbsp;��ȷ�ʣ�<input type='text' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' class=Text size='3' ReadOnly='true' value='" + strArrTypeUserAnswer[1] + "'>%</li>";

                                }
                                if (SqlDSTestType.Tables[0].Rows[i]["BaseTestType"].ToString() == "������")
                                {

                                    strPaperContent = strPaperContent + "<li class='xuanxiang'><a href='DownLoadFile.aspx?UserScoreID=" + intUserScoreID + "&RubricID=" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' title='�������'>�����ļ���</a><b>" + SqlDSTest.Tables[0].Rows[j]["TestFileName"].ToString() + "</b></li>";

                                    strPaperContent = strPaperContent + "<li class='xuanxiang'><a href='#'onclick=window.showModelessDialog('UpLoadFile.aspx?TestNum=" + intTestNum + "&UserScoreID=" + intUserScoreID + "&RubricID=" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "',window,'dialogHeight:150px;dialogWidth:330px;edge:Raised;center:Yes;help:Yes;resizable:No;scroll:No;status:No;'); title='����ϴ�'>�ϴ��ļ���</a><input type='text' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' class=Text size='16' ReadOnly='true' value=''></li>";

                                }
                                
                            }

                            strPaperContent = strPaperContent + "</ul>";
                        }
                       
                        //SqlConn.Close();
                        //SqlConn.Dispose();

                        //����Ծ���
                        strtable = strtable + "<table height='100%' width='100%'>";
                        strtable = strtable + "<tr>";
                        strtable = strtable + "<td>";
                        strtable = strtable + "<div style='FONT-SIZE: 9pt; OVERFLOW: auto; WIDTH: 100%; HEIGHT: 100%'>";
                        strtable = strtable + "<table style='FONT-SIZE: 10pt' cellSpacing='0' borderColorDark='#cccccc' cellPadding='0' border='1'>";
                        int n = 1;
                        for (int j = 1; j <= intTestNum; j++)
                        {
                            if (n == 1)
                            {
                                strtable = strtable + "<tr>";
                                strtable = strtable + "<td align='right' width='39' height='18'><span id='icon" + i.ToString() + "1'>" + i.ToString() + ":<img src='../images/nofinished.gif' border='0'></span><span id='icon" + i.ToString() + "2' style='DISPLAY: none'>" + i.ToString() + ":<img src='../images/finished.gif' border='0'></span></td>";
                                n = n + 1;
                            }
                            else
                            {
                                if (n == 10)
                                {
                                    strtable = strtable + "<td align='right' width='39' height='18'><span id='icon" + i.ToString() + "1'>" + i.ToString() + ":<img src='../images/nofinished.gif' border='0'></span><span id='icon" + i.ToString() + "2' style='DISPLAY: none'>" + i.ToString() + ":<img src='../images/finished.gif' border='0'></span></td>";
                                    strtable = strtable + "</tr>";
                                    n = 1;
                                }
                                else
                                {
                                    strtable = strtable + "<td align='right' width='39' height='18'><span id='icon" + i.ToString() + "1'>" + i.ToString() + ":<img src='../images/nofinished.gif' border='0'></span><span id='icon" + i.ToString() + "2' style='DISPLAY: none'>" + i.ToString() + ":<img src='../images/finished.gif' border='0'></span></td>";
                                    n = n + 1;
                                }
                            }
                        }
                        strtable = strtable + "</table>";
                        strtable = strtable + "</div>";
                        strtable = strtable + "</td>";
                        strtable = strtable + "</tr>";
                        strtable = strtable + "</table>";
                    }
                }
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
