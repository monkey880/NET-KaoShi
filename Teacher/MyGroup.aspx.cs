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
using System.Text.RegularExpressions;

namespace EasyExam.Teacher
{
    /// <summary>
    /// NewTest 的摘要说明。
    /// </summary>
    public partial class MyGroup : System.Web.UI.Page
    {
       

        string myUserID = "";
        string myLoginID = "";
        PublicFunction ObjFun = new PublicFunction();
        OleDbDataReader myGroup;

        #region//************初始化信息*********
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
            

            if (!IsPostBack)
            {
                string UserID = AccessDateHelper.GetValues("select UserID from UserInfo where LoginID='" + myLoginID + "'", "UserID");
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=2 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=" + UserID + " and PowerID=3 and OptionID=3)))", "UserType") != "2")
                {
                    Response.Write("<script>alert('对不起，您没有此操作权限！')</script>");
                    Response.End();
                }
                else
                {
                     myGroup = AccessDateHelper.ExecuteReader("select * from [Group] where UserID="+Convert.ToInt16(myUserID)+"");
                    if (myGroup.Read())
                    {
                        txtGroupName.Text = myGroup["GroupName"].ToString();
                        txtGroupContent.Text = myGroup["GroupContent"].ToString();
                    }

                }
            }
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

      



        protected void Button1_Click1(object sender, EventArgs e)
        {
            string strGroupName, strGroupContent;

            DateTime dtmCreateDate;

            if (txtGroupName.Text == "")
            {
                this.RegisterStartupScript("newWindow", "<script language='javascript'>alert('请填写群组名称！')</script>");
                return;
            }

            strGroupName = txtGroupName.Text;
            strGroupContent = txtGroupName.Text;

            string strsql;
            myGroup = AccessDateHelper.ExecuteReader("select * from [Group] where UserID=" + Convert.ToInt16(myUserID) + "");
            if (myGroup.Read())
            {
                strsql = "update [Group] set GroupName='" + strGroupName + "',GroupContent='" + strGroupContent + "' where GroupID=" + Convert.ToInt16(myGroup["GroupID"]) + "";
            }
            else
            {
                strsql = "insert into [Group] (GroupName,GroupContent,UserID) values ('" + strGroupName + "','" + strGroupContent + "',"+Convert.ToInt16(myUserID)+")";
            }


            if (AccessDateHelper.ExecuteNonQuery(strsql) > 0)
            {
                this.RegisterStartupScript("newWindow", "<script language='javascript'>alert('群组更改成功！');try{ window.opener.RefreshForm() }catch(e){};</script>");
            }
            else
            {
                this.RegisterStartupScript("newWindow", "<script language='javascript'>alert('新建试题失败！')</script>");
            }

        }
}
}
