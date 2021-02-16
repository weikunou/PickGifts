using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小孩类
/// </summary>
public class Child : MonoBehaviour
{
    /// <summary>
    /// 小孩子们
    /// </summary>
    public Sprite[] children;

    /// <summary>
    /// 小孩索引
    /// </summary>
    public static int childIndex = 0;

    /// <summary>
    /// 思考框
    /// </summary>
    public Sprite[] thinkings;

    /// <summary>
    /// 左侧思考框
    /// </summary>
    public GameObject thinkingLeft;

    /// <summary>
    /// 右侧思考框
    /// </summary>
    public GameObject thinkingRight;

    /// <summary>
    /// 动画
    /// </summary>
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        
    }

    
    void Update()
    {

    }

    /// <summary>
    /// 开始播放角色动画
    /// </summary>
    public void StartPlay()
    {
        InvokeRepeating("PlayChangeAnimation", 0, 5f);
    }

    /// <summary>
    /// 切换小孩
    /// </summary>
    /// <param name="index">索引</param>
    void ChangeChild(int index)
    {
        // 切换小孩形象
        transform.GetComponent<SpriteRenderer>().sprite = children[index];
        childIndex = index;

        // 切换思考框内容
        thinkingLeft.GetComponent<SpriteRenderer>().sprite = thinkings[index];
        thinkingRight.GetComponent<SpriteRenderer>().sprite = thinkings[index + 2];
    }

    /// <summary>
    /// 动画事件
    /// </summary>
    void ChangeEvent()
    {
        int r = Random.Range(0, 2);
        ChangeChild(r);
    }

    /// <summary>
    /// 重新播放切换角色的动画
    /// </summary>
    void PlayChangeAnimation()
    {
        anim.Play("ChangeChild", 0, 0f);
    }
}
