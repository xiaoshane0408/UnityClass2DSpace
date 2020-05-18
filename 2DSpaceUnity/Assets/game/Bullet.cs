﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [Header("子彈多久被消滅")]
    public float DeleteTime;
    [Header("爆炸特效")]
    public GameObject Effect;
    [Header("爆炸音效")]
    public AudioSource EffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        EffectAudio = GameObject.Find("Explosion").GetComponent<AudioSource>();
        // Destroy(要刪除的物件(型態只能是GameObject),多久以後物體自己毀滅)
        // gameObject 誰有此腳本就代表是誰
        Destroy(gameObject, DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3.up = (0,1,0)  Vector3.down = (0,-1,0)  Vector3.forward = (1,0,0)
        // 同transform.Translate(0,speed,0);
        transform.Translate(Vector3.up * speed);
    }

    // 穿透型觸碰方式 OnTriggerEnter,OnTriggerStay,OntriggerExit
    // 不穿透型碰撞   OnCollisionEnter,OnCollisionStay,OnCollisionExit
    // Enter 兩個物件一相撞，Function 內的程式只會執行一次
    // Stay  兩個物件一相撞，沒有分開，Function 內的程式會持續執行，直到兩個物件分離
    // Exit  兩個物件一相撞且分開，Function 內的程式只會執行一次
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 玩家的子彈打到有 Collider2D 物件，就檢測該物件的標籤是否為 Enemy
        if(other.GetComponent<Collider2D>().tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {
            // 爆炸特效
            // other.transform.position 兩個物件碰撞位置
            // other.transform.rotation 兩個物件碰撞的旋轉值
            Instantiate(Effect, other.transform.position, other.transform.rotation);
            // 爆炸音效
            EffectAudio.Play();
            // 敵機被消滅
            Destroy(other.gameObject);
            // 自己子彈物件被消滅
            Destroy(gameObject);
        }
    }
}
