using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Main");
            }

        }
        else
        {
            // タッチされているかチェック
            if (Input.touchCount > 0)　//この数字はタップされた指の本数に依存
            {
                // タッチ情報の取得
                Touch touch = Input.GetTouch(0);
                //touchのphaseにタップの状態が入る
             
                if (touch.phase == TouchPhase.Began)
                {
                    SceneManager.LoadScene("Main");
                }

            }
        }

    }
}
