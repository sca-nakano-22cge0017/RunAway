using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int n;
    [SerializeField]
    private float range;

    void Start()
    {
        for (int i = 0; i < n; i++)
        {
            Instantiate(prefab, new Vector3(i * range, -3, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
