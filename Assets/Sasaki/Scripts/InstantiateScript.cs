using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Prefab")]
    private GameObject[] prefab;

    private float time;

    private float x;
    private float y;

    public void RandomRange()
    {
        x = Random.Range(transform.position.x,x);

        y = Random.Range(-3.0f, 0.0f);
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 3.5f)
        {
            RandomRange();

            int item = Random.Range(0, prefab.Length);
            Instantiate(prefab[item], new Vector2(x, y), prefab[item].transform.rotation);

            time = 0.0f;
        }
    }
}
