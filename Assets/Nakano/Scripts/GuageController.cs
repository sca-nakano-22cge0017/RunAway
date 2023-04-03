using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuageController : MonoBehaviour
{
    [SerializeField] Slider sliderGreen;
    [SerializeField] Slider sliderRed;

    bool isChangeGreen;
    bool isChangeRed;

    void Start()
    {
        sliderGreen.value = 100;
        sliderRed.value = 100;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isChangeGreen = true;
        }

        if(isChangeGreen)
        {
            for(int i = 0; i <= 1; i++)
            {
                sliderGreen.value -= 5;
            }
            for (int j = 0; j <= 100; j++)
            {
                sliderRed.value -= 0.1f;
            }
            isChangeGreen = false;
        }

        if(isChangeRed)
        {
            isChangeRed = false;
        }
    }
}
