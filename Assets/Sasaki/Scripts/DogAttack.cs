using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    private Dogscript dog;
    //�t�@���̃I�u�W�F�N�g��
    private GameObject fanA;

    bool boxCheck;
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog").GetComponent<Dogscript>();

        //�q�G�����L�[��fan�̃I�u�W�F�N�g��
        fanA = GameObject.Find("fanA");

        boxCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dog.TriggerCheck() && boxCheck)
        {
            //�t�@��������
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
