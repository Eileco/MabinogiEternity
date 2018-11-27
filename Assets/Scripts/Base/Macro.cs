using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    宏定义类
 *    常量|枚举|资源路径等
/* ////////////////*/

//物品类型
public enum ItemType
{
    IT_NONE,                     // 空物品
    IT_EQUIPMENT,                // 装备
    IT_PET,                      // 宠物
    IT_SKILL,                    // 技能
    IT_TITLE,                    // 称号
}

//装备类型
public enum EquipmentType
{
    EPT_NONE,                    // 空
    EPT_PRIMARY_WEAPON,          // 主武器
    EPT_SECONDARY_WEAPON,        // 副武器
    EPT_ARMOR,                   // 防具
    EPT_ACCESSORIES,             // 饰品
}

//装备品质
public enum EquipmentQualityType
{
    EQT_NONE,                    // 空
    EQT_ORDINARY,                // 普通
    EQT_GOOD,                    // 优秀
    EQT_EXCELLENT,               // 精良
    EQT_PERFECT,                 // 完美
    EQT_EPIC,                    // 史诗
    EQT_LEGEND,                  // 传说
}

//主武器类型
public enum PrimaryWeaponType
{
    PWT_NONE,                    // 空
    PWT_SWORD,                   // 剑
    PWT_AXE,                     // 斧头
    PWT_BOW,                     // 弓
    PWT_CROSSBOW,                // 弩
    PWT_WAND,                    // 魔杖
    PWT_STAFF,                   // 法杖
}

//副武器类型
public enum SecondaryWeaponType
{
    SWT_NONE,                    // 空
    SWT_DAGGER,                  // 匕首
    SWT_SHIELD,                  // 盾牌
    SWT_BOOK,                    // 魔法书
}

//武器装备类型
public enum EquipmentRegionType
{
    ERT_NONE,                    // 空
    ERT_SINGLE_HAND,             // 单手
    ERT_TWO_HAND,                // 双手
    ERT_OFF_HAND,                // 副手
    ERT_HEAD,                    // 头部
    ERT_BODY,                    // 身体
    ERT_LEG,                     // 腿部
    ERT_NECK,                    // 颈部
    ERT_HANDS                    // 手部
}

//武器攻击类型
public enum WeaponAttackType
{
    WAT_NONE,                    // 空
    WAT_MELEE,                   // 近战
    WAT_MAGIC,                   // 法术
    WAT_RANGED,                  // 远程
}

//防具类型
public enum ArmorType
{
    AMT_NONE,                    // 空
    AMT_CLOTH_HELMET,            // 布帽
    AMT_LEATHER_HELMET,          // 皮帽
    AMT_STEEL_HELMET,            // 头盔
    AMT_CLOTH_ARMOUR,            // 布甲
    AMT_LEATHER_ARMOUR,          // 皮甲
    AMT_STEEL_ARMOUR,            // 铠甲
    AMT_CLOTH_SHOES,             // 布鞋
    AMT_LEATHER_SHOES,           // 皮靴
    AMT_STEEL_SHOES,             // 铁靴
}

//防具材质类型
public enum ArmorTextureType
{
    ATT_NONE,                    // 空
    ATT_CLOTH,                   // 布甲
    ATT_LEATHER,                 // 皮甲
    ATT_STEEL,                   // 钢甲
}

//饰品类型
public enum AccessoriesType
{
    AST_NONE,                    // 空
    AST_RING,                    // 戒指
    AST_NECKLACE,                // 项链
}

//技能属性类型
public enum SkillType
{
    SKT_NONE,                    // 非技能
    SKT_PASSIVE,                 // 被动
    SKT_MELEE,                   // 近战
    SKT_MAGIC,                   // 法术
    SKT_RANGED,                  // 远程
    SKT_HEAL,                    // 治疗
    SKT_BUFF,                    // BUFF技能
    SKT_DEBUFF,                  // DEBUFF技能
    SKT_DOT,                     // DOT技能
}

//宠物类型
public enum PetType
{
    PT_NONE,                     // 空
    PT_MELEE,                    // 近战型
    PT_DEFENSE,                  // 防御型
    PT_BALANCE,                  // 平衡型
    PT_MAGIC,                    // 魔法型
}

//菜单界面上按钮位置
public enum MenuBtnLocation
{
    MBL_BAG,                     // 初始位置 背包按钮位置
    MBL_EQUIPMENT,               // 装备按钮位置
    MBL_PET,                     // 末位置 宠物按钮位置
}

public class Macro
{
    // 实时战况信息cell最大数量
    public const int REALTIME_CELL_MAX_COUNT = 60;

    /*  资源路径   */
    public const string BAG_ITEM_CELL_PATH = "PrefabItemCell";                 //背包装备Prefab
    public const string ACTIVE_SKILL_CELL_PATH = "PrefabActiveSkillCell";      //技能释放Prefab
    public const string REALTIME_CELL_PATH = "PrefabRealTimeCell";             //实时信息Prefab
    public const string TITLE_CELL_PATH = "PrefabTitleCell";                   //称号Prefab
    public const string SKILL_CELL_PATH = "PrefabSkillCell";                   //技能Prefab


}
