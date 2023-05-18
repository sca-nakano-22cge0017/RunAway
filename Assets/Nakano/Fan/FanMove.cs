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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Attack")
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
            //“|‚ê‚éƒ‚[ƒVƒ‡ƒ“‚É•ÏX
        }
    }
}
