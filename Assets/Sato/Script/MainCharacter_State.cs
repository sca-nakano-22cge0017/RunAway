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
    bool isMove, isHit, isCarMove, isRide, isClear;
    Vector3 carScale, carScaleRe;

    Animator anim = null;
    bool isDamage, isDown, isSkill, isCap, isJump;
    Rigidbody2D rbody2D;
    [SerializeField] private float jumpForce;

    void Start() 
    {
        //UpdateManager.Instance.Bind(this, FrameControl.ON)

        for (int i = 0; i < publicPhone.Length; i++)
        {
            publicPhone[i].SetActive(false);
        }
        vec2 = new Vector2(speed,0);
        scale = new Vector3(100,100,100);
        scaleRe = new Vector3(-100, 100, 100);
        jump = new Vector3(0,2f,0);

        coinCount = 0;

        clearText.SetActive(false);
        Car.SetActive(false);
        isMove = false;
        isHit = false;
        isCarMove = false;
        isRide = false;
        isClear = false;
        isCap = false;

        carScale = new Vector3(2,2,1);
        carScaleRe = new Vector3(-2,2,1);
        Car.transform.localScale = carScale;

        anim = GetComponent<Animator>();
        rbody2D = GetComponent<Rigidbody2D>();
        isDamage = false;
        isDown = false;
        isSkill = true;
        isJump = false;

        anim.SetBool("down",false);
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
            if (Input.GetKey(KeyCode.A) && !isJump)
            {
                isMove = true;
                rectTransform.anchoredPosition += vec2;
                mainChara.transform.localScale = scaleRe;
            }

            else if (Input.GetKey(KeyCode.D) && !isJump)
            {
                isMove = true;
                rectTransform.anchoredPosition -= vec2;
                mainChara.transform.localScale = scale;
            }
            else
            {
                isMove = false;
            }

        if(isMove)
            {
                if(!isCap)
                {
                    anim.SetBool("runCap", false);
                    anim.SetBool("run", true);
                }
                else
                {
                    anim.SetBool("run", false);
                    anim.SetBool("runCap", true);
                }
            }
        else { anim.SetBool("run", false); anim.SetBool("runCap",false); }

        if(isSkill)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Debug.Log("スキル使用");
                    anim.SetBool("run", false);
                    anim.SetBool("skill", true);
                }
                else { anim.SetBool("skill", false);}
            }

        if(isCap)
            {
                anim.SetBool("cap",true);
                SpriteRenderer main = mainChara.GetComponent<SpriteRenderer>();
                main.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
                StartCoroutine(CapTime());
            }
        else
        {
            SpriteRenderer main = mainChara.GetComponent<SpriteRenderer>();
            main.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            anim.SetBool("cap",false);
        }

        if(Input.GetKeyDown(KeyCode.T)) //debug
            {
                isCap = true;
            }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            boxCollider[0].enabled = true;
            boxCollider[1].enabled = true;
            //rigidbody.AddForce(Vector2.up * 500f);
            if(!isCap)
                {
                    anim.SetBool("run", false);
                    anim.SetBool("jump", true);
                }
                else
                {
                    anim.SetBool("runCap", false);
                    anim.SetBool("jumpCap", true);
                }
            rbody2D.AddForce(transform.up * jumpForce);
        }
        else { anim.SetBool("jump", false); isJump = false;}
        }
        else
        {
            Destroy(fanManager);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                isCarMove = true;
            }
        }

        if(isDown)
        {
            anim.SetBool("down", true);
            //ゲームオーバーシーンへ遷移
        }

        Transform carPos = Car.transform;
        Vector3 pos = carPos.position;

        if (isCarMove)
        {
            Car.SetActive(true); //車を表示

            clearText.SetActive(false); //『「Z」を押す』を非表示に

            if (!isRide)
            {
                if (pos.x >= 0)
                {
                    pos.x -= 10 * Time.deltaTime;
                    carPos.position = pos;
                }
                else
                {
                    SpriteRenderer main = mainChara.GetComponent<SpriteRenderer>();
                    main.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    isRide = true;
                }
            }
        }

        if (isRide) //主人公が車に乗ったら
        {
            Car.transform.localScale = carScaleRe; //画像反転

            if (pos.x <= 15)
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

    IEnumerator CapTime()
    {
        yield return new WaitForSeconds(3);
        isCap = false;
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
            if(!isClear && !isCap)
            {
                hPGuageController.HpGuage();
                isDamage = true;
                if (isDamage)
                {
                    anim.SetBool("run", false);
                    anim.SetTrigger("damage");
                    isDamage = false;
                }
                
            }
        }
        else
        {
            collision.gameObject.SetActive(false);
            coinCount++;

            if(coinCount >= 10)
            {
                coinCount = 10;
            }

            coinCount_Text.text = StringComponent.AddString("あと", (10 - coinCount).ToString(), "枚");

            if (coinCount == 10)
            {
                for (int i = 0; i < publicPhone.Length; i++)
                {
                    publicPhone[i].SetActive(true);
                }
                isClear = true;
            }

            /*if(collision.CompareTag("Cap"))
            {
                isCap = true;
            }*/

            if (collision.CompareTag("PublicPhone"))
            {
                isHit = true;
                anim.SetBool("run", false);
                clearText.SetActive(true);
                for (int i = 0; i < publicPhone.Length; i++)
                {
                    publicPhone[i].SetActive(true);
                }
            }
        }   
    }

    public void HpDecide()
    {
        isDown = true;
    }

    public void skillOk()
    {
        isSkill = true;
    }

    public void skillNg()
    {
        isSkill = false;
    }
}
    