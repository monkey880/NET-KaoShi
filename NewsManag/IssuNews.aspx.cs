using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
	/// IssuNews ��ժҪ˵����
	/// </summary>
	public partial class IssuNews : System.Web.UI.Page
	{

		string strSql="";
		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intNewsID=0;
	
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
			
		
			if (!IsPostBack)
			{
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=1 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=UserInfo.UserID and PowerID=3 and OptionID=1)))", "UserType") != "1")
				{
					Response.Write("<script>alert('�Բ�����û�д˲���Ȩ�ޣ�')</script>");
					Response.End();
				}
				else
				{
					DelRelationData();//ɾ����������

					txtNewsTitle.Text="";
					txtNewsContent.Text="";
				
					
					System.DateTime currentTime=new System.DateTime();
					currentTime=System.DateTime.Now;
					txtCreateDate.Text=Convert.ToString(currentTime.ToString("d"));
				}
			}
		}
		#endregion

		#region//*********ɾ����������**********
		private void DelRelationData()
		{
           

            AccessDateHelper.ExecuteNonQuery("delete from NewsUser where NewsID="+intNewsID);
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

		#region//*********ѡ�������Ա*******
		protected void ButSelectAccount_Click(object sender, System.EventArgs e)
		{
			this.RegisterStartupScript("newWindow","<script language='javascript'>var obj=new Object();obj.name=document.all('txtSelectAccount').value;var str=window.showModalDialog('SelectBrower.aspx?NewsID="+intNewsID+"',obj,'dialogHeight:415px;dialogWidth:490px;edge:Raised;center:Yes;help:Yes;resizable:No;scroll:No;status:No;');if (str!=null) { document.all('txtSelectAccount').value=str; }</script>");
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
			

            string strTmp = AccessDateHelper.GetValues("select NewsID from NewsInfo where NewsTitle='" + ObjFun.getStr(ObjFun.CheckString(txtNewsTitle.Text.Trim()), 100) + "'", "NewsID");
			if (strTmp.Trim()!="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�����ű����Ѿ����ڣ����������룡')</script>");
				return;
			}

            string strNewClass = ObjFun.getStr(ddlNewClass.SelectedValue.ToString(),50);
			string strNewsTitle=ObjFun.getStr(ObjFun.CheckString(txtNewsTitle.Text.Trim()),100);
			string strNewsContent=txtNewsContent.Text;
			int intBrowAccount=0;
			
			int intCreateUserID=Convert.ToInt32(myUserID);
			DateTime dtmCreateDate=Convert.ToDateTime(txtCreateDate.Text);

           
            //    //�½�����
          
                intNewsID = AccessDateHelper.ExecuteNonQuery("insert into NewsInfo(NewsTitle,NewsContent,BrowAccount,BrowNumber,CreateUserID,CreateDate,class) values ('"+strNewsTitle+"','"+strNewsContent+"','"+intBrowAccount+"',0,'"+intCreateUserID+"','"+dtmCreateDate+"',"+strNewClass+")");
				
				
				//ObjTran.Commit();

				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�������ųɹ���');try{ window.opener.RefreshForm() }catch(e){};</script>");
          

			txtNewsTitle.Text="";
			txtNewsContent.Text="";

		

			System.DateTime currentTime=new System.DateTime();
			currentTime=System.DateTime.Now;
			txtCreateDate.Text=Convert.ToString(currentTime.ToString("d"));
		}
		#endregion

	}
}
