using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI宠物背包类
 *    显示宠物背包
/* ////////////////*/

public class UIPetBag : MonoBehaviour {

    public static UIPetBag _instance;

    private int curPetCount;           // 当前宠物数量
    private int maxPetCount;           // 宠物背包容量
    private Text textPetCount;         // text宠物数量
    private Text textPetMaxCount;      // text宠物容量

    private void Awake()
    {
        _instance = this;
        textPetCount = this.transform.Find("BGMenu/BGPet/TextPetCount").GetComponent<Text>();
        textPetMaxCount = this.transform.Find("BGMenu/BGPet/TextPetCount/TextPetMaxCount").GetComponent<Text>();
    }

    void Start ()
    {
	    	
	}
	
	void Update ()
    {
		
	}

    /// <summary>
    /// 显示添加新宠物到背包
    /// </summary>
    public void AddCellToPetBag(Pet pet)
    {

    }

    /// <summary>
    /// 扩容宠物背包容量
    /// </summary>
    public void ExtendPetBagMaxCount(int extendCount)
    {

    }
}
