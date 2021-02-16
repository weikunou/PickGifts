using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 管理器类
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static UIManager instance;

    /// <summary>
    /// 分数文本
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// 分数画布
    /// </summary>
    public GameObject scoreCanvas;

    void Awake()
    {
        if (instance == null)
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
    /// 更新分数
    /// </summary>
    public void UpdateScoreText()
    {
        scoreText.text = "分数：" + GameManager.score;
    }

    /// <summary>
    /// 显示增加分数的 UI
    /// </summary>
    /// <param name="pos">位置</param>
    public void ShowScoreIncreaseText(Vector3 pos)
    {
        Instantiate(scoreCanvas, pos, Quaternion.identity);
    }
}
