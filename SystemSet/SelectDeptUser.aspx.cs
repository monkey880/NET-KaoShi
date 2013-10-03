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

namespace EasyExam.SystemSet
{
	/// <summary>
	/// SelectDeptUser ��ժҪ˵����
	/// </summary>
	public partial class SelectDeptUser : System.Web.UI.Page
	{
		
		string strSql="";
		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intDeptID=0;

		#region//*********��ʼ��Ϣ*******
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
			//�������
			Response.Expires=0;
			Response.Buffer=true;
			Response.Clear();

			intDeptID=Convert.ToInt32(Request["DeptID"]);
			if (!IsPostBack)
			{
				ShowSelectedData();//��ʾѡ������
				//this.RegisterStartupScript("newWindow","<script language='javascript'>var obj=window.dialogArguments;document.all('txtQuery').value=obj.name;</script>");
			}
			strSql="select a.UserID,a.LoginID from UserInfo a";
			if (txtQuery.Text.Trim()!="")
			{
				strSql=strSql+" where (a.LoginID like '%"+txtQuery.Text.Trim()+"%' or a.UserName like '%"+txtQuery.Text.Trim()+"%')";
			}
			strSql=strSql+" order by a.LoginID asc";

			if (!IsPostBack)
			{
				ShowData(strSql);
			}
		}
		#endregion

		#region//******��ʾ�����б�******
		private void ShowData(string strSql)
		{
            //string strConn="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection objConn=new SqlConnection(strConn);
            //SqlDataAdapter objCmd=null;
            //DataSet objDS=null;

            LBSelect.Items.Clear();
            //objCmd=new SqlDataAdapter(strSql,objConn);
            //objDS=new DataSet();
            //objCmd.Fill(objDS,"UserInfo");
            DataSet objDS = AccessDateHelper.ExecuteDataset(strSql);
			for(int i=0;i<objDS.Tables[0].Rows.Count;i++)
			{
				LBSelect.Items.Add(new ListItem(objDS.Tables[0].Rows[i]["LoginID"].ToString().Trim(),objDS.Tables[0].Rows[i]["UserID"].ToString().Trim()));
			}

            //objCmd.Dispose();
            //objDS.Dispose();
            //objConn.Dispose();
		}
		#endregion

		#region//******��ʾ��ѡ�������б�******
		private void ShowSelectedData()
		{
            //string strConn="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection objConn=new SqlConnection(strConn);
            //SqlDataAdapter objCmd=null;
            //DataSet objDS=null;
            //objCmd=new SqlDataAdapter("select a.UserID,a.LoginID from UserInfo a where a.DeptID="+intDeptID+" order by a.LoginID asc",objConn);
            //objDS=new DataSet();
            //objCmd.Fill(objDS,"UserInfo");
            DataSet objDS = AccessDateHelper.ExecuteDataset("select a.UserID,a.LoginID from UserInfo a where a.DeptID=" + intDeptID + " order by a.LoginID asc");
			for(int i=0;i<objDS.Tables[0].Rows.Count;i++)
			{
				LBSelected.Items.Add(new ListItem(objDS.Tables[0].Rows[i]["LoginID"].ToString().Trim(),objDS.Tables[0].Rows[i]["UserID"].ToString().Trim()));
			}

            //objCmd.Dispose();
            //objDS.Dispose();
            //objConn.Dispose();
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

		#region//******ѡ������ʾ��Ա******
		private void DDLDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			strSql="select a.UserID,a.LoginID from UserInfo a";
			if (txtQuery.Text.Trim()!="")
			{
				strSql=strSql+" where (a.LoginID like '%"+txtQuery.Text.Trim()+"%' or a.UserName like '%"+txtQuery.Text.Trim()+"%')";
			}
			strSql=strSql+" order by a.LoginID asc";

			ShowData(strSql);	
		}
		#endregion

		#region//****��ѯ��Ա��ť�¼�****

