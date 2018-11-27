using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/* //////////////////
/*    算法-生成类
 *    各种数据的生成算法
/* ////////////////*/

public class Create : Singleton<Create>
{
    /// <summary>
    /// 随机生成1把主武器
    /// </summary>
    public EquipmentWeapon CreateEquipmentPrimaryWeapon()
    {
        //生成一个随机数数组
        System.Random rm = new System.Random();
        List<int> intRands = GetRandom(1, true, 1000, true, 15, rm, false);

        int index = 0;                // 随机数取值索引
        int randEquipmentType = 0;    // 随机武器类型
        if (index <= intRands.Count)
        {
            randEquipmentType = intRands[index] % 6 + 1;
            index++;
        }

        EquipmentWeapon primWeapon = new EquipmentWeapon();
        switch (randEquipmentType)
        {
            case (int)PrimaryWeaponType.PWT_SWORD:
                primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_SINGLE_HAND;           // 装备部位                
                primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_SWORD;                     // 武器类型
                primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;
                primWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型   
                primWeapon.ItemName = GetEquipmentName(primWeapon);                             // 名字
                primWeapon.ItemImage = GetEquipmentImage(primWeapon);                           // 装备图标  
                break;
            default:
                break;
        }
        //随机生成武器
        if (randEquipmentType == (int)PrimaryWeaponType.PWT_SWORD)
        {         
            primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_SINGLE_HAND;           // 装备部位                
            primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_SWORD;                     // 武器类型
            primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;                 
            primWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型   
            primWeapon.ItemName = GetEquipmentName(primWeapon);                             // 名字
            primWeapon.ItemImage = GetEquipmentImage(primWeapon);                           // 装备图标    
        }
        else if (randEquipmentType == (int)PrimaryWeaponType.PWT_AXE)
        {
            primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位                    
            primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_AXE;                       // 武器类型
            primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;              
            primWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型 
            primWeapon.ItemName = GetEquipmentName(primWeapon);                             // 名字   
            primWeapon.ItemImage = GetEquipmentImage(primWeapon);                           // 装备图标
        }
        else if (randEquipmentType == (int)PrimaryWeaponType.PWT_BOW)
        {
            primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位           
            primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_BOW;                       // 武器类型
            primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;           
            primWeapon.AtkType = WeaponAttackType.WAT_RANGED;                               // 攻击类型             
            primWeapon.ItemName = GetEquipmentName(primWeapon);                             // 名字     
            primWeapon.ItemImage = GetEquipmentImage(primWeapon);                           // 装备图标
        }
        else if (randEquipmentType == (int)PrimaryWeaponType.PWT_CROSSBOW)
        {
            primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位
            primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_CROSSBOW;                  // 武器类型
            primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;
            primWeapon.AtkType = WeaponAttackType.WAT_RANGED;                               // 攻击类型 
            primWeapon.ItemName = GetEquipmentName(primWeapon);                             // 名字
            primWeapon.ItemImage = GetEquipmentImage(primWeapon);                           // 装备图标                               
        }
        else if (randEquipmentType == (int)PrimaryWeaponType.PWT_WAND)
        {
            primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_SINGLE_HAND;           // 装备部位
            primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_WAND;                      // 武器类型
            primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;
            primWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型 
            primWeapon.ItemName = GetEquipmentName(primWeapon);                             // 名字
            primWeapon.ItemImage = GetEquipmentImage(primWeapon);                           // 装备图标
        }
        else if (randEquipmentType == (int)PrimaryWeaponType.PWT_STAFF)
        {
            primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位
            primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_STAFF;                     // 武器类型
            primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;
            primWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型 
            primWeapon.ItemName = GetEquipmentName(primWeapon);                             // 名字
            primWeapon.ItemImage = GetEquipmentImage(primWeapon);                           // 装备图标
        }
        else
        {
            Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
            return null;
        }
        //共有属性
        primWeapon.ItemType = ItemType.IT_EQUIPMENT;                                        // 物品类型
        primWeapon.EquipmentType = EquipmentType.EPT_PRIMARY_WEAPON;                        // 装备类型
        primWeapon.EquipmentQualityType = CalculateQualityType(intRands[index++]);          // 装备品质
        primWeapon.EnhanceLevel = 0;                                                        // 强化等级
        primWeapon.MinAtk = CalculateEquipmentAtk(intRands[index++]);                       // 最小攻击力
        primWeapon.MaxAtk = primWeapon.MinAtk + CalculateEquipmentAtk(intRands[index++]);   // 最大攻击力
        primWeapon.Balance = CalculateEquipmentBalance(intRands[index++]);                  // 平衡
        primWeapon.CriticalChance = CalculateEquipmentCritical(intRands[index++]);          // 暴击
        //TODO
        //生成词缀

        primWeapon.ItemPrice = CalculateEquipmentPrice(primWeapon);

        return primWeapon;
    }

