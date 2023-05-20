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
    // Start is called before the first frame update
    void Start()
    {
        isDog = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDog)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                anim.SetBool("run", true);
                text.SetActive(false);
                n++;
                Debug.Log(n);
            }
        }
        if(n >= 1)
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
        }
    }
}
