using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* //////////////////
/*    UI菜单类
 *    菜单按钮交互
/* ////////////////*/

public class UIMenu : MonoBehaviour {

    public static UIMenu _instance;

    //入口按钮
    private Toggle btnBag;                     // 背包
    private Toggle btnEquipment;               // 状态
    private Toggle btnPet;                     // 宠物
    private Toggle btnSkill;                   // 技能
    private Toggle btnTitle;                   // 称号
    private Toggle btnSetting;                 // 设置
    private Toggle btnOther;                   // 其他
    private Button btnLeft;                    // 向左
    private Button btnRight;                   // 向右
    private Scrollbar scrollBarBtn;            // 按钮滑动条
    private MenuBtnLocation menuBtnLocation;   // 按钮位置

    //界面
    private GameObject panelBag;
    private GameObject panelEquip;
    private GameObject panelSkill;
    private GameObject panelTitle;
    private GameObject panelPet;
    private GameObject panelSetting;
    private GameObject panelOther;

    private void Awake()
    {
        _instance = this;
        //赋值
        btnBag = this.transform.Find("BGMenu/BtnScrollView/Viewport/Content/BtnBag").GetComponent<Toggle>();
        btnEquipment = this.transform.Find("BGMenu/BtnScrollView/Viewport/Content/BtnEquipment").GetComponent<Toggle>();
        btnPet = this.transform.Find("BGMenu/BtnScrollView/Viewport/Content/BtnPet").GetComponent<Toggle>();
        btnSkill = this.transform.Find("BGMenu/BtnScrollView/Viewport/Content/BtnSkill").GetComponent<Toggle>();
        btnTitle = this.transform.Find("BGMenu/BtnScrollView/Viewport/Content/BtnTitle").GetComponent<Toggle>();
        btnSetting = this.transform.Find("BGMenu/BtnScrollView/Viewport/Content/BtnSetting").GetComponent<Toggle>();
        btnOther = this.transform.Find("BGMenu/BtnScrollView/Viewport/Content/BtnOther").GetComponent<Toggle>();
        btnLeft = this.transform.Find("BGMenu/BtnScrollView/Viewport/BtnLeftBG/BtnLeft").GetComponent<Button>();
        btnRight = this.transform.Find("BGMenu/BtnScrollView/Viewport/BtnRightBG/BtnRight").GetComponent<Button>();
        scrollBarBtn = this.transform.Find("BGMenu/BtnScrollView/Scrollbar").GetComponent<Scrollbar>();
        panelBag = this.transform.Find("BGMenu/BGBag").gameObject;
        panelEquip = this.transform.Find("BGMenu/BGCharacterEquip").gameObject;
        panelSkill = this.transform.Find("BGMenu/BGSkill").gameObject;
        panelTitle = this.transform.Find("BGMenu/BGTitle").gameObject;
        panelPet = this.transform.Find("BGMenu/BGPet").gameObject;
        panelSetting = this.transform.Find("BGMenu/BGSetting").gameObject;
        panelOther = this.transform.Find("BGMenu/BGOther").gameObject;
        //监听
        btnBag.onValueChanged.AddListener(OnBtnBag);
        btnEquipment.onValueChanged.AddListener(OnBtnEquipment);
        btnPet.onValueChanged.AddListener(OnBtnPet);
        btnSkill.onValueChanged.AddListener(OnBtnSkill);
        btnTitle.onValueChanged.AddListener(OnBtnTitle);
        btnSetting.onValueChanged.AddListener(OnBtnSetting);
        btnOther.onValueChanged.AddListener(OnBtnOther);
        btnLeft.onClick.AddListener(OnBtnLeft);
        btnRight.onClick.AddListener(OnBtnRight);
        //重置ScrollBarBtn
        ResetScrollBarBtn();
        OnBtnBag(true);
    }

    void Start ()
    {
    }
	

	void Update ()
    {		
	}

    #region 按钮点击
    /// <summary>
    /// 背包按钮
    /// </summary>
    public void OnBtnBag(bool value)
    {
        HideAllPanel();             //隐藏所有界面
        panelBag.SetActive(true);   //显示指定界面
    }

