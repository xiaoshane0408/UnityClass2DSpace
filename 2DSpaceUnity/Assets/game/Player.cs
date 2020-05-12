using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0f,0.1f)]    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetKeyUp/Down(按下且放開/按下) -> 只執行一次
        // Input.GetKey -> 持續執行
        /*if (Input.GetKey("a"))
        {
            transform.position = new Vector2(transform.position.x - 0.05f, transform.position.y);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector2(transform.position.x + 0.05f, transform.position.y);
        }*/

        // Input.GaetAxis("Horizontal") 沒有按按鍵的時候回傳值為0
        // Input.GaetAxis("Horizontal") 按"A"或左鍵的時候回傳值為-1
        // Input.GaetAxis("Horizontal") 按"D"或右鍵的時候回傳值為1
        // Input.GaetAxis("vertical") 沒有按按鍵的時候回傳值為0
        // Input.GaetAxis("vertical") 按"W"或上鍵的時候回傳值為1
        // Input.GaetAxis("vertical") 按"S"或下鍵的時候回傳值為-1

#if UNITY_STANDALONE
        transform.Translate(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"), 0);
#endif
#if UNITY_ANDROID
        // 手機陀螺儀
        transform.Translate(speed * Input.acceleration.x, speed * Input.acceleration.y, 0);
#endif
        /*if (transform.position.x >= 2.2)
        {
            transform.position = new Vector2(2.3f, transform.position.y);
        }
        if(transform.position.x <= -2.3)
        {
            transform.position = new Vector2(2.3f, transform.position.y);
        }*/
        // (Mathf.Clamp(限制的值, 最小值, 最大值)
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.2f, 2.2f),
                                         Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
}
