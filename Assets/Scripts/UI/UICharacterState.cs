using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI角色属性类
 *    显示角色各项属性
/* ////////////////*/

public class UICharacterState : MonoBehaviour {

    public static UICharacterState _instance;

    /*  UIObject   */
    private Text textName;             // 名字
    private Text textRace;             // 种族
    private Text textAge;              // 年龄
    private Text textLevel;            // 等级
    private Slider hpValue;            // 当前HP
    private Slider mpValue;            // 当前MP
    private Slider expValue;           // 当前EXP
    private Text textGold;             // 金币
    private Text textStr;              // 力量
    private Text textAgi;              // 敏捷
    private Text textInt;              // 智力
    private Text textVol;              // 意志
    private Text textLuk;              // 幸运
    private Text textAP;               // 技能AP
    private Text textCombatPoint;      // 战斗力
    private Text textMinAtk;           // 最小攻击力
    private Text textMaxAtk;           // 最大攻击力
    private Text textBalance;          // 平衡
    private Text textCritical;         // 暴击
    private Text textCriticalDmg;      // 暴击伤害
    private Text textDef;              // 防御
    private Text textArm;              // 护甲
    private Text textArmPiercing;      // 无视护甲

    private void Awake()
    {
        _instance = this;
        //绑定UI
        this.textName = this.transform.Find("BGCharacterState/Name/TextName").GetComponent<Text>();
        this.textRace = this.transform.Find("BGCharacterState/Race/TextRace").GetComponent<Text>();
        this.textAge = this.transform.Find("BGCharacterState/Age/TextAge").GetComponent<Text>();
        this.textLevel = this.transform.Find("BGCharacterState/LV/TextLV").GetComponent<Text>();
        this.hpValue = this.transform.Find("BGCharacterState/HP/ValueHP").GetComponent<Slider>();
        this.mpValue = this.transform.Find("BGCharacterState/MP/ValueMP").GetComponent<Slider>();
        this.expValue = this.transform.Find("BGCharacterState/EXP/ValueEXP").GetComponent<Slider>();
        this.textGold = this.transform.Find("BGCharacterState/Gold/TextGold").GetComponent<Text>();
        this.textStr = this.transform.Find("BGCharacterState/BtnStrength/TextStr").GetComponent<Text>();
        this.textAgi = this.transform.Find("BGCharacterState/BtnAgility/TextAgi").GetComponent<Text>();
        this.textInt = this.transform.Find("BGCharacterState/BtnIntelligence/TextInt").GetComponent<Text>();
        this.textVol = this.transform.Find("BGCharacterState/BtnVolition/TextVol").GetComponent<Text>();
        this.textLuk = this.transform.Find("BGCharacterState/BtnLucky/TextLuk").GetComponent<Text>();
        this.textAP = this.transform.Find("BGCharacterState/BtnAP/TextAP").GetComponent<Text>();
        this.textCombatPoint = this.transform.Find("BGCharacterState/BtnCombatPoint/TextCombatPoint").GetComponent<Text>();
        this.textMinAtk = this.transform.Find("BGCharacterState/BtnAttack/TextMinAtk").GetComponent<Text>();
        this.textMaxAtk = this.transform.Find("BGCharacterState/BtnAttack/TextMinAtk/TextWavyLine/TextMaxAtk").GetComponent<Text>();
        this.textBalance = this.transform.Find("BGCharacterState/BtnBalance/TextBalance").GetComponent<Text>();
        this.textCritical = this.transform.Find("BGCharacterState/BtnCritical/TextCritical").GetComponent<Text>();
        this.textCriticalDmg = this.transform.Find("BGCharacterState/BtnCriticalDmg/TextCriticalDmg").GetComponent<Text>();
        this.textDef = this.transform.Find("BGCharacterState/BtnDefence/TextDef").GetComponent<Text>();
        this.textArm = this.transform.Find("BGCharacterState/BtnArmour/TextArm").GetComponent<Text>();
        this.textArmPiercing = this.transform.Find("BGCharacterState/BtnArmourPiercing/TextArmPiercing").GetComponent<Text>();
    }

    void Start ()
    {           
    }
	
	void Update ()
    {       
    }

    /// <summary>
    /// 初始化界面显示
    /// </summary>
    public void InitCharacterState()
    {
        textName.text = "初心者Alex";
        textRace.text = "人类";
        textAge.text = "20";
        textLevel.text = "30";
    }

    /// <summary>
    /// 获取并更新角色 Hp Mp Exp
    /// </summary>
    public void UpdateCharacterHpMpExp()
    {      
        float hp,maxHp;
        float mp,maxMp;
        float exp,maxExp;
        long gold;
        hp = CharacterState.Instance.HpValue;
        maxHp = CharacterState.Instance.MaxHp;
        mp = CharacterState.Instance.MpValue;
        maxMp = CharacterState.Instance.MaxMp;
        exp = CharacterState.Instance.ExpValue;
        maxExp = CharacterState.Instance.MaxExp;
        gold = CharacterState.Instance.Gold;
        //更新显示
        this.hpValue.value = hp / maxHp;
        this.mpValue.value = mp / maxMp;
        this.expValue.value = exp / maxExp;
        this.textGold.text = gold.ToString();
    }
}
