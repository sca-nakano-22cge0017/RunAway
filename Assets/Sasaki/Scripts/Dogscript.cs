using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogscript : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private GameObject text;
    private Animator anim = null;
    bool isDog;
    int n;

    void Start()
    {
        isDog = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isDog);

        //Œ¢‚ÉG‚Á‚½‚ç
        if (isDog)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                anim.SetBool("run", true);
                text.SetActive(false);
                n++;
            }
        }
        if (n >= 1)
        {
            text.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);

            isDog = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            isDog = false;
        }
        if (!isDog)
        {
            Destroy(this.gameObject,10);
        }
    }
}
