using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitStaging : MonoBehaviour
{
    private GameObject ExitButton;
    ExitButtonController exitButtonController;

    [SerializeField] private GameObject Line;
    [SerializeField] private Image Circle1;
    [SerializeField] private Image Circle2;

    Vector2 stagingScale = new Vector2(0.1f, 0.1f);
    [SerializeField] private float _growingSpeed;

    [SerializeField] private float _rotateSpeed;

    void Start()
    {
        Line.SetActive(false);
        stagingScale = new Vector2(0.1f, 0.1f);

        Circle1.fillAmount = 0;
        Circle2.fillAmount = 0;
    }

    void Update()
    {
        ExitButton = GameObject.Find("Exit");
        exitButtonController = ExitButton.GetComponent<ExitButtonController>();

        if (exitButtonController.startStaging == false)
        {
            Line.SetActive(true);

            stagingScale.x += _growingSpeed * Time.deltaTime;
            Line.transform.localScale = stagingScale;
        }

        if (stagingScale.x >= 40.0f)
        {
            Circle1.fillAmount += _rotateSpeed * Time.deltaTime;
            Circle2.fillAmount += _rotateSpeed * Time.deltaTime;
        }
    }
}
