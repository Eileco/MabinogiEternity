using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

/* //////////////////
/*    XML数据处理类
 *    处理XML各种数据
/* ////////////////*/

public class DataManager : Singleton<DataManager>
{
    //装备Data
    public Dictionary<int, Equipment> equipmentDataDict = new Dictionary<int, Equipment>();

    public int GetpetXmlDictCount()//获取长度
    {
        return equipmentDataDict.Count;
    }

    public Equipment GetPetXMLInfo(int equipmentIndex)
    {
        return equipmentDataDict[equipmentIndex];
    }

}
