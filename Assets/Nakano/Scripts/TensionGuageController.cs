using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TensionGuageController : MonoBehaviour
{
    [SerializeField] private Image tensionGuage;
    private float playerTension = 100;
    [SerializeField] private float Speed;
    
    void Start()
    {
        
    }

    void Update()
    {
        tensionGuage.fillAmount = playerTension / 100.0f;
        if(Input.GetKeyDown(KeyCode.Return)) //スキルを使ったら　に変更
        {
            playerTension -= 30;
        }
        if(playerTension <= 100)
        {
            playerTension += Speed / 100.0f;
        }
        if(playerTension <= 0)
        {
            playerTension = 0;
        }
    }
}
