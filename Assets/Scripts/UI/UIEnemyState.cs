using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI当前怪物类
 *    显示当前怪物信息
/* ////////////////*/

public class UIEnemyState : MonoBehaviour {

    public static UIEnemyState _instance;

    private Text textEnemyName;      // 怪物名字
    private Text textEnemyTitle;     // 怪物称号
    private Slider sliderEnemyHp;    // 怪物血条
    private Text textCombatPoint;    // 怪物战斗力

    private void Awake()
    {
        _instance = this;
        textEnemyName = this.transform.Find("BGEnemy/TextEnemyName").GetComponent<Text>();
        textEnemyTitle = this.transform.Find("BGEnemy/BtnEnemyTitle/TextEnemyTitle").GetComponent<Text>();
        sliderEnemyHp = this.transform.Find("BGEnemy/EnemyHp/ValueEnemyHp").GetComponent<Slider>();
        textCombatPoint = this.transform.Find("BGEnemy/BtnEnemyCombatValue/TextEnemyCombatValue").GetComponent<Text>();
    }

    void Start ()
    {     
    }
	
	void Update ()
    {		
	}

    /// <summary>
    /// 更新怪物名字显示
    /// </summary>
    public void UpdateTextEnemyName(string enemyName)
    {
        textEnemyName.text = enemyName;
    }

    /// <summary>
    /// 更新怪物称号显示
    /// </summary>
    public void UpdateTextEnemyTitle(string enemyTitle)
    {
        textEnemyTitle.text = enemyTitle;
    }

    /// <summary>
    /// 更新怪物血条
    /// </summary>
    public void UpdateEnemyHp(float enemyHp, float maxHp)
    {
        sliderEnemyHp.value = enemyHp / maxHp;
    }

    /// <summary>
    /// 更新怪物战斗力显示
    /// </summary>
    public void UpdateEnemyCombatPoint(int combatPoint)
    {
        string combatStr = combatPoint.ToString();
        textCombatPoint.text = combatStr;
    }
}
