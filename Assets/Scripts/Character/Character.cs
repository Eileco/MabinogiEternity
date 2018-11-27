using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    角色类
 *    角色装备技能宠物等
/* ////////////////*/


public class Character : Singleton<Character>
{
    private Equipment equipPrimaryWeapon;            // 主武器
    private Equipment equipSecondaryWeapon;          // 副武器
    private Equipment equipHelmet;                   // 头盔
    private Equipment equipNecklace;                 // 项链
    private Equipment equipArmour;                   // 铠甲
    private Equipment equipShoes;                    // 鞋子
    private Equipment equipRing;                     // 戒指
    private Pet petCur;                              // 当前宠物
    private Skill skill;                             // 技能


}
