using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private CanvasGroup fader;
    private float loadTime;
    private float MinimumFadeTime = 3.0f;

    private void Start()
    {
        fader = FindObjectOfType<CanvasGroup>();

        fader.alpha = 1;

        if (Time.time < MinimumFadeTime)
            loadTime = MinimumFadeTime;
        else
            loadTime = Time.time;
    }
    private void Update()
    {
        if(Time.time < MinimumFadeTime)
        {
            fader.alpha = 1 - Time.time;
        }

        if(Time.time > MinimumFadeTime && loadTime != 0)
        {
            fader.alpha = Time.time - MinimumFadeTime;
            if(fader.alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
