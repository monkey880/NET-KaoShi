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

namespace EasyExam.PaperManag
{
	/// <summary>
	/// AddRandPolicy 的摘要说明。
	/// </summary>
	public partial class AddRandPolicy : System.Web.UI.Page
	{

		string strSql="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intPaperID=0;
	
		#region//*******初始化信息********
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
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
			intPaperID=Convert.ToInt32(Request["PaperID"]);
			strSql=LabCondition.Text;
			if (!IsPostBack)
			{
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=1 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=UserInfo.UserID and PowerID=3 and OptionID=4)))", "UserType") != "1")
				{
					Response.Write("<script>alert('对不起，您没有此操作权限！')</script>");
					Response.End();
				}
				else
				{
					ShowSubjectInfo();//显示科目信息
					DDLSubjectName.Items.FindByText("--请选择--").Selected=true;
					ShowTestTypeInfo();//显示题型名称
					DDLTestTypeName.Items.FindByText("--请选择--").Selected=true;
					strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from (((RubricInfo a LEFT  JOIN SubjectInfo b ON a.SubjectID=b.SubjectID) LEFT  JOIN LoreInfo c ON a.LoreID=c.LoreID )LEFT  JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID )LEFT  JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
					ShowData(strSql);
					LabCondition.Text=strSql;
				}
			}
		}
		#endregion

		#region//*********显示科目信息**********
		private void ShowSubjectInfo()
		{
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from SubjectInfo order by SubjectID");
			DDLSubjectName.Items.Clear();
			DDLSubjectName.DataSource=SqlDS.Tables[0].DefaultView;
			DDLSubjectName.DataTextField="SubjectName";
			DDLSubjectName.DataValueField="SubjectID";
			DDLSubjectName.DataBind();
			//SqlConn.Dispose();
			ListItem strTmp=new ListItem("--请选择--","0");
			DDLSubjectName.Items.Add(strTmp);
		}
		#endregion

		#region//*********显示知识点信息**********
		private void ShowLoreInfo(int SubjectID)
		{
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from LoreInfo where SubjectID=" + SubjectID + " order by LoreID");
			DDLLoreName.Items.Clear();
			DDLLoreName.DataSource=SqlDS.Tables[0].DefaultView;
			DDLLoreName.DataTextField="LoreName";
			DDLLoreName.DataValueField="LoreID";
			DDLLoreName.DataBind();
			//SqlConn.Dispose();
			ListItem strTmp=new ListItem("--请选择--","0");
			DDLLoreName.Items.Add(strTmp);
		}
		#endregion

		#region//*********显示题型名称**********
		private void ShowTestTypeInfo()
		{
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from TestTypeInfo order by TestTypeID");
			DDLTestTypeName.Items.Clear();
			DDLTestTypeName.DataSource=SqlDS.Tables[0].DefaultView;
			DDLTestTypeName.DataTextField="TestTypeName";
			DDLTestTypeName.DataValueField="TestTypeID";
			DDLTestTypeName.DataBind();
			//SqlConn.Dispose();
			ListItem strTmp=new ListItem("--请选择--","0");
			DDLTestTypeName.Items.Add(strTmp);

		}
		#endregion

		#region//*******科目选择发生改变*******
		protected void DDLSubjectName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ShowLoreInfo(Convert.ToInt32(DDLSubjectName.SelectedValue));
			DDLLoreName.Items.FindByText("--请选择--").Selected=true;
			ShowTestTypeInfo();
			DDLTestTypeName.Items.FindByText("--请选择--").Selected=true;

			strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from (((RubricInfo a LEFT  JOIN SubjectInfo b ON a.SubjectID=b.SubjectID )LEFT OUTER JOIN LoreInfo c ON a.LoreID=c.LoreID )LEFT OUTER JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID )LEFT OUTER JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
			ShowData(strSql);
			LabCondition.Text=strSql;
		}
		#endregion

		#region//*******知识点选择发生改变*******
		protected void DDLLoreName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ShowTestTypeInfo();
			DDLTestTypeName.Items.FindByText("--请选择--").Selected=true;

			strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from (((RubricInfo a LEFT OUTER JOIN SubjectInfo b ON a.SubjectID=b.SubjectID )LEFT OUTER JOIN LoreInfo c ON a.LoreID=c.LoreID) LEFT OUTER JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID) LEFT OUTER JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
			ShowData(strSql);
			LabCondition.Text=strSql;
		}
		#endregion

		#region//*******题型选择发生改变*******
		protected void DDLTestTypeName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from((( RubricInfo a LEFT OUTER JOIN SubjectInfo b ON a.SubjectID=b.SubjectID) LEFT OUTER JOIN LoreInfo c ON a.LoreID=c.LoreID )LEFT OUTER JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID) LEFT OUTER JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
			ShowData(strSql);
			LabCondition.Text=strSql;
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
			this.DataGridPolicy.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridPolicy_PageIndexChanged);
			this.DataGridPolicy.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridPolicy_ItemDataBound);

		}
		#endregion

		#region//*******表格翻页事件*******
		private void DataGridPolicy_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridPolicy.CurrentPageIndex=e.NewPageIndex;
			ShowData(strSql);
		}
		#endregion

		#region//*******行列颜色变换*******
		private void DataGridPolicy_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if( e.Item.ItemIndex != -1 )
			{
				e.Item.Attributes.Add("onmouseover", "this.bgColor='#ebf5fa'");

				if (e.Item.ItemIndex % 2 == 0 )
				{
					e.Item.Attributes.Add("bgcolor", "#FFFFFF");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridPolicy').getAttribute('singleValue')");
				}
				else
				{
					e.Item.Attributes.Add("bgcolor", "#F7F7F7");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridPolicy').getAttribute('oldValue')");
				}
			}
			else
			{
				DataGridPolicy.Attributes.Add("oldValue", "#F7F7F7");
				DataGridPolicy.Attributes.Add("singleValue", "#FFFFFF");
			}
		}
		#endregion

		#region//*******显示数据列表*******
		private void ShowData(string strSql)
		{

            DataSet SqlDS = AccessDateHelper.ExecuteDataset(strSql);
			DataGridPolicy.DataSource=SqlDS.Tables[0].DefaultView;
			DataGridPolicy.DataBind();

			
			DataSet SqlDSTmp=null;
			for(int i=0;i<DataGridPolicy.Items.Count;i++)
			{				
                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='易'");
				Label labTestDiff1=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff1");
				labTestDiff1.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);

              SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='较易'");
				Label labTestDiff2=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff2");
				labTestDiff2.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);

                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='中等'");
				Label labTestDiff3=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff3");
				labTestDiff3.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);

                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='较难'");
				Label labTestDiff4=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff4");
				labTestDiff4.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);
                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='难'");
				Label labTestDiff5=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff5");
				labTestDiff5.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);
			}
			//SqlConn.Dispose();
		}
		#endregion

		#region//*******进行编辑信息*******
		private void DataGridPolicy_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridPolicy.EditItemIndex=(int)e.Item.ItemIndex;
			ShowData(strSql);
		}
		#endregion

		#region//*******转到第一页*******
		private void LinkButFirstPage_Click(object sender, System.EventArgs e)
		{
			DataGridPolicy.CurrentPageIndex=0;
			ShowData(strSql);
		}
		#endregion

		#region//*******转到上一页*******
		private void LinkButPirorPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridPolicy.CurrentPageIndex>0)
			{
				DataGridPolicy.CurrentPageIndex-=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******转到下一页*******
		private void LinkButNextPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridPolicy.CurrentPageIndex<(DataGridPolicy.PageCount-1))
			{
				DataGridPolicy.CurrentPageIndex+=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******转到最后页*******
		private void LinkButLastPage_Click(object sender, System.EventArgs e)
		{
			DataGridPolicy.CurrentPageIndex=(DataGridPolicy.PageCount-1);
			ShowData(strSql);
		}
		#endregion

		#region//*******选定试题*******
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
//			if (ObjFun.JoySoftware()==false)
//			{
//				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('对不起，未注册用户不能添加策略！')</script>");
//				return;
//			}
			int intTestDiff=0,intSum=0,intRowID=0,intRubricID=0;
			double dblTestMark=0;
			if (DDLSubjectName.SelectedItem.Value=="0")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请选择科目名称！')</script>");
				return;
			}
			if (DDLLoreName.SelectedItem.Value=="0")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请选择知识点！')</script>");
				return;
			}
			if (DDLTestTypeName.SelectedItem.Value=="0")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请选择题型名称！')</script>");
				return;
			}
			TextBox strTestDiff=null,strTestDiff1=null,strTestDiff2=null,strTestDiff3=null,strTestDiff4=null,strTestDiff5=null;
			Label labTestDiff=null;
			for(int i=0;i<DataGridPolicy.Items.Count;i++)
			{
				for(int j=0;j<5;j++)
				{
					strTestDiff=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff"+Convert.ToString(j+1));
					labTestDiff=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff"+Convert.ToString(j+1));
					try
					{
						intTestDiff=Convert.ToInt32(strTestDiff.Text.Trim());
					}
					catch
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请在试题策略"+Convert.ToString(j+2)+"列中输入正确的题量！')</script>");
						return;
					}
					if ((intTestDiff<0)||(intTestDiff>Convert.ToInt32(labTestDiff.Text)))
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('在试题策略"+Convert.ToString(j+2)+"列中的数字应大于等于0并且小于等于"+labTestDiff.Text+"！')</script>");
						return;
					}
				}
				strTestDiff1=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff1");
				strTestDiff2=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff2");
				strTestDiff3=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff3");
				strTestDiff4=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff4");
				strTestDiff5=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff5");
				if (Convert.ToInt32(strTestDiff1.Text.Trim())+Convert.ToInt32(strTestDiff2.Text.Trim())+Convert.ToInt32(strTestDiff3.Text.Trim())+Convert.ToInt32(strTestDiff4.Text.Trim())+Convert.ToInt32(strTestDiff5.Text.Trim())==0)
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('在试题策略"+Convert.ToString(i+1)+"行中输入的题量应大于0！')</script>");
					return;
				}
			}
			//保存到数据库
			//保存试题策略
            if (AccessDateHelper.GetValues("select PaperPolicyID from PaperPolicy where SubjectID=" + DDLSubjectName.SelectedItem.Value + " and LoreID=" + DDLLoreName.SelectedItem.Value + " and TestTypeID=" + DDLTestTypeName.SelectedItem.Value + " and PaperID=" + intPaperID + "", "PaperPolicyID") == "")
			{
                AccessDateHelper.ExecuteNonQuery("Insert into PaperPolicy(PaperID,SubjectID,LoreID,TestTypeID,TestDiff1,TestDiff2,TestDiff3,TestDiff4,TestDiff5) values('" + intPaperID + "','" + DDLSubjectName.SelectedItem.Value + "','" + DDLLoreName.SelectedItem.Value + "','" + DDLTestTypeName.SelectedItem.Value + "','" + strTestDiff1.Text.Trim() + "','" + strTestDiff2.Text.Trim() + "','" + strTestDiff3.Text.Trim() + "','" + strTestDiff4.Text.Trim() + "','" + strTestDiff5.Text.Trim() + "')");
			}
			else
			{
                AccessDateHelper.ExecuteNonQuery("Update PaperPolicy set TestDiff1=" + strTestDiff1.Text.Trim() + ",TestDiff2=" + strTestDiff2.Text.Trim() + ",TestDiff3=" + strTestDiff3.Text.Trim() + ",TestDiff4=" + strTestDiff4.Text.Trim() + ",TestDiff5=" + strTestDiff5.Text.Trim() + " where SubjectID=" + DDLSubjectName.SelectedItem.Value + " and LoreID=" + DDLLoreName.SelectedItem.Value + " and TestTypeID=" + DDLTestTypeName.SelectedItem.Value + " and PaperID=" + intPaperID + "");
			}
            if (AccessDateHelper.GetValues("select PaperTestTypeID from PaperTestType where PaperID=" + intPaperID + " and TestTypeID=" + DDLTestTypeName.SelectedItem.Value + "", "PaperTestTypeID") == "")
			{
                AccessDateHelper.ExecuteNonQuery("Insert into PaperTestType(PaperID,TestTypeID,TestTypeTitle,TestTypeMark,TestAmount) values('" + intPaperID + "','" + DDLTestTypeName.SelectedItem.Value + "','" + DDLTestTypeName.SelectedItem.Text + "',0,0)");
			}
			DataSet SqlDS=null,SqlDSTmp=null;

            AccessDateHelper.ExecuteNonQuery("delete from PaperTest where RubricID in (select RubricID from RubricInfo  where    SubjectID=" + DDLSubjectName.SelectedItem.Value + " and LoreID=" + DDLLoreName.SelectedItem.Value + " and TestTypeID=" + DDLTestTypeName.SelectedItem.Value + ") and PaperID=" + intPaperID + "");


           SqlDS= AccessDateHelper.ExecuteDataset("select PaperPolicyID,SubjectID,LoreID,TestTypeID,TestDiff1,TestDiff2,TestDiff3,TestDiff4,TestDiff5 from PaperPolicy where SubjectID=" + DDLSubjectName.SelectedItem.Value + " and LoreID=" + DDLLoreName.SelectedItem.Value + " and TestTypeID=" + DDLTestTypeName.SelectedItem.Value + " and PaperID=" + intPaperID + " order by PaperPolicyID asc");
			for(int i=0;i<SqlDS.Tables[0].Rows.Count;i++)
			{
				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff1"]);
				if (intSum>0)
				{
                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='易'");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff2"]);
				if (intSum>0)
				{

                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='较易'");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff3"]);
				if (intSum>0)
				{
                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='中等' ");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff4"]);
				if (intSum>0)
				{

                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top "+intSum.ToString()+" "+intPaperID.ToString()+" AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID="+SqlDS.Tables[0].Rows[i]["SubjectID"]+" and LoreID="+SqlDS.Tables[0].Rows[i]["LoreID"]+" and TestTypeID="+SqlDS.Tables[0].Rows[i]["TestTypeID"]+" and TestDiff='较难' ");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff5"]);
				if (intSum>0)
				{
                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='难'");
				}
			}

            AccessDateHelper.ExecuteNonQuery("Update PaperTestType set TestAmount=" + Convert.ToInt32(AccessDateHelper.GetValues("select Count(*) as TestCount from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID=" + DDLTestTypeName.SelectedItem.Value + " and PaperID=" + intPaperID + "", "TestCount")) + " where TestTypeID=" + DDLTestTypeName.SelectedItem.Value + " and PaperID=" + intPaperID + "");

       

			this.RegisterStartupScript("newWindow","<script language='javascript'>alert('添加试题策略成功！');</script>");
		}
		#endregion

	}
}
