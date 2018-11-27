using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI装备背包类
 *    显示装备背包
/* ////////////////*/

public class UIEquipmentBag : MonoBehaviour {

    public static UIEquipmentBag _instance;

    private GameObject prefabItemCell;          // 装备栏预制体cell

    private Text textEquipCount;                // text装备数量
    private Text textEquipMaxCount;             // text装备容量
    private GameObject bagContentContainer;     // 背包滑动列表容器

    private Text textEnhanceCost;               // 强化费用
    private Text textEnhanceChance;             // 强化成功率
    private Toggle btnSoundEffect;              // 音效开关
    private Toggle btnAutoEnhance;              // 自动强化开关
    private Button btnEnhance;                  // 强化按钮

    private void Awake()
    {
        _instance = this;
        prefabItemCell = Resources.Load(Macro.BAG_ITEM_CELL_PATH) as GameObject;
        textEquipCount = this.transform.Find("BGMenu/BGBag/TextBagItemCount").GetComponent<Text>();
        textEquipMaxCount = this.transform.Find("BGMenu/BGBag/TextBagItemCount/TextBagItemMaxCount").GetComponent<Text>();
        textEnhanceCost = this.transform.Find("BGMenu/BGBag/BGEnhance/EnhanceCost/TextEnhanceCost").GetComponent<Text>();
        textEnhanceChance = this.transform.Find("BGMenu/BGBag/BGEnhance/EnhanceChance/TextEnhanceChance").GetComponent<Text>();
        btnSoundEffect = this.transform.Find("BGMenu/BGBag/BGEnhance/SoundEffectSwitch").GetComponent<Toggle>();
        btnAutoEnhance = this.transform.Find("BGMenu/BGBag/BGEnhance/AutoEnhanceSwitch").GetComponent<Toggle>();
        btnEnhance = this.transform.Find("BGMenu/BGBag/BGEnhance/BtnEnhance").GetComponent<Button>();
        bagContentContainer = this.transform.Find("BGMenu/BGBag/ItemScroll/Viewport/Content").gameObject;
    }

    void Start ()
    {

    }

    /// <summary>
    /// 添加1件装备到装备栏显示
    /// </summary>
    public bool AddEquipmentToBag(Equipment equipment)
    {
        //初始化预制体并添加到container
        GameObject itemCell = GameObject.Instantiate(prefabItemCell);
        itemCell.transform.SetParent(bagContentContainer.transform,false);
        if (equipment != null)
        {

        }

        return false;
    }

}
