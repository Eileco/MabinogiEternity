using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    装备基类
 *    装备各项属性
/* ////////////////*/

public class Equipment : ItemBase {

    private EquipmentType equipmentType;               // 装备类型
    private EquipmentRegionType equipmentRegionType;   // 装备部位类型
    private EquipmentQualityType equipmentQualityType; // 装备品质
    private int enhanceLevel;                          // 强化等级

    #region 字段封装
    public EquipmentType EquipmentType
    {
        get
        {
            return equipmentType;
        }

        set
        {
            equipmentType = value;
        }
    }

    public int EnhanceLevel
    {
        get
        {
            return enhanceLevel;
        }

        set
        {
            enhanceLevel = value;
        }
    }

    public EquipmentRegionType EquipmentRegionType
    {
        get
        {
            return equipmentRegionType;
        }

        set
        {
            equipmentRegionType = value;
        }
    }

    public EquipmentQualityType EquipmentQualityType
    {
        get
        {
            return equipmentQualityType;
        }

        set
        {
            equipmentQualityType = value;
        }
    }
    #endregion
}
