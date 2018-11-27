using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/* //////////////////
/*    算法-物品生成类
 *    各种物品的生成算法
/* ////////////////*/

public class ItemCreate : Singleton<ItemCreate>
{
    /// <summary>
    /// 随机生成主武器
    /// </summary>
    public EquipmentWeapon[] CreateEquipmentPrimaryWeapon(int weaponCount)
    {
        //生成一个随机数数组
        System.Random rm = new System.Random();
        List<int> intRands = GetRandom(1, true, 1000, true, weaponCount * 10, rm, false);

        int index = 0;                // 随机数取值索引
        int randEquipmentType = 0;    // 随机武器类型
        if (index <= intRands.Count)
        {
            randEquipmentType = intRands[index] % 6 + 1;
            index++;
        }
        //存储数组
        EquipmentWeapon[] weapons = new EquipmentWeapon[weaponCount];
        for (int i = 0; i < weaponCount; i++)
        {
            //随机生成武器
            EquipmentWeapon primWeapon = new EquipmentWeapon();
            switch (randEquipmentType)
            {
                case (int)PrimaryWeaponType.PWT_SWORD:
                    primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_SINGLE_HAND;           // 装备部位                
                    primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_SWORD;                     // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型   
                    break;
                case (int)PrimaryWeaponType.PWT_AXE:
                    primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位                    
                    primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_AXE;                       // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型 
                    break;
                case (int)PrimaryWeaponType.PWT_BOW:
                    primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位           
                    primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_BOW;                       // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_RANGED;                               // 攻击类型             
                    break;
                case (int)PrimaryWeaponType.PWT_CROSSBOW:
                    primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位
                    primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_CROSSBOW;                  // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_RANGED;                               // 攻击类型 
                    break;
                case (int)PrimaryWeaponType.PWT_WAND:
                    primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_SINGLE_HAND;           // 装备部位
                    primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_WAND;                      // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型 
                    break;
                case (int)PrimaryWeaponType.PWT_STAFF:
                    primWeapon.EquipmentRegionType = EquipmentRegionType.ERT_TWO_HAND;              // 装备部位
                    primWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_STAFF;                     // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型 
                    break;
                default:
                    Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                    return null;
            }
            //共有属性                                  
            primWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_NONE;
            primWeapon.ItemType = ItemType.IT_EQUIPMENT;                                        // 物品类型
            primWeapon.EquipmentType = EquipmentType.EPT_PRIMARY_WEAPON;                        // 装备类型
            primWeapon.EquipmentQualityType = CalculateQualityType(intRands[index++]);          // 装备品质
            primWeapon.EnhanceLevel = 0;                                                        // 强化等级
            primWeapon.MinAtk = CalculateEquipmentAtk(intRands[index++]);                       // 最小攻击力
            primWeapon.MaxAtk = primWeapon.MinAtk + CalculateEquipmentAtk(intRands[index++]);   // 最大攻击力
            primWeapon.Balance = CalculateEquipmentBalance(intRands[index++]);                  // 平衡
            primWeapon.CriticalChance = CalculateEquipmentCritical(intRands[index++]);          // 暴击
            primWeapon.ItemName = GetEquipmentName(primWeapon);                                 // 名字
            primWeapon.ItemImage = GetEquipmentImage(primWeapon);                               // 装备图标  
                                                                                                //TODO
                                                                                                //生成词缀

            primWeapon.ItemPrice = CalculateEquipmentPrice(primWeapon);

            weapons[i] = primWeapon;
        }
        
        //返回weaponCount个武器
        return weapons;
    }

    /// <summary>
    /// 随机生成1把副武器
    /// </summary>
    public EquipmentWeapon CreateEquipmentSecondaryWeapon()
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

