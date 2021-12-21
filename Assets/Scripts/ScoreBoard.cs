using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI highScoreListCol1;
    public TextMeshProUGUI highScoreListCol2;
    public TextMeshProUGUI highScoreListCol3;

    void Start()
    {
        highScoreListCol1.text = "";
        highScoreListCol2.text = "";
        highScoreListCol3.text = "";
        for (int i=0; i< GameManager.Instance.PlayerNames.Length; i++)
        {
            if (GameManager.Instance.Scores[i] != 0)
            {
                highScoreListCol1.text += $"{i + 1}.\n";
                highScoreListCol2.text += $"{GameManager.Instance.PlayerNames[i]}\n";
                highScoreListCol3.text += $"{GameManager.Instance.Scores[i]}\n";
            }
            
        }
    }


}
