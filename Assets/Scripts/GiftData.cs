using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 礼物数据类
/// </summary>
public static class GiftData
{
    /// <summary>
    /// 小飞机的分数字典
    /// </summary>
    public static Dictionary<int, int> plane = new Dictionary<int, int>()
    {
        { 0, -5 }, // 小女孩 -5 分
        { 1, 5 } // 小男孩 +5 分
    };

    /// <summary>
    /// 小卡车的分数字典
    /// </summary>
    public static Dictionary<int, int> lorry = new Dictionary<int, int>()
    {
        { 0, -10 }, // 小女孩 -10 分
        { 1, 10 } // 小男孩 +10 分
    };

    /// <summary>
    /// 小黄鸭的分数字典
    /// </summary>
    public static Dictionary<int, int> duck = new Dictionary<int, int>()
    {
        { 0, 5 }, // 小女孩 +5 分
        { 1, -5 } // 小男孩 -5 分
    };

    /// <summary>
    /// 小熊的分数字典
    /// </summary>
    public static Dictionary<int, int> bear = new Dictionary<int, int>()
    {
        { 0, 10 }, // 小女孩 +10 分
        { 1, -10 } // 小男孩 -10 分
    };
}
