using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = -0.1f; //背景をスクロールさせる速さ
    [SerializeField]
    private float startLine; //背景移動の開始位置
    [SerializeField]
    private float deadLine; //背景移動の終了位置
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    private void Scroll()
    {
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0); //x座標をscrollSpeed分動かす

        if (transform.position.x < deadLine) //deadLineより大きくなったら
        {
            scrollSpeed = 0; //止める
        }
    }
}
