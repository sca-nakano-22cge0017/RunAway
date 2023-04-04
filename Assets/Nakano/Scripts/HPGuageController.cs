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
    [SerializeField] private Text HPtext;
    int playerHP = 1000;
    int player_HP = 1000;
    bool isInput;
    [SerializeField] private float minusSpeed = 0.05f;
    int selectCharacter = SelectSceneManager.selectCharacter;

    void Start()
    {
        GreenSlider.value = 1000;
        RedSlider.value = 1000;
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

        HPtext.text = "" + player_HP;

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
        var valueTo = (playerHP - 100);
        if (Input.GetKeyDown(KeyCode.Return)) //ファンが当たったら　のif文に変更
        {
            isInput = true;
            player_HP -= 100;
        }
        if(isInput)
        {
            GreenSlider.value = valueTo;
            if (RedSlider.value >= valueTo)
            {
                RedSlider.value -= minusSpeed * Time.deltaTime;
            }
            if(RedSlider.value <= valueTo)
            {
                isInput = false;
                playerHP -= 100;
            }
        }
    }
}
