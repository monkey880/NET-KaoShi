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
using System.Data.OleDb;
using EasyExam;
using System.Management;
using System.Text;
using System.Security.Cryptography;

namespace EasyExam
{
	/// <summary>
	/// Login 的摘要说明。
	/// </summary>
	public partial class Login : System.Web.UI.Page
	{
//        PublicFunction pf=new PublicFunction();


		string myLoginID="";
		string strUserID="";
		string strLoginID="";
		string strUserName="";
		string strUserPwd="";
		PublicFunction ObjFun=new PublicFunction();
        
       
      
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{

                

				string strSql="";
				string strConn="";
				strSql="select * from SystemSet where SetName='OnLineRegist'";
                //strConn=ConfigurationSettings.AppSettings["accConn"];
                //OleDbConnection accConn = new OleDbConnection(strConn);
                ////SqlConnection ObjConn = new SqlConnection(strConn);
                //accConn.Open();
                //OleDbCommand ObjCmd = new OleDbCommand(strSql, accConn);
                //OleDbDataReader ObjDR=ObjCmd.ExecuteReader(CommandBehavior.CloseConnection);

                OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader(strSql);
                
				if (ObjDR.Read())
				{
					
				}
				ObjDR.Close();
                //accConn.Dispose();
				//注销帐户
				Session["UserID"]="";
				Session["LoginID"]="";
				Session["UserName"]="";
				Session["UserPwd"]="";
				//自动登录
				if ((Request["LoginID"]!=null)&&(Request["UserPwd"]!=null))
				{
					ButLogin_Click(sender,e);
				}
			}
		}

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

