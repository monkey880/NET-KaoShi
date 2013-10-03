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
	/// ManagJobPaper ��ժҪ˵����
	/// </summary>
	public partial class ManagJobPaper : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton ImgButSubject;
		protected System.Web.UI.WebControls.TextBox txtSubjectName;
		protected int RowNum=0,LinNum=0;

		bool bWhere;
		string strSql="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
		bool bJoySoftware=false;
	
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
			strSql=LabCondition.Text;
			bJoySoftware=ObjFun.JoySoftware();
			if (!IsPostBack)
			{

               
              
                ButRandPaper.NavigateUrl = "NewRandPaper.aspx?PaperType=2";
                ButRandPaper.Target = "main";
					ButDelete.Attributes.Add("onclick","javascript:{if(confirm('ȷ��Ҫɾ��ѡ���Ծ���')==false) return false;}");
                    strSql = "select a.PaperID,a.PaperName,a.PaperType,SWITCH(  a.ProduceWay = 1 , '����̶�' , a.ProduceWay = 2 , '�������' ,a.ProduceWay = 3 , '�������' ) as ProduceWay,SWITCH( a.ShowModal = 1 , '����ģʽ' ,a.ShowModal = 2 , '����ģʽ' ) as ShowModal,a.StartTime,a.EndTime,a.TestCount,a.PaperMark,a.CreateWay,b.LoginID as CreateLoginID,a.CreateDate as CreateDate from PaperInfo a LEFT  JOIN UserInfo b ON a.CreateUserID=b.UserID where a.PaperType=2 order by a.PaperID desc";
					if (DataGridPaper.Attributes["SortExpression"] == null)
					{
						DataGridPaper.Attributes["SortExpression"] = "PaperID";
						DataGridPaper.Attributes["SortDirection"] = "DESC";
					}
					ShowData(strSql);
					LabCondition.Text=strSql;
			
			}
			if (Request["hidcommand"]=="RefreshForm")
			{
				ShowData(strSql);//��ʾ����
			}
		}
		#endregion

		#region//*******��ʾ�����б�*******
		private void ShowData(string strSql)
		{

            DataSet SqlDS = AccessDateHelper.ExecuteDataset(strSql);
			RowNum=DataGridPaper.CurrentPageIndex*DataGridPaper.PageSize+1;
			LinNum=0;

			string SortExpression = DataGridPaper.Attributes["SortExpression"];
			string SortDirection = DataGridPaper.Attributes["SortDirection"];
			SqlDS.Tables[0].DefaultView.Sort = SortExpression + " " + SortDirection;

			DataGridPaper.DataSource=SqlDS.Tables[0].DefaultView;
			DataGridPaper.DataBind();
			for(int i=0;i<DataGridPaper.Items.Count;i++)
			{



                HyperLink LBEditPaper = (HyperLink)DataGridPaper.Items[i].FindControl("LinkButEditPaper");
				LinkButton LBDel=(LinkButton)DataGridPaper.Items[i].FindControl("LinkButDel");
				LinkButton LBPreviewPaper=(LinkButton)DataGridPaper.Items[i].FindControl("LinkButPreviewPaper");

				if ((myLoginID.Trim().ToUpper()=="ADMIN")||(myLoginID.Trim().ToUpper()==DataGridPaper.Items[i].Cells[8].Text.Trim().ToUpper()))
				{
					if (DataGridPaper.Items[i].Cells[11].Text.Trim()=="1")
					{
                        LBEditPaper.NavigateUrl = "EditRandPaper.aspx?PaperID=" + DataGridPaper.Items[i].Cells[0].Text.Trim() + "&PaperType=" + DataGridPaper.Items[i].Cells[11].Text.Trim() + "";
                        LBEditPaper.Target = "main";
						
					}
					else
					{
                        LBEditPaper.NavigateUrl = "EditCustomPaper.aspx?PaperID=" + DataGridPaper.Items[i].Cells[0].Text.Trim() + "&PaperType=" + DataGridPaper.Items[i].Cells[11].Text.Trim() + "";
						
					}
					LBDel.Attributes.Add("onclick","javascript:{if(confirm('ȷ��Ҫɾ��ѡ���Ծ���')==false) return false;}");
					LBPreviewPaper.Attributes.Add("onclick","javascript:NewWin=window.open('PreviewPaper.aspx?PaperID="+DataGridPaper.Items[i].Cells[0].Text.Trim()+"','PreviewPaper','titlebar=yes,menubar=no,toolbar=no,location=no,directories=no,status=yes,scrollbars=yes,resizable=no,copyhistory=yes,top=0,left=0,width=screen.availWidth,height=screen.availHeight');NewWin.moveTo(0,0);NewWin.resizeTo(screen.availWidth,screen.availHeight);return false;");
				}
				else
				{
                    //LBEditPaper.Attributes.Add("onclick", "javascript:alert('�Բ�����û�д˲���Ȩ�ޣ�');return false;");
                    //LBDel.Attributes.Add("onclick", "javascript:alert('�Բ�����û�д˲���Ȩ�ޣ�');return false;");
                    //LBPreviewPaper.Attributes.Add("onclick", "javascript:alert('�Բ�����û�д˲���Ȩ�ޣ�');return false;");
				}
			}
			LabelRecord.Text=Convert.ToString(SqlDS.Tables[0].Rows.Count);
			LabelCountPage.Text=Convert.ToString(DataGridPaper.PageCount);
			LabelCurrentPage.Text=Convert.ToString(DataGridPaper.CurrentPageIndex+1);
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
			this.DataGridPaper.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridPaper_PageIndexChanged);
			this.DataGridPaper.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGridPaper_SortCommand);
			this.DataGridPaper.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPaper_DeleteCommand);
			this.DataGridPaper.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridPaper_ItemDataBound);

		}
		#endregion

		#region//*******����ҳ�¼�*******
		private void DataGridPaper_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridPaper.CurrentPageIndex=e.NewPageIndex;
			ShowData(strSql);
		}
		#endregion

		#region//*******������ɫ�任*******
		private void DataGridPaper_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if( e.Item.ItemIndex != -1 )
			{
				e.Item.Attributes.Add("onmouseover", "this.bgColor='#ebf5fa'");

				if (e.Item.ItemIndex % 2 == 0 )
				{
					e.Item.Attributes.Add("bgcolor", "#FFFFFF");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridPaper').getAttribute('singleValue')");
				}
				else
				{
					e.Item.Attributes.Add("bgcolor", "#F7F7F7");
					e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridPaper').getAttribute('oldValue')");
				}
			}
			else
			{
				DataGridPaper.Attributes.Add("oldValue", "#F7F7F7");
				DataGridPaper.Attributes.Add("singleValue", "#FFFFFF");
			}
		}
		#endregion

		#region//*******ɾ��ѡ���ʻ�*******
		protected void ButDelete_Click(object sender, System.EventArgs e)
		{
			if (Request["chkSelect"]!=null)
			{

				int intPaperID=0;
				string[] textArray=Request["chkSelect"].ToString().Split(',');
				for (int j=0;j<textArray.Length;j++)
				{
					intPaperID=Convert.ToInt32(DataGridPaper.Items[Convert.ToInt32(textArray[j])].Cells[0].Text);
                    if (AccessDateHelper.GetValues("select UserScoreID from UserScore where PaperID=" + intPaperID + "", "UserScoreID") == "")
					{

                        AccessDateHelper.ExecuteNonQuery("delete from PaperTest where PaperID=" + intPaperID + "");
                        AccessDateHelper.ExecuteNonQuery("delete from PaperPolicy where PaperID=" + intPaperID + "");
                        AccessDateHelper.ExecuteNonQuery("delete from PaperTestType where PaperID=" + intPaperID + "");
                        AccessDateHelper.ExecuteNonQuery("delete from PaperUser where PaperID=" + intPaperID + "");
                        AccessDateHelper.ExecuteNonQuery("delete from PaperInfo where PaperID=" + intPaperID + "");

					}
				}

				//�Զ���ҳ
				if(textArray.Length==DataGridPaper.Items.Count&&DataGridPaper.CurrentPageIndex>0)
				{
					DataGridPaper.CurrentPageIndex--;
				}

				ShowData(strSql);//��ʾ����
			}
		}
		#endregion

		#region//*******���б༭��Ϣ*******
		private void DataGridPaper_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridPaper.EditItemIndex=(int)e.Item.ItemIndex;
			ShowData(strSql);
		}
		#endregion

		#region//*******ɾ��ѡ���Ծ�*******
		private void DataGridPaper_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int intPaperID=Convert.ToInt32(e.Item.Cells[0].Text);
            if (AccessDateHelper.GetValues("select UserScoreID from UserScore where PaperID=" + intPaperID + "", "UserScoreID") == "")
			{

                AccessDateHelper.ExecuteNonQuery("delete from PaperTest where PaperID=" + intPaperID + "");
                AccessDateHelper.ExecuteNonQuery("delete from PaperPolicy where PaperID=" + intPaperID + "");
                AccessDateHelper.ExecuteNonQuery("delete from PaperTestType where PaperID=" + intPaperID + "");
                AccessDateHelper.ExecuteNonQuery("delete from PaperUser where PaperID=" + intPaperID + "");
                AccessDateHelper.ExecuteNonQuery("delete from PaperInfo where PaperID=" + intPaperID + "");

				//�Զ���ҳ
				if (DataGridPaper.Items.Count==1&&DataGridPaper.CurrentPageIndex>0)
				{
					DataGridPaper.CurrentPageIndex--;
				}        

				ShowData(strSql);
			}
			else
			{
				this.RegisterStartupScript("newWindow","<script language='javascript'>alert('���Ծ�����ʹ�ã�����ɾ����Ӧ������ٽ��д˲�����')</script>");
				return;
			}
		}
		#endregion
		
		#region//*******ȡ���༭��Ϣ*******
		private void DataGridPaper_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridPaper.EditItemIndex=-1;
			ShowData(strSql);
		}
		#endregion

		#region//*******������ѯ��Ϣ*******
		protected void ButQuery_Click(object sender, System.EventArgs e)
		{
			bWhere=true;
            strSql = "select a.PaperID,a.PaperName,a.PaperType,switch( a.ProduceWay = 1 , '����̶�', a.ProduceWay = 2 , '�������' ,a.ProduceWay = 3 , '�������' ) as ProduceWay,switch( a.ShowModal = 1 , '����ģʽ' ,a.ShowModal =  2 , '����ģʽ' ) as ShowModal,a.StartTime,a.EndTime,a.TestCount,a.PaperMark,a.CreateWay,b.LoginID as CreateLoginID,a.CreateDate as CreateDate from PaperInfo a LEFT  JOIN UserInfo b ON a.CreateUserID=b.UserID where a.PaperType=2";
			//��ʾ������Ϊ����������
			if (txtPaperName.Text.Trim()!="")
			{
				if (bWhere)
				{
					strSql=strSql+" and a.PaperName like '%"+ObjFun.CheckString(txtPaperName.Text.Trim())+"%'";
				}
				else
				{
					strSql=strSql+" where a.PaperName like '%"+ObjFun.CheckString(txtPaperName.Text.Trim())+"%'";
					bWhere=true;
				}
			}
			
			strSql=strSql+" order by a.PaperID desc";

			DataGridPaper.CurrentPageIndex=0;
			ShowData(strSql);
			LabCondition.Text=strSql;
		}
		#endregion

		#region//*******ת����һҳ*******
		protected void LinkButFirstPage_Click(object sender, System.EventArgs e)
		{
			DataGridPaper.CurrentPageIndex=0;
			ShowData(strSql);
		}
		#endregion

		#region//*******ת����һҳ*******
		protected void LinkButPirorPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridPaper.CurrentPageIndex>0)
			{
				DataGridPaper.CurrentPageIndex-=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******ת����һҳ*******
		protected void LinkButNextPage_Click(object sender, System.EventArgs e)
		{
			if (DataGridPaper.CurrentPageIndex<(DataGridPaper.PageCount-1))
			{
				DataGridPaper.CurrentPageIndex+=1;
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******ת�����ҳ*******
		protected void LinkButLastPage_Click(object sender, System.EventArgs e)
		{
			DataGridPaper.CurrentPageIndex=(DataGridPaper.PageCount-1);
			ShowData(strSql);
		}
		#endregion

		#region//*******��������*******
		private void DataGridPaper_SortCommand (object source , System.Web.UI.WebControls.DataGridSortCommandEventArgs e )
		{
			//�������
			//string sColName = e.SortExpression ;

			string ImgDown = "<img border=0 src=" + Request.ApplicationPath + "/Images/uparrow.gif>";
			string ImgUp = "<img border=0 src=" + Request.ApplicationPath + "/Images/downarrow.gif>";
			string SortExpression = e.SortExpression.ToString();
			string SortDirection = "ASC";
			int colindex = -1;
			//���֮ǰ��ͼ��
			for (int i = 0; i < DataGridPaper.Columns.Count; i++)
			{
				DataGridPaper.Columns[i].HeaderText = (DataGridPaper.Columns[i].HeaderText).ToString().Replace(ImgDown, "");
				DataGridPaper.Columns[i].HeaderText = (DataGridPaper.Columns[i].HeaderText).ToString().Replace(ImgUp, "");
			}
			//�ҵ��������HeaderText��������
			for (int i = 0; i < DataGridPaper.Columns.Count; i++)
			{
				if (DataGridPaper.Columns[i].SortExpression == e.SortExpression)
				{
					colindex = i;
					break;
				}
			}
			if (SortExpression == DataGridPaper.Attributes["SortExpression"])
			{
 
				SortDirection = (DataGridPaper.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");
 
			}
			DataGridPaper.Attributes["SortExpression"] = SortExpression;
			DataGridPaper.Attributes["SortDirection"] = SortDirection;
			if (DataGridPaper.Attributes["SortDirection"] == "ASC")
			{
				DataGridPaper.Columns[colindex].HeaderText = DataGridPaper.Columns[colindex].HeaderText + ImgDown;
			}
			else
			{
				DataGridPaper.Columns[colindex].HeaderText = DataGridPaper.Columns[colindex].HeaderText + ImgUp;
			}
			ShowData(strSql);
		}
		#endregion
	}
}