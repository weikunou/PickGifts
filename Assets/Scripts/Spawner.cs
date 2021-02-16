using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 礼物生成器类
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// 礼物数组
    /// </summary>
    public GameObject[] gifts;

    /// <summary>
    /// 礼物对象池
    /// </summary>
    public static Queue<GameObject> giftPool = new Queue<GameObject>();

    /// <summary>
    /// 礼物对象池容量
    /// </summary>
    public int poolNum = 20;

    /// <summary>
    /// 礼物父对象
    /// </summary>
    public Transform giftParent;

    void Start()
    {
        // 每隔 0.5 秒随机生成一个礼物
        //InvokeRepeating("GenerateGift", 0, 0.5f);

        
    }

    
    void Update()
    {

    }

    /// <summary>
    /// 开始生成
    /// </summary>
    public void StartSpawn()
    {
        // 生成礼物对象池
        GenerateGiftToPool();

        // 每隔 0.5 秒发射一个礼物
        InvokeRepeating("LaunchItem", 0, 0.5f);
    }

    /// <summary>
    /// 生成礼物
    /// </summary>
    void GenerateGift()
    {
        // 随机礼物
        int g = Random.Range(0, 6);
        GameObject prefab = gifts[g];

        // 随机坐标
        float y = Random.Range(-3, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + y);

        // 生成礼物
        Instantiate(prefab, pos, Quaternion.identity);
    }

    /// <summary>
    /// 生成礼物对象池
    /// </summary>
    void GenerateGiftToPool()
    {
        giftPool.Clear();

        for (int i = 0; i < poolNum; i++)
        {
            giftPool.Enqueue(GeneratePoolItem());
        }
    }

    /// <summary>
    /// 生成对象池里的礼物对象
    /// </summary>
    /// <returns>礼物对象</returns>
    GameObject GeneratePoolItem()
    {
        // 随机礼物
        int g = Random.Range(0, 6);
        GameObject prefab = gifts[g];

        // 随机坐标
        float y = Random.Range(-3, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + y);

        // 生成礼物
        GameObject item = Instantiate(prefab, pos, Quaternion.identity);
        item.SetActive(false);
        item.transform.SetParent(giftParent);
        item.GetComponent<SpriteRenderer>().sortingOrder = item.transform.GetSiblingIndex();

        // 返回礼物对象
        return item;
    }

    /// <summary>
    /// 发射礼物对象
    /// </summary>
    public void LaunchItem()
    {
        // 对象池内有库存
        if (giftPool.Count > 0)
        {
            // 出队
            GameObject obj = giftPool.Dequeue();

            // 启动礼物对象
            obj.SetActive(true);
        }
    }

    /// <summary>
    /// 回收礼物对象
    /// </summary>
    /// <param name="gameObject">礼物对象</param>
    public static void RecoverItem(GameObject gameObject)
    {
        // 限制对象池容量
        if (giftPool.Count >= 20)
        {
            return;
        }

        // 入队
        giftPool.Enqueue(gameObject);

        // 礼物对象重置状态和位置
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector2(10, gameObject.transform.position.y);
    }
}