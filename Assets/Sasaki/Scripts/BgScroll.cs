using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = -4f; //”wŒi‚ğƒXƒNƒ[ƒ‹‚³‚¹‚é‘¬‚³
    [SerializeField]
    private float deadLine; //”wŒiˆÚ“®‚ÌI—¹ˆÊ’u

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
        //xÀ•W‚ğscrollSpeed•ª“®‚©‚·
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);

        //deadLine‚æ‚è‘å‚«‚­‚È‚Á‚½‚ç
        if (transform.position.x < deadLine)
        {
            //~‚ß‚é
            scrollSpeed = 0;
        }
    }
}
