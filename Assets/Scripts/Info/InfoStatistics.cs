using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    统计信息类
 *    存储当前所有统计
/* ////////////////*/

public class InfoStatistics : MonoBehaviour
{
    private long curGainGold;           // 当前地图获得金钱
    private long curGainExp;           // 当前地图获得经验
    private int curEquipOrdCnt;        // 当前地图获得普通装备
    private int curEquipGoodCnt;       // 当前地图获得优秀装备
    private int curEquipExceCnt;       // 当前地图获得精灵装备
    private int curEquipPerfCnt;       // 当前地图获得完美装备
    private int curEquipEpicCnt;       // 当前地图获得史诗装备
    private int curEquipLegCnt;        // 当前地图获得传说装备

    #region 字段封装
    public long CurGainGold {
        get{return curGainGold; }
        set { curGainGold = value;}
    }
    public long CurGainExp
    {
        get { return curGainExp; }
        set { curGainExp = value; }
    }
    public int CurEquipOrdCnt
    {
        get { return curEquipOrdCnt; }
        set { curEquipOrdCnt = value; }
    }
    public int CurEquipGoodCnt
    {
        get { return curEquipGoodCnt; }
        set { curEquipGoodCnt = value; }
    }
    public int CurEquipExceCnt
    {
        get { return curEquipExceCnt; }
        set { curEquipExceCnt = value; }
    }
    public int CurEquipPerfCnt
    {
        get { return curEquipPerfCnt; }
        set { curEquipPerfCnt = value; }
    }
    public int CurEquipEpicCnt
    {
        get { return curEquipEpicCnt; }
        set { curEquipEpicCnt = value; }
    }
    public int CurEquipLegCnt
    {
        get { return curEquipLegCnt; }
        set { curEquipLegCnt = value; }
    }
    #endregion

    //重置当前地图掉落统计
    public void ResetCurMapStatistics()
    {
        CurGainGold = 0;
        CurGainExp = 0;
        curEquipOrdCnt = 0;
        curEquipGoodCnt = 0;
        curEquipExceCnt = 0;
        curEquipPerfCnt = 0;
        curEquipEpicCnt = 0;
        curEquipLegCnt = 0;
    }
}
