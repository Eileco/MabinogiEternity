using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    信息存储类
 *    存储信息
/* ////////////////*/

public class InfoManager : Singleton<InfoManager>
{
    public Dictionary<int, Equipment> equipmentDict;

    /// <summary>
    /// 添加1件随机指定类型装备到背包
    /// </summary>
	public void InitDicts()
    {
        equipmentDict = new Dictionary<int, Equipment>();
    }
}
