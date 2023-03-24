using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    void Start()
    {
    }

    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //電話ボックスに当たったら
        if (other.gameObject.CompareTag("PhoneBox"))
        {
            //テキスト表示
            text.SetActive(true);
        }
    }
}
