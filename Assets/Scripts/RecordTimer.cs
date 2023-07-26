using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordTimer : MonoBehaviour
{
    public float timeStart;
    public Text timerText;
    public int sec;
    public int min = 0;
    public int result;

    public void Update()
    {
        TimerActive();
    }

    public void TimerActive()
    {
        timeStart += Time.deltaTime / 60 * 100;

        sec = Mathf.RoundToInt(timeStart);

        if(sec == 60)
        {
            min++;
            sec = 0;
            timeStart = 0;
        }

        if(sec < 10 && min < 10)
        {
            timerText.text = "0" + min.ToString() + ":0" + sec.ToString();
        }
        else if(sec < 10 && min >= 10)
        {
            timerText.text = min.ToString() + ":0" + sec.ToString();
        }
        else if(min < 10)
        {
            timerText.text = "0" + min.ToString() + ":" + sec.ToString();
        }
        else
        {
            timerText.text = min.ToString() + ":" + sec.ToString();
        }
        result = min*100 + sec;
        PlayerPrefs.SetInt("NewTimeInt", result);
    }
}
