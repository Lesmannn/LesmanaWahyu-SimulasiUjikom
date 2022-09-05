using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public System.Action OnTimeOver;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    float initTime = 300f;

    private void Update()
    {
        if (initTime > 0)
        {
            initTime -= Time.deltaTime;
        }
        else
        {
            initTime = 0;
            OnTimeOver?.Invoke();
            Time.timeScale = 0;
        }
        ShowTimer(initTime);
    }

    private void ShowTimer(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        //float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time);

        timerText.text = seconds.ToString();
    }
}
