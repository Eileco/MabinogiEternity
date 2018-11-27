using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    角色背包类
 *    存储角色背包信息
/* ////////////////*/

public class CharacterBag
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
    public void AddPrimaryWeaponToBag()
    {
        //生成一把主武器
        EquipmentWeapon primaryWeapon = Create.Instance.CreateEquipmentPrimaryWeapon();
        //显示在背包
        UIEquipmentBag._instance.AddEquipmentToBag(primaryWeapon);
        //存储在背包中
        
    }

    /// <summary>
    /// 添加1件装备到背包数组
    /// </summary>
    public bool AddEquipmentToArray(Equipment equipment)
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
