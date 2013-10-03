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
using System.IO;

namespace EasyExam.PersonalInfo
{
    public partial class JoinLianXi : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.DropDownList DropDownList1;
        protected System.Web.UI.WebControls.DropDownList DropDownList2;
        protected System.Web.UI.WebControls.DropDownList DropDownList3;
        protected System.Web.UI.WebControls.DropDownList DropDownList4;
        protected System.Web.UI.WebControls.TextBox Textbox1;
        protected System.Web.UI.WebControls.DropDownList DropDownList5;
        protected System.Web.UI.WebControls.DropDownList DropDownList6;
        protected System.Web.UI.WebControls.DropDownList DropDownList7;
        protected System.Web.UI.WebControls.DropDownList DropDownList8;
        protected System.Web.UI.WebControls.TextBox TextBox2;
        protected int RowNum = 0, LinNum = 0;

        bool bWhere;
        string strSql = "";
        string myUserID = "";
        string myLoginID = "";
        PublicFunction ObjFun = new PublicFunction();

        protected void Page_Load(object sender, EventArgs e)
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
           
            if (!IsPostBack)
            {
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=0 ", "UserType") != "0")
                {
                    Response.Write("<script>alert('对不起，您没有此操作权限！')</script>");
                    Response.End();
                }
                else
                {
                    
                    ShowSubjectInfo();//显示科目信息
                    DDLSubjectName.Items.FindByText("--全部--").Selected = true;
                   
                    
                    
                    
                }
            }
            

        }


        #region//*********显示科目信息**********
        private void ShowSubjectInfo()
        {
           
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from SubjectInfo order by SubjectID");
            DDLSubjectName.Items.Clear();
            DDLSubjectName.DataSource = SqlDS.Tables[0].DefaultView;
            DDLSubjectName.DataTextField = "SubjectName";
            DDLSubjectName.DataValueField = "SubjectID";
            DDLSubjectName.DataBind();
            //SqlConn.Dispose();
            ListItem strTmp = new ListItem("--全部--", "0");
            DDLSubjectName.Items.Add(strTmp);
        }
        #endregion

        #region//*********显示知识点信息**********
        private void ShowLoreInfo(int SubjectID)
        {
          
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from LoreInfo where SubjectID=" + SubjectID + " order by LoreID");
            DDLLoreName.Items.Clear();
            DDLLoreName.DataSource = SqlDS.Tables[0].DefaultView;
            DDLLoreName.DataTextField = "LoreName";
            DDLLoreName.DataValueField = "LoreID";
            DDLLoreName.DataBind();
            //SqlConn.Dispose();
            ListItem strTmp = new ListItem("--全部--", "0");
            DDLLoreName.Items.Add(strTmp);
        }
        #endregion

       
        #region//*******选择发生改变*******
        protected void DDLSubjectName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ShowLoreInfo(Convert.ToInt32(DDLSubjectName.SelectedValue));
            DDLLoreName.Items.FindByText("--全部--").Selected = true;
        }
        #endregion

        #region//*******条件查询信息*******
        protected void ButQuery_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("startLianXi.aspx?Start=yes&SubjectID="+DDLSubjectName.SelectedValue.ToString()+"&LoreID="+DDLLoreName.SelectedValue.ToString()+"");
            
        }
        #endregion
    }
}