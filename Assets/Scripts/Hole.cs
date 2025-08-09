using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // どのボールを吸い寄せるかをタグで指定
    public string targetTag;
    bool isHolding;

    // ボールが入っているか返す
    public bool IsHolding()
    {
        return isHolding;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }

    // 同じ色のHoleに接している間
    void OnTriggerStay(Collider other)
    {
        // コライダーに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        // Holeとタグが同じ色ならば
        if (other.gameObject.tag == targetTag)
        {
            // 減速しながら引き寄せる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            // 加速して弾く
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
}
