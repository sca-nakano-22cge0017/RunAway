using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawnManager : MonoBehaviour
{
    public GameObject[] fanPrefab;
    int number;
    [SerializeField] private float distanceMin;
    [SerializeField] private float distanceMax;
    private float distance;
    private float time;
    [SerializeField] private float timeInterval;

    void Start()
    {
        time = timeInterval;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            distance = Random.Range(distanceMin, distanceMax);
            number = Random.Range(0, fanPrefab.Length);
            Instantiate(fanPrefab[number], new Vector3(distance, -2.3f, 0), transform.rotation);
            time = timeInterval;
        }
    }
}
