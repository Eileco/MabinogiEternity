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
    /// 初始化背包
    /// </summary>
    public void InitBag()
    {
        curEquipCount = 0;
        MaxEquipCount = 50;
        equipments = new Equipment[maxEquipCount];
    }

    /// <summary>
    /// 添加1件随机指定类型装备到背包
    /// </summary>
    public void AddEquipmentToBag(EquipmentMainType equipmentType, int equipmentCount)
    {
        switch (equipmentType)
        {
            case EquipmentMainType.EPMT_PRIMARY_WEAPON:
                EquipmentWeapon[] primWeapons = new EquipmentWeapon[equipmentCount];
                primWeapons = ItemCreate.Instance.CreateEquipmentPrimaryWeapon(equipmentCount); 
                for (int i = 0; i < equipmentCount; i++)
                {
                    //添加进背包数组
                    if (AddEquipmentToBagArray(primWeapons[i]))
                    {
                        //显示在背包
                        UIEquipmentBag._instance.AddEquipmentToBag(primWeapons[i]);
                    }
                }         
                break;
            case EquipmentMainType.EPMT_SECONDARY_WEAPON:
                EquipmentWeapon[] secdWeapons = new EquipmentWeapon[equipmentCount];
                secdWeapons = ItemCreate.Instance.CreateEquipmentSecondaryWeapon(equipmentCount);
                for (int i = 0; i < equipmentCount; i++)
                {
                    //添加进背包数组
                    if (AddEquipmentToBagArray(secdWeapons[i]))
                    {
                        //显示在背包
                        UIEquipmentBag._instance.AddEquipmentToBag(secdWeapons[i]);
                    }
                }
                break;
            case EquipmentMainType.EPMT_ARMOR:
                EquipmentArmor[] armors = new EquipmentArmor[equipmentCount];
                armors = ItemCreate.Instance.CreateEquipmentArmor(equipmentCount);
                for (int i = 0; i < equipmentCount; i++)
                {
                    //添加进背包数组
                    if (AddEquipmentToBagArray(armors[i]))
                    {
                        //显示在背包
                        UIEquipmentBag._instance.AddEquipmentToBag(armors[i]);
                    }
                }
                break;
            case EquipmentMainType.EPMT_ACCESSORY:
                EquipmentAccessories[] accessories = new EquipmentAccessories[equipmentCount];
                accessories = ItemCreate.Instance.CreateEquipmentAccessories(equipmentCount);
                for (int i = 0; i < equipmentCount; i++)
                {
                    //添加进背包数组
                    if (AddEquipmentToBagArray(accessories[i]))
                    {
                        //显示在背包
                        UIEquipmentBag._instance.AddEquipmentToBag(accessories[i]);
                    }
                }
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
