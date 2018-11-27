using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI掉落统计类
 *    显示当前掉落统计
/* ////////////////*/

public class UIStatistics : MonoBehaviour {

    public static UIStatistics _instance;

    private Text textGainGold;           // 当前地图获得金钱
    private Text textGainExp;            // 当前地图获得经验
    private Text textEquipOrdCnt;        // 当前地图获得普通装备
    private Text textEquipGoodCnt;       // 当前地图获得优秀装备
    private Text textEquipExceCnt;       // 当前地图获得精灵装备
    private Text textEquipPerfCnt;       // 当前地图获得完美装备
    private Text textEquipEpicCnt;       // 当前地图获得史诗装备
    private Text textEquipLegCnt;        // 当前地图获得传说装备 

    
    void Awake()
    {
        _instance = this;
        this.textGainGold = this.transform.Find("BGStatistics/Gold/TextGainGold").GetComponent<Text>();
        this.textGainExp = this.transform.Find("BGStatistics/EXP/TextGainExp").GetComponent<Text>();
        this.textEquipOrdCnt = this.transform.Find("BGStatistics/Ord/TextEquipOrdCnt").GetComponent<Text>();
        this.textEquipGoodCnt = this.transform.Find("BGStatistics/Good/TextEquipGoodCnt").GetComponent<Text>();
        this.textEquipExceCnt = this.transform.Find("BGStatistics/Exce/TextEquipExceCnt").GetComponent<Text>();
        this.textEquipPerfCnt = this.transform.Find("BGStatistics/Perf/TextEquipPerfCnt").GetComponent<Text>();
        this.textEquipEpicCnt = this.transform.Find("BGStatistics/Epic/TextEquipEpicCnt").GetComponent<Text>();
        this.textEquipLegCnt = this.transform.Find("BGStatistics/Leg/TextEquipLegCnt").GetComponent<Text>();
    }

    void Start ()
    {
        changeGainGold(591251925);
        changeGainEXP(215881288);
        changeGainEquipOrdCnt(12312);
        changeGainEquipGoodCnt(213);
        changeGainEquipExceCnt(1212);
        changeGainEquipPerfCnt(55);
        changeGainEquipEpicCnt(10);
        changeGainEquipLegCnt(1);
	}
	
	void Update ()
    {
		
	}

    //修改获得金币显示
    public void changeGainGold(long gold)
    {
        if (gold < 0) return;
        textGainGold.text = gold.ToString();
    }

    //修改获得经验显示
    public void changeGainEXP(long exp)
    {
        if (exp < 0) return;
        textGainExp.text = exp.ToString();
    }

    //修改获得普通装备
    public void changeGainEquipOrdCnt(int equipCnt)
    {
        if (equipCnt < 0)
        {
            equipCnt = 0;
        }
        textEquipOrdCnt.text = equipCnt.ToString();
    }

    //修改获得优秀装备
    public void changeGainEquipGoodCnt(int equipCnt)
    {
        if (equipCnt < 0)
        {
            equipCnt = 0;
        }
        textEquipGoodCnt.text = equipCnt.ToString();
    }

    //修改获得金币显示
    public void changeGainEquipExceCnt(int equipCnt)
    {
        if (equipCnt < 0)
        {
            equipCnt = 0;
        }
        textEquipExceCnt.text = equipCnt.ToString();
    }

    //修改获得金币显示
    public void changeGainEquipPerfCnt(int equipCnt)
    {
        if (equipCnt < 0)
        {
            equipCnt = 0;
        }
        textEquipPerfCnt.text = equipCnt.ToString();
    }

    //修改获得金币显示
    public void changeGainEquipEpicCnt(int equipCnt)
    {
        if (equipCnt < 0)
        {
            equipCnt = 0;
        }
        textEquipPerfCnt.text = equipCnt.ToString();
    }

    //修改获得金币显示
    public void changeGainEquipLegCnt(int equipCnt)
    {
        if (equipCnt < 0)
        {
            equipCnt = 0;
        }
        textEquipLegCnt.text = equipCnt.ToString();
    }
}
