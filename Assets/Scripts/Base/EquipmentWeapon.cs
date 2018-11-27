using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    装备 - 武器类
 *    武器各项属性
/* ////////////////*/

public class EquipmentWeapon : Equipment
{
    private WeaponAttackType atkType;               // 武器攻击类型
    private int minAtk;                             // 武器最小攻击
    private int maxAtk;                             // 武器最大攻击
    private int balance;                            // 平衡
    private int criticalChance;                     // 暴击

    #region 字段封装
    public WeaponAttackType AtkType
    {
        get
        {
            return atkType;
        }

        set
        {
            atkType = value;
        }
    }

    public int MinAtk
    {
        get
        {
            return minAtk;
        }

        set
        {
            minAtk = value;
        }
    }

    public int MaxAtk
    {
        get
        {
            return maxAtk;
        }

        set
        {
            maxAtk = value;
        }
    }

    public int Balance
    {
        get
        {
            return balance;
        }

        set
        {
            balance = value;
        }
    }

    public int CriticalChance
    {
        get
        {
            return criticalChance;
        }

        set
        {
            criticalChance = value;
        }
    }
    #endregion
}
