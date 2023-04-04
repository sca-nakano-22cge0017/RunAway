using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 player = GameObject.Find("Player").transform.position;
        Transform myTransform = this.transform;
        Vector3 myPos = myTransform.position;
        
        if (myPos.x - player.x >= 1.5f)
        {
            Debug.Log("èPÇ§");
        }

        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
