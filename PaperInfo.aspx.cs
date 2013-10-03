using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace EasyExam
{
    public partial class PaperInfo : System.Web.UI.Page
    {
        public string PaperName = "";
        public string CreateUserID = "";
        public string CreateDate = "";
        public string Content = "";
        public string UserName = "";
        public string strPaperContent = "";
        int intTestNum = 0;
        public string strTestContent;
        int intOptionNum = 0;
        protected string[] strArrOptionContent;

        protected void Page_Load(object sender, EventArgs e)
        {

            indexNewList.DataSource = dsNew(1,10);
            indexNewList.DataBind();

            indexNewList2.DataSource = dsNew(2,10);
            indexNewList2.DataBind();

            OleDbDataReader newinfo = AccessDateHelper.ExecuteReader("select PaperID,PaperName,CreateUserID,CreateDate,Content from PaperInfo where PaperID="+Request.QueryString["id"]+"");
            
            while (newinfo.Read())
            {
                PaperName = newinfo.GetString(1);
                CreateUserID = newinfo.GetInt32(2).ToString();
                CreateDate = newinfo.GetDateTime(3).ToString();
                Content = newinfo.GetValue(4).ToString();
            }
            newinfo.Close();

            OleDbDataReader userinfo = AccessDateHelper.ExecuteReader("select UserName from UserInfo where UserID="+CreateUserID+"");
            while (userinfo.Read())
            {
                UserName = userinfo.GetString(0);
            }
            userinfo.Close();

       


            DataSet SqlDSTest = AccessDateHelper.ExecuteDataset("select top 5 a.RubricID,b.TestTypeID,b.OptionNum,a.TestMark,b.TestContent,b.OptionContent from PaperTest a,RubricInfo b where a.RubricID=b.RubricID  and b.TestTypeID =27 and a.PaperID=" + Request.QueryString["id"] + " order by Rnd(a.RubricID) asc");
            for (int j = 0; j < SqlDSTest.Tables[0].Rows.Count; j++)
            {
                strPaperContent = strPaperContent + "<ul id='trTestTypeContent" + Convert.ToString(j + 1) + "'>";
                intTestNum = intTestNum + 1;
                strTestContent = SqlDSTest.Tables[0].Rows[j]["TestContent"].ToString();

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

                    for (int k = 1; k <= intOptionNum; k++)
                    {

                        strTestContent = Reg.Replace(strTestContent, "<input type='text' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' size='16' class=filltext value='' onBlur='textcheck()' title='试题答案中不能包含半角逗号“,”'>", 1);

                    }
                }
                strPaperContent = strPaperContent + "<li class='timu'><input type='hidden' id='RubricID" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='RubricID" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "'><a id='l" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "'>第" + intTestNum.ToString() + "题</a>." + strTestContent + "</li>";

                if (SqlDSTest.Tables[0].Rows[j]["TestTypeID"].ToString() == "27")
                {
                    intOptionNum = Convert.ToInt32(SqlDSTest.Tables[0].Rows[j]["OptionNum"]);
                    strArrOptionContent = SqlDSTest.Tables[0].Rows[j]["OptionContent"].ToString().Split('|');
                    for (int k = 1; k <= intOptionNum; k++)
                    {


                        strPaperContent = strPaperContent + "<li class='xuanxiang'><input type='radio' id='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' name='Answer" + SqlDSTest.Tables[0].Rows[j]["RubricID"].ToString() + "' value='" + Convert.ToChar(64 + k) + "'>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</li>";


                    }
                }

                strPaperContent = strPaperContent + "</ul>";
            }


           

        }

        private DataSet dsNew(int newclass,int num)
        {
            DataSet list = AccessDateHelper.ExecuteDataset("select top "+num+" * from NewsInfo where class="+newclass+"");
            return list;
        }

        
        
    }
}