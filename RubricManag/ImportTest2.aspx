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
					this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ��rar�ļ���')</script>");
					return;
				}
				string strName=UpLoadFile.PostedFile.FileName.Substring(UpLoadFile.PostedFile.FileName.LastIndexOf("."));//��ȡ��׺��
                //if (strName.ToUpper()!=".doc")
                //{
                //    this.RegisterStartupScript("newWindow","<script language='javascript'>alert('��ѡ����ȷ��word�ļ���')</script>");
                //    return;
                //}

				UpLoadFile.PostedFile.SaveAs(Server.MapPath("..\\UpLoadFiles\\ImportTest.rar")); 

				string FilePath=Server.MapPath("..\\UpLoadFiles\\ImportTest.rar");
				int intTmp=0;
				string strTmp="";
				string SheetName="";
				bool canOpen=false;

              
					intTmp=AccessDateHelper.ExecuteNonQuery("delete from ImportErr");//���ImportErr���ݱ�
					int intSubjectID,intLoreID,intTestTypeID,intTestDiff,intOptionNum,intTypeTime,intStandardSpeed,intCreateUserID;
					string strSubjectName,strLoreName,strTestTypeName,strBaseTestType,strTestDiff,strTestMark,strTestContent,strOptionContent,strStandardAnswer,strTestParse;
					double dblTestMark;
					string[] strArrOptionContent,strArrTypeStandardAnswer;

                    WordHelp wordapp = new WordHelp();
                    Microsoft.Office.Interop.Word.Application worda = new Microsoft.Office.Interop.Word.ApplicationClass();
                    Regex shitiRegex = new Regex(@"\d+��", RegexOptions.None);
                    Regex optionReg = new Regex("[A-Z]��");
                    Regex daanReg = new Regex("�𰸣�");
					
					intCreateUserID=Convert.ToInt32(myUserID);
					DateTime dtmCreateDate;
					System.DateTime currentTime=new System.DateTime();
					currentTime=System.DateTime.Now;
					dtmCreateDate=Convert.ToDateTime(Convert.ToString(currentTime.ToString("d")));


                    Document doc = wordapp.CreateWordDocument(FilePath, false);
                    
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
                    foreach (Paragraph pagep in doc.Paragraphs)
					{
                        

                        int type = 0;

                        if (shitiRegex.IsMatch(pagep.Range.Text))
                        {
                            strTestContent =shitiRegex.Replace(pagep.Range.Text,"").Trim();
                            type = 0;
                        }
                        else if (optionReg.IsMatch(pagep.Range.Text))
                        {
                            if (strOptionContent == "")
                            {
                                strOptionContent += optionReg.Replace(pagep.Range.Text, "").Trim();
                            }
                            else
                            {
                                strOptionContent += "|" + optionReg.Replace(pagep.Range.Text, "").Trim();
                            }
                            intOptionNum+=1;
                            type = 1;
                        }
                        else if (daanReg.IsMatch(pagep.Range.Text))
                        {
                            strStandardAnswer = daanReg.Replace(pagep.Range.Text, "").Trim();
                            type = 2;
                        }
                        else
                        {
                            switch (type)
                            {
                                case 0:
                                    strTestContent += pagep.Range.Text.Trim();
                                    break;
                                case 1:
                                    strOptionContent += pagep.Range.Text.Trim();
                                    break;
                                case 2:
                                    strStandardAnswer += pagep.Range.Text.Trim();
                                    break;
                            }

                        }
						
						
						if ((intSubjectID!=0)&&(intLoreID!=0)&&(intTestTypeID!=0))
						{
							//��������
							if (strTestContent=="")
							{
								index=index+1;
								intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'��������Ϊ��')");
                                error = 1;
                                
							}
							//���ͼ��
                            
							strTmp=AccessDateHelper.GetValues("select RubricID from RubricInfo where SubjectID="+intSubjectID+" and LoreID="+intLoreID+" and TestContent='"+strTestContent+"'","RubricID");
							if (strTmp.Trim()!="")
							{
								index=index+1;
								intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'��ǰ��Ŀ֪ʶ�����Ѿ����ڴ�����')");
                                error = 1;
							}
							else
							{
                                string basetesttype = AccessDateHelper.GetValues("select BaseTestType from TestTypeInfo where TestTypeID=" + intTestTypeID + "", "BaseTestType");
                                if (basetesttype == "��ѡ��")
								{
									if (strOptionContent.IndexOf("|")<0)
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'����ѡ������δ�á�|������')");
                                        error = 1;
									}
									if ((strStandardAnswer.ToUpper()!="A")&&(strStandardAnswer.ToUpper()!="B")&&(strStandardAnswer.ToUpper()!="C")&&(strStandardAnswer.ToUpper()!="D")&&(strStandardAnswer.ToUpper()!="E")&&(strStandardAnswer.ToUpper()!="F"))
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'����𰸲���ȷ')");
                                        error = 1;
									}
								}
                                if (basetesttype == "��ѡ��")
								{
									if (strOptionContent.IndexOf("|")<0)
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'����ѡ������δ�á�|������')");
                                        error = 1;
									}
									if ((strStandardAnswer.ToUpper().IndexOf("A")<0)&&(strStandardAnswer.ToUpper().IndexOf("B")<0)&&(strStandardAnswer.ToUpper().IndexOf("C")<0)&&(strStandardAnswer.ToUpper().IndexOf("D")<0)&&(strStandardAnswer.ToUpper().IndexOf("E")<0)&&(strStandardAnswer.ToUpper().IndexOf("F")<0))
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'����𰸲���ȷ')");
                                        error = 1;
									}
								}
                                if (basetesttype == "�ж���")
								{
									if ((strStandardAnswer.ToUpper()!="��ȷ")&&(strStandardAnswer.ToUpper()!="����"))
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'����𰸲���ȷ')");
                                        error = 1;
									}
								}
                                if (basetesttype == "�����")
								{
									if (strTestContent.IndexOf("___")<0)
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'����������δ��3���»��ߡ�_����ʾ�����')");
                                        error = 1;
									}
									Regex regex1=new Regex("___");
									Regex regex2=new Regex(",");
									if (regex1.Matches(strTestContent,0).Count!=(regex2.Matches(strStandardAnswer,0).Count+1))
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'���λ�����������һ�£��𰸼��ð�Ƕ��š�,������')");
                                        error = 1;
									}
								}
                                if ((basetesttype == "�ʴ���") || (basetesttype == "������"))
								{
									if (strStandardAnswer=="")
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'����𰸲���Ϊ��')");
                                        error = 1;
									}
								}
                                if (basetesttype == "������")
								{
									if (strStandardAnswer.IndexOf(",")<0)
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'�������δ�á�,������')");
                                        error = 1;
									}
									strArrTypeStandardAnswer=strStandardAnswer.Split(',');
									try
									{
										intTypeTime=Convert.ToInt32(strArrTypeStandardAnswer[0]);
									}
									catch
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'��������Ĵ���ʱ�䲻��ȷ')");
                                        error = 1;
									}
									try
									{
										intStandardSpeed=Convert.ToInt32(strArrTypeStandardAnswer[1]);
									}
									catch
									{
										index=index+1;
										intTmp=AccessDateHelper.ExecuteNonQuery("insert into ImportErr(ErrID,RowNum,ErrInfo) values("+index+","+(i+2)+",'��������ı�׼�ٶȲ���ȷ')");
                                        error = 1;
									}
								}
                                if (basetesttype == "������")
								{
									
								}
							}
						}
                        if (type == 2)
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
                    object messing = Type.Missing;
                    doc.Close(ref messing, ref messing, ref messing);
                    wordapp.Quit();
                    worda.Quit(ref messing,ref messing,ref messing);
                    

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
	}
}
