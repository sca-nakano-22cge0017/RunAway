using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStaging : MonoBehaviour
{
    [SerializeField] private GameObject Circle;

    private GameObject ExitButton;
    ExitButtonController exitButtonController;

    Vector2 staging = new Vector2(0.1f, 0.1f);

    void Start()
    {
        Circle.SetActive(false);
        staging = new Vector2(0.1f, 0.1f);
    }

    void Update()
    {
        ExitButton = GameObject.Find("Exit");
        exitButtonController = ExitButton.GetComponent<ExitButtonController>();

        if (exitButtonController.startStaging == true)
        {
            Circle.SetActive(true);

            staging.x += 0.1f;
            Circle.transform.localScale = staging;
        }
    }
}
