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
	/// RegistUser ��ժҪ˵����
	/// </summary>
	public partial class RegistUser : System.Web.UI.Page
	{

		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intUserState=0;
	
		#region//************��ʼ����Ϣ*********
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//�������
			Response.Expires=0;
			Response.Buffer=true;
			Response.Clear();
			//�ж��Ƿ������ʻ�ע��
            if (AccessDateHelper.GetValues("select StartValue from SystemSet where SetName='OnLineRegist'", "StartValue") == "1")
			{
                intUserState = Convert.ToInt32(AccessDateHelper.GetValues("select StartValue from SystemSet where SetName='RegistWay'", "StartValue"));
			}
			else
			{
				ObjFun.Alert("ϵͳ�������ʻ�����ע�ᣡ");
			}
			
			if (!IsPostBack)
			{
				
				
               
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

		#region//*********�½������ʻ���Ϣ***********
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			if (txtLoginID.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�ʺŲ���Ϊ�գ�')</script>");
				return;
			}
			if (txtNewUserPwd.Text.Trim()!=txtSureUserPwd.Text.Trim())
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�������벻һ�£�')</script>");
				return;
			}
			
		
			
            string strTmp = AccessDateHelper.GetValues("select LoginID from UserInfo where LoginID='" + ObjFun.getStr(ObjFun.CheckString(txtLoginID.Text.Trim()), 20) + "'", "LoginID");
			if (strTmp.Trim()!="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��"+txtLoginID.Text.Trim()+"�ʺ��Ѿ����ڣ��޷�ע�ᣡ')</script>");
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
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��Ƭ��ʽ����ȷ��')</script>");
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
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�ʻ�ע��ɹ����ʺ���˺���Ч��');</script>");
				}
				else
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�ʻ�ע��ɹ����ʺ��Ѿ���Ч��');</script>");
				}
			}
			else
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�ʻ�ע��ʧ�ܣ�')</script>");
			}
		}
		#endregion

		

		#region//*********����ʺ��Ƿ����*********
		protected void ButCheck_Click(object sender, System.EventArgs e)
		{
            string strTmp = AccessDateHelper.GetValues("select LoginID from UserInfo where LoginID='" + ObjFun.getStr(ObjFun.CheckString(txtLoginID.Text.Trim()), 20) + "'", "LoginID");
			if (strTmp.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��"+txtLoginID.Text.Trim()+"�ʺŲ����ڣ�����ע�ᣡ')</script>");
			}
			else
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��"+txtLoginID.Text.Trim()+"�ʺ��Ѿ����ڣ�����ע�ᣡ')</script>");
			}
		}
		#endregion

        protected void RBLUserType_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
}
}
