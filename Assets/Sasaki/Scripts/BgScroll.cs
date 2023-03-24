using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = -4f; //背景をスクロールさせる速さ
    [SerializeField]
    private float deadLine; //背景移動の終了位置

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
        //x座標をscrollSpeed分動かす
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);

        //deadLineより大きくなったら
        if (transform.position.x < deadLine)
        {
            //止める
            scrollSpeed = 0;
        }
    }
}
