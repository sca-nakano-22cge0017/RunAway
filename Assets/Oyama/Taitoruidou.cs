using UnityEngine;
using UnityEngine.SceneManagement;

{ 

    IEnumerator main()
    {
        yield return WaitForSeconds(5.0f);
        SceneManager.LoadScene("TitleScene");
    }
    void Start()
    {
        yield return new WaitForSeconds(5.0f);
    }

    void Update()
    {
        if (step_time >= 3.0f)
        {
            SceneManager.LoadScene("scene2");
        }
    }