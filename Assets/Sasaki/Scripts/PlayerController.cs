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
        //�d�b�{�b�N�X�ɓ���������
        if (other.gameObject.CompareTag("PhoneBox"))
        {
            //�e�L�X�g�\��
            text.SetActive(true);
        }
    }
}
