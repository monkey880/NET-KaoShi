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
	/// AddRandPolicy ��ժҪ˵����
	/// </summary>
	public partial class AddRandPolicy : System.Web.UI.Page
	{

		string strSql="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		int intPaperID=0;
	
		#region//*******��ʼ����Ϣ********
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
			//�������
			Response.Expires=0;
			Response.Buffer=true;
			Response.Clear();
			intPaperID=Convert.ToInt32(Request["PaperID"]);
			strSql=LabCondition.Text;
			if (!IsPostBack)
			{
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=1 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=UserInfo.UserID and PowerID=3 and OptionID=4)))", "UserType") != "1")
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
					strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from (((RubricInfo a LEFT  JOIN SubjectInfo b ON a.SubjectID=b.SubjectID) LEFT  JOIN LoreInfo c ON a.LoreID=c.LoreID )LEFT  JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID )LEFT  JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
					ShowData(strSql);
					LabCondition.Text=strSql;
				}
			}
		}
		#endregion

		#region//*********��ʾ��Ŀ��Ϣ**********
		private void ShowSubjectInfo()
		{
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
            DataSet SqlDS = AccessDateHelper.ExecuteDataset("select * from TestTypeInfo order by TestTypeID");
			DDLTestTypeName.Items.Clear();
			DDLTestTypeName.DataSource=SqlDS.Tables[0].DefaultView;
			DDLTestTypeName.DataTextField="TestTypeName";
			DDLTestTypeName.DataValueField="TestTypeID";
			DDLTestTypeName.DataBind();
			//SqlConn.Dispose();
			ListItem strTmp=new ListItem("--��ѡ��--","0");
			DDLTestTypeName.Items.Add(strTmp);

		}
		#endregion

		#region//*******��Ŀѡ�����ı�*******
		protected void DDLSubjectName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ShowLoreInfo(Convert.ToInt32(DDLSubjectName.SelectedValue));
			DDLLoreName.Items.FindByText("--��ѡ��--").Selected=true;
			ShowTestTypeInfo();
			DDLTestTypeName.Items.FindByText("--��ѡ��--").Selected=true;

			strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from (((RubricInfo a LEFT  JOIN SubjectInfo b ON a.SubjectID=b.SubjectID )LEFT OUTER JOIN LoreInfo c ON a.LoreID=c.LoreID )LEFT OUTER JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID )LEFT OUTER JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
			ShowData(strSql);
			LabCondition.Text=strSql;
		}
		#endregion

		#region//*******֪ʶ��ѡ�����ı�*******
		protected void DDLLoreName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ShowTestTypeInfo();
			DDLTestTypeName.Items.FindByText("--��ѡ��--").Selected=true;

			strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from (((RubricInfo a LEFT OUTER JOIN SubjectInfo b ON a.SubjectID=b.SubjectID )LEFT OUTER JOIN LoreInfo c ON a.LoreID=c.LoreID) LEFT OUTER JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID) LEFT OUTER JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
			ShowData(strSql);
			LabCondition.Text=strSql;
		}
		#endregion

		#region//*******����ѡ�����ı�*******
		protected void DDLTestTypeName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			strSql="select count(*) as TestCount,'"+DDLSubjectName.SelectedItem.Value+"' as SubjectID,'"+DDLLoreName.SelectedItem.Value+"' as LoreID,'"+DDLTestTypeName.SelectedItem.Value+"' as TestTypeID from((( RubricInfo a LEFT OUTER JOIN SubjectInfo b ON a.SubjectID=b.SubjectID) LEFT OUTER JOIN LoreInfo c ON a.LoreID=c.LoreID )LEFT OUTER JOIN TestTypeInfo d ON a.TestTypeID=d.TestTypeID) LEFT OUTER JOIN UserInfo e ON a.CreateUserID=e.UserID where a.SubjectID="+DDLSubjectName.SelectedItem.Value+" and a.LoreID="+DDLLoreName.SelectedItem.Value+" and a.TestTypeID="+DDLTestTypeName.SelectedItem.Value+"";
			ShowData(strSql);
			LabCondition.Text=strSql;
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
			this.DataGridPolicy.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridPolicy_PageIndexChanged);
			this.DataGridPolicy.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridPolicy_ItemDataBound);

		}
		#endregion

		#region//*******���ҳ�¼�*******
		private void DataGridPolicy_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridPolicy.CurrentPageIndex=e.NewPageIndex;
			ShowData(strSql);
		}
		#endregion

		#region//*******������ɫ�任*******
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

		#region//*******��ʾ�����б�*******
		private void ShowData(string strSql)
		{

            DataSet SqlDS = AccessDateHelper.ExecuteDataset(strSql);
			DataGridPolicy.DataSource=SqlDS.Tables[0].DefaultView;
			DataGridPolicy.DataBind();

			
			DataSet SqlDSTmp=null;
			for(int i=0;i<DataGridPolicy.Items.Count;i++)
			{				
                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='��'");
				Label labTestDiff1=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff1");
				labTestDiff1.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);

              SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='����'");
				Label labTestDiff2=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff2");
				labTestDiff2.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);

                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='�е�'");
				Label labTestDiff3=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff3");
				labTestDiff3.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);

                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='����'");
				Label labTestDiff4=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff4");
				labTestDiff4.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);
                SqlDSTmp = AccessDateHelper.ExecuteDataset("select * from RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + "and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='��'");
				Label labTestDiff5=(Label)DataGridPolicy.Items[i].FindControl("labTestDiff5");
				labTestDiff5.Text=Convert.ToString(SqlDSTmp.Tables[0].Rows.Count);
			}
			//SqlConn.Dispose();
		}
		#endregion

		#region//*******���б༭��Ϣ*******
		private void DataGridPolicy_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridPolicy.EditItemIndex=(int)e.Item.ItemIndex;
			ShowData(strSql);
		}
		#endregion

		#region//*******ת����һҳ*******
		private void LinkButFirstPage_Click(object sender, System.EventArgs e)
		{
			DataGridPolicy.CurrentPageIndex=0;
			ShowData(strSql);
		}
		#endregion

		#region//*******ת����һҳ*******
		private void LinkButPirorPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridPolicy.CurrentPageIndex>0)
			{
				DataGridPolicy.CurrentPageIndex-=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******ת����һҳ*******
		private void LinkButNextPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridPolicy.CurrentPageIndex<(DataGridPolicy.PageCount-1))
			{
				DataGridPolicy.CurrentPageIndex+=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******ת�����ҳ*******
		private void LinkButLastPage_Click(object sender, System.EventArgs e)
		{
			DataGridPolicy.CurrentPageIndex=(DataGridPolicy.PageCount-1);
			ShowData(strSql);
		}
		#endregion

		#region//*******ѡ������*******
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
//			if (ObjFun.JoySoftware()==false)
//			{
//				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�Բ���δע���û�������Ӳ��ԣ�')</script>");
//				return;
//			}
			int intTestDiff=0,intSum=0,intRowID=0,intRubricID=0;
			double dblTestMark=0;
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
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('�����������"+Convert.ToString(j+2)+"����������ȷ��������')</script>");
						return;
					}
					if ((intTestDiff<0)||(intTestDiff>Convert.ToInt32(labTestDiff.Text)))
					{
						this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���������"+Convert.ToString(j+2)+"���е�����Ӧ���ڵ���0����С�ڵ���"+labTestDiff.Text+"��')</script>");
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
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���������"+Convert.ToString(i+1)+"�������������Ӧ����0��')</script>");
					return;
				}
			}
			//���浽���ݿ�
			//�����������
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
                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='��'");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff2"]);
				if (intSum>0)
				{

                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='����'");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff3"]);
				if (intSum>0)
				{
                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='�е�' ");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff4"]);
				if (intSum>0)
				{

                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top "+intSum.ToString()+" "+intPaperID.ToString()+" AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID="+SqlDS.Tables[0].Rows[i]["SubjectID"]+" and LoreID="+SqlDS.Tables[0].Rows[i]["LoreID"]+" and TestTypeID="+SqlDS.Tables[0].Rows[i]["TestTypeID"]+" and TestDiff='����' ");
				}

				intSum=Convert.ToInt32(SqlDS.Tables[0].Rows[i]["TestDiff5"]);
				if (intSum>0)
				{
                    AccessDateHelper.ExecuteNonQuery("INSERT INTO PaperTest(PaperID,RubricID,TestMark) SELECT top " + intSum.ToString() + " " + intPaperID.ToString() + " AS PaperID,RubricID,TestMark FROM RubricInfo where SubjectID=" + SqlDS.Tables[0].Rows[i]["SubjectID"] + " and LoreID=" + SqlDS.Tables[0].Rows[i]["LoreID"] + " and TestTypeID=" + SqlDS.Tables[0].Rows[i]["TestTypeID"] + " and TestDiff='��'");
				}
			}

            AccessDateHelper.ExecuteNonQuery("Update PaperTestType set TestAmount=" + Convert.ToInt32(AccessDateHelper.GetValues("select Count(*) as TestCount from PaperTest a,RubricInfo b where a.RubricID=b.RubricID and b.TestTypeID=" + DDLTestTypeName.SelectedItem.Value + " and PaperID=" + intPaperID + "", "TestCount")) + " where TestTypeID=" + DDLTestTypeName.SelectedItem.Value + " and PaperID=" + intPaperID + "");

       

			this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���������Գɹ���');</script>");
		}
		#endregion

	}
}
