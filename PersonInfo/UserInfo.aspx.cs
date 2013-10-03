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

namespace EasyExam.PersonInfo
{
	/// <summary>
	/// UserInfo ��ժҪ˵����
	/// </summary>
	public partial class UserInfo : System.Web.UI.Page
	{

		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intUserID=0;
	
		#region//************��ʼ����Ϣ*********
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				myUserID=Session["UserID"].ToString();
				myLoginID=Session["LoginID"].ToString();
				intUserID=Convert.ToInt32(myUserID);
			}
			catch
			{
			}
			if (myLoginID=="")
			{
				Response.Redirect("../Login.aspx");
			}
			if (!IsPostBack)
			{
				if (myLoginID!="")
				{
					LoadUserData();
					LoadUserPhoto();
				}
			}
		}
		#endregion
		
		#region//**********����Ҫ�޸ĵ��ʻ�����*********
		private void LoadUserData()
		{
			string strConn="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn = new SqlConnection(strConn);
            //SqlCommand ObjCmd=new SqlCommand("select a.UserID,a.LoginID,a.UserName,a.UserSex,a.Birthday,b.DeptName,a.Telephone,a.CertType,a.CertNum,a.LoginIP,c.JobName,case a.UserType when 1 then '�����ʻ�' when 0 then '��ͨ�ʻ�' end as UserType,case a.UserState when 1 then '����' when 0 then '��ֹ' end as UserState from UserInfo a LEFT OUTER JOIN DeptInfo b ON a.DeptID = b.DeptID LEFT OUTER JOIN JobInfo c ON a.JobID = c.JobID where LoginID='"+myLoginID+"'",ObjConn);
            //ObjConn.Open();
            //SqlDataReader ObjDR= ObjCmd.ExecuteReader(CommandBehavior.CloseConnection);

            OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader("select a.UserID,a.LoginID,a.UserName,a.UserSex,a.Birthday,b.DeptName,a.Telephone,a.CertType,a.CertNum,a.LoginIP,c.JobName,iif( a.UserType = 1,'�����ʻ�',iif(a.UserType= 0,'��ͨ�ʻ�' ,'')) as UserType, iif( a.UserState = 1, '����',iif(a.UserState= 0,'��ֹ')) as UserState  from JobInfo as c RIGHT JOIN (DeptInfo as b RIGHT JOIN UserInfo as a ON b.DeptID = a.DeptID) ON c.JobID = a.JobID where a.LoginID='" + myLoginID + "'");

			if (ObjDR.Read())
			{
				txtLoginID.Text=ObjDR["LoginID"].ToString();
				txtUserName.Text=ObjDR["UserName"].ToString();
                if (ObjDR["UserSex"].ToString() != "")
                {
                    RBLUserSex.Items.FindByText(ObjDR["UserSex"].ToString()).Selected = true;
                }
				if (ObjDR["Birthday"].ToString()!="")
				{
					txtBirthday.Text=Convert.ToDateTime(ObjDR["Birthday"].ToString()).ToString("d");
				}
				else
				{
					txtBirthday.Text="";
				}
				txtDept.Text=ObjDR["DeptName"].ToString();
				txtJob.Text=ObjDR["JobName"].ToString();
				txtTelephone.Text=ObjDR["Telephone"].ToString();
				txtCertType.Text=ObjDR["CertType"].ToString();
				txtCertNum.Text=ObjDR["CertNum"].ToString();
				txtLoginIP.Text=ObjDR["LoginIP"].ToString();
				txtUserType.Text=ObjDR["UserType"].ToString();
				txtUserState.Text=ObjDR["UserState"].ToString();
			}
			//ObjConn.Dispose();
		}
		#endregion

		#region//**********�����ʻ���Ƭ*********
		private void LoadUserPhoto()
		{
			string strConn="";
			string strSql="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn = new SqlConnection(strConn);
			strSql="select UserPhoto from UserInfo where UserID="+intUserID+"";
            //SqlCommand ObjCmd =null;
            //ObjCmd=new SqlCommand (strSql, ObjConn);
            //ObjConn.Open();
            //SqlDataReader ObjDR=ObjCmd.ExecuteReader();

            OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader(strSql);
			if (ObjDR.Read())
			{
				
				ImageUser.ImageUrl="../PersonInfo/ShowUserImg.aspx?UserID="+intUserID+"";
			}  
			else
			{
				ImageUser.ImageUrl="../Images/UserImage.gif";
			}
            //ObjConn.Close();
            //ObjConn.Dispose();
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