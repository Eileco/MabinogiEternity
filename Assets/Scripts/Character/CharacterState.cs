using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    角色属性类
 *    储存角色各项属性
/* ////////////////*/

public class CharacterState : Singleton<CharacterState>
{

    /*  角色属性   */
    private string playerName;       // 名字
    private string race;             // 种族
    private int age;                 // 年龄 
    private int level;               // 等级
    private float hpValue;           // HP
    private float maxHp;             // 最大HP
    private float mpValue;           // MP
    private float maxMp;             // 最大MP
    private float expValue;          // EXP
    private float maxExp;            // 最大EXP
    private long gold;               // 金币
    private int strength;            // 力量
    private int agility;             // 敏捷
    private int intelligence;        // 智力
    private int volition;            // 意志
    private int lucky;               // 幸运
    private int strengthOrigin;      // 原始力量
    private int agilityOrigin;       // 原始敏捷
    private int intelligenceOrigin;  // 原始智力
    private int volitionOrigin;      // 原始意志
    private int luckyOrigin;         // 原始幸运
    private int ap;                  // AP
    private int combatPoint;         // 战斗力
    private int minAtk;              // 最小攻击力
    private int maxAtk;              // 最大攻击力
    private int balance;             // 平衡
    private int critical;            // 暴击率
    private int criticalAtk;         // 暴击伤害
    private int defence;             // 防御
    private int armour;              // 护甲
    private int armourPiercing;      // 无视护甲
    private int reincarnationCount;  // 转生次数

    #region 字段封装
    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            age = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public float HpValue
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

    public float MpValue
    {
        get
        {
            return mpValue;
        }

        set
        {
            mpValue = value;
        }
    }

    public float ExpValue
    {
        get
        {
            return expValue;
        }

        set
        {
            expValue = value;
        }
    }

    public long Gold
    {
        get
        {
            return gold;
        }

        set
        {
            gold = value;
        }
    }

    public int Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public int Agility
    {
        get
        {
            return agility;
        }

        set
        {
            agility = value;
        }
    }

    public int Intelligence
    {
        get
        {
            return intelligence;
        }

        set
        {
            intelligence = value;
        }
    }

    public int Volition
    {
        get
        {
            return volition;
        }

        set
        {
            volition = value;
        }
    }

    public int Lucky
    {
        get
        {
            return lucky;
        }

        set
        {
            lucky = value;
        }
    }

    public int Ap
    {
        get
        {
            return ap;
        }

        set
        {
            ap = value;
        }
    }

    public int CombatPoint
    {
        get
        {
            return combatPoint;
        }

        set
        {
            combatPoint = value;
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

    public int Critical
    {
        get
        {
            return critical;
        }

        set
        {
            critical = value;
        }
    }

    public int CriticalAtk
    {
        get
        {
            return criticalAtk;
        }

        set
        {
            criticalAtk = value;
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

    public int ArmourPiercing
    {
        get
        {
            return armourPiercing;
        }

        set
        {
            armourPiercing = value;
        }
    }

    public float MaxHp
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

    public float MaxMp
    {
        get
        {
            return maxMp;
        }

        set
        {
            maxMp = value;
        }
    }

    public float MaxExp
    {
        get
        {
            return maxExp;
        }

        set
        {
            maxExp = value;
        }
    }

    public int StrengthOrigin
    {
        get
        {
            return strengthOrigin;
        }

        set
        {
            strengthOrigin = value;
        }
    }

    public int AgilityOrigin
    {
        get
        {
            return agilityOrigin;
        }

        set
        {
            agilityOrigin = value;
        }
    }

    public int IntelligenceOrigin
    {
        get
        {
            return intelligenceOrigin;
        }

        set
        {
            intelligenceOrigin = value;
        }
    }

    public int VolitionOrigin
    {
        get
        {
            return volitionOrigin;
        }

        set
        {
            volitionOrigin = value;
        }
    }

    public int LuckyOrigin
    {
        get
        {
            return luckyOrigin;
        }

        set
        {
            luckyOrigin = value;
        }
    }

    public string Race
    {
        get
        {
            return race;
        }

        set
        {
            race = value;
        }
    }

    public int ReincarnationCount
    {
        get
        {
            return reincarnationCount;
        }

        set
        {
            reincarnationCount = value;
        }
    }
    
    #endregion

    //初始化角色信息(1级)
    public void InitCharacter()
    {
        this.Age = 10;
        this.Level = 1;
        this.MaxHp = 100;
        this.MaxMp = 50;
        this.MaxExp = 1000;
        this.HpValue = MaxHp;
        this.MpValue = MaxMp;
        this.ExpValue = 0;
        this.Strength = 10;
        this.Agility = 10;
        this.Intelligence = 10;
        this.Volition = 10;
        this.Lucky = 10;
        this.Ap = 0;
        this.CombatPoint = 10;
        this.MinAtk = 10;
        this.MaxAtk = 10;
        this.Balance = 30;
        this.Critical = 0;
        this.CriticalAtk = 150;
        this.Defence = 0;
        this.Armour = 0;
        this.ArmourPiercing = 0;
        this.ReincarnationCount = 0;
    }

    //重置Hp
    public void ResetCharacter()
    {
        this.hpValue = this.MaxHp;
    }


}
