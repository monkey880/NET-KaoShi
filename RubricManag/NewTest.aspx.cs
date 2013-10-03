using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyExam.RubricManag
{
	/// <summary>
	/// NewTest ��ժҪ˵����
	/// </summary>
	public partial class NewTest : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTable JudgeTable;
		protected System.Web.UI.HtmlControls.HtmlTable OtherTable;
		protected string strActive;
		protected string strRubricID;

		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
	
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
			strActive="Add";
			strRubricID="0";

			if (!IsPostBack)
			{
                string UserID = AccessDateHelper.GetValues("select UserID from UserInfo where LoginID='" + myLoginID+"'", "UserID");
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=1 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=" + UserID + " and PowerID=3 and OptionID=3)))", "UserType") != "1")
				{
					Response.Write("<script>alert('�Բ�����û�д˲���Ȩ�ޣ�')</script>");
					Response.End();
				}
				else
				{
					ShowSubjectInfo();//��ʾ��Ŀ��Ϣ
					DDLSubjectName.Items.FindByText("--��ѡ��--").Selected=true;
					ShowTestTypeInfo();//��ʾ��������
					DDLTestTypeName.Items.FindByText("--��ѡ��--").Selected=true;

					System.DateTime currentTime=new System.DateTime();
					currentTime=System.DateTime.Now;
					txtCreateDate.Text=Convert.ToString(currentTime.ToString("d"));
				}
			}
		}
		#endregion

		#region//*********��ʾ��Ŀ��Ϣ**********
		private void ShowSubjectInfo()
		{
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection SqlConn=new SqlConnection(strConn);
            //SqlDataAdapter SqlCmd=new SqlDataAdapter("select * from SubjectInfo order by SubjectID",SqlConn);
            //DataSet SqlDS=new DataSet();
            //SqlCmd.Fill(SqlDS,"SubjectInfo");
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from SubjectInfo order by SubjectID");
			DDLSubjectName.Items.Clear();
			DDLSubjectName.DataSource=SqlDS.Tables[0].DefaultView;
			DDLSubjectName.DataTextField="SubjectName";
			DDLSubjectName.DataValueField="SubjectID";
			DDLSubjectName.DataBind();
			//SqlConn.Dispose();
			ListItem strTmp=new ListItem("--��ѡ��--","0");
			DDLSubjectName.Items.Add(strTmp);
		}
		#endregion

		#region//*********��ʾ֪ʶ����Ϣ**********
		private void ShowLoreInfo(int SubjectID)
		{
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection SqlConn=new SqlConnection(strConn);
            //SqlDataAdapter SqlCmd=new SqlDataAdapter("select * from LoreInfo where SubjectID="+SubjectID+" order by LoreID",SqlConn);
            //DataSet SqlDS=new DataSet();
            //SqlCmd.Fill(SqlDS,"LoreInfo");
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from LoreInfo where SubjectID=" + SubjectID + " order by LoreID");
			DDLLoreName.Items.Clear();
			DDLLoreName.DataSource=SqlDS.Tables[0].DefaultView;
			DDLLoreName.DataTextField="LoreName";
			DDLLoreName.DataValueField="LoreID";
			DDLLoreName.DataBind();
			//SqlConn.Dispose();
			ListItem strTmp=new ListItem("--��ѡ��--","0");
			DDLLoreName.Items.Add(strTmp);
		}
		#endregion

		#region//*********��ʾ��������**********
		private void ShowTestTypeInfo()
		{
            //string strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection SqlConn=new SqlConnection(strConn);
            //SqlDataAdapter SqlCmd=new SqlDataAdapter("select * from TestTypeInfo order by TestTypeID",SqlConn);
            //DataSet SqlDS=new DataSet();
            //SqlCmd.Fill(SqlDS,"TestTypeInfo");
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from TestTypeInfo order by TestTypeID");
			DDLTestTypeName.Items.Clear();
			for(int i=0;i<SqlDS.Tables[0].Rows.Count;i++)
			{
				DDLTestTypeName.Items.Add(new ListItem(SqlDS.Tables[0].Rows[i][1].ToString(),SqlDS.Tables[0].Rows[i][0].ToString()+","+SqlDS.Tables[0].Rows[i][2].ToString()));
			}
			//SqlConn.Dispose();
			ListItem strTmp=new ListItem("--��ѡ��--","0");
			DDLTestTypeName.Items.Add(strTmp);
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

		#region//*******ѡ�����ı�*******
		protected void DDLSubjectName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ShowLoreInfo(Convert.ToInt32(DDLSubjectName.SelectedValue));
			DDLLoreName.Items.FindByText("--��ѡ��--").Selected=true;
		}
		#endregion

		#region//*********�½�������Ϣ***********
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			int intSubjectID,intLoreID,intTestTypeID,intOptionNum,intTypeTime,intStandardSpeed,intCreateUserID;
			string strTestDiff,strTestContent,strTestFileName,strOptionContent,strStandardAnswer,strTestParse;
			double dblTestMark;
			DateTime dtmCreateDate;
	
			if (DDLSubjectName.SelectedItem.Value=="0")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ���Ŀ���ƣ�')</script>");
				return;
			}
			if (DDLLoreName.SelectedItem.Value=="0")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ��֪ʶ�㣡')</script>");
				return;
			}
			if (DDLTestTypeName.SelectedItem.Value=="0")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ���������ƣ�')</script>");
				return;
			}
			if (DDLTestDiff.SelectedItem.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ�������Ѷȣ�')</script>");
				return;
			}
			if (txtTestMark.Text.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���������������')</script>");
				return;
			}
			try
			{
				dblTestMark=Convert.ToDouble(txtTestMark.Text.Trim());
			}
			catch
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��������ȷ�����������')</script>");
				return;
			}
			if (dblTestMark<=0)
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�������Ӧ����0��')</script>");
				return;
			}
			strTestContent=ObjFun.getStr(ObjFun.CheckTestStr(txtTestContent0.Text.Trim()),4000);
			if (strTestContent.Trim()=="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�������������ݣ�')</script>");
				return;
			}
			string strTmp=ObjFun.GetValues("select RubricID from RubricInfo where SubjectID='"+DDLSubjectName.SelectedItem.Value+"' and LoreID='"+DDLLoreName.SelectedItem.Value+"' and TestContent='"+strTestContent+"'","RubricID");
			if (strTmp.Trim()!="")
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ǰ��Ŀ֪ʶ�����Ѿ����ڴ����⣬���������룡')</script>");
				return;
			}

			bool bSelected=false;
			int i=0;
			intOptionNum=4;
			strOptionContent="";
			strStandardAnswer="";
			if (DDLTestTypeName.SelectedItem.Value.IndexOf("��ѡ��")>=0)
			{
				intOptionNum=Convert.ToInt32(DDLOptionNum.SelectedItem.Value);
				for (i=1;i<=intOptionNum;i++)
				{
					if (Request["txtTestContent"+i.ToString()]=="")
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('����������ѡ�����ݣ�')</script>");
						return;
					}
				}
				RadioButton rbStr=null;
				for (i=1;i<=intOptionNum;i++)
				{
					rbStr=(RadioButton)Page.FindControl("rbOneSelect"+i.ToString());
					if (rbStr.Checked==true)
					{
						bSelected=true;
						strStandardAnswer=strStandardAnswer+rbStr.Text;
					}
					if (strOptionContent=="")
					{
						strOptionContent=ObjFun.getStr(Request["txtTestContent"+i.ToString()],300);
					}
					else
					{
						strOptionContent=strOptionContent+"|"+ObjFun.getStr(Request["txtTestContent"+i.ToString()],300);
					}
				}
				if (bSelected==false)
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ������𰸣�')</script>");
					return;
				}
			}
			if (DDLTestTypeName.SelectedItem.Value.IndexOf("��ѡ��")>=0)
			{
				intOptionNum=Convert.ToInt32(DDLOptionNum.SelectedItem.Value);
				for (i=1;i<=intOptionNum;i++)
				{
					if (Request["txtTestContent"+i.ToString()]=="")
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('����������ѡ�����ݣ�')</script>");
						return;
					}
				}
				CheckBox chkStr=null;
				for (i=1;i<=intOptionNum;i++)
				{
					chkStr=(CheckBox)Page.FindControl("chkMultiSelect"+i.ToString());
					if (chkStr.Checked==true)
					{
						bSelected=true;
						strStandardAnswer=strStandardAnswer+chkStr.Text;
					}
					if (strOptionContent=="")
					{
						strOptionContent=ObjFun.getStr(Request["txtTestContent"+i.ToString()],300);
					}
					else
					{
						strOptionContent=strOptionContent+"|"+ObjFun.getStr(Request["txtTestContent"+i.ToString()],300);
					}
				}
				if (bSelected==false)
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ������𰸣�')</script>");
					return;
				}
			}
			if (DDLTestTypeName.SelectedItem.Value.IndexOf("�ж���")>=0)
			{
				if ((rbJudgeRight.Checked==false)&&(rbJudgeWrong.Checked==false))
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ������𰸣�')</script>");
					return;
				}
				if (rbJudgeRight.Checked==true)
				{
					strStandardAnswer=rbJudgeRight.Text.Trim();
				}
				if (rbJudgeWrong.Checked==true)
				{
					strStandardAnswer=rbJudgeWrong.Text.Trim();
				}
			}
			if ((DDLTestTypeName.SelectedItem.Value.IndexOf("�����")>=0)||(DDLTestTypeName.SelectedItem.Value.IndexOf("�ʴ���")>=0)||(DDLTestTypeName.SelectedItem.Value.IndexOf("������")>=0))
			{
				strStandardAnswer=txtTestContent7.Text.Trim();
				if (DDLTestTypeName.SelectedItem.Value.IndexOf("�����")>=0)
				{
					if (strTestContent.IndexOf("___")<0)
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�����������������3���»��ߡ�_����ʾ���λ�ã�')</script>");
						return;
					}
					Regex regex1=new Regex("___");
					Regex regex2=new Regex(",");
					if (regex1.Matches(strTestContent,0).Count!=(regex2.Matches(strStandardAnswer,0).Count+1))
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���λ�����������һ�£����մ𰸼��ð�Ƕ��š�,��������')</script>");
						return;
					}
				}
			}
			if (DDLTestTypeName.SelectedItem.Value.IndexOf("������")>=0)
			{
				try
				{
					intTypeTime=Convert.ToInt32(txtTypeTime.Text.Trim());
				}
				catch
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��������ȷ�Ĵ���ʱ�䣡')</script>");
					return;
				}
				try
				{
					intStandardSpeed=Convert.ToInt32(txtStandardSpeed.Text.Trim());
				}
				catch
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��������ȷ�ı�׼�ٶȣ�')</script>");
					return;
				}
				strStandardAnswer=txtTypeTime.Text.Trim()+","+txtStandardSpeed.Text.Trim();
			}
			strTestFileName="";
			byte[] fileBinaryData;
			fileBinaryData=new byte[0];
			if (DDLTestTypeName.SelectedItem.Value.IndexOf("������")>=0)
			{
				strTestFileName=TestFile.PostedFile.FileName.Substring(TestFile.PostedFile.FileName.LastIndexOf("\\")+1);
				if (strTestFileName.Trim()!="")
				{
					Stream fileStream;
					int fileLen;
					fileStream=TestFile.PostedFile.InputStream;
					fileLen=TestFile.PostedFile.ContentLength;
					fileBinaryData=new byte[fileLen];
					int n=fileStream.Read(fileBinaryData,0,fileLen);
				}
				else
				{
					fileBinaryData=new byte[0];
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ�������ļ���')</script>");
					return;
				}
				strStandardAnswer="";
			}

			string[] strArrTestType=DDLTestTypeName.SelectedItem.Value.Split(',');
			intSubjectID=Convert.ToInt32(DDLSubjectName.SelectedItem.Value);
			intLoreID=Convert.ToInt32(DDLLoreName.SelectedItem.Value);
			intTestTypeID=Convert.ToInt32(strArrTestType[0]);
			strTestDiff=DDLTestDiff.SelectedItem.Value;
			intOptionNum=Convert.ToInt32(DDLOptionNum.SelectedItem.Value);
			dblTestMark=System.Math.Round(Convert.ToDouble(txtTestMark.Text.Trim()),1);
			strOptionContent=ObjFun.getStr(ObjFun.CheckTestStr(strOptionContent),1800);
			strStandardAnswer=ObjFun.getStr(ObjFun.CheckTestStr(strStandardAnswer),2000);
			strTestParse=ObjFun.getStr(ObjFun.CheckTestStr(txtTestContent8.Text.Trim()),500);
            intCreateUserID=Convert.ToInt32(myUserID);
			dtmCreateDate=Convert.ToDateTime(txtCreateDate.Text);

			int NumRowsAffected=MyDatabaseMethod(intSubjectID,intLoreID,intTestTypeID,strTestDiff,intOptionNum,dblTestMark,strTestContent,fileBinaryData,strTestFileName,strOptionContent,strStandardAnswer,strTestParse,intCreateUserID,dtmCreateDate);
			if (NumRowsAffected>0)
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�½�����ɹ���');try{ window.opener.RefreshForm() }catch(e){};</script>");
			}
			else
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�½�����ʧ�ܣ�')</script>");
			}

			txtTestContent0.Text="";
			txtTestContent1.Text="";
			txtTestContent2.Text="";
			txtTestContent3.Text="";
			txtTestContent4.Text="";
			txtTestContent5.Text="";
			txtTestContent6.Text="";
			txtTestContent7.Text="";
			txtTestContent8.Text="";
			rbOneSelect1.Checked=false;
			rbOneSelect2.Checked=false;
			rbOneSelect3.Checked=false;
			rbOneSelect4.Checked=false;
			rbOneSelect5.Checked=false;
			rbOneSelect6.Checked=false;
			chkMultiSelect1.Checked=false;
			chkMultiSelect2.Checked=false;
			chkMultiSelect3.Checked=false;
			chkMultiSelect4.Checked=false;
			chkMultiSelect5.Checked=false;
			chkMultiSelect6.Checked=false;
			rbJudgeRight.Checked=false;
			rbJudgeWrong.Checked=false;
			txtTypeTime.Text="5";
			txtStandardSpeed.Text="30";
		}
		#endregion

		#region//*********�����ݸ������ݿ���*********
		public int MyDatabaseMethod(int intSubjectID,int intLoreID,int intTestTypeID,string strTestDiff,int intOptionNum,double dblTestMark,string strTestContent,byte[] fileBinaryData,string strTestFileName,string strOptionContent,string strStandardAnswer,string strTestParse,int intCreateUserID,DateTime dtmCreateDate)
		{
			//string strConn="";
			string strSql="";
            //strConn=ConfigurationSettings.AppSettings["strConn"];
            //SqlConnection ObjConn = new SqlConnection(strConn);
			strSql="Insert into RubricInfo(SubjectID,LoreID,TestTypeID,TestDiff,OptionNum,TestMark,TestContent,TestFile,TestFileName,OptionContent,StandardAnswer,TestParse,CreateUserID,CreateDate) Values (@TmpSubjectID,@TmpLoreID,@TmpTestTypeID,@TmpTestDiff,@TmpOptionNum,@TmpTestMark,@TmpTestContent,@TmpTestFile,@TmpTestFileName,@TmpOptionContent,@TmpStandardAnswer,@TmpTestParse,@TmpCreateUserID,@TmpCreateDate)";
			//SqlCommand ObjCmd=new SqlCommand(strSql,ObjConn);

            OleDbCommand ObjCmd = new OleDbCommand(strSql);

			OleDbParameter ParamSubjectID=new OleDbParameter("@TmpSubjectID",OleDbType.Integer);
			ParamSubjectID.Value = intSubjectID;
			ObjCmd.Parameters.Add(ParamSubjectID); 

			OleDbParameter ParamLoreID=new OleDbParameter("@TmpLoreID",OleDbType.Integer);
			ParamLoreID.Value = intLoreID;
			ObjCmd.Parameters.Add(ParamLoreID); 

			OleDbParameter ParamTestTypeID=new OleDbParameter("@TmpTestTypeID",OleDbType.Integer);
			ParamTestTypeID.Value = intTestTypeID;
			ObjCmd.Parameters.Add(ParamTestTypeID); 

			OleDbParameter ParamTestDiff=new OleDbParameter("@TmpTestDiff",OleDbType.VarChar,6);
			ParamTestDiff.Value = strTestDiff;
			ObjCmd.Parameters.Add(ParamTestDiff); 

			OleDbParameter ParamOptionNum=new OleDbParameter("@TmpOptionNum",OleDbType.Integer);
			ParamOptionNum.Value = intOptionNum;
			ObjCmd.Parameters.Add(ParamOptionNum); 

			OleDbParameter ParamTestMark=new OleDbParameter("@TmpTestMark",OleDbType.Double);
			ParamTestMark.Value = dblTestMark;
			ObjCmd.Parameters.Add(ParamTestMark); 

			OleDbParameter ParamTestContent=new OleDbParameter("@TmpTestContent",OleDbType.VarChar,4000);
			ParamTestContent.Value = strTestContent;
			ObjCmd.Parameters.Add(ParamTestContent);

            //if (fileBinaryData.Length>0)
            //{
            //    OleDbParameter ParamTestFile=new OleDbParameter("@TmpTestFile",OleDbType.Image);
            //    ParamTestFile.Value = fileBinaryData;
            //    ObjCmd.Parameters.Add(ParamTestFile);

            //    OleDbParameter ParamTestFileName=new OleDbParameter("@TmpTestFileName",OleDbType.VarChar,255);
            //    ParamTestFileName.Value = strTestFileName.Trim();
            //    ObjCmd.Parameters.Add(ParamTestFileName);
            //}
            //else
            //{
            //    OleDbParameter ParamTestFile=new OleDbParameter("@TmpTestFile",OleDbType.Image);
            //    ParamTestFile.Value = System.DBNull.Value;
            //    ObjCmd.Parameters.Add(ParamTestFile);

            //    OleDbParameter ParamTestFileName=new OleDbParameter("@TmpTestFileName",OleDbType.VarChar,255);
            //    ParamTestFileName.Value = strTestFileName.Trim();
            //    ObjCmd.Parameters.Add(ParamTestFileName);
            //}

			OleDbParameter ParamOptionContent=new OleDbParameter("@TmpOptionContent",OleDbType.VarChar,1800);
			ParamOptionContent.Value = strOptionContent;
			ObjCmd.Parameters.Add(ParamOptionContent);

			OleDbParameter ParamStandardAnswer=new OleDbParameter("@TmpStandardAnswer",OleDbType.VarChar,2000);
			ParamStandardAnswer.Value = strStandardAnswer;
			ObjCmd.Parameters.Add(ParamStandardAnswer);

			OleDbParameter ParamTestParse=new OleDbParameter("@TmpTestParse",OleDbType.VarChar,500);
			ParamTestParse.Value = strTestParse;
			ObjCmd.Parameters.Add(ParamTestParse);

			OleDbParameter ParamCreateUserID=new OleDbParameter("@TmpCreateUserID",OleDbType.Integer);
			ParamCreateUserID.Value = intCreateUserID;
			ObjCmd.Parameters.Add(ParamCreateUserID); 

			OleDbParameter ParamCreateDate=new OleDbParameter("@TmpCreateDate",OleDbType.DBDate);
			ParamCreateDate.Value = dtmCreateDate;
			ObjCmd.Parameters.Add(ParamCreateDate);

			//ObjConn.Open();
            int numRowsAffected = AccessDateHelper.ExecuteNonQuery(ObjCmd);
			//ObjConn.Close();
			//ObjConn.Dispose();
			return numRowsAffected;
		}
		#endregion

	}
}
