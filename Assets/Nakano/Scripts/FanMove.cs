using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanMove : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
    }

    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
