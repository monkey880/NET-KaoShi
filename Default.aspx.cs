using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EasyExam
{
    public partial class Default : System.Web.UI.Page
    {
        public string kemu = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            indexNewList.DataSource = dsNew(1,10);
            indexNewList.DataBind();

            indexNewList2.DataSource = dsNew(2,10);
            indexNewList2.DataBind();

            getkemu();

        }

        private DataSet dsNew(int newclass,int num)
        {
            DataSet list = AccessDateHelper.ExecuteDataset("select top " + num + " * from NewsInfo where class=" + newclass + " order by NewsID desc");
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


                DataSet zhuoye = AccessDateHelper.ExecuteDataset("select top 10 * from PaperInfo where PaperID in (select distinct PaperID from PaperPolicy where SubjectID="+list.Tables[0].Rows[i]["SubjectID"]+" and PaperType=2 )");
                
                kemu += "<div class='con' ><ul>";

                for (int j = 0; j < zhuoye.Tables[0].Rows.Count; j++)
                {
                    kemu += "<li><a href='PaperInfo.aspx?id="+zhuoye.Tables[0].Rows[j]["PaperID"]+"'>"+zhuoye.Tables[0].Rows[j]["PaperName"]+"</a></li>";
                }

                kemu += "</ul></div></div>";

            }



        }
        
    }
}