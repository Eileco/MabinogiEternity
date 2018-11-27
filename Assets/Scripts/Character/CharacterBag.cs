using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    角色背包类
 *    存储角色背包信息
/* ////////////////*/

public class CharacterBag : Singleton<CharacterBag>
{
    private Equipment[] equipments = null;     // 背包当前装备
    private int curEquipCount;                 // 当前装备数量
    private int maxEquipCount;                 // 装备背包容量

    #region 字段封装
    public int CurEquipCount
    {
        get
        {
            return curEquipCount;
        }

        set
        {
            curEquipCount = value;
        }
    }

    public int MaxEquipCount
    {
        get
        {
            return maxEquipCount;
        }

        set
        {
            maxEquipCount = value;
        }
    }
    #endregion

    /// <summary>
    /// 添加1把随机主武器到背包
    /// </summary>
    public void InitBag()
    {
        curEquipCount = 0;
        MaxEquipCount = 50;
        equipments = new Equipment[maxEquipCount];
    }

    /// <summary>
    /// 添加1件装备到背包
    /// </summary>
    public void AddEquipmentToBag(EquipmentType equipmentType, int equipmentCount)
    {
        switch (equipmentType)
        {
            case EquipmentType.EPT_PRIMARY_WEAPON:
                EquipmentWeapon[] weapons = new EquipmentWeapon[equipmentCount];
                weapons = ItemCreate.Instance.CreateEquipmentPrimaryWeapon(equipmentCount); 
                for (int i = 0; i < equipmentCount; i++)
                {
                    //添加进背包数组
                    if (AddEquipmentToBagArray(weapons[i]))
                    {
                        //显示在背包
                        UIEquipmentBag._instance.AddEquipmentToBag(weapons[i]);
                    }
                }         
                break;
            case EquipmentType.EPT_SECONDARY_WEAPON:
                break;
            case EquipmentType.EPT_ARMOR:
                break;
            case EquipmentType.EPT_ACCESSORIES:
                break;
            default:
                break;
        }      
    }

    /// <summary>
    /// 存储1件装备到背包数组
    /// </summary>
    public bool AddEquipmentToBagArray(Equipment equipment)
    {
        if (equipment != null)
        {
            if (curEquipCount <= maxEquipCount)
            {
                equipments[curEquipCount] = equipment;
                curEquipCount++;
                return true;
            }            
        }
        return false;
    }
}
