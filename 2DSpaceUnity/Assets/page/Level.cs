using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    #region 下一關
    [Header("下一關卡的名稱")]
    public string NextSceneName;

    public int LevelID;
    public Text LevelText;
    [Header("設定每個關卡最高得分數")]
    public float SetHeightScore;
    // 儲存每個關卡最高得分數
    string SaveHeightScore = "SaveHeightScore";
    string SaveLevelID="SaveLevelID";

    // 記錄要開啟的關卡數量
    public static int OpenLevelID = 1;
    // 抓取所有 Level 頁面關卡按鈕
    public GameObject[] LevelButton;

    private void Start()
    {
        if (Application.loadedLevelName =="Level" && GetComponentInChildren<Text>() != null)
        {
            // 抓子物件
            LevelText = GetComponentInChildren<Text>();
            // 字串轉成數值
            LevelID = int.Parse(LevelText.text);
            // 自動抓取 tag 為 LevelButton 的按鈕放入陣列中
            //LevelButton = GameObject.FindGameObjectsWithTag("LevelButton");
            // 用 for 迴圈開啟按鈕
            for (int i = 0; i <= OpenLevelID - 1; i++)
            {
                LevelButton[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void NextScene()
    {
        /*// 如果場景為 Menu
        if(NextSceneName == "Menu")
        {
            // Destroy 刪除物件
            Destroy(GameObject.Find("BGM").gameObject);
        }*/

        if (NextSceneName == "Movie")
        {

            PlayerPrefs.SetFloat(SaveLevelID, LevelID);
            // 跳關卡到 Game 畫面前，先將每關最高得分數儲存
            PlayerPrefs.SetFloat(SaveHeightScore + SaveLevelID, SetHeightScore);
            //Debug.Log("LevelID:"+PlayerPrefs.GetFloat(SaveLevelID));

            //Debug.Log(PlayerPrefs.GetFloat(SaveHeightScore + SaveLevelID));
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
