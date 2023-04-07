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

    [SerializeField]
    GameObject clearText;

    [SerializeField]
    GameObject Car;

    [SerializeField]
    GameObject fanManager;

    bool justOnce = true;
    Vector2 vec2;
    Vector3 scale, scaleRe,jump;

    int coinCount = 0;
    bool isHit, isCarMove, isRide;
    Vector3 carScale, carScaleRe;

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

        coinCount = 0;

        clearText.SetActive(false);
        Car.SetActive(false);
        isHit = false;
        isCarMove = false;
        isRide = false;

        carScale = new Vector3(2,2,1);
        carScaleRe = new Vector3(-2,2,1);
        Car.transform.localScale = carScale;
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

        if (!isHit)
        {
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("�ʂ���");
            rectTransform.anchoredPosition += vec2;
            mainChara.transform.localScale = scaleRe;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("�ʂ���");
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
        else
        {
            Destroy(fanManager);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                isCarMove = true;
            }
        }

        Transform carPos = Car.transform;
        Vector3 pos = carPos.position;

        if (isCarMove)
        {
            Car.SetActive(true); //�Ԃ�\��
            clearText.SetActive(false); //�w�uZ�v�������x���\����

            if (!isRide)
            {
                if (pos.x >= 0)
                {
                    pos.x -= 10 * Time.deltaTime;
                    carPos.position = pos;
                }
                else
                {
                    mainChara.SetActive(false);
                    isRide = true;
                }
            }
        }

        if (isRide) //��l�����Ԃɏ������
        {
            Car.transform.localScale = carScaleRe; //�摜���]

            if (pos.x <= 1500)
            {
                pos.x += 10 * Time.deltaTime;
                carPos.position = pos;
            }
            else
            {
                fade.FadeIn(1f);
                UnityEngine.SceneManagement.SceneManager.LoadScene("ClearScene");
            }
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

            coinCount_Text.text = StringComponent.AddString("����", (10 - coinCount).ToString(), "��");

            if (coinCount == 10)
            {
                //fade.FadeIn(1f);
                //UnityEngine.SceneManagement.SceneManager.LoadScene("ClearScene");
                for (int i = 0; i < publicPhone.Length; i++)
                {
                    publicPhone[i].SetActive(true);
                }
            }

            if (collision.CompareTag("PublicPhone"))
            {
                isHit = true;
                clearText.SetActive(true);
            }
        }   
    }
}
    