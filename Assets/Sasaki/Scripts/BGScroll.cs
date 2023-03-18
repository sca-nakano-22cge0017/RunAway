using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = -0.1f; //”wŒi‚ğƒXƒNƒ[ƒ‹‚³‚¹‚é‘¬‚³
    [SerializeField]
    private float startLine; //”wŒiˆÚ“®‚ÌŠJnˆÊ’u
    [SerializeField]
    private float deadLine; //”wŒiˆÚ“®‚ÌI—¹ˆÊ’u
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
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0); //xÀ•W‚ğscrollSpeed•ª“®‚©‚·

        if (transform.position.x < deadLine) //deadLine‚æ‚è‘å‚«‚­‚È‚Á‚½‚ç
        {
            scrollSpeed = 0; //~‚ß‚é
        }
    }
}
