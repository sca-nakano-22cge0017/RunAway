using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningTextManager : MonoBehaviour
{
    public string[] texts; //�e�L�X�g�̕\��
    int textNumber; //�\������e�L�X�g�̔ԍ�
    string displayText;
    int textCharNumber; //�\�����镶���̐�
    int displayTextSpeed;
    [SerializeField] int speed = 40; //��������X�s�[�h
    bool Return; //Enter�������ꂽ���ǂ�������
    bool textStop;
    bool x = true;

    private void Start()
    {
        
    }

    void Update()
    {
        displayTextSpeed++;
        if (displayTextSpeed % speed == 0)
        {
            /*if (textNumber == 4 && x == true)
            {
                displayText = displayText + "��������� \n �P. �}�E�X�Ŏ��_�ύX \n �Q. WASD�L�[�ňړ�";
                x = false;
            }*/

            if (textCharNumber != texts[textNumber].Length) //�\����������������̒����ƈقȂ�Ƃ�
            {
                displayText = displayText + texts[textNumber][textCharNumber]; //n�Ԗڂ�n�����ڂ�\��
                textCharNumber = textCharNumber + 1; //�\�����镶�������ꕶ�������₷
            }
            else
            {
                if (textNumber != texts.Length) //�Ō�̃e�L�X�g�łȂ��Ƃ�
                {
                    if (Return == true) //Enter�������ꂽ��
                    {
                        displayText = ""; //�e�L�X�g��������
                        textCharNumber = 0; //�\�����镶������������
                        textNumber = textNumber + 1; //�\�����镶��������̂��̂ɕύX
                    }
                }
            }
        }

        this.GetComponent<Text>().text = displayText;
        Return = false;

        if (Input.GetKey(KeyCode.Return))
        {
            Return = true;
        }

        /*if (textNumber >= texts.Length)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("");
            }
        }*/
    }
}