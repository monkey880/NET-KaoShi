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

namespace EasyExam.SystemSet
{
	/// <summary>
	/// SetOther 的摘要说明。
	/// </summary>
	public partial class SetOther : System.Web.UI.Page
	{

		string strSql="";
		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intRegistUser=0,intRegistManag=0,intRegistWay=0;
	
		#region//************初始化信息*********
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
			txtStartTime.Attributes["readonly"]="true";
			txtEndTime.Attributes["readonly"]="true";
			if (!IsPostBack)
			{
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and LoginID='Admin'", "UserType") != "1")
				{
					Response.Write("<script>alert('对不起，您没有此操作权限！')</script>");
					Response.End();
				}
				else
				{
					LoadSetOtherData();
				}
			}
		}
		#endregion

		#region//**********加载要修改的数据*********
		private void LoadSetOtherData()
		{
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection SqlConn=new SqlConnection(strConn);
            //SqlDataAdapter SqlCmd=new SqlDataAdapter("select * from SystemSet",SqlConn);
            //DataSet SqlDS=new DataSet();
            //SqlCmd.Fill(SqlDS,"SystemSet");
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from SystemSet");
			for(int i=0;i<SqlDS.Tables[0].Rows.Count;i++)
			{
				if (SqlDS.Tables[0].Rows[i]["SetName"].ToString()=="LoginIP")
				{
					txtStartIP.Text=SqlDS.Tables[0].Rows[i]["StartValue"].ToString();
					txtEndIP.Text=SqlDS.Tables[0].Rows[i]["EndValue"].ToString();
				}
				if (SqlDS.Tables[0].Rows[i]["SetName"].ToString()=="LoginTime")
				{
					txtStartTime.Text=SqlDS.Tables[0].Rows[i]["StartValue"].ToString();
					txtEndTime.Text=SqlDS.Tables[0].Rows[i]["EndValue"].ToString();
				}
				if (SqlDS.Tables[0].Rows[i]["SetName"].ToString()=="OnLineRegist")
				{
					if (SqlDS.Tables[0].Rows[i]["StartValue"].ToString()=="0")
					{
						chkRegistUser.Checked=false;
					}
					else
					{
						chkRegistUser.Checked=true;
					}
				}
				if (SqlDS.Tables[0].Rows[i]["SetName"].ToString()=="RegistManag")
				{
					if (SqlDS.Tables[0].Rows[i]["StartValue"].ToString()=="0")
					{
						chkRegistManag.Checked=false;
					}
					else
					{
						chkRegistManag.Checked=true;
					}
				}
				if (SqlDS.Tables[0].Rows[i]["SetName"].ToString()=="RegistWay")
				{
					if (SqlDS.Tables[0].Rows[i]["StartValue"].ToString()=="0")
					{
						rbRegistDefine2.Checked=true;
						rbRegistDefine1.Checked=false;
					}
					else
					{
						rbRegistDefine1.Checked=true;
						rbRegistDefine2.Checked=false;
					}
				}
                if (SqlDS.Tables[0].Rows[i]["SetName"].ToString() == "SiteName")
                {

                    txtSiteName.Text = SqlDS.Tables[0].Rows[i]["StartValue"].ToString();
                    
                }
                if (SqlDS.Tables[0].Rows[i]["SetName"].ToString() == "SiteDescription")
                {


                    txtDescription.Text = SqlDS.Tables[0].Rows[i]["StartValue"].ToString();

                }
                if (SqlDS.Tables[0].Rows[i]["SetName"].ToString() == "SiteKeywords")
                {

                    txtKeywords.Text = SqlDS.Tables[0].Rows[i]["StartValue"].ToString();
                   

                }
                if (SqlDS.Tables[0].Rows[i]["SetName"].ToString() == "WebUrl")
                {


                    txtUrl.Text = SqlDS.Tables[0].Rows[i]["StartValue"].ToString();

                }
                if (SqlDS.Tables[0].Rows[i]["SetName"].ToString() == "Tongji")
                {


                    txtTongji.Text = SqlDS.Tables[0].Rows[i]["StartValue"].ToString();

                }
			}
			//SqlConn.Dispose();
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

		#region//*********提交新闻信息***********
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			if (((txtStartTime.Text.Trim()!="")&&(txtEndTime.Text.Trim()==""))||((txtStartTime.Text.Trim()=="")&&(txtEndTime.Text.Trim()!="")))
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请输入完整的登录时间范围！')</script>");
				return;
			}
			if (((txtStartIP.Text.Trim()!="")&&(txtEndIP.Text.Trim()==""))||((txtStartIP.Text.Trim()=="")&&(txtEndIP.Text.Trim()!="")))
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请输入完整的登录IP范围！')</script>");
				return;
			}
			if ((txtStartIP.Text.Trim()!="")&&(txtEndIP.Text.Trim()!=""))
			{
				string[] strArrStartIP=txtStartIP.Text.Trim().Split('.');
				string[] strArrEndIP=txtEndIP.Text.Trim().Split('.');
				if(strArrStartIP.Length!=4)
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('起始IP地址不合法！')</script>");
					return;
				}
				if(strArrEndIP.Length!=4)
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('终止IP地址不合法！')</script>");
					return;
				}
				for(int i=0;i<strArrStartIP.Length;i++)
				{
					try
					{
						if ((int.Parse(strArrStartIP[i])<0)||(int.Parse(strArrStartIP[i])>255))
						{
							this.RegisterStartupScript("newWindow","<script language='javascript'>alert('起始IP地址不合法！')</script>");
							return;
						}
					}
					catch
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('起始IP地址不合法！')</script>");
						return;
					}
					try
					{
						if ((int.Parse(strArrEndIP[i])<0)||(int.Parse(strArrEndIP[i])>255))
						{
							this.RegisterStartupScript("newWindow","<script language='javascript'>alert('终止IP地址不合法！')</script>");
							return;
						}
					}
					catch
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('终止IP地址不合法！')</script>");
						return;
					}
				}
			}

			

			string strTmp="";
			//时间范围

            strTmp = AccessDateHelper.GetValues("select SetName from SystemSet where SetName='LoginTime'", "SetName");
			if (strTmp=="")
			{
				
                AccessDateHelper.ExecuteNonQuery("insert into SystemSet(SetName,StartValue,EndValue) values('LoginTime','" + txtStartTime.Text.Trim() + "','" + txtEndTime.Text.Trim() + "')");
			}
			else
			{
				
                AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + txtStartTime.Text.Trim() + "',EndValue='" + txtEndTime.Text.Trim() + "' where SetName='LoginTime'");
			}
			//IP范围
            strTmp = AccessDateHelper.GetValues("select SetName from SystemSet where SetName='LoginIP'", "SetName");
			if (strTmp=="")
			{
				
                AccessDateHelper.ExecuteNonQuery("insert into SystemSet(SetName,StartValue,EndValue) values('LoginIP','" + txtStartIP.Text.Trim() + "','" + txtEndIP.Text.Trim() + "')");
			}
			else
			{
				

                AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + txtStartIP.Text.Trim() + "',EndValue='" + txtEndIP.Text.Trim() + "' where SetName='LoginIP'");
			}
			//帐户注册
			if (chkRegistUser.Checked)
			{
				intRegistUser=1;
			}
			else
			{
				intRegistUser=0;
			}
            strTmp = AccessDateHelper.GetValues("select SetName from SystemSet where SetName='OnLineRegist'", "SetName");
			if (strTmp=="")
			{
				

                AccessDateHelper.ExecuteNonQuery("insert into SystemSet(SetName,StartValue,EndValue) values('OnLineRegist','" + intRegistUser.ToString() + "','0')");
			}
			else
			{
				
                AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + intRegistUser.ToString() + "',EndValue='0' where SetName='OnLineRegist'");
			}
			//管理帐户注册
			if (chkRegistManag.Checked)
			{
				intRegistManag=1;
			}
			else
			{
				intRegistManag=0;
			}
            strTmp = AccessDateHelper.GetValues("select SetName from SystemSet where SetName='RegistManag'", "SetName");
			if (strTmp=="")
			{
				
                AccessDateHelper.ExecuteNonQuery("insert into SystemSet(SetName,StartValue,EndValue) values('RegistManag','" + intRegistManag.ToString() + "','0')");
			}
			else
			{
				

                AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + intRegistManag.ToString() + "',EndValue='0' where SetName='RegistManag'");
			}
			//生效方式
			if (rbRegistDefine1.Checked)
			{
				intRegistWay=1;
			}
			else
			{
				intRegistWay=0;
			}
            strTmp = AccessDateHelper.GetValues("select SetName from SystemSet where SetName='RegistWay'", "SetName");
			if (strTmp=="")
			{
				
                AccessDateHelper.ExecuteNonQuery("insert into SystemSet(SetName,StartValue,EndValue) values('RegistWay','" + intRegistWay.ToString() + "','0')");
			}
			else
			{
				
                AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + intRegistWay.ToString() + "',EndValue='0' where SetName='RegistWay'");
			}


            AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + txtSiteName.Text + "',EndValue='0' where SetName='SiteName'");
            AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + txtDescription.Text + "',EndValue='0' where SetName='SiteDescription'");
            AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + txtKeywords.Text + "',EndValue='0' where SetName='SiteKeywords'");
            AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + txtUrl.Text + "',EndValue='0' where SetName='WebUrl'");
            AccessDateHelper.ExecuteNonQuery("update SystemSet set StartValue='" + txtTongji.Text + "',EndValue='0' where SetName='Tongji'");
           

			this.RegisterStartupScript("newWindow","<script language='javascript'>alert('综合设置成功！')</script>");
		}
		#endregion

	}
}
