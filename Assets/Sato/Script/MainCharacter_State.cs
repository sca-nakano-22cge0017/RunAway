using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacter_State : MonoBehaviour
{
    [SerializeField]
    Fade fade;

    [SerializeField]
    FadeImage fadeImage;

    [SerializeField]
    GameObject mainChara;

    [SerializeField]
    RectTransform rectTransform;

    [SerializeField]
    float speed;

    [SerializeField]
    Rigidbody2D rigidbody;

    [SerializeField]
    BoxCollider2D[] boxCollider;

    [SerializeField]
    Text coinCount_Text;

    [SerializeField]
    HPGuageController hPGuageController;

    [SerializeField]
    GameObject[] publicPhone;

    bool justOnce = true;
    Vector2 vec2;
    Vector3 scale, scaleRe,jump;

    int coinCount = 0;

    void Start() 
    {
        //UpdateManager.Instance.Bind(this, FrameControl.ON);

        for (int i = 0; i < publicPhone.Length; i++)
        {
            publicPhone[i].SetActive(false);
        }
        vec2 = new Vector2(speed,0);
        scale = new Vector3(1,1,1);
        scaleRe = new Vector3(-1, 1, 1);
        jump = new Vector3(0,2f,0);
    }

    void Update()
    {
        if (!this.gameObject.activeInHierarchy) return;


        if(rectTransform.anchoredPosition.x > 0f)
        {
            rectTransform.anchoredPosition = new Vector2(0f,0f);
        }
        if(rectTransform.anchoredPosition.x < -13000f && justOnce)
        {
            justOnce = false;

            fade.FadeIn(1f);

            StartCoroutine(StartPosReturn());
        }

        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("’Ê‚Á‚½");
            rectTransform.anchoredPosition += vec2;
            mainChara.transform.localScale = scaleRe;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("’Ê‚Á‚½");
            rectTransform.anchoredPosition -= vec2;
            mainChara.transform.localScale = scale;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            boxCollider[0].enabled = true;
            boxCollider[1].enabled = true;
            rigidbody.AddForce(Vector2.up * 500f);
        }
    }
    
    IEnumerator StartPosReturn()
    {
        yield return new WaitUntil( () => fadeImage.CutoutRange == 1f);

        rectTransform.anchoredPosition = new Vector2(0,0);

        justOnce = true;

        fade.FadeOut(1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Ground")
        {
            boxCollider[0].enabled = false;
            boxCollider[1].enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fun"))
        {
            hPGuageController.HpGuage();
        }
        else
        {
            collision.gameObject.SetActive(false);
            coinCount++;

            coinCount_Text.text = StringComponent.AddString("‚ ‚Æ", (10 - coinCount).ToString(), "–‡");

            if (coinCount == 10)
            {
                fade.FadeIn(1f);
                UnityEngine.SceneManagement.SceneManager.LoadScene("ClearScene");
                for (int i = 0; i < publicPhone.Length; i++)
                {
                    publicPhone[i].SetActive(true);
                }
            }
        }   
    }
}
    