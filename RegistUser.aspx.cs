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

namespace EasyExam
{
	/// <summary>
	/// RegistUser 的摘要说明。
	/// </summary>
	public partial class RegistUser : System.Web.UI.Page
	{

		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intUserState=0;
	
		#region//************初始化信息*********
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//清除缓存
			Response.Expires=0;
			Response.Buffer=true;
			Response.Clear();
			//判断是否允许帐户注册
            if (AccessDateHelper.GetValues("select StartValue from SystemSet where SetName='OnLineRegist'", "StartValue") == "1")
			{
                intUserState = Convert.ToInt32(AccessDateHelper.GetValues("select StartValue from SystemSet where SetName='RegistWay'", "StartValue"));
			}
			else
			{
				ObjFun.Alert("系统不允许帐户在线注册！");
			}
			
			if (!IsPostBack)
			{
				
				
               
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

		#region//*********新建单个帐户信息***********
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			if (txtLoginID.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('帐号不能为空！')</script>");
				return;
			}
			if (txtNewUserPwd.Text.Trim()!=txtSureUserPwd.Text.Trim())
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('两次密码不一致！')</script>");
				return;
			}
			
		
			
            string strTmp = AccessDateHelper.GetValues("select LoginID from UserInfo where LoginID='" + ObjFun.getStr(ObjFun.CheckString(txtLoginID.Text.Trim()), 20) + "'", "LoginID");
			if (strTmp.Trim()!="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('此"+txtLoginID.Text.Trim()+"帐号已经存在，无法注册！')</script>");
				return;
			}

			string strLoginID=ObjFun.getStr(ObjFun.CheckString(txtLoginID.Text.Trim()),20);
			string strUserName=ObjFun.getStr(ObjFun.CheckString(txtUserName.Text.Trim()),20);
			string strUserPwd=ObjFun.getStr(ObjFun.CheckString(txtNewUserPwd.Text.Trim()),20);
			string strUserImg=UpUserPhoto.PostedFile.FileName;
			string strTelephone=ObjFun.getStr(ObjFun.CheckString(txtTelephone.Text.Trim()),20);
			string strCertNum=ObjFun.getStr(ObjFun.CheckString(txtCertNum.Text.Trim()),20);
            int intUserType = Convert.ToInt32(RBLUserType.SelectedValue);
                
            //int intUserType = Convert.ToInt32(RBLUserType.SelectedValue.ToString());
			
			//int intUserState=Convert.ToInt32(DDLUserState.SelectedItem.Value);
			int intJudgeUser=0;
			int intJudgeTestType=0;
			int intRoleMenu=0;
			
            int intCreateUserID = Convert.ToInt32(AccessDateHelper.GetValues("select UserID from UserInfo where LoginID='Admin'", "UserID"));
			DateTime dtmCreateDate=Convert.ToDateTime(System.DateTime.Now.ToString("d"));

			byte[] imgBinaryData;
			if (strUserImg.Trim()!="")
			{
				string strName=strUserImg.Substring(strUserImg.Length-4);
				strTmp=".JPG.GIF";
				if (strTmp.IndexOf(strName.ToUpper())<0)
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('照片格式不正确！')</script>");
					return;
				}
				Stream imgStream;
				int imgLen;
				imgStream=UpUserPhoto.PostedFile.InputStream;
				imgLen=UpUserPhoto.PostedFile.ContentLength;
				imgBinaryData=new byte[imgLen];
				int n=imgStream.Read(imgBinaryData,0,imgLen);
			}
			else
			{
				imgBinaryData=new byte[0];
			}
            string strSql = "Insert into UserInfo(LoginID,UserName,UserPwd,Telephone,UserType,CreateUserID,CreateDate,UserState) Values ('" + strLoginID + "','" + strUserName + "','" + strUserPwd + "','" + strTelephone + "'," + intUserType + "," + intCreateUserID + ",'" + dtmCreateDate + "',1)";
             int NumRowsAffected = AccessDateHelper.ExecuteNonQuery(strSql);
			if (NumRowsAffected>0)
			{
				if (intUserState==0)
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('帐户注册成功，帐号审核后生效！');</script>");
				}
				else
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('帐户注册成功，帐号已经生效！');</script>");
				}
			}
			else
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('帐户注册失败！')</script>");
			}
		}
		#endregion

		

		#region//*********检测帐号是否存在*********
		protected void ButCheck_Click(object sender, System.EventArgs e)
		{
            string strTmp = AccessDateHelper.GetValues("select LoginID from UserInfo where LoginID='" + ObjFun.getStr(ObjFun.CheckString(txtLoginID.Text.Trim()), 20) + "'", "LoginID");
			if (strTmp.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('此"+txtLoginID.Text.Trim()+"帐号不存在，可以注册！')</script>");
			}
			else
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('此"+txtLoginID.Text.Trim()+"帐号已经存在，不能注册！')</script>");
			}
		}
		#endregion

        protected void RBLUserType_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
}
}