    /// <summary>
    /// 根据随机数生成物品品质等级
    /// </summary>
    /// <param name="randNum">随机数</param>
    public EquipmentQualityType CalculateQualityType(int randNum)
    {
        int qualityTypeRand = randNum % 7 + 1;
        foreach (EquipmentQualityType item in Enum.GetValues(typeof(EquipmentQualityType)))
        {
            if ((int)item == qualityTypeRand)
            {
                return item;
            }
        }
        Debug.Log("CreateEquipmentQualityType ERROR");
        return EquipmentQualityType.EQT_EXCELLENT;
    }

    /// <summary>
    /// 根据装备生成物品名字
    /// </summary>
    public string GetEquipmentName(Equipment equipment)
    {
        //TODO
        string equipmentName = "";

        return equipmentName;
    }

    /// <summary>
    /// 根据装备生成物品图标
    /// </summary>
    public string GetEquipmentImage(Equipment equipment)
    {
        //TODO
        string equipmentImagePath = "";

        return equipmentImagePath;
    }

    /// <summary>
    /// 根据装备生成物品价值
    /// </summary>
    public int CalculateEquipmentPrice(Equipment equipment)
    {
        //TODO

        return 0;
    }

    /// <summary>
    /// 根据随机数生成物品攻击力
    /// </summary>
    public int CalculateEquipmentAtk(int randNum)
    {
        //TODO

        return randNum;
    }

    /// <summary>
    /// 根据随机数生成物品平衡
    /// </summary>
    public int CalculateEquipmentBalance(int randNum)
    {
        //TODO

        return randNum;
    }

    /// <summary>
    /// 根据随机数生成物品暴击
    /// </summary>
    public int CalculateEquipmentCritical(int randNum)
    {
        //TODO

        return randNum;
    }

    /// <summary>
    /// 根据随机数范围获取一定数量的随机数
    /// </summary>
    /// <param name="minNum">随机数最小值</param>
    /// <param name="minNum">是否包含最小值</param>
    /// <param name="maxNum">随机数最大值</param>
    /// <param name="minNum">是否包含最大值</param>
    /// <param name="ResultCount">随机结果数量</param>
    /// <param name="rm">随机数对象</param>
    /// <param name="isSame">结果是否重复</param>
    public static List<int> GetRandom(int minNum, bool isIncludeMinNum, int maxNum, bool isIncludeMaxNum, int ResultCount, System.Random rm, bool isSame)
    {
        List<int> randomList = new List<int>();
        int nValue = 0;

        //是否包含最大最小值，默认包含最小值，不包含最大值
        if (!isIncludeMinNum) { minNum = minNum + 1; }
        if (isIncludeMaxNum) { maxNum = maxNum + 1; }

        if (isSame)
        {
            for (int i = 0; randomList.Count < ResultCount; i++)
            {
                nValue = rm.Next(minNum, maxNum);
                randomList.Add(nValue);
            }
        }
        else
        {
            for (int i = 0; randomList.Count < ResultCount; i++)
            {
                nValue = rm.Next(minNum, maxNum);
                //重复判断
                if (!randomList.Contains(nValue))
                {
                    randomList.Add(nValue);
                }
            }
        }

        return randomList;
    }

}
