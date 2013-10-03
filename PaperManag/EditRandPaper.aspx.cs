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

namespace EasyExam.PaperManag
{
	/// <summary>
	/// EditRandPaper 的摘要说明。
	/// </summary>
	public partial class EditRandPaper : System.Web.UI.Page
	{

		string strSql="";
		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intPaperID=0,intUserID=0;
		int intPaperTypeID=0,intCreateUserID=0;
		bool bJoySoftware=false;
	
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
			intPaperID=Convert.ToInt32(Request["PaperID"]);
			intPaperTypeID=Convert.ToInt32(Request["PaperType"]);
			bJoySoftware=ObjFun.JoySoftware();

			
			if (!IsPostBack)
			{

                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=1 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=UserInfo.UserID and PowerID=3 and OptionID=4)))", "UserType") != "1")
				{
					Response.Write("<script>alert('对不起，您没有此操作权限！')</script>");
					Response.End();
				}
				else
				{
					if ((intPaperID!=0)&&(intPaperTypeID!=0))
					{
//						if (bJoySoftware==false)
//						{
//							ButInput.Attributes.Add("onclick", "javascript:alert('对不起，未注册用户不能修改试卷！');return false;");
//							ButAddPolicy.Attributes.Add("onclick", "javascript:alert('对不起，未注册用户不能修改试卷！');return false;");
//							ButSelectExam.Attributes.Add("onclick", "javascript:alert('对不起，未注册用户不能修改试卷！');return false;");
//							ButSelectManager.Attributes.Add("onclick", "javascript:alert('对不起，未注册用户不能修改试卷！');return false;");
//						}
//						else
//						{
							ButInput.Attributes.Add("onclick", "javascript:submitexam1.style.visibility='visible';return true;");
							ButAddPolicy.Attributes.Add("onclick", "javascript:var str=window.showModalDialog('AddRandPolicy.aspx?PaperID="+intPaperID+"','','dialogHeight:190px;dialogWidth:500px;edge:Raised;center:Yes;help:Yes;resizable:No;scroll:No;status:No;');");
							
//						}
						ShowPaperPolicy();//显示试题策略
						
						LoadPaperData();//加载试卷数据
					}
				}
			}
		}
		#endregion

		#region//*********删除关联数据**********
		private void DelRelationData()
		{
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn = new SqlConnection(strConn);
            //ObjConn.Open();
            //SqlTransaction ObjTran=ObjConn.BeginTransaction();
            //SqlCommand ObjCmd=new SqlCommand();
            //ObjCmd.Transaction=ObjTran;
            //ObjCmd.Connection=ObjConn;
			try
			{
                //ObjCmd.CommandText="delete from PaperPolicy where PaperID="+intPaperID+"";
                //ObjCmd.ExecuteNonQuery();

                //ObjCmd.CommandText="delete from PaperTestType where PaperID="+intPaperID+"";
                //ObjCmd.ExecuteNonQuery();

                //ObjCmd.CommandText="delete from PaperUser where PaperID="+intPaperID+"";
                //ObjCmd.ExecuteNonQuery();
				
                //ObjCmd.CommandText="delete from PaperTest where PaperID="+intPaperID+"";
                //ObjCmd.ExecuteNonQuery();
                //ObjTran.Commit();

                AccessDateHelper.ExecuteNonQuery("delete from PaperPolicy where PaperID=" + intPaperID + "");
                AccessDateHelper.ExecuteNonQuery("delete from PaperTestType where PaperID=" + intPaperID + "");
                AccessDateHelper.ExecuteNonQuery("delete from PaperUser where PaperID=" + intPaperID + "");
                AccessDateHelper.ExecuteNonQuery("delete from PaperTest where PaperID=" + intPaperID + "");
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
		}
		#endregion

		#region//******显示试题策略列表******
		private void ShowPaperPolicy()
		{
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection SqlConn=new SqlConnection(strConn);
            //SqlDataAdapter SqlCmd=new SqlDataAdapter("select a.PaperPolicyID,a.SubjectID,b.SubjectName,a.LoreID,c.LoreName,a.TestTypeID,d.TestTypeName,a.TestDiff1,a.TestDiff2,a.TestDiff3,a.TestDiff4,a.TestDiff5 from PaperPolicy a,SubjectInfo b,LoreInfo c,TestTypeInfo d where a.SubjectID=b.SubjectID and a.LoreID=c.LoreID and a.TestTypeID=d.TestTypeID and a.PaperID="+intPaperID+" order by a.PaperPolicyID asc",SqlConn);
            //DataSet SqlDS=new DataSet();
            //SqlCmd.Fill(SqlDS,"PaperPolicy");
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select a.PaperPolicyID,a.SubjectID,b.SubjectName,a.LoreID,c.LoreName,a.TestTypeID,d.TestTypeName,a.TestDiff1,a.TestDiff2,a.TestDiff3,a.TestDiff4,a.TestDiff5 from PaperPolicy a,SubjectInfo b,LoreInfo c,TestTypeInfo d where a.SubjectID=b.SubjectID and a.LoreID=c.LoreID and a.TestTypeID=d.TestTypeID and a.PaperID=" + intPaperID + " order by a.PaperPolicyID asc");
			DataGridPolicy.DataSource=SqlDS.Tables[0].DefaultView;
			DataGridPolicy.DataBind();

			for(int i=0;i<DataGridPolicy.Items.Count;i++)
			{
				TextBox strTestDiff1=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff1");
				strTestDiff1.Text=SqlDS.Tables[0].Rows[i]["TestDiff1"].ToString();

				TextBox strTestDiff2=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff2");
				strTestDiff2.Text=SqlDS.Tables[0].Rows[i]["TestDiff2"].ToString();

				TextBox strTestDiff3=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff3");
				strTestDiff3.Text=SqlDS.Tables[0].Rows[i]["TestDiff3"].ToString();

				TextBox strTestDiff4=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff4");
				strTestDiff4.Text=SqlDS.Tables[0].Rows[i]["TestDiff4"].ToString();

				TextBox strTestDiff5=(TextBox)DataGridPolicy.Items[i].FindControl("txtTestDiff5");
				strTestDiff5.Text=SqlDS.Tables[0].Rows[i]["TestDiff5"].ToString();

				LinkButton LBEdit=(LinkButton)DataGridPolicy.Items[i].FindControl("LinkButEdit");
				LinkButton LBDel=(LinkButton)DataGridPolicy.Items[i].FindControl("LinkButDel");
//				if (bJoySoftware==false)
//				{
//					LBEdit.Attributes.Add("onclick", "javascript:alert('对不起，未注册用户不能修改试卷！');return false;");
//					LBDel.Attributes.Add("onclick", "javascript:alert('对不起，未注册用户不能修改试卷！');return false;");
//				}
//				else
//				{
					LBEdit.Attributes.Add("onclick", "javascript:var str=window.showModalDialog('EditRandPolicy.aspx?PaperID="+intPaperID+"&SubjectID="+DataGridPolicy.Items[i].Cells[10].Text+"&LoreID="+DataGridPolicy.Items[i].Cells[11].Text+"&TestTypeID="+DataGridPolicy.Items[i].Cells[12].Text+"','','dialogHeight:190px;dialogWidth:500px;edge:Raised;center:Yes;help:Yes;resizable:No;scroll:No;status:No;');");
					LBDel.Attributes.Add("onclick", "javascript:{if(confirm('确定要删除选择策略吗？')==false) return false;}");
//				}
			}
			//SqlConn.Dispose();
		}
		#endregion

	

		#region//**********加载要修改的试卷数据*********
		private void LoadPaperData()
		{
            //string strConn="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn = new SqlConnection(strConn);
            //SqlConnection SqlConn = new SqlConnection(strConn);
            //SqlCommand ObjCmd=new SqlCommand("select * from PaperInfo where PaperID="+intPaperID+"",ObjConn);
            //ObjConn.Open();
            //SqlDataReader ObjDR= ObjCmd.ExecuteReader(CommandBehavior.CloseConnection);
            OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader("select * from PaperInfo where PaperID=" + intPaperID + "");
			if (ObjDR.Read())
			{
				txtPaperName.Text=ObjDR["PaperName"].ToString();

                txtPaperContent.Text = ObjDR["Content"].ToString();
				
				DataSet SqlDS=null;
				int i=0;
				
				
				intCreateUserID=Convert.ToInt32(ObjDR["CreateUserID"].ToString());
			}
			
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
			this.DataGridPolicy.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPolicy_ItemCommand);
			this.DataGridPolicy.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPolicy_DeleteCommand);
			this.DataGridPolicy.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridPolicy_ItemDataBound);
			

		}
		#endregion

	

		#region//*******DataGridPolicy行列颜色变换*******
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

		#region//*******DataGridPolicy删除选中策略*******
		private void DataGridPolicy_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int intPaperPolicyID=Convert.ToInt32(e.Item.Cells[0].Text);
			int intSubjectID=Convert.ToInt32(e.Item.Cells[10].Text);
			int intLoreID=Convert.ToInt32(e.Item.Cells[11].Text);
			int intTestTypeID=Convert.ToInt32(e.Item.Cells[12].Text);

			

            AccessDateHelper.ExecuteNonQuery("delete from PaperPolicy where PaperPolicyID=" + intPaperPolicyID + "");
            if (AccessDateHelper.GetValues("select PaperPolicyID from PaperPolicy where PaperID='" + intPaperID + "' and TestTypeID='" + intTestTypeID + "'", "PaperPolicyID") == "")
			{
				
                AccessDateHelper.ExecuteNonQuery("delete from PaperTestType where PaperID='" + intPaperID + "' and TestTypeID='" + intTestTypeID + "'");
			}

			
			DataSet SqlDSTmp=null;
			
            AccessDateHelper.ExecuteNonQuery("select a.PaperTestID,a.RubricID,b.SubjectID,b.LoreID,b.TestTypeID from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.SubjectID=" + intSubjectID + "and b.LoreID=" + intLoreID + " and b.TestTypeID=" + intTestTypeID + " and a.PaperID=" + intPaperID + " order by a.PaperTestID asc");
			for(int i=0;i<SqlDSTmp.Tables[0].Rows.Count;i++)
			{
				
                AccessDateHelper.ExecuteNonQuery("delete from PaperTest where PaperTestID=" + Convert.ToInt32(SqlDSTmp.Tables[0].Rows[i]["PaperTestID"]) + "");
			}
			//更新题型题量
		

            AccessDateHelper.ExecuteNonQuery("Update PaperTestType set TestAmount=" + Convert.ToInt32(ObjFun.GetValues("select Count(*) as TestCount from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID=" + intTestTypeID + " and PaperID=" + intPaperID + "", "TestCount")) + " where TestTypeID=" + intTestTypeID + " and PaperID=" + intPaperID + "");

			ShowPaperPolicy();
			
		}
		#endregion

		#region//*******DataGridPolicy按钮事件*******
		private void DataGridPolicy_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Edit")
			{
				ShowPaperPolicy();//显示试题策略
				
			}
		}
		#endregion

		#region//*******DataGridTestType行列颜色变换*******
		private void DataGridTestType_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if( e.Item.ItemIndex != -1 )
			{
				e.Item.Attributes.Add("onmouseover", "this.bgColor='#ebf5fa'");

				if (e.Item.ItemIndex % 2 == 0 )
				{
					e.Item.Attributes.Add("bgcolor", "#FFFFFF");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridTestType').getAttribute('singleValue')");
				}
				else
				{
					e.Item.Attributes.Add("bgcolor", "#F7F7F7");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridTestType').getAttribute('oldValue')");
				}
			}
			else
			{
				
			}
		}
		#endregion

		
		
		#region//*******提交按钮事件*******
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			int i=0,j=0,intExamTime=0,intPaperMark=0,intPassMark=0,intSaveTime=0,intTestCount=0,intAutoJudge=1,intTmp=0;
			double dblTestTypeMark=0,dblTotalMark=0,dblRate=0;
