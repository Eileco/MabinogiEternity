using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    装备基类
 *    装备各项属性
/* ////////////////*/

public class Equipment : ItemBase {

    private EquipmentMainType equipmentMainType;       // 装备主要类型
    private EquipmentSubType equipmentSubType;         // 装备次要类型
    private EquipmentRegionType equipmentRegionType;   // 装备部位类型
    private EquipmentQualityType equipmentQualityType; // 装备品质
    private int enhanceLevel;                          // 强化等级

    #region 字段封装
    public EquipmentMainType EquipmentMainType
    {
        get
        {
            return equipmentMainType;
        }

        set
        {
            equipmentMainType = value;
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

    public EquipmentSubType EquipmentSubType
    {
        get
        {
            return equipmentSubType;
        }

        set
        {
            equipmentSubType = value;
        }
    }

    #endregion
}
