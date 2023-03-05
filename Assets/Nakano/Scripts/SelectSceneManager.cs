using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneManager : MonoBehaviour
{
    //��l��A
    [SerializeField] private GameObject FlameA1;
    [SerializeField] private GameObject FlameA2;
    [SerializeField] private GameObject CharacterA1;
    [SerializeField] private GameObject CharacterA2;
    [SerializeField] private GameObject ExplanationA;

    //��l��B
    [SerializeField] private GameObject FlameB1;
    [SerializeField] private GameObject FlameB2;
    [SerializeField] private GameObject CharacterB1;
    [SerializeField] private GameObject CharacterB2;
    [SerializeField] private GameObject ExplanationB;

    //�m�F�E�B���h�E
    [SerializeField] private GameObject ConfirmationWindow;

    int select = 0;


    void First() //�������
    {
        FlameA1.SetActive(true);
        FlameA2.SetActive(false);
        CharacterA1.SetActive(true);
        CharacterA2.SetActive(false);
        ExplanationA.SetActive(false);

        FlameB1.SetActive(true);
        FlameB2.SetActive(false);
        CharacterB1.SetActive(true);
        CharacterB2.SetActive(false);
        ExplanationB.SetActive(false);
    }
    
    void SelectA() //��l��A��I�������Ƃ�
    {
        FlameA1.SetActive(false);
        FlameA2.SetActive(true);
        CharacterA1.SetActive(false);
        CharacterA2.SetActive(true);
        ExplanationA.SetActive(true);

        FlameB1.SetActive(true);
        FlameB2.SetActive(false);
        CharacterB1.SetActive(true);
        CharacterB2.SetActive(false);
        ExplanationB.SetActive(false);
    }

    void SelectB() //��l��B��I�������Ƃ�
    {
        FlameA1.SetActive(true);
        FlameA2.SetActive(false);
        CharacterA1.SetActive(true);
        CharacterA2.SetActive(false);
        ExplanationA.SetActive(false);

        FlameB1.SetActive(false);
        FlameB2.SetActive(true);
        CharacterB1.SetActive(false);
        CharacterB2.SetActive(true);
        ExplanationB.SetActive(true);
    }

    void selectDecide() //�m�FWindow�\��
    {
        ConfirmationWindow.SetActive(true);
    }
    
    void Start()
    {
        select = 0;
    }

    void Update()
    {
        if (select > 2)
        {
            select = 1;
        }

        if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.A)))
        {
            select += 1;
        }


        switch(select)
        {
            case 0:
                First();
            break;
            case 1:
                SelectA();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    selectDecide();
                }
            break;
            case 2:
                SelectB();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    selectDecide();
                }
                break;
        }
    }
}
