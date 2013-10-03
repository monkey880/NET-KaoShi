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

namespace EasyExam.NewsManag
{
	/// <summary>
	/// EditNews ��ժҪ˵����
	/// </summary>
	public partial class EditNews : System.Web.UI.Page
	{

		string strSql="";
		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intNewsID=0,intCreateUserID=0;
	
		#region//************��ʼ����Ϣ*********
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				myUserID=Session["UserID"].ToString();
				myLoginID=Session["LoginID"].ToString();
			}
			catch
			{
			}
			if (myLoginID=="")
			{
				Response.Redirect("../Login.aspx");
			}
			intNewsID=Convert.ToInt32(Request["NewsID"]);
			if (!IsPostBack)
			{
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=1 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=UserInfo.UserID and PowerID=3 and OptionID=1)))", "UserType") != "1")
				{
					Response.Write("<script>alert('�Բ�����û�д˲���Ȩ�ޣ�')</script>");
					Response.End();
				}
				else
				{
					if (intNewsID!=0)
					{
						
						LoadNewsData();
					}
				}
			}
		}
		#endregion

		#region//*********ɾ����������**********
		private void DelRelationData()
		{

                AccessDateHelper.ExecuteNonQuery("delete from NewsUser where NewsID=" + intNewsID + "");
				
		}
		#endregion

		#region//**********����Ҫ�޸ĵ���������*********
		private void LoadNewsData()
		{

            OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader("select * from NewsInfo where NewsID=" + intNewsID + "");
			if (ObjDR.Read())
			{
				txtNewsTitle.Text=ObjDR["NewsTitle"].ToString();
				txtNewsContent.Text=ObjDR["NewsContent"].ToString();
			
				if (ObjDR["BrowAccount"].ToString()=="1")
				{
					
				}
				SqlDataAdapter SqlCmd=null;
				DataSet SqlDS=null;
				int i=0;
				if (ObjDR["BrowAccount"].ToString()=="2")
				{
					
                    SqlDS = AccessDateHelper.ExecuteDataset("select b.DeptID,b.DeptName from NewsUser a,DeptInfo b where a.DeptID=b.DeptID and a.NewsID=" + intNewsID + " order by a.DeptID asc");
					
                    SqlDS = AccessDateHelper.ExecuteDataset("select b.UserID,b.LoginID from NewsUser a,UserInfo b where a.UserID=b.UserID and a.NewsID=" + intNewsID + " order by a.UserID asc");
					
				}
				txtCreateDate.Text=Convert.ToDateTime(ObjDR["CreateDate"].ToString()).ToString("d");
				intCreateUserID=Convert.ToInt32(ObjDR["CreateUserID"].ToString());
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

		

		#region//*********�ύ������Ϣ***********
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			if (txtNewsTitle.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���ű��ⲻ��Ϊ�գ�')</script>");
				return;
			}
			if (txtNewsContent.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�������ݲ���Ϊ�գ�')</script>");
				return;
			}
			

            string strTmp = AccessDateHelper.GetValues("select NewsID from NewsInfo where NewsTitle='" + ObjFun.getStr(ObjFun.CheckString(txtNewsTitle.Text.Trim()), 100) + "' and NewsID<>" + intNewsID + "", "NewsID");
			if (strTmp.Trim()!="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�����ű����Ѿ����ڣ����������룡')</script>");
				return;
			}

			string strNewsTitle=ObjFun.getStr(ObjFun.CheckString(txtNewsTitle.Text.Trim()),100);
			string strNewsContent=txtNewsContent.Text;
			int intBrowAccount=0;
			
			int intCreateUserID=Convert.ToInt32(myUserID);
			DateTime dtmCreateDate=Convert.ToDateTime(txtCreateDate.Text);

			try
			{
				

                AccessDateHelper.ExecuteNonQuery("Update NewsInfo set NewsTitle='" + strNewsTitle + "',NewsContent='" + strNewsContent + "',BrowAccount='" + intBrowAccount + "' where NewsID=" + intNewsID + "");

				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�޸����ųɹ���');try{ window.opener.RefreshForm() }catch(e){};window.close();</script>");
			}
			catch
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�޸�����ʧ�ܣ�')</script>");
			}
		}
		#endregion

	}
}
