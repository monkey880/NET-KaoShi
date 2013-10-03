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
	/// SelectSubjectUser 的摘要说明。
	/// </summary>
	public partial class SelectSubjectUser : System.Web.UI.Page
	{
		
		string strSql1="",strSql2="";
		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intSubjectID=0;

		#region//*********初始信息*******
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
			//清除缓存
			Response.Expires=0;
			Response.Buffer=true;
			Response.Clear();

			intSubjectID=Convert.ToInt32(Request["SubjectID"]);
			if (!IsPostBack)
			{
                if (Convert.ToInt32(AccessDateHelper.GetValues("select BrowAccount from SubjectInfo where SubjectID=" + intSubjectID + "", "BrowAccount")) == 1)
				{
					rbAllAccount.Checked=true;
					rbSelectAccount.Checked=false;
				}
				else
				{
					rbSelectAccount.Checked=true;
					rbAllAccount.Checked=false;
				}
				
				ShowSelectedData();//显示选择数据
				//this.RegisterStartupScript("newWindow","<script language='javascript'>var obj=window.dialogArguments;document.all('txtQuery').value=obj.name;</script>");
			}
			//显示全部
			
				strSql1="select DeptID,DeptName from DeptInfo order by DeptName";
				strSql2="select a.UserID,a.LoginID from UserInfo a";
				if (txtQuery.Text.Trim()!="")
				{
					strSql2=strSql2+" where (a.LoginID like '%"+txtQuery.Text.Trim()+"%' or a.UserName like '%"+txtQuery.Text.Trim()+"%')";
				}
			
			
			strSql2=strSql2+" order by a.LoginID asc";

			if (!IsPostBack)
			{
				ShowData(strSql1,strSql2);
			}
		}
		#endregion

		

		#region//******显示数据列表******
		private void ShowData(string strSql1,string strSql2)
		{
			string strConn="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection objConn=new SqlConnection(strConn);
            //SqlDataAdapter objCmd=null;
            DataSet objDS=null;

			LBSelect.Items.Clear();
            //objCmd=new SqlDataAdapter(strSql1,objConn);
            //objDS=new DataSet();
            //objCmd.Fill(objDS,"DeptInfo");
            objDS = AccessDateHelper.ExecuteDataset(strSql1);
			for(int i=0;i<objDS.Tables[0].Rows.Count;i++)
			{
				LBSelect.Items.Add(new ListItem(objDS.Tables[0].Rows[i]["DeptName"].ToString().Trim(),"#"+objDS.Tables[0].Rows[i]["DeptID"].ToString().Trim()));
			}

            //objCmd=new SqlDataAdapter(strSql2,objConn);
            //objDS=new DataSet();
            //objCmd.Fill(objDS,"UserInfo");
            DataSet objDS2 = AccessDateHelper.ExecuteDataset(strSql2);
			for(int i=0;i<objDS2.Tables[0].Rows.Count;i++)
			{
				LBSelect.Items.Add(new ListItem(objDS2.Tables[0].Rows[i]["LoginID"].ToString().Trim(),objDS2.Tables[0].Rows[i]["UserID"].ToString().Trim()));
			}

			//objCmd.Dispose();
			objDS.Dispose();
			//objConn.Dispose();
		}
		#endregion

		#region//******显示已选择数据列表******
		private void ShowSelectedData()
		{
			string strConn="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection objConn=new SqlConnection(strConn);
            //SqlDataAdapter objCmd=null;
			DataSet objDS=null;

			LBSelected.Items.Clear();
            //objCmd=new SqlDataAdapter("select b.DeptID,b.DeptName from SubjectUser a,DeptInfo b where a.DeptID=b.DeptID and a.SubjectID="+intSubjectID+" order by b.DeptName asc",objConn);
            //objDS=new DataSet();
            //objCmd.Fill(objDS,"DeptInfo");
            objDS = AccessDateHelper.ExecuteDataset("select b.DeptID,b.DeptName from SubjectUser a,DeptInfo b where a.DeptID=b.DeptID and a.SubjectID=" + intSubjectID + " order by b.DeptName asc");
			for(int i=0;i<objDS.Tables[0].Rows.Count;i++)
			{
				LBSelected.Items.Add(new ListItem(objDS.Tables[0].Rows[i]["DeptName"].ToString().Trim(),"#"+objDS.Tables[0].Rows[i]["DeptID"].ToString().Trim()));
			}

            //objCmd=new SqlDataAdapter("select b.UserID,b.LoginID from SubjectUser a,UserInfo b where a.UserID=b.UserID and a.SubjectID="+intSubjectID+" order by b.LoginID asc",objConn);
            //objDS=new DataSet();
            //objCmd.Fill(objDS,"UserInfo");
            DataSet objDS2 = AccessDateHelper.ExecuteDataset("select b.UserID,b.LoginID from SubjectUser a,UserInfo b where a.UserID=b.UserID and a.SubjectID=" + intSubjectID + " order by b.LoginID asc");
			for(int i=0;i<objDS2.Tables[0].Rows.Count;i++)
			{
				LBSelected.Items.Add(new ListItem(objDS2.Tables[0].Rows[i]["LoginID"].ToString().Trim(),objDS2.Tables[0].Rows[i]["UserID"].ToString().Trim()));
			}

			//objCmd.Dispose();
			objDS.Dispose();
			//objConn.Dispose();
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

		

		#region//****查询人员按钮事件****

		protected void ButQuery_Click(object sender, System.EventArgs e)
		{
			
				strSql1="select DeptID,DeptName from DeptInfo order by DeptName";
				strSql2="select a.UserID,a.LoginID from UserInfo a";
				if (txtQuery.Text.Trim()!="")
				{
					strSql2=strSql2+" where (a.LoginID like '%"+txtQuery.Text.Trim()+"%' or a.UserName like '%"+txtQuery.Text.Trim()+"%')";
				}
			
			strSql2=strSql2+" order by a.LoginID asc";

			ShowData(strSql1,strSql2);	
		}
		#endregion

		#region//****选择人员按钮事件****
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

		#region//********选定帐号人员*******
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			//保存到数据库
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
                //ObjCmd.CommandText="delete from SubjectUser where SubjectID="+intSubjectID+"";
                //ObjCmd.ExecuteNonQuery();

                AccessDateHelper.ExecuteNonQuery("delete from SubjectUser where SubjectID=" + intSubjectID + "");

				if (rbAllAccount.Checked==true)
				{
                    //ObjCmd.CommandText="Update SubjectInfo set BrowAccount=1 where SubjectID="+intSubjectID+"";
                    //ObjCmd.ExecuteNonQuery();
                    AccessDateHelper.ExecuteNonQuery("Update SubjectInfo set BrowAccount=1 where SubjectID=" + intSubjectID + "");
				}
				else
				{
					for(i=0;i<LBSelected.Items.Count;i++)
					{
						if (LBSelected.Items[i].Value.ToString().IndexOf("#")>=0)
						{
                            //ObjCmd.CommandText="insert into SubjectUser(SubjectID,UserID,DeptID) values("+intSubjectID+",0,"+LBSelected.Items[i].Value.Replace("#","")+")";
                            //ObjCmd.ExecuteNonQuery();
                            AccessDateHelper.ExecuteNonQuery("insert into SubjectUser(SubjectID,UserID,DeptID) values(" + intSubjectID + ",0," + LBSelected.Items[i].Value.Replace("#", "") + ")");
						}
						else
						{
                            //ObjCmd.CommandText="insert into SubjectUser(SubjectID,UserID,DeptID) values("+intSubjectID+","+LBSelected.Items[i].Value+",0)";
                            //ObjCmd.ExecuteNonQuery();

                            AccessDateHelper.ExecuteNonQuery("insert into SubjectUser(SubjectID,UserID,DeptID) values(" + intSubjectID + "," + LBSelected.Items[i].Value + ",0)");
						}
					}
                    //ObjCmd.CommandText="Update SubjectInfo set BrowAccount=2 where SubjectID="+intSubjectID+"";
                    //ObjCmd.ExecuteNonQuery();
                    AccessDateHelper.ExecuteNonQuery("Update SubjectInfo set BrowAccount=2 where SubjectID=" + intSubjectID + "");
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
