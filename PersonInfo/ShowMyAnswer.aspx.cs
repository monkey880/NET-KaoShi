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
    /// ShowAnswer 的摘要说明。
    /// </summary>
    public partial class ShowMyAnswer : System.Web.UI.Page
    {

        protected string strPaperName = "";
        protected string strTestCount = "";
        protected string strPaperMark = "";
        protected string strPaperContent = "";

        protected string strLoginID = "";
        protected string strUserName = "";
        protected string strExamTime = "";
        protected string strPassMark = "";
        protected string strTotalMark = "";
        protected string strPractiseNum = "20";

        protected int intPaperID = 0;
        protected int intUserID = 0;
        
        protected int intTestNum = 0;

        string myUserID = "";
        string myLoginID = "";
        PublicFunction ObjFun = new PublicFunction();
        int k = 0, intProduceWay = 0, intOptionNum = 0, intSeeResult = 0;
        double dblTotalMark = 0;
        string strTestContent = "";
        string strManageUser = "";
        string[] strArrOptionContent, strArrTypeStandardAnswer, strArrTypeUserAnswer;

        #region//*********初始信息*******
        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                myUserID = Session["UserID"].ToString();
                myLoginID = Session["LoginID"].ToString();
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

            strPaperContent = "";
            intPaperID = Convert.ToInt32(Request["PaperID"]);
            strManageUser = Convert.ToString(Request["ManageUser"]);
            //if (!IsPostBack)
            //{
            //权限判断

            if (intPaperID != 0)
            {
                
                DataSet SqlDS = null, SqlDSTestType = null, SqlDSTest = null;



                SqlDS = AccessDateHelper.ExecuteDataset("select * from PaperInfo where PaperID=" + intPaperID + " order by PaperID asc");

                strPaperName = SqlDS.Tables[0].Rows[0]["PaperName"].ToString();
                strTestCount = SqlDS.Tables[0].Rows[0]["TestCount"].ToString();
                //strPractiseNum = SqlDS.Tables[0].Rows[0]["PractiseNum"].ToString();
                strPaperMark = SqlDS.Tables[0].Rows[0]["PaperMark"].ToString();
                strPassMark = SqlDS.Tables[0].Rows[0]["PassMark"].ToString();
                intSeeResult = Convert.ToInt32(SqlDS.Tables[0].Rows[0]["SeeResult"]);
                if ((intSeeResult == 0) && (strManageUser != "1"))
                {
                    ObjFun.Alert("该试卷不允许查看结果！");
                }

                intTestNum = 0;


                SqlDSTest = AccessDateHelper.ExecuteDataset("select top "+strTestCount+" rr.RubricID,ri.TestTypeID,ri.TestDiff,ri.OptionNum,ri.TestContent,ri.OptionContent,ri.StandardAnswer,ri.TestParse,rr.Answer,ps.Score,ti.BaseTestType,rr.isCorrect,rr.PractiseTime from PractiseRecord rr,RubricInfo ri,PractiseScore ps,TestTypeinfo ti where rr.RubricID=ri.RubricID and rr.RubricID=ps.RubricID and rr.TestTypeID=ti.TestTypeID and rr.UserID=" + Convert.ToInt32(myUserID) + " and  rr.PaperID=" + intPaperID + " and (DateDiff('d',PractiseTime,Date())=0)   order by rr.PractiseTime asc");

                    for (int j = 0; j < SqlDSTest.Tables[0].Rows.Count; j++)
                    {
                        intTestNum = j + 1;
                        strTestContent = SqlDSTest.Tables[0].Rows[j]["TestContent"].ToString();
                        if (RadioButAll.Checked || RadioButWrong.Checked )
                        {
                            strPaperContent = strPaperContent + "<ul>";
                            if (SqlDSTest.Tables[0].Rows[j]["TestTypeID"].ToString() == "30")
                            {
                                intOptionNum = 0;
                                Regex Reg = new Regex("___", RegexOptions.IgnoreCase);
                                while (strTestContent.IndexOf("___") >= 0)
                                {
                                    strTestContent = Reg.Replace(strTestContent, "", 1);
                                    intOptionNum = intOptionNum + 1;
                                }
                                strTestContent = SqlDSTest.Tables[0].Rows[j]["TestContent"].ToString();
                                strArrOptionContent = SqlDSTest.Tables[0].Rows[j]["Answer"].ToString().Split(',');
                                for (k = 1; k <= intOptionNum; k++)
                                {
                                    if (k <= strArrOptionContent.Length)
                                    {
                                        strTestContent = Reg.Replace(strTestContent, "<input type='text' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' size='16' class=filltext value='" + strArrOptionContent[k - 1] + "' onBlur='textcheck()' readonly title='试题答案中不能包含半角逗号“,”'>", 1);
                                    }
                                    else
                                    {
                                        strTestContent = Reg.Replace(strTestContent, "<input type='text' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' size='16' class=filltext value='' onBlur='textcheck()' readonly title='试题答案中不能包含半角逗号“,”'>", 1);
                                    }
                                }
                            }
                            strPaperContent = strPaperContent + "<li class='timu'><input type='hidden' id='TestTypeTitle" + intTestNum.ToString() + "' name='TestTypeTitle" + intTestNum.ToString() + "' value='" + SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() + "'><input type='hidden' id='RubricID" + intTestNum.ToString() + "' name='RubricID" + intTestNum.ToString() + "' value='" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "'><input type='hidden' id='BaseTestType" + intTestNum.ToString() + "' name='BaseTestType" + intTestNum.ToString() + "' value='" + SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() + "'><a id='l" + intTestNum.ToString() + "' style='color:black'>" + intTestNum.ToString() + "</a>." + strTestContent + "("+SqlDSTest.Tables[0].Rows[j]["PractiseTime"].ToString()+")</li>";
                           
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "单选类")
                            {
                                intOptionNum = Convert.ToInt32(SqlDSTest.Tables[0].Rows[j]["OptionNum"]);
                                strArrOptionContent = SqlDSTest.Tables[0].Rows[j]["OptionContent"].ToString().Split('|');
                                for (k = 1; k <= intOptionNum; k++)
                                {
                                   
                                    if (SqlDSTest.Tables[0].Rows[j]["Answer"].ToString().IndexOf(Convert.ToChar(64 + k)) >= 0)
                                    {
                                        strPaperContent = strPaperContent + "<li><input type='radio' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='" + Convert.ToChar(64 + k) + "' checked disabled>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</li>";
                                    }
                                    else
                                    {
                                        strPaperContent = strPaperContent + "<li><input type='radio' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='" + Convert.ToChar(64 + k) + "' disabled>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</li>";
                                    }
                                    
                                }
                            }
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "多选类")
                            {
                                intOptionNum = Convert.ToInt32(SqlDSTest.Tables[0].Rows[j]["OptionNum"]);
                                strArrOptionContent = SqlDSTest.Tables[0].Rows[j]["OptionContent"].ToString().Split('|');
                                for (k = 1; k <= intOptionNum; k++)
                                {
                                   
                                    if (SqlDSTest.Tables[0].Rows[j]["Answer"].ToString().IndexOf(Convert.ToChar(64 + k)) >= 0)
                                    {
                                        strPaperContent = strPaperContent + "<li><input type='checkbox' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='" + Convert.ToChar(64 + k) + "' checked disabled>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</li>";
                                    }
                                    else
                                    {
                                        strPaperContent = strPaperContent + "<li><input type='checkbox' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='" + Convert.ToChar(64 + k) + "' disabled>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</li>";
                                    }
                                   
                                }
                            }
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "判断类")
                            {
                              
                                
                                if (SqlDSTest.Tables[0].Rows[j]["Answer"].ToString().IndexOf("正确") >= 0)
                                {
                                    strPaperContent = strPaperContent + "<li><input type='radio' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='正确' checked disabled>正确</li>";
                                }
                                else
                                {
                                    strPaperContent = strPaperContent + "<li><input type='radio' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='正确' disabled>正确</li>";
                                }
                              
                                if (SqlDSTest.Tables[0].Rows[j]["Answer"].ToString().IndexOf("错误") >= 0)
                                {
                                    strPaperContent = strPaperContent + "<li><input type='radio' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='错误' checked disabled>错误</li>";
                                }
                                else
                                {
                                    strPaperContent = strPaperContent + "<li><input type='radio' id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' value='错误' disabled>错误</li>";
                                }
                               
                            }
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "填空类")
                            {
                            }
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "问答类")
                            {
                                
                                strPaperContent = strPaperContent + "<li><TEXTAREA rows=6 cols=40 id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' style='width:100%' class=Text readonly>" + SqlDSTest.Tables[0].Rows[j]["Answer"].ToString() + "</TEXTAREA></li>";
                                
                            }
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "作文类")
                            {
                               
                                strPaperContent = strPaperContent + "<li><TEXTAREA rows=10 cols=40 id='Answer" + intTestNum.ToString() + "' name='Answer" + intTestNum.ToString() + "' style='width:100%' class=Text readonly>" + SqlDSTest.Tables[0].Rows[j]["Answer"].ToString() + "</TEXTAREA></li>";
                               
                            }
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "打字类")
                            {
                            }
                            
                            if (SqlDSTest.Tables[0].Rows[j]["BaseTestType"].ToString() == "打字类")
                            {
                                strArrTypeStandardAnswer = SqlDSTest.Tables[0].Rows[j]["StandardAnswer"].ToString().Split(',');
                               
                                strPaperContent = strPaperContent + "<li><font color='blue'>标准答案：标准速度：" + strArrTypeStandardAnswer[1] + "个字/分钟&nbsp;正确率：100%</font></li>";
                             

                                if (SqlDSTest.Tables[0].Rows[j]["Answer"].ToString().IndexOf(",") >= 0)
                                {
                                    strArrTypeUserAnswer = SqlDSTest.Tables[0].Rows[j]["Answer"].ToString().Split(',');
                                }
                                else
                                {
                                    strArrTypeUserAnswer = "0,0".Split(',');
                                }
                                
                                strPaperContent = strPaperContent + "<li><font color='blue'>考生答案：打字速度：" + strArrTypeUserAnswer[0] + "个字/分钟&nbsp;正确率：" + strArrTypeUserAnswer[1] + "%</font></li>";
                               
                            }
                            else
                            {
                                string isCorrect;
                                if (SqlDSTest.Tables[0].Rows[j]["isCorrect"].ToString() == "0")
                                {
                                     isCorrect = " color='red'";
                                }
                                else
                                {
                                     isCorrect = " color='blue'";
                                }
                               
                                strPaperContent = strPaperContent + "<li class='daan'><font " + isCorrect + ">标准答案：" + SqlDSTest.Tables[0].Rows[j]["StandardAnswer"].ToString() + "</font></li>";


                                strPaperContent = strPaperContent + "<li class='daan2'><font " + isCorrect + ">考生答案：" + SqlDSTest.Tables[0].Rows[j]["Answer"].ToString() + "</font></li>";
                                
                            }


                            strPaperContent = strPaperContent + "<li class='jiexi'><font color='blue'>试题解析：" + SqlDSTest.Tables[0].Rows[j]["TestParse"].ToString() + "</font></li>";
                          
                            strPaperContent = strPaperContent + "</ul>";
                        }
                    }
                   
            }
            //}
        }
        #endregion

        #region Web 窗体设计器生成的代码
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
        #endregion

        #region
        protected void RadioButAll_CheckedChanged(object sender, System.EventArgs e)
        {
            Page_Load(sender, e);
        }
        #endregion

        #region
        protected void RadioButWrong_CheckedChanged(object sender, System.EventArgs e)
        {
            Page_Load(sender, e);
        }
        #endregion
    }
}
