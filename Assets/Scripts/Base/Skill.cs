using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    技能基类
 *    技能所有基本属性
/* ////////////////*/

public class Skill : MonoBehaviour
{
    private string skillName;       // 技能名字
    private int type;               // 技能类型
    private string description;     // 技能描述
    private float damageDirect;     // 技能直接伤害
    private float damageDot;        // 技能持续伤害

    #region 字段封装
    public string SkillName
    {
        get
        {
            return skillName;
        }

        set
        {
            skillName = value;
        }
    }

    public int Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public float DamageDirect
    {
        get
        {
            return damageDirect;
        }

        set
        {
            damageDirect = value;
        }
    }

    public float DamageDot
    {
        get
        {
            return damageDot;
        }

        set
        {
            damageDot = value;
        }
    }

    #endregion
}
