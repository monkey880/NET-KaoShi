using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Office.Interop.Word;
using System.IO;
using com.jwork.log;

namespace fckeditor.editor.dialog.ImportWord
{
    public partial class ImportWord : System.Web.UI.Page
    {
        //Html�ļ���
        private string _htmlFileName; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ��ȡ��ǰӦ�ó���������
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string GetContext(HttpRequest httpRequest)
        {
            if (!httpRequest.ApplicationPath.EndsWith("/"))
            {
                return (httpRequest.ApplicationPath + "/");
            }
            return httpRequest.ApplicationPath;
        }
        
        /// <summary>
        /// �ϴ�Word�ĵ�
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="filePath"></param>
        private string UpLoadFile(HtmlInputFile inputFile)
        {
            string fileName, fileExtension;
  
            //�����ϴ�����
            HttpPostedFile postedFile = inputFile.PostedFile;

            fileName = System.IO.Path.GetFileName(postedFile.FileName); 
            fileExtension = System.IO.Path.GetExtension(fileName);

            string phyPath = @"" + Server.MapPath("~/ ") + "UserFiles\\����(��ɾ)\\"; 

            //�ж�·���Ƿ����,���������򴴽�·��
            DirectoryInfo upDir = new DirectoryInfo(phyPath);
            if (!upDir.Exists)
            {
                upDir.Create();
            }

            //�����ļ�
            try
            {
                postedFile.SaveAs(phyPath + fileName);
            }
            catch
            {
                
            }
            return phyPath + fileName;
        }

        /// <summary>
        /// wordת��html
        /// </summary>
        /// <param name="wordFileName"></param>
        private string WordToHtml(object wordFileName)
        {
            //�ڴ˴������û������Գ�ʼ��ҳ��
            ApplicationClass word = new ApplicationClass();
            Type wordType = word.GetType();
            Documents docs = word.Documents;

            //���ļ�
            Type docsType = docs.GetType();
            Document doc = (Document)docsType.InvokeMember("Open",
            System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { wordFileName, true, true });

            //ת����ʽ�����Ϊ
            Type docType = doc.GetType();

            string wordSaveFileName = wordFileName.ToString();
            string strSaveFileName = wordSaveFileName.Substring(0, wordSaveFileName.Length - 3) + "html";
            object saveFileName = (object)strSaveFileName;
            //������Microsoft Word 9 Object Library��д���������10������д�ɣ�
            /*
            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
             null, doc, new object[]{saveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML});
            */
            ///������ʽ��
            ///wdFormatHTML
            ///wdFormatDocument
            ///wdFormatDOSText
            ///wdFormatDOSTextLineBreaks
            ///wdFormatEncodedText
            ///wdFormatRTF
            ///wdFormatTemplate
            ///wdFormatText
            ///wdFormatTextLineBreaks
            ///wdFormatUnicodeText
            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
             null, doc, new object[] { saveFileName, WdSaveFormat.wdFormatHTML });

            docType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod,
             null, doc, null);

            //�˳� Word
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod,
             null, word, null);

            return saveFileName.ToString();
        }

        /// <summary>
        /// �ϴ�������word�ĵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strFilename = UpLoadFile(this.fileWord);
            _htmlFileName = WordToHtml((object)strFilename); 
            findUsedFromHtml(getHtml(_htmlFileName),strFilename);
        }

        /// <summary>
        /// ��ȡhtml�ļ��������ַ���
        /// </summary>
        /// <param name="strHtmlFileName"></param>
        /// <returns></returns>
        private string getHtml(string strHtmlFileName)
        {
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("gb2312");            
            StreamReader sr = new StreamReader(strHtmlFileName, encoding);
            string str = sr.ReadToEnd(); 
            sr.Close();
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        private void findUsedFromHtml(string strHtml, string strFileName)
        {
            string strStyle;
            string strBody;

            // stytle ����
            int index = 0;
            int intStyleStart = 0;
            int intStyleEnd = 0; 
            while (index < strHtml.Length)
            {
                int intStyleStartTmp = strHtml.IndexOf("<style>", index);
                if (intStyleStartTmp == -1)
                {
                    break;
                }
                int intContentStart = strHtml.IndexOf("<!--", intStyleStartTmp);
                if (intContentStart - intStyleStartTmp == 9)
                {
                    intStyleStart = intStyleStartTmp;
                    break;
                }
                else
                {
                    index = intStyleStartTmp + 7;
                }
            }

            index = 0;
            while (index < strHtml.Length)
            {
                int intContentEndTmp = strHtml.IndexOf("-->", index);
                if (intContentEndTmp == -1)
                {
                    break;
                }
                int intStyleEndTmp = strHtml.IndexOf("</style>", intContentEndTmp);
                if (intStyleEndTmp - intContentEndTmp == 5)
                {
                    intStyleEnd = intStyleEndTmp;
                    break;
                }
                else
                {
                    index = intContentEndTmp + 4;
                }
            }

            strStyle = strHtml.Substring(intStyleStart, intStyleEnd - intStyleStart + 8);
             
            // Body����
            int bodyStart = strHtml.IndexOf("<body");
            int bodyEnd = strHtml.IndexOf("</body>");

            strBody = strHtml.Substring(bodyStart, bodyEnd - bodyStart + 7);

            //�滻ͼƬ��ַ
            string fullName = strFileName.Substring(strFileName.LastIndexOf("\\")+1);
            string strOld = fullName.Replace("doc","files"); 
            string strNew= this.GetContext(this.Request)+"UserFiles/����(��ɾ)/" + strOld; 
            strOld = strOld.Replace(" ","%20");
            strBody = strBody.Replace(strOld, strNew);
            strBody = strBody.Replace("v:imagedata", "img");
            strBody = strBody.Replace("</v:imagedata>", "");

            //this.TextBox1.Text = strBody;
            this.TextArea1.InnerText = strStyle;
            this.Textarea2.InnerText = strBody;
        }

       
    }
}  