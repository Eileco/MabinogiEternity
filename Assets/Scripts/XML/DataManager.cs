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
    /// 协程开始读取xml文件
    /// </summary>
    /// <param name="fileName">xml文件名带后缀</param>
    /// <param name="itemType">读取物品类型</param>
    public IEnumerator StartReadXml(string fileName, ItemType itemType)
    {
        string xmlDataPath = Application.dataPath + "/Resources/" + fileName;
        ReadXMlTest(xmlDataPath, itemType);
        yield return 0;


        ////WWW www = new WWW("file://" + Application.streamingAssetsPath + "/XMLData.xml");
        ////yield return www;
        ////ReadXMlTest(new MemoryStream(www.bytes));
        //////ReadXMLMono(www.text);
        ////www.Dispose();
    }


    /// <summary>
    /// 读取xml文件
    /// </summary>
    /// <param name="xmlPath">xml文件路径</param>
    /// <param name="itemType">读取物品类型</param>
    void ReadXMlTest(string xmlPath, ItemType itemType)
    {
        //初始化读取xml
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(xmlPath);
        //读取指定类型Node
        XmlNode info = xmldoc.SelectSingleNode(itemType.ToString());
        foreach (XmlNode node in info.ChildNodes)
        {
            string id = node.Attributes["id"].Value;
            string name = node.Attributes["name"].Value;
            string itemImage = node.Attributes["itemImage"].Value;
            string regionType = node.Attributes["regionType"].Value;
            //存储到Dict
            Equipment equipment = new Equipment();
            int idInt = int.Parse(id);
            int regionInt = int.Parse(regionType);
            EquipmentRegionType regionEnum = (EquipmentRegionType)System.Enum.ToObject(typeof(EquipmentRegionType), regionInt);
            equipment.Id = idInt;
            equipment.ItemName = name;
            equipment.ItemImage = itemImage;
            equipment.EquipmentRegionType = regionEnum;
            InfoManager.Instance.equipmentDict[idInt] = equipment;

            //Debug.Log("node.Name:" + node.Name + " id:" + id + " name:" + name + " itemImage:" + itemImage);
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
