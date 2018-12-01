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

}
