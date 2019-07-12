using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    //重力加速度
    const float Gravity = 9.81f;
    //重力の適用具合
    public float gravityScale = 1.0f;


    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3();


        //Unityエディターと実機で処理を分ける
        if (Application.isEditor)
        {
            //キーの入力を検知しベクトルを設定
            vector.x = Input.GetAxis("Horizontal"); //左右のコントローラー
            vector.z = Input.GetAxis("Vertical"); //上下のコントローラー

            //高さ方向の判定はzキーとする
            if (Input.GetKey("z"))
            {
                vector.y = 1.0f; //入力中は上に1
            }
            else
            {
                vector.y = -1.0f; //基本は下に1
            }
        }
        else
        {
            //加速度センサーが実機とUnityの空間で違うので合わせる
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            if (Input.touchCount > 0)　//この数字はタップされた指の本数に依存
            {
                // タッチ情報の取得
                Touch touch = Input.GetTouch(0);
                //touchのphaseにタップの状態が入る

                if (touch.phase == TouchPhase.Moved)  //押しぱなし
                {
                    vector.y = 1.0f;
                }
            }
            else
            {
                vector.y = -1.0f; //基本は下に1
            }
        }

        //シーンの重力を入力方向ベクトルの方向に合わせて変化させる
        //normarizedは正規化
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
