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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using EasyExam;
using System.Web.UI;
using System.Windows.Forms;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Nodes;


namespace EasyExam.RubricManag
{
	/// <summary>
	/// ImportTest ��ժҪ˵����
	/// </summary>
	public partial class ImportTest : System.Web.UI.Page
	{

		string myUserID="";
		string myLoginID="";
		PublicFunction ObjFun=new PublicFunction();
        

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
			if (!IsPostBack)
			{
                if (AccessDateHelper.GetValues("select UserType from UserInfo where LoginID='" + myLoginID + "' and UserType=1 and (RoleMenu=1 or (RoleMenu=2 and Exists(select OptionID from UserPower where UserID=UserInfo.UserID and PowerID=3 and OptionID=3)))", "UserType") != "1")
				{
					Response.Write("<script>alert('�Բ�����û�д˲���Ȩ�ޣ�')</script>");
					Response.End();
				}
				else
				{
                    ShowSubjectInfo();//��ʾ��Ŀ��Ϣ
                    DDLSubjectName.Items.FindByText("--ȫ��--").Selected = true;
                    ShowTestTypeInfo();//��ʾ��������
                    DDLTestTypeName.Items.FindByText("--ȫ��--").Selected = true;

					ButInput.Attributes.Add("onclick","javascript:document.all('LabelMessage').innerHTML='���ڵ��룬���Ժ�......';");
				}
			}
		}

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