		protected void ButQuery_Click(object sender, System.EventArgs e)
		{
			strSql="select a.UserID,a.LoginID from UserInfo a";
			if (txtQuery.Text.Trim()!="")
			{
				strSql=strSql+" where (a.LoginID like '%"+txtQuery.Text.Trim()+"%' or a.UserName like '%"+txtQuery.Text.Trim()+"%')";
			}
			strSql=strSql+" order by a.LoginID asc";

			ShowData(strSql);	
		}
		#endregion

		#region//****ѡ����Ա��ť�¼�****
		protected void butAllSelect_Click(object sender, System.EventArgs e)
		{
			ListItem LITmp=null;
			for(int i=0;i<LBSelect.Items.Count;i++)
			{
				LITmp=new ListItem(LBSelect.Items[i].Text,LBSelect.Items[i].Value);
				if(LBSelected.Items.IndexOf(LITmp)==-1)
				{
					LBSelected.Items.Add(LITmp);
				}
			}
			LBSelect.Items.Clear();
		}

		protected void butOneSelect_Click(object sender, System.EventArgs e)
		{
			ArrayList arrList=new ArrayList();
			foreach(ListItem item in LBSelect.Items)
			{
				if (item.Selected)
				{
					arrList.Add(item);
				}
			}  
			foreach(ListItem item in arrList)
			{
				if (LBSelected.Items.IndexOf(item)==-1)
				{
					LBSelected.Items.Add(item);
				}
				LBSelect.Items.Remove(item);
			}
			LBSelected.SelectedIndex=-1;
		}

		protected void butOneDel_Click(object sender, System.EventArgs e)
		{
			ArrayList arrList=new ArrayList();
			foreach(ListItem item in LBSelected.Items)
			{
				if (item.Selected)
				{
					arrList.Add(item);
				}
			}  
			foreach(ListItem item in arrList)
			{
				if (LBSelect.Items.IndexOf(item)==-1)
				{
					LBSelect.Items.Add(item);
				}
				LBSelected.Items.Remove(item);
			}
			LBSelect.SelectedIndex=-1;
		}

		protected void butAllDel_Click(object sender, System.EventArgs e)
		{
			ListItem LITmp=null;
			for(int i=0;i<LBSelected.Items.Count;i++)
			{
				LITmp=new ListItem(LBSelected.Items[i].Text,LBSelected.Items[i].Value);
				if(LBSelect.Items.IndexOf(LITmp)==-1)
				{
					LBSelect.Items.Add(LITmp);
				}
			}
			LBSelected.Items.Clear();
		}
		#endregion

		#region//********ѡ���ʺ���Ա*******
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			//���浽���ݿ�
			int i=0;
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn =new SqlConnection(strConn);
            //ObjConn.Open();
            //SqlTransaction ObjTran=ObjConn.BeginTransaction();
            //SqlCommand ObjCmd=new SqlCommand();
            //ObjCmd.Transaction=ObjTran;
            //ObjCmd.Connection=ObjConn;
			try
			{
                //ObjCmd.CommandText="Update UserInfo set DeptID=0 where DeptID="+intDeptID+"";
                //ObjCmd.ExecuteNonQuery();

                AccessDateHelper.ExecuteNonQuery("Update UserInfo set DeptID=0 where DeptID=" + intDeptID + "");

				for(i=0;i<LBSelected.Items.Count;i++)
				{
                    //ObjCmd.CommandText="Update UserInfo set DeptID="+intDeptID+" where UserID="+LBSelected.Items[i].Value+"";
                    //ObjCmd.ExecuteNonQuery();
                    AccessDateHelper.ExecuteNonQuery("Update UserInfo set DeptID=" + intDeptID + " where UserID=" + LBSelected.Items[i].Value + "");
				}

				//ObjTran.Commit();
			}
			catch
			{
				//ObjTran.Rollback();
			}
			finally
			{
                //ObjConn.Close();
                //ObjConn.Dispose();
			}
			this.RegisterStartupScript("newWindow","<script language='javascript'>window.close();</script>");
		}
		#endregion
	}
}