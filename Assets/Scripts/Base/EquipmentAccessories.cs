using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    装备 - 饰品类
 *    饰品各项属性
/* ////////////////*/

public class AccessoriesEquipment : Equipment
{
    private AccessoriesType accessoriesType;               // 饰品类型

    #region 字段封装
    public AccessoriesType AccessoriesType
    {
        get
        {
            return accessoriesType;
        }

        set
        {
            accessoriesType = value;
        }
    }
    #endregion
}
