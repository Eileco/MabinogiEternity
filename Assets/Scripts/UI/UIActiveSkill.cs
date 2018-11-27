using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI技能释放概率类
 *    显示技能释放概率
/* ////////////////*/

public class UIActiveSkill : MonoBehaviour {

    public static UIActiveSkill _instance;

    private GameObject prefabCell;              // 技能概率cell预制体
    private GameObject contentContainer;        // 滚动列表容器
    private Scrollbar contentScrollbar;         // 滚动列表滚动条

    //技能类型标志
    private bool hadMeleeSkill = false;
    private bool hadRangedSkill = false;
    private bool hadMagicSkill = false;
    //cell数量
    private int cellCount = 0;

    private void Awake()
    {
        _instance = this;
        this.prefabCell = Resources.Load(Macro.ACTIVE_SKILL_CELL_PATH) as GameObject;
        this.contentContainer = this.transform.Find("BGActiveSkill/ScrollRect/ScrollView/Content").gameObject;
        this.contentScrollbar = this.transform.Find("BGActiveSkill/Scrollbar").GetComponent<Scrollbar>();
    }

    void Start ()
    {
        
    }
	
	void Update ()
    {
		
	}

    /// <summary>
    /// 尾端添加1个技能cell
    /// </summary>
    public void AddSkillCell(SkillType skillType, string skillName, float skillChance)
    {
        ++cellCount;
        if (cellCount >= 3) //实时改变列表大小
        {
            RectTransform contentRect =  contentContainer.GetComponent<RectTransform>();
            float rectHeight = contentRect.rect.height;
            contentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectHeight + 30);
        }
        //添加cell
        GameObject cell = GameObject.Instantiate(prefabCell);
        Text textSkillName = cell.transform.Find("TextName").GetComponent<Text>();
        Text textSkillChance = cell.transform.Find("TextChance").GetComponent<Text>();
        textSkillName.text = skillName;                          //技能名字
        string strChance = skillChance.ToString("F2")+"%";       //保留两位
        textSkillChance.text = strChance;
        cell.transform.SetParent(contentContainer.transform, false);       
    }

    /// <summary>
    /// 尾端删除1个技能cell
    /// </summary>
    public void DeleteSkillCell()
    {

    }

    /// <summary>
    /// 技能滑动列表重置位置
    /// </summary>
    public void ResetScrollView()
    {
        contentScrollbar.value = 1;
    }

}