//			if (ObjFun.JoySoftware()==false)
//			{
//				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('对不起，未注册用户不能修改试卷！')</script>");
//				return;
//			}
			if (txtPaperName.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请输入试卷名称！')</script>");
				return;
			}
		
			
			
			if (DataGridPolicy.Items.Count==0)
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('请添加试题策略！')</script>");
				return;
			}
			TextBox strTestDiff1=null,strTestDiff2=null,strTestDiff3=null,strTestDiff4=null,strTestDiff5=null;
			for(i=0;i<DataGridPolicy.Items.Count;i++)
			{
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
			TextBox strTestTypeTitle=null;
			TextBox strTestTypeMark=null;
		




			string strPaperName=ObjFun.getStr(ObjFun.CheckString(txtPaperName.Text.Trim()),50);
		
			int intMarkDefine=0;
			
			int intCreateUserID=Convert.ToInt32(myUserID);
			DateTime currentTime=new System.DateTime();
			currentTime=System.DateTime.Now;
			DateTime dtmCreateDate=Convert.ToDateTime(currentTime.ToString("d"));

            string strTmp = AccessDateHelper.GetValues("select PaperName from PaperInfo where PaperName='" + strPaperName + "' and PaperID<>" + intPaperID + "", "PaperName");
			if (strTmp!="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('此试卷名称已经存在！')</script>");
				return;
			}
			else
			{
				
                //try
                //{
					
					DataSet SqlDS=null,SqlDSTmp=null;
					//生成试题
				
                   // AccessDateHelper.ExecuteNonQuery("Update PaperTest set PaperTest.TestMark=RubricInfo.TestMark from PaperTest,RubricInfo where PaperTest.RubricID=RubricInfo.RubricID and PaperID=" + intPaperID + "");
					//SqlCmd=new SqlDataAdapter("select a.RubricID,b.TestMark from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and PaperID="+intPaperID+"",SqlConn);
					//SqlDS=new DataSet();
					//SqlCmd.Fill(SqlDS,"PaperTest");
					//for(i=0;i<SqlDS.Tables[0].Rows.Count;i++)
					//{
					//	ObjectCmd.CommandText="Update PaperTest set TestMark="+SqlDS.Tables[0].Rows[i]["TestMark"]+" where RubricID="+SqlDS.Tables[0].Rows[i]["RubricID"]+" and PaperID="+intPaperID+"";
					//	ObjectCmd.ExecuteNonQuery();
					//}

					
			
					//统计试题数量
				
                    SqlDS = AccessDateHelper.ExecuteDataset("select Count(*) as TestCount from PaperTest where PaperID=" + intPaperID + "");
					intTestCount=Convert.ToInt32(SqlDS.Tables[0].Rows[0]["TestCount"]);
					
					//更新试卷
				

                    AccessDateHelper.ExecuteNonQuery("Update PaperInfo set PaperName='" + strPaperName + "',TestCount='" + intTestCount + "',AutoJudge='" + intAutoJudge + "',CreateWay=1,Content='"+txtPaperContent.Text+"' where PaperID=" + intPaperID + "");

					
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('修改随机组卷成功！');try{ window.opener.RefreshForm() }catch(e){};window.close();</script>");
                //}
                //catch
                //{
					
                //    this.RegisterStartupScript("newWindow","<script language='javascript'>alert('修改随机组卷失败！')</script>");
                //}
                //finally
                //{
					
                //}
			}
		}
		#endregion

		#region//*******取消按钮事件*******
		private void ButCancel_Click(object sender, System.EventArgs e)
		{
			if (intPaperTypeID==1)
			{
				Response.Redirect("ManagExamPaper.aspx");
			}
			else
			{
				Response.Redirect("ManagJobPaper.aspx");
			}
		}
		#endregion

		#region//*******添加策略事件*******
		protected void ButAddPolicy_Click(object sender, System.EventArgs e)
		{
			ShowPaperPolicy();//显示试题策略
			
		}
		#endregion

	}
}
