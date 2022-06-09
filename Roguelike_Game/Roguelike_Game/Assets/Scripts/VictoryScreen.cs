using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public float waitForAnykey = 2f;

    public GameObject anyKeyText;

    public string mainMenuScene;

    private void Update()
    {
        if(waitForAnykey > 0)
        {
            waitForAnykey -= Time.deltaTime;
            if (waitForAnykey <= 0)
            {
                anyKeyText.SetActive(true);
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(mainMenuScene);
            }
        }
    }
}
