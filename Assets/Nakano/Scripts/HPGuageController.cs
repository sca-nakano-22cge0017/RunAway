using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGuageController : MonoBehaviour
{
    [SerializeField] private Slider GreenSlider;
    [SerializeField] private Slider RedSlider;
    [SerializeField] private GameObject FlameA;
    [SerializeField] private GameObject FlameB;
    int playerHP = 100;
    bool isInput;
    [SerializeField] private float minusSpeed = 0.05f;
    int selectCharacter = SelectSceneManager.selectCharacter;

    void Start()
    {
        GreenSlider.value = 100;
        RedSlider.value = 100;
        selectCharacter = SelectSceneManager.selectCharacter;
        FlameA.SetActive(true);
        FlameB.SetActive(false);
    }

    
    void Update()
    {
        if(selectCharacter == null)
        {
            selectCharacter = 1;
        }

        switch(selectCharacter)
        {
            case 1:
                FlameA.SetActive(true);
                FlameB.SetActive(false);
            break;
            case 2:
                FlameA.SetActive(false);
                FlameB.SetActive(true);
            break;
        }
        var valueTo = (playerHP - 10);
        if (Input.GetKeyDown(KeyCode.Return)) //ファンが当たったら　のif文に変更
        {
            isInput = true;
        }
        if(isInput)
        {
            GreenSlider.value = valueTo;
            if(RedSlider.value >= valueTo)
            {
                RedSlider.value -= minusSpeed;
            }
            if(RedSlider.value <= valueTo)
            {
                isInput = false;
                playerHP -= 10;
            }
        }
    }
}
