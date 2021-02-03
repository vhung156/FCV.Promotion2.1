using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FCV.Promotion
{
    public class Common
    {
        public static string STR_FILECONF = Application.StartupPath + @"\FCV.Promotion.exe.config";
        public static string ReadConfigXML(string cfile, string inkey)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(cfile);
            XmlNode xmlNode = xmlDocument.SelectSingleNode("/configuration/appSettings/add[@key='" + inkey + "']");
            if (xmlNode != null)
                return xmlNode.Attributes["value"].Value;
            return (string)null;
        }

        public static void WtiteConfigXML(string cfile, string inkey, string invalue)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(cfile);
            XmlNode newChild = xmlDocument.SelectSingleNode("/configuration/appSettings/add[@key='" + inkey + "']");
            if (newChild == null)
            {
                XmlNode xmlNode = xmlDocument.SelectSingleNode("/configuration/appSettings");
                newChild = xmlDocument.CreateNode(XmlNodeType.Element, "add", (string)null);
                xmlNode.AppendChild(newChild);
                XmlAttribute node = (XmlAttribute)xmlDocument.CreateNode(XmlNodeType.Attribute, "key", "");
                node.Value = inkey;
                newChild.Attributes.Append(node);
            }
            if (newChild != null)
            {
                XmlAttribute attribute = newChild.Attributes["value"];
                if (attribute != null)
                    newChild.Attributes.Remove(attribute);
                XmlAttribute node = (XmlAttribute)xmlDocument.CreateNode(XmlNodeType.Attribute, "value", "");
                node.Value = invalue;
                newChild.Attributes.Append(node);
            }
            string str = cfile + ".new";
            xmlDocument.Save(str);
            if (!File.Exists(str))
                return;
            long num = 0;
            using (FileStream fileStream = File.OpenRead(str))
                num = fileStream.Length;
            if (num <= 0L)
                return;
            if (File.Exists(cfile))
                File.Delete(cfile);
            File.Move(str, cfile);
        }

        public static string GetDataFromColumnList(DataRow dataRow, string Slist)
        {
            string sData = string.Empty;
            string[] sArray = Slist.Split(';');
            foreach (string s in sArray)
            {
                int iColumnIndex = -1;
                int.TryParse(s, out iColumnIndex);
                if (iColumnIndex != -1)
                {
                    if (sData == string.Empty)
                        sData += dataRow[iColumnIndex].ToString();
                    else
                        sData = sData + "_" + dataRow[iColumnIndex].ToString();

                }
            }

            return sData;
        }
        public static string RemoveNonAlphanumeric(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (Char.IsDigit(c))
                    sb.Append(text[i]);
            }

            return sb.ToString();
        }
    }
}
