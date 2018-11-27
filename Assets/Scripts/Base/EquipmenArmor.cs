using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    装备 - 防具类
 *    防具各项属性
/* ////////////////*/

public class EquipmentArmor : Equipment
{
    private ArmorTextureType armorTextureType;       // 防具材质类型
    private int defence;                             // 防御值
    private int armour;                              // 护甲值

    #region 字段封装

    public ArmorTextureType ArmorTextureType
    {
        get
        {
            return armorTextureType;
        }

        set
        {
            armorTextureType = value;
        }
    }

    public int Defence
    {
        get
        {
            return defence;
        }

        set
        {
            defence = value;
        }
    }

    public int Armour
    {
        get
        {
            return armour;
        }

        set
        {
            armour = value;
        }
    }
    #endregion

}