		#region//*******������������*******
		protected void ButInput_Click(object sender, System.EventArgs e)
		{
			if (UpLoadFile.PostedFile!=null)//����ϴ��ļ���Ϊ��
			{
				if (UpLoadFile.PostedFile.FileName=="")
				{
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ��zip�ļ���')</script>");
					return;
				}
				string strName=UpLoadFile.PostedFile.FileName.Substring(UpLoadFile.PostedFile.FileName.LastIndexOf("."));//��ȡ��׺��
                if (strName.ToUpper() != ".ZIP")
                {
                    this.RegisterStartupScript("newWindow", "<script language='javascript'>alert('��ѡ����ȷ��ѹ����.zip�ļ���')</script>");
                    return;
                }

				UpLoadFile.PostedFile.SaveAs(Server.MapPath("..\\UpLoadFiles\\ImportTest.zip")); 

				string FilePath=Server.MapPath("..\\UpLoadFiles\\ImportTest.zip");
                string imgPath = DateTime.Now.Year.ToString();
                string imgPath2 = DateTime.Now.Month.ToString();
                string imgPath3 = DateTime.Now.Day.ToString();
                string imgPath4 = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
              
                string unzipPath = Server.MapPath("..\\UpLoadFiles\\"+imgPath+"\\"+imgPath2+"\\"+imgPath3+"\\"+imgPath4+"\\");

                JieYa uncls = new JieYa();
                uncls.unZipFile(FilePath,unzipPath);

                string source = "";
               
                StreamReader myStream = new StreamReader(unzipPath+"images.htm", System.Text.Encoding.GetEncoding("gb2312"));
                string stringLine = myStream.ReadLine();
                while (stringLine != null)
                {
                    source += stringLine;
                    stringLine = myStream.ReadLine();
                }
                myStream.Close();
                source.Replace("\r\n", " ");
                
                Parser imageshtml = Parser.CreateParser(source, null);

                NodeList htmllist = imageshtml.ExtractAllNodesThatMatch(new TagNameFilter("p"));

               

				int intTmp=0;
				string strTmp="";
				string SheetName="";
				bool canOpen=false;

              
					intTmp=AccessDateHelper.ExecuteNonQuery("delete from ImportErr");//���ImportErr���ݱ�
					int intSubjectID,intLoreID,intTestTypeID,intTestDiff,intOptionNum,intTypeTime,intStandardSpeed,intCreateUserID;
					string strSubjectName,strLoreName,strTestTypeName,strBaseTestType,strTestDiff,strTestMark,strTestContent,strOptionContent,strStandardAnswer,strTestParse;
					double dblTestMark;
					string[] strArrOptionContent,strArrTypeStandardAnswer;

                   
                    Regex shitiRegex = new Regex(@"\d+\)", RegexOptions.None);
                    Regex optionReg = new Regex(@"[A-Z]\.");
                    Regex daanReg = new Regex("�𰸣�");
					
					intCreateUserID=Convert.ToInt32(myUserID);
					DateTime dtmCreateDate;
					System.DateTime currentTime=new System.DateTime();
					currentTime=System.DateTime.Now;
					dtmCreateDate=Convert.ToDateTime(Convert.ToString(currentTime.ToString("d")));


                    
                    
                    intSubjectID =Convert.ToInt32( DDLSubjectName.SelectedItem.Value);//��Ŀ����
                    intLoreID = Convert.ToInt32( DDLLoreName.SelectedItem.Value);//֪ʶ��
                    intTestTypeID =Convert.ToInt32( DDLTestTypeName.SelectedItem.Value);//��������
                    strTestDiff = DDLTestDiff.SelectedItem.Value;//�����Ѷ�

                    int index = 0;
                    int i = 0;
                    int error = 0;
                    strTestContent = "";
                    strOptionContent = "";
                    strStandardAnswer = "";
                    intOptionNum = 0;
                    dblTestMark = 0;
                    strTestParse = "";

                    

                    for (int j = 0; j < htmllist.Count; j++)
                    {

                        string webp = NoHTML(htmllist[j].ToHtml());
                        webp = Regex.Replace(webp, "src=['|\"]([^\"]+)['|\"]", " src=/UpLoadFiles/"+imgPath+"/"+imgPath2+"/"+imgPath3+"/"+imgPath4+"/$1", RegexOptions.IgnoreCase);
                        int type = 0;

                        if (shitiRegex.IsMatch(webp))
                        {
                            strTestContent = "";
                            strOptionContent = "";
                            strStandardAnswer = "";
                            intOptionNum = 0;
                            dblTestMark = 0;
                            strTestParse = "";
                            strTestContent = shitiRegex.Replace(webp, "").Trim();
                            //type = 0;djy
                        }
                        else if (optionReg.IsMatch(webp))
                        {
                            if (strOptionContent == "")
                            {
                                strOptionContent += optionReg.Replace(webp, "").Trim();
                            }
                            else
                            {
                                strOptionContent += "|" + optionReg.Replace(webp, "").Trim();
                            }
                            intOptionNum =intOptionNum + 1;
                            type = 1;
                        }
                        else if (daanReg.IsMatch(webp))
                        {
                            strStandardAnswer = daanReg.Replace(webp, "").Trim();
                            type = 2;
                            
                        }
                        //else
                        //{
                        //    switch (type)
                        //    {
                        //        case 0:
                        //            strTestContent += webp.Trim();
                        //            break;
                        //        case 1:
                        //            strOptionContent += webp.Trim();
                        //            break;
                        //        case 2:
                        //            strStandardAnswer += webp.Trim();
                        //            break;
                        //    }

                        //}


                        if ((intSubjectID != 0) && (intLoreID != 0) && (intTestTypeID != 0)&&(type==2))
                        {
                            //��������
                            if (strTestContent == "")
                            {
                                index = index + 1;
                                intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'��������Ϊ��')");
                                error = 1;

                            }
                            //���ͼ��

                            strTmp = AccessDateHelper.GetValues("select RubricID from RubricInfo where SubjectID=" + intSubjectID + " and LoreID=" + intLoreID + " and TestContent='" + strTestContent + "'", "RubricID");
                            if (strTmp.Trim() != "")
                            {
                                index = index + 1;
                                intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + (j + 2) + ",'��ǰ��Ŀ֪ʶ�����Ѿ����ڴ�����')");
                                error = 1;
                            }
                            else
                            {
                                string basetesttype = AccessDateHelper.GetValues("select BaseTestType from TestTypeInfo where TestTypeID=" + intTestTypeID + "", "BaseTestType");
                                if (basetesttype == "��ѡ��")
                                {
                                    if (strOptionContent.IndexOf("|") < 0)
                                    {
                                        index = index + 1;
                                       intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + (j + 2) + ",'����ѡ������δ�á�|������')");
                                        error = 1;
                                    }
                                    if ((strStandardAnswer.ToUpper() != "A") && (strStandardAnswer.ToUpper() != "B") && (strStandardAnswer.ToUpper() != "C") && (strStandardAnswer.ToUpper() != "D") && (strStandardAnswer.ToUpper() != "E") && (strStandardAnswer.ToUpper() != "F"))
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'����𰸲���ȷ')");
                                        error = 1;
                                    }
                                }
                                if (basetesttype == "��ѡ��")
                                {
                                    if (strOptionContent.IndexOf("|") < 0)
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'����ѡ������δ�á�|������')");
                                        error = 1;
                                    }
                                    if ((strStandardAnswer.ToUpper().IndexOf("A") < 0) && (strStandardAnswer.ToUpper().IndexOf("B") < 0) && (strStandardAnswer.ToUpper().IndexOf("C") < 0) && (strStandardAnswer.ToUpper().IndexOf("D") < 0) && (strStandardAnswer.ToUpper().IndexOf("E") < 0) && (strStandardAnswer.ToUpper().IndexOf("F") < 0))
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'����𰸲���ȷ')");
                                        error = 1;
                                    }
                                }
                                if (basetesttype == "�ж���")
                                {
                                    if ((strStandardAnswer.ToUpper() != "��ȷ") && (strStandardAnswer.ToUpper() != "����"))
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'����𰸲���ȷ')");
                                        error = 1;
                                    }
                                }
                                if (basetesttype == "�����")
                                {
                                    if (strTestContent.IndexOf("___") < 0)
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'����������δ��3���»��ߡ�_����ʾ�����')");
                                        error = 1;
                                    }
                                    Regex regex1 = new Regex("___");
                                    Regex regex2 = new Regex(",");
                                    if (regex1.Matches(strTestContent, 0).Count != (regex2.Matches(strStandardAnswer, 0).Count + 1))
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'���λ�����������һ�£��𰸼��ð�Ƕ��š�,������')");
                                        error = 1;
                                    }
                                }
                                if ((basetesttype == "�ʴ���") || (basetesttype == "������"))
                                {
                                    if (strStandardAnswer == "")
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'����𰸲���Ϊ��')");
                                        error = 1;
                                    }
                                }
                                if (basetesttype == "������")
                                {
                                    if (strStandardAnswer.IndexOf(",") < 0)
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'�������δ�á�,������')");
                                        error = 1;
                                    }
                                    strArrTypeStandardAnswer = strStandardAnswer.Split(',');
                                    try
                                    {
                                        intTypeTime = Convert.ToInt32(strArrTypeStandardAnswer[0]);
                                    }
                                    catch
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'��������Ĵ���ʱ�䲻��ȷ')");
                                        error = 1;
                                    }
                                    try
                                    {
                                        intStandardSpeed = Convert.ToInt32(strArrTypeStandardAnswer[1]);
                                    }
                                    catch
                                    {
                                        index = index + 1;
                                        intTmp = AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values(" + index + "," + ( j + 2) + ",'��������ı�׼�ٶȲ���ȷ')");
                                        error = 1;
                                    }
                                }
                                if (basetesttype == "������")
                                {

                                }
                            }
                        }
                        if (type==2&&error==0)
                        {
                            AccessDateHelper.ExecuteNonQuery("Insert into RubricInfo(SubjectID,LoreID,TestTypeID,TestDiff,OptionNum,TestMark,TestContent,OptionContent,StandardAnswer,TestParse,CreateUserID,CreateDate) Values (" + intSubjectID + "," + intLoreID + "," + intTestTypeID + ",'" + strTestDiff + "'," + intOptionNum + "," + dblTestMark + ",'" + strTestContent + "','" + strOptionContent + "','" + strStandardAnswer + "','" + strTestParse + "'," + intCreateUserID + ",'" + dtmCreateDate + "')");
                            strTestContent = "";
                            strOptionContent = "";
                            strStandardAnswer = "";
                            intOptionNum = 0;
                            dblTestMark = 0;
                            strTestParse = "";
                        }

                    }
                   
                    

					string strSql="select a.ErrID,a.RowNum,a.ErrInfo from ImportErr a order by a.ErrID asc";
                    //string strConn=ConfigurationSettings.AppSettings["strConn"];
                    //SqlConnection SqlConn=new SqlConnection(strConn);
                    //SqlDataAdapter SqlCmd=new SqlDataAdapter(strSql,SqlConn);
                    //DataSet SqlDS=new DataSet();
                    //SqlCmd.Fill(SqlDS,"ImportErr");
                    DataSet SqlDS= AccessDateHelper.ExecuteDataset(strSql);
					if (SqlDS.Tables[0].Rows.Count>0)//��������д������DataGridErr
					{
						DataGridErr.DataSource=SqlDS;
						DataGridErr.AllowPaging=false;
						DataGridErr.DataBind();
						DataGridErr.Visible=true;
						LabelMessage.Text="��������ʧ�ܣ�";
					}
					
				}
			//}
		}
		#endregion

        #region//*******ѡ�����ı�*******
        protected void DDLSubjectName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ShowLoreInfo(Convert.ToInt32(DDLSubjectName.SelectedValue));
            DDLLoreName.Items.FindByText("--ȫ��--").Selected = true;
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
            DDLSubjectName.DataSource = SqlDS.Tables[0].DefaultView;
            DDLSubjectName.DataTextField = "SubjectName";
            DDLSubjectName.DataValueField = "SubjectID";
            DDLSubjectName.DataBind();
            //SqlConn.Dispose();
            ListItem strTmp = new ListItem("--ȫ��--", "0");
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
            DDLLoreName.DataSource = SqlDS.Tables[0].DefaultView;
            DDLLoreName.DataTextField = "LoreName";
            DDLLoreName.DataValueField = "LoreID";
            DDLLoreName.DataBind();
            //SqlConn.Dispose();
            ListItem strTmp = new ListItem("--ȫ��--", "0");
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
            DDLTestTypeName.DataSource = SqlDS.Tables[0].DefaultView;
            DDLTestTypeName.DataTextField = "TestTypeName";
            DDLTestTypeName.DataValueField = "TestTypeID";
            DDLTestTypeName.DataBind();
            //SqlConn.Dispose();
            ListItem strTmp = new ListItem("--ȫ��--", "0");
            DDLTestTypeName.Items.Add(strTmp);
        }
        #endregion

        private  string NoHTML(string Htmlstring)
        {
            //ɾ���ű�
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
           
            //ɾ��HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<p(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</p>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<span(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</span>", "", RegexOptions.IgnoreCase);
         
           
            
            //Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
           // Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
          
            Htmlstring.Replace("'", "");
           

            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            
            return Htmlstring;
        }
	}
}
