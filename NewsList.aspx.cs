using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EasyExam
{
    public partial class NewsList : System.Web.UI.Page
    {
        public string kemu = "";
        protected string strSql;
        protected int RowNum = 0, LinNum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            indexNewList.DataSource = dsNew(1,10);
            indexNewList.DataBind();

            indexNewList2.DataSource = dsNew(2,10);
            indexNewList2.DataBind();

            strSql = "select a.NewsID,a.NewsTitle,a.NewsContent,a.BrowNumber,b.LoginID as CreateLoginID,a.CreateDate as CreateDate from NewsInfo a LEFT OUTER JOIN UserInfo b ON a.CreateUserID=b.UserID order by a.NewsID desc";
            if (DataGridNews.Attributes["SortExpression"] == null)
            {
                DataGridNews.Attributes["SortExpression"] = "NewsID";
                DataGridNews.Attributes["SortDirection"] = "DESC";
            }
            ShowData(strSql);

        }

        private DataSet dsNew(int newclass,int num)
        {
            DataSet list = AccessDateHelper.ExecuteDataset("select top "+num+" * from NewsInfo where class="+newclass+"");
            return list;
        }

        private void getkemu()
        {
            DataSet list = AccessDateHelper.ExecuteDataset("select top 4 * from SubjectInfo ");

            for (int i = 0; i < list.Tables[0].Rows.Count; i++)
            {
                string classstr = "";
                if ((i+1) % 2 == 0)
                {
                    classstr = "style='margin-left:10px'";
                }
                kemu += "<div class=box " + classstr + ">    <h3>" + list.Tables[0].Rows[i]["SubjectName"] + "</h3> ";


                DataSet zhuoye = AccessDateHelper.ExecuteDataset("select top 10 * from PaperInfo where PaperID in (select distinct PaperID from PaperPolicy where SubjectID="+list.Tables[0].Rows[i]["SubjectID"]+" )");
                
                kemu += "<div class='con' ><ul>";

                for (int j = 0; j < zhuoye.Tables[0].Rows.Count; j++)
                {
                    kemu += "<li><a href='PaperInfo.aspx?id="+zhuoye.Tables[0].Rows[j]["PaperID"]+"'>"+zhuoye.Tables[0].Rows[j]["PaperName"]+"</a></li>";
                }

                kemu += "</ul></div></div>";

            }



        }

        #region//*******表格翻页事件*******
        private void DataGridNews_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            DataGridNews.CurrentPageIndex = e.NewPageIndex;
            ShowData(strSql);
        }
        #endregion

        #region//*******行列颜色变换*******
        private void DataGridNews_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex != -1)
            {
                e.Item.Attributes.Add("onmouseover", "this.bgColor='#ebf5fa'");

                if (e.Item.ItemIndex % 2 == 0)
                {
                    e.Item.Attributes.Add("bgcolor", "#FFFFFF");
                    e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridNews').getAttribute('singleValue')");
                }
                else
                {
                    e.Item.Attributes.Add("bgcolor", "#F7F7F7");
                    e.Item.Attributes.Add("onmouseout", "this.bgColor=document.getElementById('DataGridNews').getAttribute('oldValue')");
                }
            }
            else
            {
                DataGridNews.Attributes.Add("oldValue", "#F7F7F7");
                DataGridNews.Attributes.Add("singleValue", "#FFFFFF");
            }
        }
        #endregion

      

        #region//*******显示数据列表*******
        private void ShowData(string strSql)
        {
            

            DataSet SqlDS = AccessDateHelper.ExecuteDataset(strSql);
            RowNum = DataGridNews.CurrentPageIndex * DataGridNews.PageSize + 1;
            LinNum = 0;

            string SortExpression = DataGridNews.Attributes["SortExpression"];
            string SortDirection = DataGridNews.Attributes["SortDirection"];
            SqlDS.Tables[0].DefaultView.Sort = SortExpression + " " + SortDirection;

            DataGridNews.DataSource = SqlDS.Tables[0].DefaultView;
            DataGridNews.DataBind();
            for (int i = 0; i < DataGridNews.Items.Count; i++)
            {
               

               
            }
            LabelRecord.Text = Convert.ToString(SqlDS.Tables[0].Rows.Count);
            LabelCountPage.Text = Convert.ToString(DataGridNews.PageCount);
            LabelCurrentPage.Text = Convert.ToString(DataGridNews.CurrentPageIndex + 1);
            
        }
        #endregion

       
       
       

        #region//*******转到第一页*******
        protected void LinkButFirstPage_Click(object sender, System.EventArgs e)
        {
            DataGridNews.CurrentPageIndex = 0;
            ShowData(strSql);
        }
        #endregion

        #region//*******转到上一页*******
        protected void LinkButPirorPage_Click(object sender, System.EventArgs e)
        {
            if (DataGridNews.CurrentPageIndex > 0)
            {
                DataGridNews.CurrentPageIndex -= 1;
                ShowData(strSql);
            }
        }
        #endregion

        #region//*******转到下一页*******
        protected void LinkButNextPage_Click(object sender, System.EventArgs e)
        {
            if (DataGridNews.CurrentPageIndex < (DataGridNews.PageCount - 1))
            {
                DataGridNews.CurrentPageIndex += 1;
                ShowData(strSql);
            }
        }
        #endregion

        #region//*******转到最后页*******
        protected void LinkButLastPage_Click(object sender, System.EventArgs e)
        {
            DataGridNews.CurrentPageIndex = (DataGridNews.PageCount - 1);
            ShowData(strSql);
        }
        #endregion

        #region//*******数据排序*******
        private void DataGridNews_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
            //获得列名
            //string sColName = e.SortExpression ;

            string ImgDown = "<img border=0 src=" + Request.ApplicationPath + "/Images/uparrow.gif>";
            string ImgUp = "<img border=0 src=" + Request.ApplicationPath + "/Images/downarrow.gif>";
            string SortExpression = e.SortExpression.ToString();
            string SortDirection = "ASC";
            int colindex = -1;
            //清空之前的图标
            for (int i = 0; i < DataGridNews.Columns.Count; i++)
            {
                DataGridNews.Columns[i].HeaderText = (DataGridNews.Columns[i].HeaderText).ToString().Replace(ImgDown, "");
                DataGridNews.Columns[i].HeaderText = (DataGridNews.Columns[i].HeaderText).ToString().Replace(ImgUp, "");
            }
            //找到所点击的HeaderText的索引号
            for (int i = 0; i < DataGridNews.Columns.Count; i++)
            {
                if (DataGridNews.Columns[i].SortExpression == e.SortExpression)
                {
                    colindex = i;
                    break;
                }
            }
            if (SortExpression == DataGridNews.Attributes["SortExpression"])
            {

                SortDirection = (DataGridNews.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");

            }
            DataGridNews.Attributes["SortExpression"] = SortExpression;
            DataGridNews.Attributes["SortDirection"] = SortDirection;
            if (DataGridNews.Attributes["SortDirection"] == "ASC")
            {
                DataGridNews.Columns[colindex].HeaderText = DataGridNews.Columns[colindex].HeaderText + ImgDown;
            }
            else
            {
                DataGridNews.Columns[colindex].HeaderText = DataGridNews.Columns[colindex].HeaderText + ImgUp;
            }
            ShowData(strSql);
        }
        #endregion
        
    }
}