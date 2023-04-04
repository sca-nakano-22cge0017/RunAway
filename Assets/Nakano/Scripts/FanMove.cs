using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float fanRange;
    [SerializeField] private Text textSample;
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        /*Vector3 player = GameObject.Find("Player").transform.position;
        Transform myTransform = this.transform;
        Vector3 myPos = myTransform.position;
        
        if (myPos.x - player.x <= fanRange / 100 && myPos.x - player.x >= 0)
        {
            Debug.Log(myPos.x - player.x);
            textSample.text = "èPÇ§";
        }
        else { textSample.text = "";}*/

        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            textSample.text = "èPÇ§";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textSample.text = "";
    }
}
