using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    怪物类
 *    当前怪物的属性等
/* ////////////////*/


public class Enemy : MonoBehaviour {

    private int hpValue;             // 怪物当前血量
    private int maxHp;               // 怪物最大血量 
    private float minAtk;            // 怪物最小伤害
    private float maxAtk;            // 怪物最大伤害
    private int defence;             // 怪物防御
    private int armour;              // 怪物护甲

    #region 字段封装
    public int HpValue
    {
        get
        {
            return hpValue;
        }

        set
        {
            hpValue = value;
        }
    }

    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }

    public float MinAtk
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

    public float MaxAtk
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
