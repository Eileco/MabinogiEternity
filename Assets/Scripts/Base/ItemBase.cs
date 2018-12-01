using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    物品基类
 *    武器|防具|宠物|等基类
/* ////////////////*/

public class ItemBase
{
    private int id;                      // 物品ID
    private ItemType itemType;           // 物品类型
    private string itemName;             // 物品名称
    private string itemImage;            // 物品图标
    private int itemPrice;               // 物品价值

    #region 字段封装
    public ItemType ItemType
    {
        get
        {
            return itemType;
        }

        set
        {
            itemType = value;
        }
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }

    public string ItemImage
    {
        get
        {
            return itemImage;
        }

        set
        {
            itemImage = value;
        }
    }

    public int ItemPrice
    {
        get
        {
            return itemPrice;
        }

        set
        {
            itemPrice = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }
    #endregion

    //点击物品
    public virtual void OnBtnItem(bool value)
    {
        //ITEM BTN
    }

    //装备物品
    public virtual void OnBtnEquip(bool value)
    {
        //EQUIP BTN
    }

    //出售物品
    public virtual void OnBtnSell(bool value)
    {
        //SELL BTN
    }


}
