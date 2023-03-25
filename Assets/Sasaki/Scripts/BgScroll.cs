using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = -4f; //�w�i���X�N���[�������鑬��
    [SerializeField]
    private float startLine; //�w�i�ړ��̊J�n�ʒu
    [SerializeField]
    private float deadLine; //�w�i�ړ��̏I���ʒu
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
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0); //x���W��scrollSpeed��������

        if (transform.position.x < deadLine) //deadLine���傫���Ȃ�����
        {
            scrollSpeed = 0; //�~�߂�
        }
    }
}
