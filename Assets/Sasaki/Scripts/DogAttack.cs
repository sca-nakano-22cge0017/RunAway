using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    private Dogscript dog;
    //ファンのオブジェクト名
    private GameObject fanA;

    bool boxCheck;
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog").GetComponent<Dogscript>();

        //ヒエラルキーのfanのオブジェクト名
        fanA = GameObject.Find("fanA");

        boxCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dog.TriggerCheck() && boxCheck)
        {
            //ファンを消す
            Destroy(fanA.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxCheck = true;
        }
    }
}
