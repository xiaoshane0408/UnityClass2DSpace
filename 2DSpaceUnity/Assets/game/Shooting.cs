using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("設定幾秒產生一顆子彈")]
    public float CreateTime;
    [Header("子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成點")]
    public Transform CreateObject;
    [Header("射擊音效")]
    public AudioSource ShootingSound;

    // Start is called before the first frame update
    void Start()
    {
        ShootingSound = GameObject.Find("Shoot").GetComponent<AudioSource>();
        // InvokeRepeating(方法, 等待幾秒第一次呼叫, 之後每隔幾秒呼叫);
        InvokeRepeating("CreateBullet", CreateTime, CreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBullet()
    {
        // 動態生成 Instantiate(要生成的物件, 生成出來以後的位置, 生成出來以後的物件角度);
        Instantiate(Bullet, CreateObject.position, CreateObject.rotation);
        ShootingSound.Play();
    }
}
