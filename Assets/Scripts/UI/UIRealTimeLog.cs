using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI实时信息类
 *    显示实时信息
/* ////////////////*/

public class UIRealTimeLog : MonoBehaviour {

    public static UIRealTimeLog _instance;

    private int cellCount;                      // cell数量

    private GameObject scrollRect;              // 滑动列表主物体
    private GameObject contentContainer;        // 滑动列表容器
    private GameObject prefabCell;              // 实时信息cell预制体
    

    private void Awake()
    {
        _instance = this;    
        this.scrollRect = this.transform.Find("BGRealTimeLog/ScrollRect").gameObject;
        this.contentContainer = this.transform.Find("BGRealTimeLog/ScrollRect/ScrollView/Content").gameObject;
        this.prefabCell = Resources.Load(Macro.REALTIME_CELL_PATH) as GameObject;
    }

    void Start ()
    {
        
    }
	
	void Update ()
    {
        
    }

    /// <summary>
    /// 添加1条infoCell到实时信息列表
    /// </summary>
    public void AddCellToContent()
    {
        if (cellCount >= Macro.REALTIME_CELL_MAX_COUNT)     //cell数量容错
        {
            DeleteCellFromContent();
        }
        GameObject cellPrefab = GameObject.Instantiate(prefabCell);
        //修改cell信息
        Text textTime = cellPrefab.transform.Find("TextTime").GetComponent<Text>();
        Text textInfo = cellPrefab.transform.Find("TextInfo").GetComponent<Text>();
        textTime.text = "["+ System.DateTime.Now.Hour.ToString() +":"
            + System.DateTime.Now.Minute.ToString()+":"
            + System.DateTime.Now.Second.ToString()+"]";
        textInfo.text = "测试用测试用测试用测试用测试用测试用";

        cellPrefab.GetComponent<Transform>().SetParent(contentContainer.GetComponent<Transform>(), false);
        cellCount++;
    }

    /// <summary>
    /// 删除1条infoCell从实时信心列表
    /// </summary>
    public void DeleteCellFromContent()
    {
        if (cellCount == 0)    //cell数量容错
        {
            return;
        }
        GameObject cell = contentContainer.transform.GetChild(cellCount).gameObject;
        Destroy(cell);
        cellCount--;
    }

    /// <summary>
    /// 清除所有信息
    /// </summary>
    public void DeleteAllCell()
    {
        //TODO
        cellCount = 0;
    }
}
