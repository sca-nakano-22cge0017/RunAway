using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogscript : MonoBehaviour
{
    //[SerializeField]
    //private GameObject Text;
    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("a");
            if (Input.GetKey(KeyCode.Z))
            {
                anim.SetBool("run", true);
            }
        }
    }
}
