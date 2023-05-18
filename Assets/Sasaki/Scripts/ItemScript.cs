using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject[] itemPrefab;
    int number;
    [SerializeField] private float distanceMin;
    [SerializeField] private float distanceMax;
    private float distance;
    private float time;
    [SerializeField] private float timeInterval;
    [SerializeField] private GameObject charaA;
    [SerializeField] private GameObject charaB;
    [SerializeField] private GameObject chara;
    float chara_x;
    int count;
    private int selectChara;

    //charaÇÃç¿ïWéÊìæ
    private void charas()
    {
        chara_x = chara.transform.position.x;
        switch (selectChara)
        {
            case 1:
                chara_x = charaA.transform.position.x;
                break;
            case 2:
                chara_x = charaB.transform.position.x;
                break;
            default:
                chara_x = charaA.transform.position.x;
                break;
        }
    }

    void Start()
    {
        selectChara = SelectSceneManager.selectCharacter;
        time = timeInterval;
    }

    void Update()
    {
        charas();

        time -= Time.deltaTime;
            if (time <= 0)
            {
                distance = Random.Range(distanceMin, distanceMax);
                number = Random.Range(0, itemPrefab.Length);
                Instantiate(itemPrefab[number], new Vector3(distance + chara_x, -2.3f, 0), transform.rotation);
                time = timeInterval;
            }
    }
}
