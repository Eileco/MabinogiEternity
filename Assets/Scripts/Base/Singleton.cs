using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    // 定义一个静态变量来保存类的实例
    protected static T _instance = null;

    /// <summary>
    /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
    /// </summary>
    /// <returns></returns>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //寻找不销毁的组件
                GameObject go = GameObject.Find("Singleton");
                if (go == null)
                {
                    //创建一个新的不可销毁的组件
                    go = new GameObject("Singleton");

                    DontDestroyOnLoad(go);
                }
                _instance = go.GetComponent<T>();
                if (_instance == null)
                {
                    _instance = go.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}
