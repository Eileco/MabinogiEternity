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
    /// 初始化装备Dict
    /// </summary>
	public void InitDicts()
    {
        equipmentDict = new Dictionary<int, Equipment>();
    }
}