        //随机生成武器
        EquipmentWeapon secdWeapon = new EquipmentWeapon();
        switch (randEquipmentType)
        {
            case (int)SecondaryWeaponType.SWT_DAGGER:
                secdWeapon.EquipmentRegionType = EquipmentRegionType.ERT_OFF_HAND;              // 装备部位                
                secdWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_DAGGER;                // 武器类型
                secdWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型   
                break;
            case (int)SecondaryWeaponType.SWT_SHIELD:
                secdWeapon.EquipmentRegionType = EquipmentRegionType.ERT_OFF_HAND;              // 装备部位                
                secdWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_SHIELD;                // 武器类型
                secdWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型 
                break;
            case (int)SecondaryWeaponType.SWT_BOOK:
                secdWeapon.EquipmentRegionType = EquipmentRegionType.ERT_OFF_HAND;              // 装备部位                
                secdWeapon.SecondaryWeaponType = SecondaryWeaponType.SWT_BOOK;                  // 武器类型
                secdWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型             
                break;
            default:
                Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                return null;
        }
        //共有属性                                  
        secdWeapon.PrimaryWeaponType = PrimaryWeaponType.PWT_NONE;
        secdWeapon.ItemType = ItemType.IT_EQUIPMENT;                                        // 物品类型
        secdWeapon.EquipmentType = EquipmentType.EPT_SECONDARY_WEAPON;                      // 装备类型
        secdWeapon.EquipmentQualityType = CalculateQualityType(intRands[index++]);          // 装备品质
        secdWeapon.EnhanceLevel = 0;                                                        // 强化等级
        secdWeapon.MinAtk = CalculateEquipmentAtk(intRands[index++]);                       // 最小攻击力
        secdWeapon.MaxAtk = secdWeapon.MinAtk + CalculateEquipmentAtk(intRands[index++]);   // 最大攻击力
        secdWeapon.Balance = CalculateEquipmentBalance(intRands[index++]);                  // 平衡
        secdWeapon.CriticalChance = CalculateEquipmentCritical(intRands[index++]);          // 暴击
        secdWeapon.ItemName = GetEquipmentName(secdWeapon);                                 // 名字
        secdWeapon.ItemImage = GetEquipmentImage(secdWeapon);                               // 装备图标  
        //TODO
        //生成词缀

        secdWeapon.ItemPrice = CalculateEquipmentPrice(secdWeapon);

