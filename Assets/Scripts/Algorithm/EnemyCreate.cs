using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* //////////////////
/*    算法-怪物生成类
 *    怪物的生成算法
/* ////////////////*/

public class EnemyCreate : Singleton<EnemyCreate>
{
    /// <summary>
    /// 随机一个怪物
    /// </summary>
    public Enemy CreateEnemy()
    {
        Enemy enemy = new Enemy();


        return enemy;
    }



}
