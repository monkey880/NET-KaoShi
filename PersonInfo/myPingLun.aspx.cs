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
using System.Text.RegularExpressions;

namespace EasyExam.PersonalInfo
{
	/// <summary>
	/// JoinJob ��ժҪ˵����
	/// </summary>
	public partial class myPingLun : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton ImgButSubject;
		protected System.Web.UI.WebControls.TextBox txtSubjectName;
		protected int RowNum=0;

		string strSql="";
		string myUserID="";
		string myLoginID="";
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
            strSql = "select p.Contents,p.CreateDate,r.TestContent,r.OptionContent,r.StandardAnswer,r.TestTypeID,r.OptionNum,p.pid,r.RubricID from PingLun p left join RubricInfo r on p.RubricID=r.RubricID  where p.UserID="+intUserID+"";
            if (!IsPostBack)
			{
				if (DataGridPaper.Attributes["SortExpression"] == null)
				{
					DataGridPaper.Attributes["SortExpression"] = "pid";
					DataGridPaper.Attributes["SortDirection"] = "DESC";
				}
				ShowData(strSql);
			}
		}
		#endregion

		#region//*******��ʾ�����б�*******
		private void ShowData(string strSql)
		{
           
            DataSet SqlDS = AccessDateHelper.ExecuteDataset(strSql);
			RowNum=DataGridPaper.CurrentPageIndex*DataGridPaper.PageSize+1;

			string SortExpression = DataGridPaper.Attributes["SortExpression"];
			string SortDirection = DataGridPaper.Attributes["SortDirection"];
			SqlDS.Tables[0].DefaultView.Sort = SortExpression + " " + SortDirection;

			DataGridPaper.DataSource=SqlDS.Tables[0].DefaultView;
			DataGridPaper.DataBind();
			for(int i=0;i<DataGridPaper.Items.Count;i++)
			{


                string shiti = "<dl><dt>"+DataGridPaper.Items[i].Cells[0].Text+"</dt>";
                string[] option = DataGridPaper.Items[i].Cells[1].Text.Split('|');

                string strTestContent = "";
                string strPaperContent = "";
                int intOptionNum;
                string[] strArrOptionContent;
                if (DataGridPaper.Items[i].Cells[2].Text == "30")
                {

                }


                if (DataGridPaper.Items[i].Cells[2].Text == "27")
                {
                    intOptionNum = Convert.ToInt32(DataGridPaper.Items[i].Cells[3].Text);
                    strArrOptionContent = DataGridPaper.Items[i].Cells[1].Text.Split('|');
                    for (int k = 1; k <= intOptionNum; k++)
                    {


                        strPaperContent = strPaperContent + "<dd><input type='radio' id='Answer' name='Answer' value='" + Convert.ToChar(64 + k) + "'>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</dd>";


                    }
                }
                if (DataGridPaper.Items[i].Cells[2].Text == "28")
                {
                    intOptionNum = Convert.ToInt32(DataGridPaper.Items[i].Cells[3].Text);
                    strArrOptionContent = DataGridPaper.Items[i].Cells[1].Text.Split('|');
                    for (int k = 1; k <= intOptionNum; k++)
                    {

                        strPaperContent = strPaperContent + "<dd><input type='checkbox' id='Answer' name='Answer' value='" + Convert.ToChar(64 + k) + "'>" + Convert.ToChar(64 + k) + "." + strArrOptionContent[k - 1] + "</dd>";


                    }
                }
                if (DataGridPaper.Items[i].Cells[2].Text == "29")
                {


                    strPaperContent = strPaperContent + "<dd><input type='radio' id='Answer' name='Answer' value='��ȷ'>��ȷ</dd>";



                    strPaperContent = strPaperContent + "<dd><input type='radio' id='Answer' name='Answer' value='����'>����</dd>";


                }

                if (DataGridPaper.Items[i].Cells[2].Text == "31")
                {

                    strPaperContent = strPaperContent + "<dd><TEXTAREA rows=6 cols=40 id='Answer' name='Answer' style='width:100%' class=Text></TEXTAREA></dd>";

                }

                shiti += strPaperContent;
                
                Label lblshiti = (Label)DataGridPaper.Items[i].FindControl("lblshiti");
                lblshiti.Text = shiti;
				
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
			this.DataGridPaper.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridPaper_ItemDataBound);

		}
		#endregion

		#region//*******���ҳ�¼�*******
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

		#region//*******���б༭��Ϣ*******
		private void DataGridPaper_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridPaper.EditItemIndex=(int)e.Item.ItemIndex;
			ShowData(strSql);
		}
		#endregion

		#region//*******ȡ���༭��Ϣ*******
		private void DataGridPaper_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridPaper.EditItemIndex=-1;
			ShowData(strSql);
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
