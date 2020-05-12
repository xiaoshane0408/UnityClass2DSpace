using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region 下一關
    [Header("下一關卡的名稱")]
    public string NextSceneName;

    public void NextScene()
    {
        /*// 如果場景為 Menu
        if(NextSceneName == "Menu")
        {
            // Destroy 刪除物件
            Destroy(GameObject.Find("BGM").gameObject);
        }*/
        if(NextSceneName == "Movie")
        {
            // GameObject.Find("BGM").SetActive(false); -> 關掉後會找不到BGM這物件
            // GameObject.Find("物件名稱").GetComponent<元件名稱>().enabled -> 判斷物件身上的元件是否要開啟
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
        }
        if(NextSceneName == "Game")
        {
            // GameObject.Find("BGM").SetActive(true); -> 物件被關閉，程式會錯誤
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = true;
        }
        Application.LoadLevel(NextSceneName);
    }
    #endregion
}
