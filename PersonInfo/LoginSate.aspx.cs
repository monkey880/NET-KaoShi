using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace EasyExam.PersonInfo
{

    public partial class LoginSate : System.Web.UI.Page
    {

        string myUserID = "";
        string myLoginID = "";
        string myUserName = "";
        string baseUrl = ConfigurationSettings.AppSettings["baseUrl"];

        protected void Page_Load(object sender, EventArgs e)
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

        if (myUserID == "")
        {
            conBox.Text = "<a href='" + baseUrl + "RegistUser.aspx' target='_parent'>免费注册</a> <a href='" + baseUrl + "login.aspx' target='_parent'>登录</a> ";
        }
        else
        {
            string strSql="select * from UserInfo where LoginID='"+myLoginID+"'";
            OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader(strSql);
            ObjDR.Read();
            if (Convert.ToInt32(ObjDR["UserType"]) == 1)
            {
                conBox.Text = myLoginID + ",欢迎登录在线考试网， <a href='" + baseUrl + "PersonInfo/' target='_parent'>会员中心</a> <a href='" + baseUrl + "MainFrame.aspx' target='_parent'>后台管理</a> <a href='" + baseUrl + "login.aspx' target='_parent'>退出登录</a>";
            }
            else if (Convert.ToInt32(ObjDR["UserType"]) == 2)
            {
                conBox.Text = myLoginID + ",欢迎登录在线考试网， <a href='" + baseUrl + "Teacher/' target='_parent'>会员中心</a> <a href='" + baseUrl + "login.aspx' target='_parent'>退出登录</a>";
            }
            else
            {
                conBox.Text = myLoginID + ",欢迎登录在线考试网， <a href='" + baseUrl + "PersonInfo/' target='_parent'>会员中心</a> <a href='" + baseUrl + "login.aspx' target='_parent'>退出登录</a>";
            }
        }

    }
    }
}