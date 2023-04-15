using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TensionGuageController : MonoBehaviour
{
    [SerializeField] private Image tensionGuage;
    private float playerTension = 100;
    [SerializeField] private float Speed;

    //[SerializeField]
    //GameObject character;

    //[SerializeField]
    //Image chara_AttackImage;

    [SerializeField]
    BoxCollider2D boxCollider2d;
    void Start()
    {
        boxCollider2d.enabled = false;
        //chara_AttackImage.enabled = false;
    }

    void Update()
    {
        tensionGuage.fillAmount = playerTension / 100.0f;
        if(Input.GetKeyDown(KeyCode.P)) //スキルを使ったら　に変更
        {
            playerTension -= 30;

            StartCoroutine(Attack());
        }
        if(playerTension <= 100)
        {
            playerTension += Speed / 60.0f;
        }
        if(playerTension <= 0)
        {
            playerTension = 0;
        }
    }

    IEnumerator Attack()
    {
        //character.SetActive(false);
        //chara_AttackImage.enabled = true;
        boxCollider2d.enabled = true;
        
        yield return new WaitForSeconds(0.3f);

        boxCollider2d.enabled = false;
        //chara_AttackImage.enabled = false;
        //character.SetActive(true);
    }
}
