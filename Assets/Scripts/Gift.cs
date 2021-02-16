using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 礼物类型
/// </summary>
public enum GiftType { EmptyBox, CoverBox, Plane, Lorry, Duck, Bear}

/// <summary>
/// 礼物类
/// </summary>
public class Gift : MonoBehaviour
{
    /// <summary>
    /// 礼物移动速度
    /// </summary>
    public float speed;

    /// <summary>
    /// 礼物类型
    /// </summary>
    public GiftType giftType;

    void Start()
    {
        // 初始速度随机
        speed = Random.Range(2, 5);
    }

    void Update()
    {
        // 向左移动
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < -10)
        {
            // 销毁礼物
            //Destroy(gameObject);

            // 回收礼物
            Spawner.RecoverItem(gameObject);
        }
    }

    /// <summary>
    /// 鼠标点击后触发
    /// </summary>
    void OnMouseDown()
    {
        int score = 0;

        switch(giftType)
        {
            case GiftType.EmptyBox:
                score = -1;
                break;
            case GiftType.CoverBox:
                int r = Random.Range(-5, 6);
                score = r;
                break;
            case GiftType.Plane:
                score = GiftData.plane[Child.childIndex];
                break;
            case GiftType.Lorry:
                score = GiftData.lorry[Child.childIndex];
                break;
            case GiftType.Duck:
                score = GiftData.duck[Child.childIndex];
                break;
            case GiftType.Bear:
                score = GiftData.bear[Child.childIndex];
                break;
            default:
                Debug.Log("nothing");
                break;
        }

        // 累加分数
        GameManager.score += score;

        // 更新 UI
        UIManager.instance.UpdateScoreText();

        // 改变增加分数的数值和颜色
        Text scoreIncreaseText = UIManager.instance.scoreCanvas.transform.GetChild(0).GetComponent<Text>();
        scoreIncreaseText.text = score > 0 ? "+" + score : "" + score;
        scoreIncreaseText.color = score > 0 ? new Color(0.5f, 1, 0.5f) : new Color(1, 0.3f, 0.3f);

        // 显示增加分数的 UI
        UIManager.instance.ShowScoreIncreaseText(transform.position);

        // 销毁礼物
        //Destroy(gameObject);

        // 回收礼物
        Spawner.RecoverItem(gameObject);
    }
}
