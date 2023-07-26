using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishSceneScript : MonoBehaviour
{
    public Text resultText;
    public Text BestTimeText;
    public GameObject InputNameField;
    public GameObject SaveResultButton;
    private int minResult;
    private int secResult;
    private int resultTime;
    private int bestTime = 0;
    private int minBest;
    private int secBest;
    private string bestName;
    private string resultName;

    public void Start()
    {
        InputNameField.SetActive(false);
        SaveResultButton.SetActive(false);
        TextConversion();
        CheckResult();
    }

    private void TextConversion()
    {
        resultTime = PlayerPrefs.GetInt("NewTimeInt");
        minResult = resultTime/100;
        secResult = resultTime - minResult*100;

        if(secResult < 10 && minResult < 10)
        {
            resultText.text = "Your result: " + "0" + minResult.ToString() + ":0" + secResult.ToString();
        }
        else if(secResult < 10 && minResult >= 10)
        {
            resultText.text = "Your result: " + minResult.ToString() + ":0" + secResult.ToString();
        }
        else if(minResult < 10)
        {
            resultText.text = "Your result: " + "0" + minResult.ToString() + ":" + secResult.ToString();
        }
        else
        {
            resultText.text = "Your result: " + minResult.ToString() + ":" + secResult.ToString();
        }
    }

    private void CheckResult()
    {
        if(PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetInt("BestTime");
            bestName = PlayerPrefs.GetString("BestName");
            minBest = bestTime/100;
            secBest = bestTime - minBest*100;

            if(secBest < 10 && minBest < 10)
            {
                BestTimeText.text = "Best time: " + bestName + " 0" + minBest.ToString() + ":0" + secBest.ToString();
            }
            else if(secBest < 10 && minBest >= 10)
            {
                BestTimeText.text = "Best time: " + bestName + " " + minBest.ToString() + ":0" + secBest.ToString();
            }
            else if(minBest < 10)
            {
                BestTimeText.text = "Best time: " + bestName + " 0" + minBest.ToString() + ":" + secBest.ToString();
            }
            else
            {
                BestTimeText.text = "Best time: " + bestName + " " + minBest.ToString() + ":" + secBest.ToString();
            }

            if(bestTime > resultTime)
            {
                InputNameField.SetActive(true);
                SaveResultButton.SetActive(true);
            }
        }
        else
        {
            InputNameField.SetActive(true);
            SaveResultButton.SetActive(true);
        }
    }

    public void SaveButtonEnter()
    {
        resultName = InputNameField.GetComponent<InputField>().text;
        PlayerPrefs.SetString("BestName", resultName);
        PlayerPrefs.SetInt("BestTime", resultTime);
    }

    public void MenuButtonEnter()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButtonEnter()
    {
        SceneManager.LoadScene(1);
    }
}
