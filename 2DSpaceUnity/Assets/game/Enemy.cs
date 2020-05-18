using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("敵機移動速度")]
    public float Speed = 0.01f;
    public float DeleteTime = 12;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 敵機往下位移
        transform.Translate(Vector3.down * Speed);
    }
}