		protected void ButLogin_Click(object sender, System.EventArgs e)
		{
			string strSql="";
			string strConn="";

			strLoginID=ObjFun.CheckString(Convert.ToString(Request["LoginID"]).Trim());
			strUserPwd=ObjFun.CheckString(Convert.ToString(Request["UserPwd"]).Trim());
            //if ((TimeRestrict()==true)&&(strLoginID.ToUpper()!="ADMIN"))//判断登录时间是否受限
            //{
            //    this.RegisterStartupScript("newWindow","<script language='javascript'>alert('对不起，您登录的时间受限！');</script>");
            //    return;
            //}
            //if ((IPRestrict()==true)&&(strLoginID.ToUpper()!="ADMIN"))//判断登录IP是否受限
            //{
            //    this.RegisterStartupScript("newWindow","<script language='javascript'>alert('对不起，您登录的IP受限！');</script>");
            //    return;
            //}
			
			strSql="select * from UserInfo where LoginID='"+strLoginID+"' and UserPwd='"+strUserPwd+"'";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn=new SqlConnection(strConn);
            //ObjConn.Open();
            //SqlCommand ObjCmd=new SqlCommand(strSql,ObjConn);
            //SqlDataReader ObjDR=ObjCmd.ExecuteReader(CommandBehavior.CloseConnection);
            OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader(strSql);
			if (ObjDR.Read())
			{
				string strUserIP=Convert.ToString(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);//先取得代理IP
				if ((strUserIP=="")||(strUserIP==null))
				{
					strUserIP=Convert.ToString(Request.ServerVariables["REMOTE_ADDR"]);//如果代理IP为空就取直接IP
				}
				if ((Convert.ToString(ObjDR["LoginIP"])!="")&&(Convert.ToString(ObjDR["LoginIP"])!=strUserIP))//判断登录IP是否受制
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('对不起，您不是指定的登录IP！');</script>");
				}
				else
				{
					if ((Convert.ToInt32(ObjDR["UserState"])==0)&&(strLoginID.ToUpper()!="ADMIN"))//判断帐号是否被禁用
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('对不起，此帐号已被禁用！');</script>");
					}
					else
					{
						Session["UserID"]=Convert.ToString(ObjDR["UserID"]);
						Session["LoginID"]=Convert.ToString(ObjDR["LoginID"]);
						Session["UserName"]=Convert.ToString(ObjDR["UserName"]);
						Session["UserPwd"]=Convert.ToString(ObjDR["UserPwd"]);

                        if (Convert.ToInt32(ObjDR["UserType"]) == 1)
                        {
                            Response.Redirect("MainFrame.aspx");
                        }
                        else if (Convert.ToInt32(ObjDR["UserType"]) == 2)
                        {
                            Response.Redirect("Teacher/");
                        }
                        else
                        {
                            Response.Redirect("PersonInfo/");
                        }

					}
				}
			}
			else
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('对不起，帐号或密码错误！');</script>");
			}
			ObjDR.Close();
			//ObjConn.Dispose();
		}

		#region//******判断时间范围是否受限*****
		private bool TimeRestrict()
		{
			bool bTmp=false;
			string strConn="";
			string strStartTime="";
			string strEndTime="";
			string strNowTime=DateTime.Now.ToShortTimeString();
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn=new SqlConnection(strConn);
            //SqlDataAdapter ObjCmd=new SqlDataAdapter("select * from SystemSet where SetName='LoginTime'",ObjConn);

            DataSet ObjDS = AccessDateHelper.ExecuteDataset("select * from SystemSet where SetName='LoginTime'");

			//ObjCmd.Fill(ObjDS,"SystemSet");

			if (ObjDS.Tables["SystemSet"].Rows.Count>0)
			{
				strStartTime=ObjDS.Tables["SystemSet"].Rows[0]["StartValue"].ToString().Trim();
				strEndTime=ObjDS.Tables["SystemSet"].Rows[0]["EndValue"].ToString().Trim();
				if ((strStartTime!="")&&(strEndTime!=""))
				{
					DateTime DTNowTime;
					DateTime DTStartTime;
					DateTime DTEndTime;

					DTNowTime=Convert.ToDateTime(strNowTime);
					DTStartTime=Convert.ToDateTime(strStartTime);
					DTEndTime=Convert.ToDateTime(strEndTime);
			
					if ((DTNowTime<DTStartTime)||(DTNowTime>DTEndTime))
					{
						bTmp=true;
					}
				}
			}

			//ObjConn.Dispose();
			return bTmp;
		}
		#endregion

		#region//******判断IP范围是否受限*****
		private bool IPRestrict()
		{
			bool bTmp=false;
			string strConn="";
			string strUserIP=Convert.ToString(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);//先取得代理IP
			string strStartIP="";
			string strEndIP="";
			if ((strUserIP=="")||(strUserIP==null))
			{
				strUserIP=Convert.ToString(Request.ServerVariables["REMOTE_ADDR"]);//如果代理IP为空就取直接IP
			}
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn=new SqlConnection(strConn);
            //SqlDataAdapter ObjCmd=new SqlDataAdapter("select * from SystemSet where SetName='LoginIP'",ObjConn);
            DataSet ObjDS = AccessDateHelper.ExecuteDataset("select * from SystemSet where SetName='LoginIP");
			//ObjCmd.Fill(ObjDS,"SystemSet");
			if (ObjDS.Tables["SystemSet"].Rows.Count>0)
			{
				strStartIP=ObjDS.Tables["SystemSet"].Rows[0]["StartValue"].ToString().Trim();
				strEndIP=ObjDS.Tables["SystemSet"].Rows[0]["EndValue"].ToString().Trim();
				if ((strStartIP!="")&&(strEndIP!=""))
				{
					string[] ArrUserIP;
					string[] ArrStartIP;
					string[] ArrEndIP;
					ArrUserIP=strUserIP.Split('.');
					ArrStartIP=strStartIP.Split('.');
					ArrEndIP=strEndIP.Split('.');

					for(int i=0;i<ArrUserIP.Length;i++)
					{
						if ((Convert.ToInt16(ArrUserIP[i])<Convert.ToInt16(ArrStartIP[i]))||(Convert.ToInt16(ArrUserIP[i])>Convert.ToInt16(ArrEndIP[i])))
						{
							bTmp=true;
						}
					}
				}
			}

			//ObjConn.Dispose();
			return bTmp;
		}
		#endregion

	
		//获得网卡序列号----MAc地址
		public string GetMoAddress()
		{
			string MoAddress = " ";
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc2 = mc.GetInstances();
			foreach (ManagementObject mo in moc2)
			{
				if ((bool)mo["IPEnabled"] == true)
					MoAddress = mo["MacAddress"].ToString();
				mo.Dispose();
			}
			return MoAddress.ToString();
		}

		//加密
		public static string Encrypt(string Text)
		{
			return Encrypt(Text, "zhangweilong");
		}
		public static string Encrypt(string Text, string sKey)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			byte[] inputByteArray;
			inputByteArray = Encoding.Default.GetBytes(Text);
			des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			StringBuilder ret = new StringBuilder();
			foreach (byte b in ms.ToArray())
			{
				ret.AppendFormat("{0:X2}", b);
			}
			return ret.ToString();
		}

		//解密
		public static string Decrypt(string Text)
		{
			return Decrypt(Text, "zhangweilong");
		}
		public static string Decrypt(string Text, string sKey)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			int len;
			len = Text.Length / 2;
			byte[] inputByteArray = new byte[len];
			int x, i;
			for (x = 0; x < len; x++)
			{
				i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
				inputByteArray[x] = (byte)i;
			}
			des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			return Encoding.Default.GetString(ms.ToArray());
		}

	}
}

