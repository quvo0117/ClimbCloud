using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float jumpForce = 680.0f;  // puclic にすると inspector で指定できる

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
    }
}