    /// <summary>
    /// 装备按钮
    /// </summary>
    public void OnBtnEquipment(bool value)
    {
        HideAllPanel();             //隐藏所有界面
        panelEquip.SetActive(true);   //显示指定界面
    }

    /// <summary>
    /// 宠物按钮
    /// </summary>
    public void OnBtnPet(bool value)
    {
        HideAllPanel();             //隐藏所有界面
        panelPet.SetActive(true);   //显示指定界面
    }

    /// <summary>
    /// 技能按钮
    /// </summary>
    public void OnBtnSkill(bool value)
    {
        HideAllPanel();             //隐藏所有界面
        panelSkill.SetActive(true);   //显示指定界面
    }

    /// <summary>
    /// 称号按钮
    /// </summary>
    public void OnBtnTitle(bool value)
    {
        HideAllPanel();             //隐藏所有界面
        panelTitle.SetActive(true);   //显示指定界面
    }

    /// <summary>
    /// 设置按钮
    /// </summary>
    public void OnBtnSetting(bool value)
    {
        HideAllPanel();             //隐藏所有界面
        panelSetting.SetActive(true);   //显示指定界面
    }

    /// <summary>
    /// 其他按钮
    /// </summary>
    public void OnBtnOther(bool value)
    {
        HideAllPanel();             //隐藏所有界面
        panelOther.SetActive(true);   //显示指定界面
    }

    /// <summary>
    /// 向左按钮
    /// </summary>
    public void OnBtnLeft()
    {
        //判断按钮位置
        switch (menuBtnLocation)
        {
            case MenuBtnLocation.MBL_EQUIPMENT:
                scrollBarBtn.value = 0f;
                //SetBtnRightActive(true);
                SetBtnLeftActive(false);            
                break;
            case MenuBtnLocation.MBL_PET:
                scrollBarBtn.value = 0.48f;
                SetBtnRightActive(true);
                break;
            default:
                scrollBarBtn.value = 0f;
                SetBtnRightActive(false);
                SetBtnLeftActive(true);
                break;
        }
    }

    /// <summary>
    /// 向右按钮
    /// </summary>
    public void OnBtnRight()
    {
        //判断按钮位置
        switch(menuBtnLocation)
        {
            case MenuBtnLocation.MBL_BAG:
                scrollBarBtn.value = 0.48f;
                SetBtnLeftActive(true);
                break;
            case MenuBtnLocation.MBL_EQUIPMENT:
                scrollBarBtn.value = 0.95f;
                SetBtnLeftActive(true);
                StartCoroutine(SetBtnActive(btnRight, false));
                //SetBtnRightActive(false);
                break;
            default:
                scrollBarBtn.value = 0f;
                SetBtnLeftActive(false);
                SetBtnRightActive(true);
                break;
        }
    }
    #endregion

    /// <summary>
    /// 重置ScrollViewBtn
    /// </summary>
    public void ResetScrollBarBtn()
    {
        menuBtnLocation = MenuBtnLocation.MBL_BAG;
        scrollBarBtn.value = 0f;
    }

    /// <summary>
    /// 隐藏所有panel
    /// </summary>
    public void HideAllPanel()
    {
        panelBag.SetActive(false);
        panelEquip.SetActive(false);
        panelPet.SetActive(false);
        panelSkill.SetActive(false);
        panelTitle.SetActive(false);
        panelSetting.SetActive(false);
        panelOther.SetActive(false);
    }

    /// <summary>
    /// 设置向左按钮Active
    /// </summary>
    public void SetBtnLeftActive(bool active)
    {
        btnLeft.transform.parent.gameObject.SetActive(active);
    }

    /// <summary>
    /// 设置向右按钮Active
    /// </summary>
    public void SetBtnRightActive(bool active)
    {
        btnRight.transform.parent.gameObject.SetActive(active);
    }

    IEnumerator SetBtnActive(Button button, bool active)
    {
        
        yield return 0;
        button.transform.parent.gameObject.SetActive(active);
    }
}
