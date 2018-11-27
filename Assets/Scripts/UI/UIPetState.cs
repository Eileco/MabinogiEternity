using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI宠物属性类
 *    显示宠物各项属性
/* ////////////////*/

public class UIPetState : MonoBehaviour {

    public static UIPetState _instance;

    private Text textPetName;
    private Text textPetLV;
    private Slider sliderPetHP;
    private Slider sliderPetEXP;
    

    private void Awake()
    {
        _instance = this;
        textPetName = this.transform.Find("BGPet/TextPetName").GetComponent<Text>();
        textPetLV = this.transform.Find("BGPet/LV/TextPetLV").GetComponent<Text>();
        sliderPetHP = this.transform.Find("BGPet/HP/ValuePetHP").GetComponent<Slider>();
        sliderPetEXP = this.transform.Find("BGPet/EXP/ValuePetEXP").GetComponent<Slider>();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
        
    }

    /// <summary>
    /// 更新宠物名字显示
    /// </summary>
    public void UpdateTextPetName(string petName)
    {
        textPetName.text = petName;
    }

    /// <summary>
    /// 更新宠物等级显示
    /// </summary>
    public void UpdateTextPetLV(int petLV)
    {
        textPetLV.text = petLV.ToString();
    }

    /// <summary>
    /// 更新宠物血条
    /// </summary>
    public void UpdatePetHp(float petHp, float maxHp)
    {
        sliderPetHP.value = petHp / maxHp;
    }

    /// <summary>
    /// 更新宠物经验值显示
    /// </summary>
    public void UpdatePetCombatPoint(float enemyExp, float maxExp)
    {
        sliderPetEXP.value = enemyExp / maxExp;
    }
}
