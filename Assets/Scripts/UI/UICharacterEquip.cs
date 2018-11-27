using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI玩家装备类
 *    显示玩家当前装备
/* ////////////////*/

public class UICharacterEquip : MonoBehaviour {

    public static UICharacterEquip _instance;

    //装备栏
    private Button equipPrimWeapon;           // 主武器
    private Button equipSecdWeapon;           // 副武器
    private Button equipHelmet;               // 头盔
    private Button equipNecklace;             // 项链
    private Button equipArmour;               // 铠甲
    private Button equipShoes;                // 鞋子
    private Button equipRing;                 // 戒指
    private Button equipPet;                  // 宠物

    //宠物状态
    private Text petName;                      // 宠物名字
    private Text petHp;                        // 宠物Hp
    private Text petMp;                        // 宠物Mp
    private Text petMinAtk;                    // 宠物最小攻击
    private Text petMaxAtk;                    // 宠物最大攻击
    private Text petBalance;                   // 宠物平衡
    private Text petCritical;                  // 宠物暴击
    private Text petCriticalDamage;            // 宠物暴击伤害
    private Text petDefence;                   // 宠物防御
    private Text petArmour;                    // 宠物护甲
    private Text petMagicMuitiple;             // 宠物魔伤倍数
    private Button petSkill1;                  // 宠物技能1
    private Button petSkill2;                  // 宠物技能2
    private Button petSkill3;                  // 宠物技能3
    private Button petSkill4;                  // 宠物技能4


    private void Awake()
    {
        _instance = this;
        equipPrimWeapon = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipPrimaryWeapon").GetComponent<Button>();
        equipSecdWeapon = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipSecondaryWeapon").GetComponent<Button>();
        equipHelmet = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipHelmet").GetComponent<Button>();
        equipNecklace = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipNecklace").GetComponent<Button>();
        equipArmour = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipArmour").GetComponent<Button>();
        equipShoes = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipShoes").GetComponent<Button>();
        equipRing = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipRing").GetComponent<Button>();
        equipPet = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/EquipPet").GetComponent<Button>();
        petName = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/TextTitle/TextPetName").GetComponent<Text>();
        petHp = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/HP/TextHP").GetComponent<Text>();
        petMp = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/MP/TextMP").GetComponent<Text>();
        petMinAtk = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/Atk/TextMinAtk").GetComponent<Text>();
        petMaxAtk = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/Atk/TextMinAtk/TextWavyLine/TextMaxAtk").GetComponent<Text>();
        petBalance = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/Balance/TextBal").GetComponent<Text>();
        petCritical = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/Critical/TextCrit").GetComponent<Text>();
        petCriticalDamage = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/CriticalDamage/TextCriDmg").GetComponent<Text>();
        petDefence = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/Defence/TextDef").GetComponent<Text>();
        petArmour = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/Armour/TextArm").GetComponent<Text>();
        petMagicMuitiple = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/MagicMuitiple").GetComponent<Text>();
        petSkill1 = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/PetSkill1").GetComponent<Button>();
        petSkill2 = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/PetSkill2").GetComponent<Button>();
        petSkill3 = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/PetSkill3").GetComponent<Button>();
        petSkill4 = this.transform.Find("BGMenu/BGCharacterEquip/CharacterEquip/BGPetState/PetSkill4").GetComponent<Button>();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
