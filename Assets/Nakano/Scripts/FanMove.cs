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
        //transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime * 0.3f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(speed * Time.deltaTime * 1.5f, 0, 0);
        }
        else { transform.position -= new Vector3(speed * Time.deltaTime, 0, 0); }

        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Attack")
        {
            gameObject.SetActive(false);
        }
    }
}
