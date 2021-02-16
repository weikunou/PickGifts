using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏管理器类
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// 分数
    /// </summary>
    public static int score;

    /// <summary>
    /// 礼物生成器
    /// </summary>
    public Spawner spawner;

    /// <summary>
    /// 小孩
    /// </summary>
    public Child child;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 开始游戏
    /// </summary>
    public void StartGame()
    {
        spawner.StartSpawn();
        child.StartPlay();
    }

    /// <summary>
    /// 重新开始游戏
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
