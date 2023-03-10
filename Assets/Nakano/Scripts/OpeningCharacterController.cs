using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCharacterController : MonoBehaviour
{
    //主人公A
    [SerializeField] private GameObject BackGroundA; //背景
    [SerializeField] private GameObject CharacterA;
    [SerializeField] private GameObject SerifA; //セリフ

    //主人公B
    [SerializeField] private GameObject BackGroundB; //背景
    [SerializeField] private GameObject CharacterB;
    [SerializeField] private GameObject SerifB; //セリフ

    int selectCharacter = SelectSceneManager.selectCharacter;

    void First() //初期設定
    {
        //主人公A
        BackGroundA.SetActive(false);
        CharacterA.SetActive(false);
        SerifA.SetActive(false);

        //主人公B
        BackGroundB.SetActive(false);
        CharacterB.SetActive(false);
        SerifB.SetActive(false);
    }

    void SelectA()
    {
        BackGroundA.SetActive(true);
        CharacterA.SetActive(true);
        SerifA.SetActive(true);
    }

    void SelectB()
    {
        BackGroundB.SetActive(true);
        CharacterB.SetActive(true);
        SerifB.SetActive(true);
    }

    void Start()
    {
        selectCharacter = SelectSceneManager.selectCharacter;
    }

    void Update()
    {
        switch(selectCharacter)
        {
            case 1:
                SelectA();
            break;
            case 2:
                SelectB();
            break;
        }
    }
}
