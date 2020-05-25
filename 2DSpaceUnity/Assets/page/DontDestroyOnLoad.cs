using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // DontDestroyOnLoad 切換場景時不要把括號內的物件刪除
        // gameObject 代表物件自己
        DontDestroyOnLoad(gameObject);
    }
}
