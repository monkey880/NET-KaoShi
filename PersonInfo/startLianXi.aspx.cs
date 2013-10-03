using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
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
    /// StartExamOne 的摘要说明。
    /// </summary>
    public partial class startLianXi : System.Web.UI.Page
    {
        protected string strPaperName = "";
        protected string strTestCount = "";
        protected string strPaperMark = "";
        protected string strPlan = "";
        protected string strTestTypeMark = "";
        protected string strTestContent = "";
        protected string strSelectOption = "";
        protected string strPaperContent = "";
        protected string strJavaScript = "";
        protected string strSubmitExam = "";
        protected string strCheckAnswer = "";
        protected string strContent = "";
        protected string strCreateName = "";
        protected string strPractiseTime = "";
        public string strPingLunList = "";

        public string strSubjectName = "";
        public string strLoreName = "";

        protected int intRubricID = 0;


        protected DateTime PractiseTime;
        protected int intUseTime = 0;
        protected int intTestTypeID = 0;
        protected string strLoginID = "";
        protected string strUserName = "";
        protected int intExamTime = 0;

        protected int intPaperID = 0;
        protected int intUserID = 0;
        protected int intUserScoreID = 0;
        protected int intTestNum = 0;
        protected int intPractiseNum = 20;
        protected int intSubjectID = 0;
        protected int intLoreID = 0;

        protected string strPingLun = "";

        string myUserID = "";
        string myLoginID = "";
        string myUserName = "";
        PublicFunction ObjFun = new PublicFunction();
        int i = 0, k = 0, intOptionNum = 0;
        double dblTotalMark = 0;
        string[] strArrOptionContent, strArrTypeUserAnswer;

        string strRubricID = "", strBaseTestType = "", strUserAnswer = "";
        int intProduceWay = 0, intTestAmount = 1;
        double dblUserScore = 0, dblImpScore = 0;

        #region//*********初始信息*******
        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                myUserID = Session["UserID"].ToString();
                myLoginID = Session["LoginID"].ToString();
                myUserName = Session["UserName"].ToString();
            }
            catch
            {
            }
            if (myLoginID == "")
            {
                Response.Redirect("../Login.aspx");
            }
            //清除缓存
            Response.Expires = 0;
            Response.Buffer = true;
            Response.Clear();

            intPaperID = Convert.ToInt32(Request["PaperID"]);
            intSubjectID = Convert.ToInt32(Request["SubjectID"]);
            intLoreID = Convert.ToInt32(Request["LoreID"]);
            intUserID = Convert.ToInt32(myUserID);
            strPingLun = Request["plcon"];


            if (!IsPostBack)
            {
                if (intSubjectID != 0 || intLoreID!=0)
                {

                    DataSet SqlDS = null, SqlDSTestType = null, SqlDSTest = null;
                    strLoginID = Convert.ToString(myLoginID);
                    strUserName = Convert.ToString(myUserName);

                    


                    if (Request["Start"] == "yes")
                    {
                        string wheresql = "";
                        if (intSubjectID > 0)
                        {
                            wheresql += " and pt.SubjectID="+intSubjectID+"";
                        }
                        if (intLoreID > 0)
                        {
                            wheresql += " and pt.LoreID="+intLoreID+"";
                        }
                        OleDbDataReader RubricIdReader = AccessDateHelper.ExecuteReader("SELECT top " + intPractiseNum + " pt.RubricID FROM RubricInfo AS pt LEFT JOIN PractiseScore AS ps ON pt.RubricID = ps.RubricID WHERE pt.RubricID Not In (select RubricID from PractiseScore where UserID=" + intUserID + " and Score=3) "+wheresql+" ORDER BY ps.Score");
                        AccessDateHelper.ExecuteNonQuery("delete from TempRubric where UserID=" + intUserID );
                        while (RubricIdReader.Read())
                        {
                            AccessDateHelper.ExecuteNonQuery("INSERT INTO TempRubric (UserID,PaperID,RubricID) VALUES (" + intUserID + ",0," + (int)RubricIdReader[0] + ")");
                        }
                    }

                    intTestNum = (int)AccessDateHelper.ExecuteScalar("select count(*) from TempRubric where [Is]=1  and UserID=" + intUserID + "");
                    intPractiseNum=(int)AccessDateHelper.ExecuteScalar("select count(*) from TempRubric where  UserID=" + intUserID + "");
                    if (Request["Start"] == null)
                    {
                        dblUserScore = 0;
                        strRubricID = Convert.ToString(Request["RubricID"]);
                        strBaseTestType = Convert.ToString(Request["BaseTestType"]);
                        intTestTypeID = Convert.ToInt32(Request["TestTypeID"]);
                        strUserAnswer = Convert.ToString(Request["Answer"]);
                        PractiseTime = Convert.ToDateTime(Request["PractiseTime"]);
                        TimeSpan practise = new TimeSpan(PractiseTime.Ticks);
                        TimeSpan UseTime = practise.Subtract(new TimeSpan(DateTime.Now.Ticks)).Duration();
                        //添加评论
                        if (strPingLun != "")
                    {
                        string sql = "insert into PingLun (UserID,RubricID,Contents) values ("+intUserID+","+strRubricID+",'"+strPingLun+"')";
                        AccessDateHelper.ExecuteNonQuery(sql);
                    }

                        if (strUserAnswer == null)
                        {
                            strUserAnswer = "";
                        }
                        if (strUserAnswer.Length > 2000)
                        {
                            strUserAnswer = strUserAnswer.Substring(0, 2000);
                        }
                        strUserAnswer = strUserAnswer.Replace("|", "︱");
                        switch (strBaseTestType)
                        {
                            case "单选类":
                                strUserAnswer = strUserAnswer.Trim().Replace(",", "");
                                strUserAnswer = strUserAnswer.Trim().Replace(" ", "");
                                break;
                            case "多选类":
                                strUserAnswer = strUserAnswer.Trim().Replace(",", "");
                                strUserAnswer = strUserAnswer.Trim().Replace(" ", "");
                                break;
                            case "判断类":
                                strUserAnswer = strUserAnswer.Trim().Replace(",", "");
                                strUserAnswer = strUserAnswer.Trim().Replace(" ", "");
                                break;
                            case "填空类":
                                strUserAnswer = strUserAnswer.Trim().Replace(" ", "");
                                break;
                            case "问答类":
                                break;
                            case "作文类":
                                break;
                            case "打字类":
                                break;
                            case "操作类":
                                break;
                        }
                        //更新当前试题答案、得分
                        int isCorrect = 0;
                        string answer = AccessDateHelper.ExecuteScalar("select StandardAnswer from RubricInfo where RubricID=" + Convert.ToInt32(strRubricID) + "").ToString();
                        if (strUserAnswer == answer)
                        {
                            isCorrect = 1;
                        }
                        AccessDateHelper.ExecuteNonQuery("insert into PractiseRecord (UserID,PaperID,RubricID,IsCorrect,Answer,PractiseTime,UseTime,TestTypeID) values(" + intUserID + ",0," + Convert.ToInt32(strRubricID) + "," + isCorrect + ",'" + strUserAnswer + "','" + PractiseTime + "'," + UseTime.TotalSeconds + "," + intTestTypeID + ")");

                        AccessDateHelper.ExecuteNonQuery("Update TempRubric set [Is]=1 where RubricID=" + Convert.ToInt32(strRubricID) + "  and UserID=" + intUserID + "");

                        if (AccessDateHelper.ExecuteScalar("select UserID from PractiseScore where UserID=" + intUserID + " and RubricID=" + Convert.ToInt32(strRubricID) + "") != null)
                        {
                            int score = (int)AccessDateHelper.ExecuteScalar("select Score from PractiseScore where UserID=" + intUserID + "  and RubricID=" + Convert.ToInt32(strRubricID) + "");

                            if (isCorrect > 0)
                            {
                                if (score >= 0)
                                {
                                    score = score + 1;
                                }
                                else
                                {
                                    score = 1;
                                }
                                AccessDateHelper.ExecuteNonQuery("Update PractiseScore set Score=" + score + " where UserID=" + intUserID + "  and RubricID=" + Convert.ToInt32(strRubricID) + "");
                            }
                            else
                            {
                                AccessDateHelper.ExecuteNonQuery("Update PractiseScore set Score=Score-1 where UserID=" + intUserID + " and  RubricID=" + Convert.ToInt32(strRubricID) + "");
                            }
                        }
                        else
                        {
                            if (isCorrect > 0)
                            {
                                AccessDateHelper.ExecuteNonQuery("insert into PractiseScore (UserID,PaperID,RubricID,Score,LastTime) values(" + intUserID + ",0," + Convert.ToInt32(strRubricID) + ",1,'" + PractiseTime + "')");
                            }
                            else
                            {
                                AccessDateHelper.ExecuteNonQuery("insert into PractiseScore (UserID,PaperID,RubricID,Score,LastTime) values(" + intUserID + ",0," + Convert.ToInt32(strRubricID) + ",-1,'" + PractiseTime + "')");
                            }

                        }


                    }


                    if (intTestNum<intPractiseNum&& AccessDateHelper.ExecuteScalar("select * from TempRubric where UserID=" + myUserID + " and [Is]=0") != null)
                    {

                        int rubricid = (Int32)AccessDateHelper.ExecuteScalar("select top 1 RubricID from TempRubric where UserID="+myUserID+" and [Is]=0 order by Rnd(RubricID)");
                        SqlDSTest = AccessDateHelper.ExecuteDataset("select a.PaperTestTypeID,a.TestTypeID,b.BaseTestType,a.TestTypeTitle,a.TestAmount,a.TestTotalMark,a.TestTypeOrder,d.RubricID,d.OptionNum,d.TestContent,d.OptionContent from PaperTestType a,TestTypeInfo b,RubricInfo d where a.TestTypeID=b.TestTypeID  and d.TestTypeID=a.TestTypeID and d.RubricID =" + rubricid + "");


                        intTestTypeID = (int)SqlDSTest.Tables[0].Rows[0]["TestTypeID"];
                        strBaseTestType = SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString();
                        strPractiseTime = DateTime.Now.ToString();

                        strTestTypeMark = "";
                        //评论列表
                        DataSet plset = AccessDateHelper.ExecuteDataset("select * from PingLun p left join UserInfo u on p.UserID=u.UserID where RubricID="+rubricid+"");

                        for (int n=0; n < plset.Tables[0].Rows.Count; n++)
                        {
                            strPingLunList += "<li><span>"+plset.Tables[0].Rows[n]["UserName"].ToString()+"发表于："+plset.Tables[0].Rows[n]["CreateDate"].ToString()+"</span><p>"+plset.Tables[0].Rows[0]["Contents"]+"</p></li>";
                        }


                        strPlan = intTestNum.ToString() + "/" + intPractiseNum.ToString();

                        strPaperContent = strPaperContent + "<table cellSpacing='0' cellPadding='1' width='100%' align='center' border='0' id='trTestTypeContent" + Convert.ToString(i + 1) + "'>";
                        strTestContent = "(" + SqlDSTest.Tables[0].Rows[0]["TestTypeTitle"].ToString() + ") " + SqlDSTest.Tables[0].Rows[0]["TestContent"].ToString();
                        strPaperContent = strPaperContent + "<tr>";
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "填空类")
                        {
                            intOptionNum = 0;
                            Regex Reg = new Regex("___", RegexOptions.IgnoreCase);
                            while (strTestContent.IndexOf("___") >= 0)
                            {
                                strTestContent = Reg.Replace(strTestContent, "", 1);
                                intOptionNum = intOptionNum + 1;
                            }
                            strTestContent = SqlDSTest.Tables[0].Rows[0]["TestContent"].ToString();
                            strArrOptionContent = SqlDSTest.Tables[0].Rows[0]["UserAnswer"].ToString().Split(',');
                            for (k = 1; k <= intOptionNum; k++)
                            {

                                strTestContent = Reg.Replace(strTestContent, "<input type='text' id='Answer' name='Answer' size='16' class=filltext value='' onBlur='textcheck()' title='试题答案中不能包含半角逗号“,”'>", 1);

                            }
                        }
                        strPaperContent = strPaperContent + "<td colspan='2' width='100%'><input type='hidden' id='TestTypeTitle' name='TestTypeTitle' value='" + SqlDSTest.Tables[0].Rows[0]["TestTypeTitle"].ToString() + "'><input type='hidden' id='RubricID' name='RubricID' value='" + SqlDSTest.Tables[0].Rows[0]["RubricID"].ToString() + "'><input type='hidden' id='BaseTestType' name='BaseTestType' value='" + SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() + "'><a id='l' style='color:black'></a>." + strTestContent + "</td>";
                        strPaperContent = strPaperContent + "</tr>";
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "单选类")
                        {
                            intOptionNum = Convert.ToInt32(SqlDSTest.Tables[0].Rows[0]["OptionNum"]);
                            strArrOptionContent = SqlDSTest.Tables[0].Rows[0]["OptionContent"].ToString().Split('|');
                            for (k = 1; k <= intOptionNum; k++)
                            {
                                strPaperContent = strPaperContent + "<tr>";

                                strPaperContent = strPaperContent + "<td width='10px' nowrap><td width='100%'><input type='radio' id='Answer' name='Answer' value='" + Convert.ToChar(64 + k) + "'>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</td>";

                                strPaperContent = strPaperContent + "</tr>";
                            }
                        }
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "多选类")
                        {
                            intOptionNum = Convert.ToInt32(SqlDSTest.Tables[0].Rows[0]["OptionNum"]);
                            strArrOptionContent = SqlDSTest.Tables[0].Rows[0]["OptionContent"].ToString().Split('|');
                            for (k = 1; k <= intOptionNum; k++)
                            {
                                strPaperContent = strPaperContent + "<tr>";

                                strPaperContent = strPaperContent + "<td width='10px' nowrap><td width='100%'><input type='checkbox' id='Answer' name='Answer' value='" + Convert.ToChar(64 + k) + "'>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</td>";

                                strPaperContent = strPaperContent + "</tr>";
                            }
                        }
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "判断类")
                        {
                            strPaperContent = strPaperContent + "<tr>";
                            strPaperContent = strPaperContent + "<td width='10' nowrap>";

                            strPaperContent = strPaperContent + "<td width='100%'><input type='radio' id='Answer' name='Answer' value='正确'>正确</td>";

                            strPaperContent = strPaperContent + "</tr>";
                            strPaperContent = strPaperContent + "<tr>";
                            strPaperContent = strPaperContent + "<td width='10' nowrap>";

                            strPaperContent = strPaperContent + "<td width='100%'><input type='radio' id='Answer' name='Answer' value='错误'>错误</td>";

                            strPaperContent = strPaperContent + "</tr>";
                        }
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "填空类")
                        {
                        }
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "问答类")
                        {
                            strPaperContent = strPaperContent + "<tr>";
                            strPaperContent = strPaperContent + "<td width='10px' nowrap><td width='100%'><TEXTAREA rows=6 cols=40 id='Answer' name='Answer' style='width:100%' class=Text></TEXTAREA></td>";
                            strPaperContent = strPaperContent + "</tr>";
                        }
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "作文类")
                        {
                            strPaperContent = strPaperContent + "<tr>";
                            strPaperContent = strPaperContent + "<td width='10px' nowrap><td width='100%'><TEXTAREA rows=10 cols=40 id='Answer' name='Answer' style='width:100%' class=Text></TEXTAREA></td>";
                            strPaperContent = strPaperContent + "</tr>";
                        }
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "打字类")
                        {

                            strArrTypeUserAnswer = "0,0".Split(',');

                            strPaperContent = strPaperContent + "<tr>";
                            strPaperContent = strPaperContent + "<td width='10px' nowrap><td width='100%'><a href='#'onclick=window.showModelessDialog('TypeWord.aspx?TestNum=" + intTestNum + "&UserScoreID=" + intUserScoreID + "&RubricID=" + SqlDSTest.Tables[0].Rows[0]["RubricID"].ToString() + "',window,'dialogHeight:430px;dialogWidth:570px;edge:Raised;center:Yes;help:Yes;resizable:No;status:No;'); title='点击开始打字'>开始打字</a>&nbsp;打字速度：<input type='text' id='Answer' name='Answer' class=Text size='3' ReadOnly='true' value='" + strArrTypeUserAnswer[0] + "'>个字/分钟&nbsp;正确率：<input type='text' id='Answer' name='Answer' class=Text size='3' ReadOnly='true' value='" + strArrTypeUserAnswer[1] + "'>%</td>";
                            strPaperContent = strPaperContent + "</tr>";
                        }
                        if (SqlDSTest.Tables[0].Rows[0]["BaseTestType"].ToString() == "操作类")
                        {
                            strPaperContent = strPaperContent + "<tr>";
                            strPaperContent = strPaperContent + "<td width='10px' nowrap><td width='100%'><a href='DownLoadFile.aspx?UserScoreID=" + intUserScoreID + "&RubricID=" + SqlDSTest.Tables[0].Rows[0]["RubricID"].ToString() + "' title='点击下载'>下载文件：</a><b>" + SqlDSTest.Tables[0].Rows[0]["TestFileName"].ToString() + "</b></td>";
                            strPaperContent = strPaperContent + "</tr>";
                            strPaperContent = strPaperContent + "<tr>";
                            strPaperContent = strPaperContent + "<td width='10px' nowrap><td width='100%'><a href='#'onclick=window.showModelessDialog('UpLoadFile.aspx?TestNum=" + intTestNum + "&UserScoreID=" + intUserScoreID + "&RubricID=" + SqlDSTest.Tables[0].Rows[0]["RubricID"].ToString() + "',window,'dialogHeight:150px;dialogWidth:330px;edge:Raised;center:Yes;help:Yes;resizable:No;scroll:No;status:No;'); title='点击上传'>上传文件：</a><input type='text' id='Answer' name='Answer' class=Text size='16' ReadOnly='true' value=''></td>";
                            strPaperContent = strPaperContent + "</tr>";
                        }
                        strPaperContent = strPaperContent + "<tr>";
                        strPaperContent = strPaperContent + "<td colspan='2' height='10'></td>";
                        strPaperContent = strPaperContent + "</tr>";
                        strPaperContent = strPaperContent + "</table>";

                    }
                    else
                    {
                        
                        strPaperContent = "本科目没有试题可做 <a href='ShowMyAnswer.aspx?PaperID=" + intPaperID + "'>查看结果</a>";
                    }








                }
            }
        }
        #endregion

        //#region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        //#endregion
    }
}
