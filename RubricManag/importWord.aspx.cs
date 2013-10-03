using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Word;
using EasyExam;
using System.Web.UI;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;


namespace EasyExam.RubricManag
{
    public partial class importWord : System.Web.UI.Page
    {
        WordHelp wordapp = new WordHelp();
        Microsoft.Office.Interop.Word.Application worda = new Microsoft.Office.Interop.Word.ApplicationClass();
        Regex shitiRegex = new Regex(@"^试题(\d+)：", RegexOptions.None);
        Regex optionReg = new Regex("^[A-Z]:");
        Regex daanReg = new Regex("答案:");
        string shiti = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Document doc = wordapp.CreateWordDocument("d:/1.doc",false);
            int pacount = doc.Paragraphs.Count;
            foreach (Paragraph pagep in doc.Paragraphs)
            {
                string timu = "";
                string optiona = "";
                string optionb = "";
                string optionc = "";
                string optiond = "";
                string daan = "";
                int type = 0;
                

                if (shitiRegex.IsMatch(pagep.Range.Text))
                {
                    timu = "试题："+pagep.Range.Text+"<br>";
                    type = 0;
                }
                else if(optionReg.IsMatch(pagep.Range.Text)){
                    optiona += "选项："+ pagep.Range.Text + "<br>";
                    type = 1;
                }
                else if (daanReg.IsMatch(pagep.Range.Text))
                {
                    daan = "答案："+pagep.Range.Text + "<br>";
                    type = 2;
                }
                else
                {
                    switch(type)
                    {
                        case 0:
                            timu += pagep.Range.Text;
                            break;
                        case 1:
                            optiona += pagep.Range.Text;
                            break;
                        case 2:
                            daan += pagep.Range.Text;
                            break;
                    }

                }
                
                shiti += timu + optiona + daan;

                int i = 0;
                foreach (InlineShape ish in pagep.Range.InlineShapes)
                {
                    if (ish.Type == WdInlineShapeType.wdInlineShapePicture)
                    {

                        byte[] img = (byte[])ish.Range.EnhMetaFileBits;
                        Bitmap bitmap = new Bitmap(new MemoryStream(img));
                        bitmap.Save("c:\\pic" + i.ToString() + ".jpg");
                        i++;
                    }
                }
               
            }
            Response.Write(shiti);
            //txtcon.Text = doc.Lists[1].ListParagraphs[2].Range.Text;
            ////byte[] img = (byte[])doc.Lists[1].Range.InlineShapes[1].Range.EnhMetaFileBits;
            //int i = 0;
            
            //foreach (InlineShape ish in doc.Lists[1].ListParagraphs[3].Range.InlineShapes)
            //{
            //    if (ish.Type == WdInlineShapeType.wdInlineShapePicture)
            //    {

            //        byte[] img = (byte[])ish.Range.EnhMetaFileBits;
            //        Bitmap bitmap = new Bitmap(new MemoryStream(img));
            //        bitmap.Save("c:\\pic" + i.ToString() + ".jpg");
            //        i++;
            //    }
            //}
        }


    }
}