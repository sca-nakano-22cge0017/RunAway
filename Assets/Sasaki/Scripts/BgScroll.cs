using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = -4f; //�w�i���X�N���[�������鑬��
    [SerializeField]
    private float deadLine; //�w�i�ړ��̏I���ʒu

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
        //x���W��scrollSpeed��������
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);

        //deadLine���傫���Ȃ�����
        if (transform.position.x < deadLine)
        {
            //�~�߂�
            scrollSpeed = 0;
        }
    }
}