        return secdWeapon;
    }

    /// <summary>
    /// 随机生成1件防具
    /// </summary>
    public EquipmentArmor CreateEquipmentArmor()
    {
        //生成一个随机数数组
        System.Random rm = new System.Random();
        List<int> intRands = GetRandom(1, true, 1000, true, 15, rm, false);

        int index = 0;                // 随机数取值索引
        int randEquipmentType = 0;    // 随机装备类型
        if (index <= intRands.Count)
        {
            randEquipmentType = intRands[index] % 6 + 1;
            index++;
        }

        //随机生成武器
        EquipmentArmor armor = new EquipmentArmor();
        switch (randEquipmentType)
        {
            case (int)ArmorType.AMT_CLOTH_HELMET:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_HEAD;                  // 装备部位                
                armor.ArmorType = ArmorType.AMT_CLOTH_ARMOUR;                              // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_CLOTH;                       // 攻击类型   
                break;
            case (int)ArmorType.AMT_CLOTH_ARMOUR:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_BODY;                  // 装备部位                
                armor.ArmorType = ArmorType.AMT_CLOTH_ARMOUR;                              // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_CLOTH;                       // 攻击类型 
                break;
            case (int)ArmorType.AMT_CLOTH_SHOES:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_LEG;                   // 装备部位                
                armor.ArmorType = ArmorType.AMT_CLOTH_ARMOUR;                              // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_CLOTH;                       // 攻击类型              
                break;
            case (int)ArmorType.AMT_LEATHER_HELMET:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_HEAD;                  // 装备部位                
                armor.ArmorType = ArmorType.AMT_LEATHER_HELMET;                            // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_LEATHER;                     // 攻击类型              
                break;
            case (int)ArmorType.AMT_LEATHER_ARMOUR:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_BODY;                  // 装备部位                
                armor.ArmorType = ArmorType.AMT_LEATHER_ARMOUR;                            // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_LEATHER;                     // 攻击类型              
                break;
            case (int)ArmorType.AMT_LEATHER_SHOES:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_LEG;                   // 装备部位                
                armor.ArmorType = ArmorType.AMT_LEATHER_SHOES;                             // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_LEATHER;                     // 攻击类型              
                break;
            case (int)ArmorType.AMT_STEEL_HELMET:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_HEAD;                  // 装备部位                
                armor.ArmorType = ArmorType.AMT_STEEL_HELMET;                              // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_STEEL;                       // 攻击类型              
                break;
            case (int)ArmorType.AMT_STEEL_ARMOUR:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_BODY;                  // 装备部位                
                armor.ArmorType = ArmorType.AMT_STEEL_ARMOUR;                              // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_STEEL;                       // 攻击类型              
                break;
            case (int)ArmorType.AMT_STEEL_SHOES:
                armor.EquipmentRegionType = EquipmentRegionType.ERT_LEG;                   // 装备部位                
                armor.ArmorType = ArmorType.AMT_STEEL_SHOES;                               // 武器类型
                armor.ArmorTextureType = ArmorTextureType.ATT_STEEL;                       // 攻击类型              
                break;
            default:
                Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                return null;
        }
        //共有属性                                  
        armor.ItemType = ItemType.IT_EQUIPMENT;                                        // 物品类型
        armor.EquipmentType = EquipmentType.EPT_ARMOR;                                 // 装备类型
        armor.EquipmentQualityType = CalculateQualityType(intRands[index++]);          // 装备品质
        armor.EnhanceLevel = 0;                                                        // 强化等级
        armor.Defence = CalculateEquipmentDefence(intRands[index++]);                  // 防御
        armor.Armour = CalculateEquipmentArmor(intRands[index++]);                     // 护甲
        armor.ItemName = GetEquipmentName(armor);                                      // 名字
        armor.ItemImage = GetEquipmentImage(armor);                                    // 装备图标  
        //TODO
        //生成词缀

        armor.ItemPrice = CalculateEquipmentPrice(armor);                              // 价值

        return armor;
    }

    /// <summary>
    /// 随机生成1件饰品
    /// </summary>
    public EquipmentAccessories CreateEquipmentAccessories()
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

        //随机生成武器
        EquipmentAccessories accessories = new EquipmentAccessories();
        switch (randEquipmentType)
        {
            case (int)AccessoriesType.AST_RING:
                accessories.EquipmentRegionType = EquipmentRegionType.ERT_HANDS;                 // 装备部位                
                accessories.AccessoriesType = AccessoriesType.AST_RING;                          // 饰品类型
                break;
            case (int)AccessoriesType.AST_NECKLACE:
                accessories.EquipmentRegionType = EquipmentRegionType.ERT_NECK;                  // 装备部位                
                accessories.AccessoriesType = AccessoriesType.AST_NECKLACE;                      // 饰品类型
                break;
            default:
                Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                return null;
        }
        //共有属性                                  
        accessories.ItemType = ItemType.IT_EQUIPMENT;                                        // 物品类型
        accessories.EquipmentType = EquipmentType.EPT_SECONDARY_WEAPON;                      // 装备类型
        accessories.EquipmentQualityType = CalculateQualityType(intRands[index++]);          // 装备品质
        accessories.EnhanceLevel = 0;                                                        // 强化等级
        accessories.ItemName = GetEquipmentName(accessories);                                 // 名字
        accessories.ItemImage = GetEquipmentImage(accessories);                               // 装备图标  
        //TODO
        //生成词缀

        accessories.ItemPrice = CalculateEquipmentPrice(accessories);

        return accessories;
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
        EquipmentType equipmentType = equipment.EquipmentType;

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
    /// 根据随机数生成物品防御
    /// </summary>
    public int CalculateEquipmentDefence(int randNum)
    {
        //TODO

        return randNum;
    }

    /// <summary>
    /// 根据随机数生成物品护甲
    /// </summary>
    public int CalculateEquipmentArmor(int randNum)
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
