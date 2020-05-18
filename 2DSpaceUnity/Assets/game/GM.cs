using UnityEngine;

public class GM : MonoBehaviour
{
    [Header("所有敵機物件")]
    public GameObject[] Enemy;
    [Header("設定每幾秒產出敵機")]
    public float CreateTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", CreateTime, CreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        // 生成位置 Random
        Vector3 position = new Vector3(Random.Range(-2.5f, 2.5f),transform.position.y,transform.position.z);
        // 動態生成
        Instantiate(Enemy[Random.Range(0, Enemy.Length)], position, transform.rotation);
    }
}
