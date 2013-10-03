using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace EasyExam.Teacher
{
	/// <summary>
	/// EditCustomPaper ��ժҪ˵����
	/// </summary>
	public partial class EditCustomPaper : System.Web.UI.Page
	{

		string strSql="";
		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intPaperID=0,intUserID=0;
		int intPaperTypeID=0,intCreateUserID=0;
		bool bJoySoftware=false;
	
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
			intPaperID=Convert.ToInt32(Request["PaperID"]);
			intPaperTypeID=Convert.ToInt32(Request["PaperType"]);
			bJoySoftware=ObjFun.JoySoftware();

			if (!IsPostBack)
			{
                string UserID = AccessDateHelper.GetValues("select UserID from UserInfo where LoginID='" + myLoginID + "'", "UserID");
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=2 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=" + UserID + " and PowerID=3 and OptionID=4)))", "UserType") != "2")
				{
					Response.Write("<script>alert('�Բ�����û�д˲���Ȩ�ޣ�')</script>");
					Response.End();
				}
				else
				{
					if ((intPaperID!=0)&&(intPaperTypeID!=0))
					{
							ButInput.Attributes.Add("onclick", "javascript:submitexam1.style.visibility='visible';return true;");
							ButAddPolicy.Attributes.Add("onclick", "javascript:var str=window.showModalDialog('AddCustomPolicy.aspx?PaperID="+intPaperID+"','','dialogHeight:497px;dialogWidth:660px;edge:Raised;center:Yes;help:Yes;resizable:No;scroll:No;status:No;');");
						

						ShowPaperPolicy();//��ʾ�������
						
						LoadPaperData();//�����Ծ�����
					}
				}
			}
		}
		#endregion

		#region//*********ɾ����������**********
		private void DelRelationData()
		{
            

            AccessDateHelper.ExecuteNonQuery("delete from PaperPolicy where PaperID=" + intPaperID + "");
            AccessDateHelper.ExecuteNonQuery("delete from PaperTestType where PaperID=" + intPaperID + "");
            AccessDateHelper.ExecuteNonQuery("delete from PaperUser where PaperID=" + intPaperID + "");
            AccessDateHelper.ExecuteNonQuery("delete from PaperTest where PaperID=" + intPaperID + "");
           
		}
		#endregion

		#region//******��ʾ��������б�******
		private void ShowPaperPolicy()
		{
           
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select a.PaperPolicyID,a.SubjectID,b.SubjectName,a.LoreID,c.LoreName,a.TestTypeID,d.TestTypeName,a.TestDiff1,a.TestDiff2,a.TestDiff3,a.TestDiff4,a.TestDiff5 from PaperPolicy a,SubjectInfo b,LoreInfo c,TestTypeInfo d where a.SubjectID=b.SubjectID and a.LoreID=c.LoreID and a.TestTypeID=d.TestTypeID and a.PaperID=" + intPaperID + " order by a.PaperPolicyID asc");
			DataGridPolicy.DataSource=SqlDS.Tables[0].DefaultView;
			DataGridPolicy.DataBind();

			SqlDataAdapter SqlCmdTmp=null;
			DataSet SqlDSTmp=null;
			for(int i=0;i<DataGridPolicy.Items.Count;i++)
			{
              

                SqlDSTmp = AccessDateHelper.ExecuteDataset("select a.PaperTestID,a.RubricID,b.SubjectID,b.LoreID,b.TestTypeID from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and b.LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and b.TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and a.PaperID=" + intPaperID + " order by a.PaperTestID asc");

				TextBox strSelectTest=(TextBox)DataGridPolicy.Items[i].FindControl("txtSelectTest");
				strSelectTest.Text="";
				for(int j=0;j<SqlDSTmp.Tables[0].Rows.Count;j++)
				{
					if (strSelectTest.Text=="")
					{
						strSelectTest.Text=strSelectTest.Text+SqlDSTmp.Tables[0].Rows[j]["RubricID"].ToString();
					}
					else
					{
						strSelectTest.Text=strSelectTest.Text+";"+SqlDSTmp.Tables[0].Rows[j]["RubricID"].ToString();
					}
				}
				LinkButton LBEdit=(LinkButton)DataGridPolicy.Items[i].FindControl("LinkButEdit");
				LinkButton LBDel=(LinkButton)DataGridPolicy.Items[i].FindControl("LinkButDel");
                LBEdit.Attributes.Add("onclick", "javascript:window.location.href='EditCustomPolicy.aspx?PaperID=" + intPaperID + "&SubjectID=" + DataGridPolicy.Items[i].Cells[6].Text + "&LoreID=" + DataGridPolicy.Items[i].Cells[7].Text + "&TestTypeID=" + DataGridPolicy.Items[i].Cells[8].Text + "';");
					LBDel.Attributes.Add("onclick", "javascript:{if(confirm('ȷ��Ҫɾ��ѡ�������')==false) return false;}");
			}
		}
		#endregion

		

		#region//**********����Ҫ�޸ĵ��Ծ�����*********
		private void LoadPaperData()
		{
           
            OleDbDataReader ObjDR = AccessDateHelper.ExecuteReader("select * from PaperInfo where PaperID=" + intPaperID + "");
            if (ObjDR.Read())
            {
                txtPaperName.Text = ObjDR["PaperName"].ToString();




                DataSet SqlDS = null;
                int i = 0;
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
			this.DataGridPolicy.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPolicy_ItemCommand);
			this.DataGridPolicy.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPolicy_DeleteCommand);
			this.DataGridPolicy.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridPolicy_ItemDataBound);
			this.DataGridTestType.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridTestType_ItemCommand);
			this.DataGridTestType.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridTestType_ItemDataBound);

		}
		#endregion

		

		#region//*******DataGridPolicy������ɫ�任*******
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

		#region//*******DataGridPolicyɾ��ѡ�в���*******
		private void DataGridPolicy_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int intPaperPolicyID=Convert.ToInt32(e.Item.Cells[0].Text);
			int intSubjectID=Convert.ToInt32(e.Item.Cells[6].Text);
			int intLoreID=Convert.ToInt32(e.Item.Cells[7].Text);
			int intTestTypeID=Convert.ToInt32(e.Item.Cells[8].Text);

            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection SqlConn=new SqlConnection(strConn);
            //SqlConn.Open();
            //SqlCommand SqlCmd=null;
            //SqlCmd=new SqlCommand("delete from PaperPolicy where PaperPolicyID="+intPaperPolicyID+"",SqlConn);
            //SqlCmd.ExecuteNonQuery();
            AccessDateHelper.ExecuteNonQuery("delete from PaperPolicy where PaperPolicyID=" + intPaperPolicyID + "");
            if (AccessDateHelper.GetValues("select PaperPolicyID from PaperPolicy where PaperID='" + intPaperID + "' and TestTypeID='" + intTestTypeID + "'", "PaperPolicyID") == "")
			{
                //SqlCmd=new SqlCommand("delete from PaperTestType where PaperID='"+intPaperID+"' and TestTypeID='"+intTestTypeID+"'",SqlConn);
                //SqlCmd.ExecuteNonQuery();
                AccessDateHelper.ExecuteNonQuery("delete from PaperTestType where PaperID='" + intPaperID + "' and TestTypeID='" + intTestTypeID + "'");
			}

            //SqlDataAdapter SqlCmdTmp=null;
            //DataSet SqlDSTmp=null;
            //SqlCmdTmp=new SqlDataAdapter("select a.PaperTestID,a.RubricID,b.SubjectID,b.LoreID,b.TestTypeID from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.SubjectID="+intSubjectID+"and b.LoreID="+intLoreID+" and b.TestTypeID="+intTestTypeID+" and a.PaperID="+intPaperID+" order by a.PaperTestID asc",SqlConn);
            //SqlDSTmp=new DataSet();
            //SqlCmdTmp.Fill(SqlDSTmp,"PaperTest");
            DataSet SqlDSTmp = AccessDateHelper.ExecuteDataset("select a.PaperTestID,a.RubricID,b.SubjectID,b.LoreID,b.TestTypeID from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.SubjectID=" + intSubjectID + "and b.LoreID=" + intLoreID + " and b.TestTypeID=" + intTestTypeID + " and a.PaperID=" + intPaperID + " order by a.PaperTestID asc");
			for(int i=0;i<SqlDSTmp.Tables[0].Rows.Count;i++)
			{
                //SqlCmd=new SqlCommand("delete from PaperTest where PaperTestID="+Convert.ToInt32(SqlDSTmp.Tables[0].Rows[i]["PaperTestID"])+"",SqlConn);
                //SqlCmd.ExecuteNonQuery();
                AccessDateHelper.ExecuteNonQuery("delete from PaperTest where PaperTestID=" + Convert.ToInt32(SqlDSTmp.Tables[0].Rows[i]["PaperTestID"]) + "");
			}
			//������������
            //SqlCmd=new SqlCommand("Update PaperTestType set TestAmount="+Convert.ToInt32(ObjFun.GetValues("select Count(*) as TestCount from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID="+intTestTypeID+" and PaperID="+intPaperID+"","TestCount"))+" where TestTypeID="+intTestTypeID+" and PaperID="+intPaperID+"",SqlConn);
            //SqlCmd.ExecuteNonQuery();

            //SqlConn.Close();
            //SqlConn.Dispose();

            AccessDateHelper.ExecuteNonQuery("Update PaperTestType set TestAmount=" + Convert.ToInt32(AccessDateHelper.GetValues("select Count(*) as TestCount from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID=" + intTestTypeID + " and PaperID=" + intPaperID + "", "TestCount")) + " where TestTypeID=" + intTestTypeID + " and PaperID=" + intPaperID + "");

			ShowPaperPolicy();
			ShowPaperTestType();
		}
		#endregion

		#region//*******DataGridPolicy��ť�¼�*******
		private void DataGridPolicy_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Edit")
			{
				ShowPaperPolicy();//��ʾ�������
				ShowPaperTestType();//��ʾ�������
			}
		}
		#endregion

		#region//*******DataGridTestType������ɫ�任*******
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
				DataGridTestType.Attributes.Add("oldValue", "#F7F7F7");
				DataGridTestType.Attributes.Add("singleValue", "#FFFFFF");
			}
		}
		#endregion

		#region//*******DataGridTestType��ť�¼�*******
		private void DataGridTestType_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int intPriorPaperTestTypeID=0,intPriorTestTypeID=0,intPriorTestAmount=0,intNextPaperTestTypeID=0,intNextTestTypeID=0,intNextTestAmount=0;
			string strPriorTestTypeTitle="",strNextTestTypeTitle="";
			double dblPriorTestTypeMark=0,dblNextTestTypeMark=0;

			string strConn=ConfigurationSettings.AppSettings["strConn"];
			SqlConnection SqlConn=new SqlConnection(strConn);
			SqlCommand SqlCmd=null;
			SqlDataReader ObjDR=null;
			if (e.CommandName=="MoveUp")
			{
				if (e.Item.ItemIndex>0)
				{
					SqlConn.Open();
					intPriorPaperTestTypeID=Convert.ToInt32(DataGridTestType.Items[e.Item.ItemIndex-1].Cells[0].Text);
					SqlCmd=new SqlCommand("select TestTypeID,TestTypeTitle,TestTypeMark,TestAmount from PaperTestType where PaperTestTypeID='"+intPriorPaperTestTypeID+"'",SqlConn);
					ObjDR=SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
					if (ObjDR.Read())
					{
						intPriorTestTypeID=Convert.ToInt32(ObjDR["TestTypeID"].ToString());
						strPriorTestTypeTitle=ObjDR["TestTypeTitle"].ToString();
						dblPriorTestTypeMark=Convert.ToDouble(ObjDR["TestTypeMark"].ToString());
						intPriorTestAmount=Convert.ToInt32(ObjDR["TestAmount"].ToString());
					}
					SqlConn.Close();

					SqlConn.Open();
					intNextPaperTestTypeID=Convert.ToInt32(DataGridTestType.Items[e.Item.ItemIndex].Cells[0].Text);
					SqlCmd=new SqlCommand("select TestTypeID,TestTypeTitle,TestTypeMark,TestAmount from PaperTestType where PaperTestTypeID='"+intNextPaperTestTypeID+"'",SqlConn);
					ObjDR=SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
					if (ObjDR.Read())
					{
						intNextTestTypeID=Convert.ToInt32(ObjDR["TestTypeID"].ToString());
						strNextTestTypeTitle=ObjDR["TestTypeTitle"].ToString();
						dblNextTestTypeMark=Convert.ToDouble(ObjDR["TestTypeMark"].ToString());
						intNextTestAmount=Convert.ToInt32(ObjDR["TestAmount"].ToString());
					}
					SqlConn.Close();

					SqlConn.Open();
					SqlCmd=new SqlCommand("Update PaperTestType set TestTypeID='"+intNextTestTypeID+"',TestTypeTitle='"+strNextTestTypeTitle+"',TestTypeMark='"+dblNextTestTypeMark+"',TestAmount='"+intNextTestAmount+"' where PaperTestTypeID='"+intPriorPaperTestTypeID+"'",SqlConn);
					SqlCmd.ExecuteNonQuery();

					SqlCmd=new SqlCommand("Update PaperTestType set TestTypeID='"+intPriorTestTypeID+"',TestTypeTitle='"+strPriorTestTypeTitle+"',TestTypeMark='"+dblPriorTestTypeMark+"',TestAmount='"+intPriorTestAmount+"' where PaperTestTypeID='"+intNextPaperTestTypeID+"'",SqlConn);
					SqlCmd.ExecuteNonQuery();
					SqlConn.Close();
				}
			}
			if (e.CommandName=="MoveDown")
			{
				if (e.Item.ItemIndex<DataGridTestType.Items.Count-1)
				{
					SqlConn.Open();
					intPriorPaperTestTypeID=Convert.ToInt32(DataGridTestType.Items[e.Item.ItemIndex].Cells[0].Text);
					SqlCmd=new SqlCommand("select TestTypeID,TestTypeTitle,TestTypeMark,TestAmount from PaperTestType where PaperTestTypeID='"+intPriorPaperTestTypeID+"'",SqlConn);
					ObjDR=SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
					if (ObjDR.Read())
					{
						intPriorTestTypeID=Convert.ToInt32(ObjDR["TestTypeID"].ToString());
						strPriorTestTypeTitle=ObjDR["TestTypeTitle"].ToString();
						dblPriorTestTypeMark=Convert.ToDouble(ObjDR["TestTypeMark"].ToString());
						intPriorTestAmount=Convert.ToInt32(ObjDR["TestAmount"].ToString());
					}
					SqlConn.Close();

					SqlConn.Open();
					intNextPaperTestTypeID=Convert.ToInt32(DataGridTestType.Items[e.Item.ItemIndex+1].Cells[0].Text);
					SqlCmd=new SqlCommand("select TestTypeID,TestTypeTitle,TestTypeMark,TestAmount from PaperTestType where PaperTestTypeID='"+intNextPaperTestTypeID+"'",SqlConn);
					ObjDR=SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
					if (ObjDR.Read())
					{
						intNextTestTypeID=Convert.ToInt32(ObjDR["TestTypeID"].ToString());
						strNextTestTypeTitle=ObjDR["TestTypeTitle"].ToString();
						dblNextTestTypeMark=Convert.ToDouble(ObjDR["TestTypeMark"].ToString());
						intNextTestAmount=Convert.ToInt32(ObjDR["TestAmount"].ToString());
					}
					SqlConn.Close();

					SqlConn.Open();
					SqlCmd=new SqlCommand("Update PaperTestType set TestTypeID='"+intNextTestTypeID+"',TestTypeTitle='"+strNextTestTypeTitle+"',TestTypeMark='"+dblNextTestTypeMark+"',TestAmount='"+intNextTestAmount+"' where PaperTestTypeID='"+intPriorPaperTestTypeID+"'",SqlConn);
					SqlCmd.ExecuteNonQuery();

					SqlCmd=new SqlCommand("Update PaperTestType set TestTypeID='"+intPriorTestTypeID+"',TestTypeTitle='"+strPriorTestTypeTitle+"',TestTypeMark='"+dblPriorTestTypeMark+"',TestAmount='"+intPriorTestAmount+"' where PaperTestTypeID='"+intNextPaperTestTypeID+"'",SqlConn);
					SqlCmd.ExecuteNonQuery();
					SqlConn.Close();
				}
			}
			SqlConn.Dispose();

			ShowPaperTestType();
		}
		#endregion
		
		#region//*******�ύ��ť�¼�*******
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			int i=0,j=0,intExamTime=0,intPaperMark=0,intPassMark=0,intSaveTime=0,intTestCount=0,intAutoJudge=1,intTmp=0;
			double dblTestTypeMark=0,dblTotalMark=0,dblRate=0;


			if (txtPaperName.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�������Ծ����ƣ�')</script>");
				return;
			}
			
			int intFillAutoGrade=0;
		
			if (DataGridPolicy.Items.Count==0)
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�����������ԣ�')</script>");
				return;
			}
			TextBox strSelectTest=null;
			for(i=0;i<DataGridPolicy.Items.Count;i++)
			{
				strSelectTest=(TextBox)DataGridPolicy.Items[i].FindControl("txtSelectTest");
				if (strSelectTest.Text.Trim()=="")
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�����������"+Convert.ToString(i+1)+"��3����ѡ�����⣡')</script>");
					return;
				}
			}
			TextBox strTestTypeTitle=null;
			TextBox strTestTypeMark=null;
			

			string strPaperName=ObjFun.getStr(ObjFun.CheckString(txtPaperName.Text.Trim()),50);
			
			int intMarkDefine=0;
			
			int intRepeatExam=0;
			
			int intExamAccount=0;
			
			int intCreateUserID=Convert.ToInt32(myUserID);
			DateTime currentTime=new System.DateTime();
			currentTime=System.DateTime.Now;
			DateTime dtmCreateDate=Convert.ToDateTime(currentTime.ToString("d"));

            string strTmp = AccessDateHelper.GetValues("select PaperName from PaperInfo where PaperName='" + strPaperName + "' and PaperID<>" + intPaperID + "", "PaperName");
			if (strTmp!="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���Ծ������Ѿ����ڣ�')</script>");
				return;
			}
			else
			{
               
                //try
                //{
                    //SqlCommand ObjectCmd=new SqlCommand();
                    //ObjectCmd.Connection=SqlConn;
                    //SqlDataAdapter SqlCmd=null,SqlCmdTmp=null;
					DataSet SqlDS=null,SqlDSTmp=null;
					
                   SqlDS= AccessDateHelper.ExecuteDataset("select TestTypeID from PaperTestType where PaperID="+intPaperID+" order by PaperTestTypeID asc");
					for(i=0;i<SqlDS.Tables[0].Rows.Count;i++)
					{
                        
                        SqlDSTmp = AccessDateHelper.ExecuteDataset("select sum(a.TestMark) as TotalMark from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID="+SqlDS.Tables[0].Rows[i]["TestTypeID"]+" and PaperID="+intPaperID+"");
                    

                        AccessDateHelper.ExecuteNonQuery("Update PaperTestType set TestTotalMark="+System.Math.Round(Convert.ToDouble(SqlDSTmp.Tables[0].Rows[0]["TotalMark"]),2)+",TestTypeOrder="+Convert.ToString(i+1)+" where TestTypeID="+SqlDS.Tables[0].Rows[i]["TestTypeID"]+" and PaperID="+intPaperID+"");
					}
					

                    SqlDS = AccessDateHelper.ExecuteDataset("select Count(*) as TestCount from PaperTest where PaperID="+intPaperID+"");
					intTestCount=Convert.ToInt32(SqlDS.Tables[0].Rows[0]["TestCount"]);
					//������Ա����
					
					

                    AccessDateHelper.ExecuteNonQuery("Update PaperInfo set PaperName='"+strPaperName+"',PaperType=1,ProduceWay=1,ShowModal=1,ExamTime=60,StartTime='2013-8-1',EndTime='2023-8-1',PaperMark='100',PassMark='60',MarkDefine='"+intMarkDefine+"',RepeatExam='"+intRepeatExam+"',FillAutoGrade='"+intFillAutoGrade+"',SeeResult=1,AutoSave=1,ExamAccount='"+intExamAccount+"',ManagerAccount='',TestCount='"+intTestCount+"',AutoJudge='"+intAutoJudge+"',CreateWay=2 where PaperID="+intPaperID+"");


                   
					for(i=0;i<SqlDS.Tables[0].Rows.Count;i++)
					{
						intUserID=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["UserID"]);

                       
					}

					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�޸��ֹ����ɹ���');try{ window.opener.RefreshForm() }catch(e){};window.close();</script>");
               
			}
		}
		#endregion

		#region//*******ȡ����ť�¼�*******
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

		#region//*******��Ӳ����¼�*******
		protected void ButAddPolicy_Click(object sender, System.EventArgs e)
		{
			ShowPaperPolicy();//��ʾ�������
			
		}
		#endregion


	}
}
