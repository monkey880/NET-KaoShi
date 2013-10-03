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
using System.IO;


namespace EasyExam.Teacher
{
	/// <summary>
	/// ManagUserList 的摘要说明。
	/// </summary>
	public partial class LoreUserList : System.Web.UI.Page
	{
		protected int RowNum=0,LinNum=0;

		bool bWhere;
		string strSql="";
		string myUserID="";
		string myLoginID="";
        int intUserID = 0;
		PublicFunction ObjFun=new PublicFunction();

		#region//*******初始信息*********
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
				intUserID =Convert.ToInt32(Request["UserID"]);
			}
			
			if (!IsPostBack)
			{
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=2 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=UserInfo.UserID and PowerID=3 and OptionID=2)))", "UserType") != "2")
				{
					Response.Write("<script>alert('对不起，您没有此操作权限！')</script>");
					Response.End();
				}
				else
				{


                    strSql = "select LoreID,LoreName from LoreInfo ";
					if (DataGridUser.Attributes["SortExpression"] == null)
					{
						DataGridUser.Attributes["SortExpression"] = "LoreID";
						DataGridUser.Attributes["SortDirection"] = "DESC";
					}
					ShowData(strSql);
					
                    
				}
			}
			if (Request["hidcommand"]=="RefreshForm")
			{
				ShowData(strSql);//显示数据
			}
		}
		#endregion

	

		#region//******显示数据列表******
		private void ShowData(string strSql)
		{
           
            DataSet SqlDS = AccessDateHelper.ExecuteDataset(strSql);
			RowNum=DataGridUser.CurrentPageIndex*DataGridUser.PageSize+1;
			LinNum=0;

			string SortExpression = DataGridUser.Attributes["SortExpression"];
			string SortDirection = DataGridUser.Attributes["SortDirection"];
			SqlDS.Tables[0].DefaultView.Sort = SortExpression + " " + SortDirection;

			DataGridUser.DataSource=SqlDS.Tables[0].DefaultView;
			DataGridUser.DataBind();

           
			for(int i=0;i<DataGridUser.Items.Count;i++)
			{
                HyperLink LinkButUserScore = (HyperLink)DataGridUser.Items[i].FindControl("LinkButUserScore");
                LinkButUserScore.NavigateUrl = "ShowLoreUser.aspx?LoreID="+DataGridUser.Items[i].Cells[0].Text;
					
			}
			LabelRecord.Text=Convert.ToString(SqlDS.Tables[0].Rows.Count);
			LabelCountPage.Text=Convert.ToString(DataGridUser.PageCount);
			LabelCurrentPage.Text=Convert.ToString(DataGridUser.CurrentPageIndex+1);
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
			this.DataGridUser.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridUser_PageIndexChanged);
			this.DataGridUser.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGridUser_SortCommand);
			this.DataGridUser.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridUser_DeleteCommand);
			this.DataGridUser.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridUser_ItemDataBound);

		}
		#endregion

		#region//*******表格分页信息*********
		private void DataGridUser_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridUser.CurrentPageIndex=e.NewPageIndex;
			ShowData(strSql);		
		}
		#endregion

		#region//*******删除选定帐户*******
		private void DataGridUser_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            int intUserID=Convert.ToInt32(e.Item.Cells[0].Text);
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection SqlConn=new SqlConnection(strConn);
            //SqlConn.Open();
            //SqlCommand SqlCmd=null;
			if ((e.Item.Cells[3].Text.Trim().ToUpper()!="ADMIN")&&(e.Item.Cells[3].Text.Trim().ToUpper()!="GUEST"))
			{
				if ((myLoginID.Trim().ToUpper()=="ADMIN")||(myLoginID.Trim().ToUpper()==e.Item.Cells[10].Text.Trim().ToUpper()))
				{
                    ////数据表NewsUser
                    //SqlCmd=new SqlCommand("delete from NewsUser where UserID="+intUserID+"",SqlConn);
                    //SqlCmd.ExecuteNonQuery();
                    ////数据表PaperUser
                    //SqlCmd=new SqlCommand("delete from PaperUser where UserID="+intUserID+"",SqlConn);
                    //SqlCmd.ExecuteNonQuery();
                    ////数据表UserAnswer
                    //SqlCmd=new SqlCommand("delete UserAnswer from UserAnswer a LEFT OUTER JOIN UserScore b ON a.UserScoreID=b.UserScoreID where b.UserID="+intUserID+"",SqlConn);
                    //SqlCmd.ExecuteNonQuery();
                    ////数据表UserScore
                    //SqlCmd=new SqlCommand("delete from UserScore where UserID="+intUserID+"",SqlConn);
                    //SqlCmd.ExecuteNonQuery();
                    ////数据表UserPower
                    //SqlCmd=new SqlCommand("delete from UserPower where UserID="+intUserID+"",SqlConn);
                    //SqlCmd.ExecuteNonQuery();
                    //SqlCmd=new SqlCommand("delete from UserPower where PowerID=1 and OptionID="+intUserID+"",SqlConn);
                    //SqlCmd.ExecuteNonQuery();
                    ////数据表UserInfo
                    //SqlCmd=new SqlCommand("delete from UserInfo where UserID="+intUserID+"",SqlConn);
                    //SqlCmd.ExecuteNonQuery();

                    AccessDateHelper.ExecuteNonQuery("delete from NewsUser where UserID=" + intUserID + "");
                    AccessDateHelper.ExecuteNonQuery("delete from PaperUser where UserID=" + intUserID + "");
                    string UserScoreID = AccessDateHelper.GetValues("select UserScoreID from UserScore where UserID=" + intUserID, "UserScoreID");
                    AccessDateHelper.ExecuteNonQuery("delete from UserAnswer  where UserScoreID=" + UserScoreID + "");
                    AccessDateHelper.ExecuteNonQuery("delete from UserScore where UserID=" + intUserID + "");
                    AccessDateHelper.ExecuteNonQuery("delete from UserPower where UserID=" + intUserID + "");
                    AccessDateHelper.ExecuteNonQuery("delete from UserPower where PowerID=1 and OptionID=" + intUserID + "");
                    AccessDateHelper.ExecuteNonQuery("delete from UserInfo where UserID=" + intUserID + "");
				}
			}
            //SqlConn.Close();
            //SqlConn.Dispose();

			//自动翻页
			if (DataGridUser.Items.Count==1&&DataGridUser.CurrentPageIndex>0)
			{
				DataGridUser.CurrentPageIndex--;
			}        

			ShowData(strSql);
		}
		#endregion

		#region//*******行列颜色变换*******
		private void DataGridUser_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if( e.Item.ItemIndex != -1 )
			{
				e.Item.Attributes.Add("onmouseover", "this.bgColor='#ebf5fa'");

				if (e.Item.ItemIndex % 2 == 0 )
				{
					e.Item.Attributes.Add("bgcolor", "#FFFFFF");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridUser').getAttribute('singleValue')");
				}
				else
				{
					e.Item.Attributes.Add("bgcolor", "#F7F7F7");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridUser').getAttribute('oldValue')");
				}
			}
			else
			{
				DataGridUser.Attributes.Add("oldValue", "#F7F7F7");
				DataGridUser.Attributes.Add("singleValue", "#FFFFFF");
			}
		}
		#endregion

	

		#region//*******查询人员信息*******
		protected void btnQuery_Click(object sender, System.EventArgs e)
		{
			bWhere=false;
            strSql = "select a.UserID,a.LoginID,a.UserName,a.UserSex,b.DeptName,c.JobName,Switch( a.UserType = 0 , '普通帐户' , a.UserType =1 , '管理帐户' ) as UserType,Switch (a.UserState = 1 , '正常' ,a.UserState = 0 , '禁止' ) as UserState,d.LoginID as CreateLoginID,a.CreateDate as CreateDate from ((UserInfo a LEFT  JOIN DeptInfo b ON a.DeptID=b.DeptID )LEFT  JOIN JobInfo c ON a.JobID=c.JobID )LEFT  JOIN UserInfo d ON a.CreateUserID=d.UserID";
			
			
			
			strSql=strSql+" order by a.UserID desc";

			DataGridUser.CurrentPageIndex=0;
			ShowData(strSql);
			
		}
		#endregion

		

	


		#region//*******转到第一页*******
		protected void LinkButFirstPage_Click(object sender, System.EventArgs e)
		{
			DataGridUser.CurrentPageIndex=0;
            ShowData(strSql);
		}
		#endregion

		#region//*******转到上一页*******
		protected void LinkButPirorPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridUser.CurrentPageIndex>0)
			{
				DataGridUser.CurrentPageIndex-=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******转到下一页*******
		protected void LinkButNextPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridUser.CurrentPageIndex<(DataGridUser.PageCount-1))
			{
				DataGridUser.CurrentPageIndex+=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******转到最后页*******
		protected void LinkButLastPage_Click(object sender, System.EventArgs e)
		{
			DataGridUser.CurrentPageIndex=(DataGridUser.PageCount-1);
			ShowData(strSql);
		}
		#endregion

		

		#region//*******数据排序*******
		private void DataGridUser_SortCommand (object source , System.Web.UI.WebControls.DataGridSortCommandEventArgs e )
        {
			//获得列名
			//string sColName = e.SortExpression ;

			string ImgDown = "<img border=0 src=" + Request.ApplicationPath + "/Images/uparrow.gif>";
			string ImgUp = "<img border=0 src=" + Request.ApplicationPath + "/Images/downarrow.gif>";
			string SortExpression = e.SortExpression.ToString();
			string SortDirection = "ASC";
			int colindex = -1;
			//清空之前的图标
			for (int i = 0; i < DataGridUser.Columns.Count; i++)
			{
				DataGridUser.Columns[i].HeaderText = (DataGridUser.Columns[i].HeaderText).ToString().Replace(ImgDown, "");
				DataGridUser.Columns[i].HeaderText = (DataGridUser.Columns[i].HeaderText).ToString().Replace(ImgUp, "");
			}
			//找到所点击的HeaderText的索引号
			for (int i = 0; i < DataGridUser.Columns.Count; i++)
			{
				if (DataGridUser.Columns[i].SortExpression == e.SortExpression)
				{
					colindex = i;
					break;
				}
			}
			if (SortExpression == DataGridUser.Attributes["SortExpression"])
			{
 
				SortDirection = (DataGridUser.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");
 
			}
			DataGridUser.Attributes["SortExpression"] = SortExpression;
			DataGridUser.Attributes["SortDirection"] = SortDirection;
			if (DataGridUser.Attributes["SortDirection"] == "ASC")
			{
				DataGridUser.Columns[colindex].HeaderText = DataGridUser.Columns[colindex].HeaderText + ImgDown;
			}
			else
			{
				DataGridUser.Columns[colindex].HeaderText = DataGridUser.Columns[colindex].HeaderText + ImgUp;
			}
			ShowData(strSql);
		}
		#endregion

	}
}
