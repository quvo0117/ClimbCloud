using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float jumpForce = 680.0f;  // puclic にすると inspector で指定できる
    public float walkForce = 30.0f;
    public float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();  // 毎回参照する必要がないため、 Start 時に一度取得して、Update 時に必要に応じて使用する
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプする
        if(Input.GetKeyDown(KeyCode.Space)) {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 左右移動
        int key = 0;

        if(Input.GetKey(KeyCode.RightArrow)) {
            key = 1;
        }

        if(Input.GetKey(KeyCode.LeftArrow)) {
            key = -1;
        }


        // プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if(speedx < this.maxWalkSpeed) {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 動く方向に応じて反転
        if(key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        }
    }
}
