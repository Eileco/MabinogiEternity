using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    主场景控制类
 *    用于控制主场景
/* ////////////////*/

public class MainSceneManager : MonoBehaviour
{

    private void Awake()
    {
        //初始化信息存储
        InfoManager.Instance.InitDicts();
        //初始化背包
        CharacterBag.Instance.InitBag();      
        //读取XML表
        StartCoroutine(DataManager.Instance.StartReadXml("XMLData.xml", ItemType.IT_EQUIPMENT)); 
    }

    void Start ()
    {
        //初始化玩家状态界面显示
        UICharacterState._instance.InitCharacterState();
        //初始化怪物界面
        UIEnemyState._instance.UpdateTextEnemyName("奥西里斯的天空龙");
        UIEnemyState._instance.UpdateTextEnemyTitle("古神");
        UIEnemyState._instance.UpdateEnemyHp(1000f, 2000f);
        UIEnemyState._instance.UpdateEnemyCombatPoint(88888);
        //初始化宠物界面
        UIPetState._instance.UpdateTextPetName("耿鬼");
        UIPetState._instance.UpdateTextPetLV(80);
        UIPetState._instance.UpdatePetHp(320f, 902f);
        UIPetState._instance.UpdatePetCombatPoint(893210f, 8812672f);
        //清空实时信息
        UIRealTimeLog._instance.DeleteAllCell();
        UIRealTimeLog._instance.AddCellToContent();
        UIRealTimeLog._instance.AddCellToContent();
        UIRealTimeLog._instance.AddCellToContent();
        UIRealTimeLog._instance.AddCellToContent();
        UIRealTimeLog._instance.AddCellToContent();
        UIRealTimeLog._instance.DeleteCellFromContent();
        //初始化技能概率界面
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "阿瑟", 13);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "十大", 13);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "公司", 14);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "请问", 15);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "请问", 15);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "请问", 15);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "请问", 15);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "阿瑟", 13);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "十大", 13);
        UIActiveSkill._instance.AddSkillCell(SkillType.SKT_NONE, "公司", 14);
        UIActiveSkill._instance.ResetScrollView();

        //生成5把主武器
        CharacterBag.Instance.AddEquipmentToBag(EquipmentMainType.EPMT_PRIMARY_WEAPON,5);
        CharacterBag.Instance.AddEquipmentToBag(EquipmentMainType.EPMT_ARMOR, 4);
        CharacterBag.Instance.AddEquipmentToBag(EquipmentMainType.EPMT_ACCESSORY, 3);
        CharacterBag.Instance.AddEquipmentToBag(EquipmentMainType.EPMT_SECONDARY_WEAPON, 1);
    }

    void Update ()
    {
        //实时追踪显示HpMpExp
        UICharacterState._instance.UpdateCharacterHpMpExp();
    }
}
