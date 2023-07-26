using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Text bestTimeText;
    private int bestTime;
    private string bestName;
    private int sec;
    private int min;
    void Start()
    {
        if(PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetInt("BestTime");
            bestName = PlayerPrefs.GetString("BestName");
            min = bestTime/100;
            sec = bestTime - min*100;
            
            if(sec < 10 && min < 10)
            {
                bestTimeText.text = "Best time: " + bestName + " 0" + min.ToString() + ":0" + sec.ToString();
            }
            else if(sec < 10 && min >= 10)
            {
                bestTimeText.text = "Best time: " + bestName + " " + min.ToString() + ":0" + sec.ToString();
            }
            else if(min < 10)
            {
                bestTimeText.text = "Best time: " + bestName + " 0" + min.ToString() + ":" + sec.ToString();
            }
            else
            {
                bestTimeText.text = "Best time: " + bestName + " " + min.ToString() + ":" + sec.ToString();
            }
        }
    }

    public void StartButtonEnter()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButtonEnter()
    {
        Application.Quit();
    }
}
