using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace EasyExam
{
    public partial class NewInfo : System.Web.UI.Page
    {
        public string title = "";
        public string newContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            indexNewList.DataSource = dsNew(1,10);
            indexNewList.DataBind();

            indexNewList2.DataSource = dsNew(2,10);
            indexNewList2.DataBind();

            OleDbDataReader newinfo = AccessDateHelper.ExecuteReader("select NewsID,NewsTitle,NewsContent,CreateDate from NewsInfo where NewsID="+Request.QueryString["id"]+" ");
            while (newinfo.Read())
            {
                title = newinfo.GetString(1);
                newContent = newinfo.GetString(2);
            }

        }

        private DataSet dsNew(int newclass,int num)
        {
            DataSet list = AccessDateHelper.ExecuteDataset("select top " + num + " * from NewsInfo where class=" + newclass + " order by NewsID desc");
            return list;
        }

        
        
    }
}