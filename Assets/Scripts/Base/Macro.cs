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

//装备主要类型
public enum EquipmentMainType
{
    EPMT_NONE,                   // 空
    EPMT_PRIMARY_WEAPON,          // 主武器
    EPMT_SECONDARY_WEAPON,        // 副武器
    EPMT_ARMOR,                  // 防具
    EPMT_ACCESSORY,              // 饰品
}

//装备次要类型
public enum EquipmentSubType
{
    EPT_NONE,                    // 空
    EPT_SWORD,                   // 剑
    EPT_AXE,                     // 斧头
    EPT_BOW,                     // 弓
    EPT_CROSSBOW,                // 弩
    EPT_WAND,                    // 魔杖
    EPT_STAFF,                   // 法杖
    EPT_DAGGER,                  // 匕首
    EPT_SHIELD,                  // 盾牌
    EPT_BOOK,                    // 魔法书
    EPT_CLOTH_HELMET,            // 布帽
    EPT_LEATHER_HELMET,          // 皮帽
    EPT_STEEL_HELMET,            // 头盔
    EPT_CLOTH_ARMOUR,            // 布甲
    EPT_LEATHER_ARMOUR,          // 皮甲
    EPT_STEEL_ARMOUR,            // 铠甲
    EPT_CLOTH_SHOES,             // 布鞋
    EPT_LEATHER_SHOES,           // 皮靴
    EPT_STEEL_SHOES,             // 铁靴
    EPT_RING,                    // 戒指
    EPT_NECKLACE,                // 项链
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

public class Macro : Singleton<Macro>
{
    // 实时战况信息cell最大数量
    public const int REALTIME_CELL_MAX_COUNT = 60;

    /*  资源路径   */
    public const string BAG_ITEM_CELL_PATH = "PrefabItemCell";                 // 背包装备Prefab
    public const string ACTIVE_SKILL_CELL_PATH = "PrefabActiveSkillCell";      // 技能释放Prefab
    public const string REALTIME_CELL_PATH = "PrefabRealTimeCell";             // 实时信息Prefab
    public const string TITLE_CELL_PATH = "PrefabTitleCell";                   // 称号Prefab
    public const string SKILL_CELL_PATH = "PrefabSkillCell";                   // 技能Prefab


    /*  品质颜色   */
    public Color32 ORE_COLOR_RGB = new Color32(100, 100, 100, 255);            // 普通
    public const string ORE_COLOR = "646464";
    public Color32 GOOD_COLOR_RGB = new Color32(25, 225, 0, 255);              // 优秀
    public const string GOOD_COLOR = "19E100";
    public Color32 EXCE_COLOR_RGB = new Color32(0, 50, 225, 255);              // 精良
    public const string EXCE_COLOR = "0032E1";                     
    public Color32 PREF_COLOR_RGB = new Color32(200, 200, 0, 255);             // 完美
    public const string PREF_COLOR = "C8C800";                                 
    public Color32 EPIC_COLOR_RGB = new Color32(255, 25, 225, 255);            // 史诗
    public const string EPIC_COLOR = "FF19E1";                                 
    public Color32 LEG_COLOR_RGB = new Color32(255, 66, 0, 255);               // 传说
    public const string LEG_COLOR = "FF4200";                                  
    


}
