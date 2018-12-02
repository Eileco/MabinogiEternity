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
    private GameObject prefabInfoAffixCell;     // 装备信息词缀cell

    private Text textEquipCount;                // text装备数量
    private Text textEquipMaxCount;             // text装备容量
    private GameObject bagContentContainer;     // 背包滑动列表容器

    //按钮
    private Text textEnhanceCost;               // 强化费用
    private Text textEnhanceChance;             // 强化成功率
    private Toggle btnSoundEffect;              // 音效开关
    private Toggle btnAutoEnhance;              // 自动强化开关
    private Button btnEnhance;                  // 强化按钮

    //装备信息
    private const float infoInitialHeight=92.5f;// 装备信息框初始高度
    private bool isCurItemInfoShow;             // 当前装备信息是否打开
    private GameObject bgCurItemInfo;           // 当前装备信息
    private Text textCurItemName;               // 当前名字
    private Text textCurItemSubType;            // 当前次要类型
    private GameObject bgPrimWeapon;            // 主武器底板
    private GameObject bgSecdWeapon;            // 副武器底板
    private GameObject bgArmor;                 // 护甲底板
    private GameObject bgAccessory;             // 饰品底板
    private Text textPrimMinAtk;                // 主武器最小攻击
    private Text textPrimMaxAtk;                // 主武器最大攻击
    private Text textPrimBalece;                // 主武器平衡
    private Text textPrimCritical;              // 主武器暴击
    private Text textSecdMinAtk;                // 副武器最小攻击
    private Text textSecdMaxAtk;                // 副武器最大攻击
    private Text textSecdCritical;              // 副武器暴击
    private Text textArmorDefence;              // 防具防御
    private Text textArmorArmour;               // 防具护甲

    private void Awake()
    {
        _instance = this;
        isCurItemInfoShow = false;
        prefabItemCell = Resources.Load(Macro.BAG_ITEM_CELL_PATH) as GameObject;
        prefabInfoAffixCell = Resources.Load(Macro.INFO_AFFIX_CELL_PATH) as GameObject;
        textEquipCount = this.transform.Find("BGMenu/BGBag/TextBagItemCount").GetComponent<Text>();
        textEquipMaxCount = this.transform.Find("BGMenu/BGBag/TextBagItemCount/TextBagItemMaxCount").GetComponent<Text>();
        textEnhanceCost = this.transform.Find("BGMenu/BGBag/BGEnhance/EnhanceCost/TextEnhanceCost").GetComponent<Text>();
        textEnhanceChance = this.transform.Find("BGMenu/BGBag/BGEnhance/EnhanceChance/TextEnhanceChance").GetComponent<Text>();
        btnSoundEffect = this.transform.Find("BGMenu/BGBag/BGEnhance/SoundEffectSwitch").GetComponent<Toggle>();
        btnAutoEnhance = this.transform.Find("BGMenu/BGBag/BGEnhance/AutoEnhanceSwitch").GetComponent<Toggle>();
        btnEnhance = this.transform.Find("BGMenu/BGBag/BGEnhance/BtnEnhance").GetComponent<Button>();
        bagContentContainer = this.transform.Find("BGMenu/BGBag/ItemScroll/Viewport/Content").gameObject;
        bgCurItemInfo = this.transform.Find("BGMenu/BGBag/ItemScroll/BGItemInfo").gameObject;
        textCurItemName = bgCurItemInfo.transform.Find("TextItemName").GetComponent<Text>();
        textCurItemSubType = bgCurItemInfo.transform.Find("TextItemSubType").GetComponent<Text>();
        bgPrimWeapon = bgCurItemInfo.transform.Find("TypePrimWeapon").gameObject;
        bgSecdWeapon = bgCurItemInfo.transform.Find("TypeSecdWeapon").gameObject;
        bgArmor = bgCurItemInfo.transform.Find("TypeArmor").gameObject;
        bgAccessory = bgCurItemInfo.transform.Find("TypeAccessory").gameObject;
        textPrimMinAtk = bgPrimWeapon.transform.Find("Atk/TextMinAtk").GetComponent<Text>();
        textPrimMaxAtk = bgPrimWeapon.transform.Find("Atk/TextMinAtk/TextMaxAtk").GetComponent<Text>();
        textPrimBalece = bgPrimWeapon.transform.Find("Balance/TextBalance").GetComponent<Text>();
        textPrimMinAtk = bgPrimWeapon.transform.Find("Critical/TextCritical").GetComponent<Text>();
        textSecdMinAtk = bgSecdWeapon.transform.Find("Atk/TextMinAtk").GetComponent<Text>();
        textSecdMaxAtk = bgSecdWeapon.transform.Find("Atk/TextMinAtk/TextMaxAtk").GetComponent<Text>();
        textSecdCritical = bgSecdWeapon.transform.Find("Critical/TextCritical").GetComponent<Text>();
        textArmorDefence = bgArmor.transform.Find("Defence/TextDefence").GetComponent<Text>();
        textArmorArmour = bgArmor.transform.Find("Armour/TextArmour").GetComponent<Text>();
    }

    void Start ()
    {

    }

    /// <summary>
    /// 添加1件装备到装备栏显示
    /// </summary>
    public bool AddEquipmentToBag(Equipment equipment)
    {
        if (CharacterBag.Instance.CurEquipCount >= 7)
        {
            //扩容content size
            RectTransform contentRect = bagContentContainer.GetComponent<RectTransform>();
            float rectHeight = contentRect.rect.height;
            contentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectHeight + 60);
        }
        //初始化预制体并添加到container
        GameObject itemCell = GameObject.Instantiate(prefabItemCell);
        itemCell.transform.SetParent(bagContentContainer.transform,false);
        if (equipment != null)
        {
            //装备图标
            Image itemImage = itemCell.transform.Find("ItemImage").GetComponent<Image>();
            string itemImagePath = equipment.ItemImage;
            itemImage.sprite = Resources.Load(itemImagePath, typeof(Sprite)) as Sprite;
            //装备名
            Text itemNameText = itemCell.transform.Find("TextEquipName").GetComponent<Text>();
            string itemNameStr = equipment.ItemName;
            int equipmentEnhance = equipment.EnhanceLevel;
            string enhanceLevelStr = equipmentEnhance.ToString();
            if (equipmentEnhance > 0)
            {
                itemNameText.text = itemNameStr + " +" + enhanceLevelStr;
            }
            ChangeEquipmentNameAndImage(equipment, itemNameText, itemImage);
            ChangeEquipmentColor(equipment, itemNameText);
            //添加按钮监听
            Button itemBtn = itemCell.GetComponent<Button>();
            itemBtn.onClick.AddListener(delegate()
            {
                OnEquipmentClick(equipment);
            });
        }
        else
        {
            Debug.LogError("AddEquipmentToBag ERUIPMENT ERROR");
            Destroy(itemCell);
        }

        return false;
    }

    /// <summary>
    /// 根据装备改变装备名字和图标
    /// </summary>
    public void ChangeEquipmentNameAndImage(Equipment equipment, Text itemName, Image itemImage)
    {
        string equipmentItemImagePath = equipment.ItemImage;
        string itemImagePath = "Images/Equipments/" + equipmentItemImagePath;
        Texture2D imageTexture = (Texture2D)Resources.Load(itemImagePath) as Texture2D;
        Sprite imageSprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
        itemImage.sprite = imageSprite;
        itemName.text = equipment.ItemName;
    }

    /// <summary>
    /// 根据装备品质改变装备名字颜色
    /// </summary>
    public void ChangeEquipmentColor(Equipment equipment, Text itemNameText)
    {
        if (itemNameText == null)
        {
            return;
        }
        switch (equipment.EquipmentQualityType)
        {
            case EquipmentQualityType.EQT_ORDINARY:
                itemNameText.color = Macro.Instance.ORE_COLOR_RGB;
                break;
            case EquipmentQualityType.EQT_GOOD:
                itemNameText.color = Macro.Instance.GOOD_COLOR_RGB;
                break;
            case EquipmentQualityType.EQT_EXCELLENT:
                itemNameText.color = Macro.Instance.EXCE_COLOR_RGB;
                break;
            case EquipmentQualityType.EQT_PERFECT:
                itemNameText.color = Macro.Instance.PREF_COLOR_RGB;
                break;
            case EquipmentQualityType.EQT_EPIC:
                itemNameText.color = Macro.Instance.EPIC_COLOR_RGB;
                break;
            case EquipmentQualityType.EQT_LEGEND:
                itemNameText.color = Macro.Instance.LEG_COLOR_RGB;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 设置装备信息框
    /// </summary>
    public void SetEquipmentInfo(Equipment equipment)
    {
        EquipmentMainType equipmentMainType = equipment.EquipmentMainType;
        int qualityLV = (int)equipment.EquipmentQualityType;    // 物品品质等级
        int cellCount = 0;                                      // 词缀个数
        switch (equipmentMainType)
        {
            case EquipmentMainType.EPMT_PRIMARY_WEAPON:
                bgPrimWeapon.SetActive(true);
                cellCount = 3 + qualityLV;
                break;
            case EquipmentMainType.EPMT_SECONDARY_WEAPON:
                bgPrimWeapon.SetActive(true);
                cellCount = 2 + qualityLV;
                break;
            case EquipmentMainType.EPMT_ARMOR:
                bgArmor.SetActive(true);
                cellCount = 2 + qualityLV;
                break;
            case EquipmentMainType.EPMT_ACCESSORY:
                bgAccessory.SetActive(true);
                cellCount = qualityLV;
                break;
            default:
                break;
        }
        
        RectTransform rtInfo = bgCurItemInfo.transform.GetComponent<RectTransform>();       // 背景框长度
        rtInfo.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, infoInitialHeight + 30 * cellCount);   // 设置高度对应词缀数量
        //设置数值
        textCurItemName.text = equipment.ItemName;
        ChangeEquipmentColor(equipment, textCurItemName);
        //string strSubType = equipment.EquipmentRegionType
    }

    /// <summary>
    /// 重置装备信息框
    /// </summary>
    public void ResetEquipmentInfo()
    {
        //TODO
        //隐藏所有属性
        bgPrimWeapon.SetActive(false);
        bgSecdWeapon.SetActive(false);
        bgArmor.SetActive(false);
        bgAccessory.SetActive(false);
        //重置背景框
        RectTransform rtInfo = bgCurItemInfo.transform.GetComponent<RectTransform>();       // 背景框长度
        rtInfo.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, infoInitialHeight);   // 设置为初始高度
    }


    /*  /////////////////////////////////////按钮监听////////////////////////////////////////  */
    /// <summary>
    /// 背包装备点击
    /// </summary>
    public void OnEquipmentClick(Equipment equipment)
    {
        if (isCurItemInfoShow == false)
        {
            bgCurItemInfo.SetActive(true);
            SetEquipmentInfo(equipment);
            isCurItemInfoShow = true;
        }
        else
        {
            bgCurItemInfo.SetActive(false);
            ResetEquipmentInfo();
            isCurItemInfoShow = false;
        }
    }
}
