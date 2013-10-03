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

namespace EasyExam.PersonalInfo
{
	/// <summary>
	/// JoinJob ��ժҪ˵����
	/// </summary>
	public partial class MyGroup : System.Web.UI.Page
	{
	

		string strSql="";
		string myUserID="";
		string myLoginID="";
        public string res = "";
		PublicFunction ObjFun=new PublicFunction();
		int intUserID=0;
        
	
		#region//*******��ʼ����Ϣ********
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
            strSql = "select * from [Group] a ,UserInfo b where a.UserID=b.UserID  order by a.GroupID desc";
            if (!IsPostBack)
			{
				
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******��ʾ�����б�*******
		private void ShowData(string strSql)
		{
           
            DataSet SqlDS = AccessDateHelper.ExecuteDataset(strSql);
			
			for(int i=0;i<SqlDS.Tables[0].Rows.Count;i++)
			{
              
				res+="<table width='100%' border='0' cellpadding='5'>";
                res+="<tr>";
                res+="    <td width='39%' bgcolor='#D1EAF8'>Ⱥ�����ƣ�"+SqlDS.Tables[0].Rows[i]["GroupName"].ToString()+"</td>";
                res += "    <td colspan='2'  bgcolor='#D1EAF8'>�����ߣ�" + SqlDS.Tables[0].Rows[i]["UserName"].ToString() + "</td>";
                res += "    <td colspan='2'  bgcolor='#D1EAF8'>����ʱ�䣺" + SqlDS.Tables[0].Rows[i]["Uptime"].ToString() + "</td>";
                res+="    </tr>";
                res+="  <tr>";
                res += "    <td colspan='5'  bgcolor='#D1EAF8'>��飺" + SqlDS.Tables[0].Rows[i]["GroupContent"].ToString() + "</td>";
                res+="  </tr>";
                res+="  <tr>";
                if (AccessDateHelper.GetValues("select GroupID from [GroupUser] where UserID=" + myUserID + " and GroupID=" + SqlDS.Tables[0].Rows[i]["GroupID"].ToString() + "", "GroupID")!=null)
                {
                    res += "    <td colspan='5' align='right'  bgcolor='#D1EAF8'>���Ѽ���</td>";
                }
                else
                {
                    res += "    <td colspan='5' align='right'  bgcolor='#D1EAF8'><a href='?action=join&gid=" + SqlDS.Tables[0].Rows[i]["GroupID"].ToString() + "'>�������</a></td>";
                }
                res+="    </tr>";
                res += "</table>";

            				
				
			}
			
			//SqlConn.Dispose();
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
