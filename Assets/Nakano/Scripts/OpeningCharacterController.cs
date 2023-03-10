using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCharacterController : MonoBehaviour
{
    //ĺlöA
    [SerializeField] private GameObject BackGroundA; //wi
    [SerializeField] private GameObject CharacterA;
    [SerializeField] private GameObject SerifA; //Zt

    //ĺlöB
    [SerializeField] private GameObject BackGroundB; //wi
    [SerializeField] private GameObject CharacterB;
    [SerializeField] private GameObject SerifB; //Zt

    int selectCharacter = SelectSceneManager.selectCharacter;

    void First() //úÝč
    {
        //ĺlöA
        BackGroundA.SetActive(false);
        CharacterA.SetActive(false);
        SerifA.SetActive(false);

        //ĺlöB
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
