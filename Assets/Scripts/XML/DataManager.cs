using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security;
using System.Xml;
//using Mono.Xml;

/* //////////////////
/*    XML数据处理类
 *    处理XML各种数据
/* ////////////////*/

public class DataManager : Singleton<DataManager>
{
    /// <summary>
    /// 读取xml文件
    /// </summary>
    public IEnumerator StartReadXml(string fileName)
    {
        string xmlDataPath = Resources.Load(fileName.Split('.')[0]).ToString();
        ReadXMlTest(xmlDataPath);
        yield return 0;        
        //WWW www = new WWW("file://" + Application.streamingAssetsPath + "/XMLData.xml");
        //yield return www;
        //ReadXMlTest(new MemoryStream(www.bytes));
        ////ReadXMLMono(www.text);
        //www.Dispose();
    }

    void ReadXMlTest(string xmlPath)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(xmlPath);
        XmlNode info = xmldoc.SelectSingleNode("Equipments");
        foreach (XmlNode node in info.ChildNodes)
        {
            string id = node.Attributes["id"].Value;
            string lang = node.Attributes["lang"].Value;
            string name = node.SelectSingleNode("name").InnerText;
            string price = node.SelectSingleNode("price").InnerText;
            Debug.Log("node.Name:" + node.Name + " id:" + id + " lang:" + lang + " name:" + name + " price:" + price);
        }
    }

    //void ReadXMLMono(string text)
    //{
    //    Mono.Xml.SecurityParser sp = new Mono.Xml.SecurityParser;
    //    sp.LoadXml(text);
    //    SecurityElement se = sp.ToXml();
    //    foreach (SecurityElement sel in se.Children)
    //    ｛
    //        string id = (string)sel.Attributes["id"];
    //    string lang = (string)sel.Attributes["lang"];
    //    string name = "", price = "";
    //    foreach (SecurityElement se2 in sel.Children)
    //        ｛
    //            if (se2.Tag == "name")
    //            ｛
    //                name = se2.Text;
    //            ｝
    //            else if (se2.Tag == "price")
    //            ｛
    //                price = se2.Text;
    //            ｝
    //        ｝
    //        Debug.Log(" id:" + id + " lang:" + lang + " name:" + name + " price:" + price);
    //    ｝
    //}

}
