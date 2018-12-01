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
        List<int> intRands = GetRandoms(1, true, 1000, true, weaponCount * 20, rm, false);

        int index = 0;                // 随机数取值索引
        int randEquipmentType = 0;    // 随机武器类型

        //存储数组
        EquipmentWeapon[] weapons = new EquipmentWeapon[weaponCount];
        for (int i = 0; i < weaponCount; i++)
        {
            //随机生成武器
            EquipmentWeapon primWeapon = new EquipmentWeapon();
            randEquipmentType = GetRand(intRands, index) % 6 + 1;
            index++;
            switch (randEquipmentType)
            {
                case (int)PrimaryWeaponType.PWT_SWORD:               
                    primWeapon.EquipmentSubType = EquipmentSubType.EPT_SWORD;                       // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型   
                    break;
                case (int)PrimaryWeaponType.PWT_AXE:                   
                    primWeapon.EquipmentSubType = EquipmentSubType.EPT_AXE;                         // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型 
                    break;
                case (int)PrimaryWeaponType.PWT_BOW:          
                    primWeapon.EquipmentSubType = EquipmentSubType.EPT_BOW;                         // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_RANGED;                               // 攻击类型             
                    break;
                case (int)PrimaryWeaponType.PWT_CROSSBOW:
                    primWeapon.EquipmentSubType = EquipmentSubType.EPT_CROSSBOW;                    // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_RANGED;                               // 攻击类型 
                    break;
                case (int)PrimaryWeaponType.PWT_WAND:
                    primWeapon.EquipmentSubType = EquipmentSubType.EPT_WAND;                        // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型 
                    break;
                case (int)PrimaryWeaponType.PWT_STAFF:
                    primWeapon.EquipmentSubType = EquipmentSubType.EPT_STAFF;                       // 武器类型
                    primWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型 
                    break;
                default:
                    Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                    return null;
            }
            // 共有属性                                  
            SetEquipmentFromDict(primWeapon);                                                       // 物品类型|图标|名字|部位
            primWeapon.EquipmentMainType = EquipmentMainType.EPMT_PRIMARY_WEAPON;                   // 装备类型
            primWeapon.EnhanceLevel = 0;                                                            // 强化等级
            // 随机属性
            primWeapon.EquipmentQualityType = CalculateQualityType(intRands[index++]);              // 装备品质          
            primWeapon.MinAtk = CalculateEquipmentAtk(intRands[index++]);                           // 最小攻击力
            primWeapon.MaxAtk = primWeapon.MinAtk + CalculateEquipmentAtk(intRands[index++]);       // 最大攻击力
            primWeapon.Balance = CalculateEquipmentBalance(intRands[index++]);                      // 平衡
            primWeapon.CriticalChance = CalculateEquipmentCritical(intRands[index++]);              // 暴击
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
    public EquipmentWeapon[] CreateEquipmentSecondaryWeapon(int weaponCount)
    {
        //生成一个随机数数组
        System.Random rm = new System.Random();
        List<int> intRands = GetRandoms(1, true, 1000, true, weaponCount*20, rm, false);

        int index = 0;                // 随机数取值索引
        int randEquipmentType = 0;    // 随机武器类型

        //存储数组
        EquipmentWeapon[] weapons = new EquipmentWeapon[weaponCount];
        for (int i = 0; i < weaponCount; i++)
        {
            //随机生成武器
            EquipmentWeapon secdWeapon = new EquipmentWeapon();
            randEquipmentType = GetRand(intRands, index) % 3 + 1;
            index++;
            switch (randEquipmentType)
            {
                case (int)SecondaryWeaponType.SWT_DAGGER:             
                    secdWeapon.EquipmentSubType = EquipmentSubType.EPT_DAGGER;                      // 武器类型
                    secdWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型   
                    break;
                case (int)SecondaryWeaponType.SWT_SHIELD:             
                    secdWeapon.EquipmentSubType = EquipmentSubType.EPT_SHIELD;                      // 武器类型
                    secdWeapon.AtkType = WeaponAttackType.WAT_MELEE;                                // 攻击类型 
                    break;
                case (int)SecondaryWeaponType.SWT_BOOK:        
                    secdWeapon.EquipmentSubType = EquipmentSubType.EPT_BOOK;                        // 武器类型
                    secdWeapon.AtkType = WeaponAttackType.WAT_MAGIC;                                // 攻击类型             
                    break;
                default:
                    Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                    return null;
            }
            // 共有属性                                  
            SetEquipmentFromDict(secdWeapon);                                                       // 物品类型|图标|名字|部位
            secdWeapon.EquipmentMainType = EquipmentMainType.EPMT_SECONDARY_WEAPON;                 // 装备类型
            secdWeapon.EnhanceLevel = 0;                                                            // 强化等级
            // 随机属性
            secdWeapon.EquipmentQualityType = CalculateQualityType(intRands[index++]);              // 装备品质            
            secdWeapon.MinAtk = CalculateEquipmentAtk(intRands[index++]);                           // 最小攻击力
            secdWeapon.MaxAtk = secdWeapon.MinAtk + CalculateEquipmentAtk(intRands[index++]);       // 最大攻击力
            secdWeapon.Balance = CalculateEquipmentBalance(intRands[index++]);                      // 平衡
            secdWeapon.CriticalChance = CalculateEquipmentCritical(intRands[index++]);              // 暴击
            //TODO
            //生成词缀

            secdWeapon.ItemPrice = CalculateEquipmentPrice(secdWeapon);

            weapons[i] = secdWeapon;
        }

        //返回weaponCount个武器
        return weapons;
    }

    /// <summary>
    /// 随机生成1件防具
    /// </summary>
    public EquipmentArmor[] CreateEquipmentArmor(int armorCount)
    {
        //生成一个随机数数组
        System.Random rm = new System.Random();
        List<int> intRands = GetRandoms(1, true, 1000, true, armorCount*20, rm, false);

        int index = 0;                // 随机数取值索引
        int randEquipmentType = 0;    // 随机装备类型

        //存储数组
        EquipmentArmor[] armors = new EquipmentArmor[armorCount];
        for (int i = 0; i < armorCount; i++)
        {
            //随机生成武器
            EquipmentArmor armor = new EquipmentArmor();
            randEquipmentType = GetRand(intRands, index) % 9 + 1;
            index++;
            switch (randEquipmentType)
            {
                case (int)ArmorType.AMT_CLOTH_HELMET:              
                    armor.EquipmentSubType = EquipmentSubType.EPT_CLOTH_HELMET;                // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_CLOTH;                       // 材质类型   
                    break;
                case (int)ArmorType.AMT_CLOTH_ARMOUR:            
                    armor.EquipmentSubType = EquipmentSubType.EPT_CLOTH_ARMOUR;                // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_CLOTH;                       // 材质类型 
                    break;
                case (int)ArmorType.AMT_CLOTH_SHOES:              
                    armor.EquipmentSubType = EquipmentSubType.EPT_CLOTH_SHOES;                 // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_CLOTH;                       // 材质类型              
                    break;
                case (int)ArmorType.AMT_LEATHER_HELMET:             
                    armor.EquipmentSubType = EquipmentSubType.EPT_LEATHER_HELMET;              // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_LEATHER;                     // 材质类型               
                    break;
                case (int)ArmorType.AMT_LEATHER_ARMOUR:              
                    armor.EquipmentSubType = EquipmentSubType.EPT_LEATHER_ARMOUR;              // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_LEATHER;                     // 材质类型               
                    break;
                case (int)ArmorType.AMT_LEATHER_SHOES:               
                    armor.EquipmentSubType = EquipmentSubType.EPT_LEATHER_SHOES;               // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_LEATHER;                     // 材质类型               
                    break;
                case (int)ArmorType.AMT_STEEL_HELMET:               
                    armor.EquipmentSubType = EquipmentSubType.EPT_STEEL_HELMET;                // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_STEEL;                       // 材质类型               
                    break;
                case (int)ArmorType.AMT_STEEL_ARMOUR:              
                    armor.EquipmentSubType = EquipmentSubType.EPT_STEEL_ARMOUR;                // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_STEEL;                       // 材质类型              
                    break;
                case (int)ArmorType.AMT_STEEL_SHOES:               
                    armor.EquipmentSubType = EquipmentSubType.EPT_STEEL_SHOES;                 // 装备类型
                    armor.ArmorTextureType = ArmorTextureType.ATT_STEEL;                       // 材质类型              
                    break;
                default:
                    Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                    return null;
            }                                
            // 共有属性                                  
            SetEquipmentFromDict(armor);                                                       // 物品类型|图标|名字|部位
            armor.EquipmentMainType = EquipmentMainType.EPMT_ARMOR;                            // 装备类型
            armor.EnhanceLevel = 0;                                                            // 强化等级
            // 随机属性
            armor.EquipmentQualityType = CalculateQualityType(intRands[index++]);              // 装备品质            
            armor.Defence = CalculateEquipmentDefence(intRands[index++]);                      // 防御
            armor.Armour = CalculateEquipmentArmor(intRands[index++]);                         // 护甲
            // TODO
            // 生成词缀

            armor.ItemPrice = CalculateEquipmentPrice(armor);                                  // 价值

            armors[i] = armor;
        }
            

        return armors;
    }

    /// <summary>
    /// 随机生成1件饰品
    /// </summary>
    public EquipmentAccessories[] CreateEquipmentAccessories(int accessoriesCount)
    {
        //生成一个随机数数组
        System.Random rm = new System.Random();
        List<int> intRands = GetRandoms(1, true, 1000, true, accessoriesCount*20, rm, false);

        int index = 0;                // 随机数取值索引
        int randEquipmentType = 0;    // 随机武器类型

        //存储数组
        EquipmentAccessories[] accessories = new EquipmentAccessories[accessoriesCount];
        for (int i = 0; i < accessoriesCount; i++)
        {
            //随机生成饰品
            EquipmentAccessories accessory = new EquipmentAccessories();
            randEquipmentType = GetRand(intRands, index) % 2 + 1;
            index++;
            switch (randEquipmentType)
            {
                case (int)AccessoriesType.AST_RING:             
                    accessory.EquipmentSubType = EquipmentSubType.EPT_RING;                    // 饰品类型
                    break;
                case (int)AccessoriesType.AST_NECKLACE:            
                    accessory.EquipmentSubType = EquipmentSubType.EPT_NECKLACE;                // 饰品类型
                    break;
                default:
                    Debug.Log("CreateEquipmentPrimaryWeapon Index ERROR");
                    return null;
            }                                  
            // 共有属性                                  
            SetEquipmentFromDict(accessory);                                                   // 物品类型|图标|名字|部位
            accessory.EquipmentMainType = EquipmentMainType.EPMT_ACCESSORY;                    // 装备类型
            accessory.EnhanceLevel = 0;                                                        // 强化等级
            // 随机属性
            accessory.EquipmentQualityType = CalculateQualityType(intRands[index++]);          // 装备品质
            //TODO
            //生成词缀

            accessory.ItemPrice = CalculateEquipmentPrice(accessory);

            accessories[i] = accessory;
        }    

        return accessories;
    }

    /// <summary>
    /// 根据随机数生成物品品质等级
    /// </summary>
    /// <param name="randNum">随机数</param>
    public EquipmentQualityType CalculateQualityType(int randNum)
    {
        int qualityTypeRand = randNum % 7 + 1;
        if (qualityTypeRand < 1 || qualityTypeRand > 7)
        {
            Debug.Log("CreateEquipmentQualityType ERROR");
        }
        foreach (EquipmentQualityType item in Enum.GetValues(typeof(EquipmentQualityType)))
        {
            if ((int)item == qualityTypeRand)
            {
                return item;
            }
        }     
        return EquipmentQualityType.EQT_EXCELLENT;
    }

    /// <summary>
    /// 读取装备Dict，获取装备名字|装备图标|装备部位
    /// </summary>
    public void SetEquipmentFromDict(Equipment equipment)
    {
        //SubType对应xml表id
        int subType = (int)equipment.EquipmentSubType;
        Equipment equipmentTmp = InfoManager.Instance.equipmentDict[subType];
        if (equipmentTmp == null)
        {
            Debug.LogError("SetEquipmentFromDict EQUIPMENT ERROR");
        }
        equipment.ItemType = ItemType.IT_EQUIPMENT;
        equipment.ItemName = equipmentTmp.ItemName;
        equipment.ItemImage = equipmentTmp.ItemImage;
        equipment.EquipmentRegionType = equipmentTmp.EquipmentRegionType;
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
    public static List<int> GetRandoms(int minNum, bool isIncludeMinNum, int maxNum, bool isIncludeMaxNum, int ResultCount, System.Random rm, bool isSame)
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

    /// <summary>
    /// 得到随机数容错
    /// </summary>
    public int GetRand(List<int> randomList, int index)
    {
        //TODO
        int rand;
        if (index < randomList.Count)
        {
            rand = randomList[index];
        }
        else
        {
            Debug.Log("GetRand INDEX ERROR");
            rand = UnityEngine.Random.Range(0, 1000);
        }
        return rand;
    }

}
