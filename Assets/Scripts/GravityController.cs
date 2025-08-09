using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // 重力加速度(定数)
    const float Gravity = 9.81f;

    // 重力の適用具合  ※publicをつけるとUnity上で変更可能になる
    // [serializeField]をつかうと、privateで変更可能
    public float gravityScale = 1.0f;

    void Update()
    {
        Vector3 vector = new Vector3();

        // キー入力を検知しベクトルを設定
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");

        // 高さ方向の判定はキーのｚとする
        if (Input.GetKey("z"))
        {
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }

        // シーンの重力を入力ベクトルの方向に合わせて変化させる
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
