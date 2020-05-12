using UnityEngine;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public VideoPlayer Movie_;
    float Timer;

    private void Start()
    {
        // 依照時間呼叫 function
        // InvokeRepeating(function名稱,遊戲一開始要等待幾秒才進行第一次呼叫,第二次呼叫...需要等幾秒做呼叫);
        InvokeRepeating("CheckMovie",3f,0.1f);  // 抓系統秒數值，非FPS
    }

    private void Update()
    {
        //Timer += Time.deltaTime;
        //if(Timer > 3f)
        //{
        //    // Movie_.isPlaying = true 影片還沒播放結束
        //    // Movie_.isPlaying = false 影片播放結束
        //    if (Movie_.isPlaying == false)
        //    {
        //        Application.LoadLevel("Game");
        //    }   
        //}
    }

    public void CheckMovie()
    {
        if (Movie_.isPlaying == false)
        {
            Application.LoadLevel("Game");
        }
    }
}
