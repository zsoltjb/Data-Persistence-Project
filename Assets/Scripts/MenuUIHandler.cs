using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField userInput;
  
    public void StartGame()
    {
        GameManager.Instance.playerName = userInput.text;    
        SceneManager.LoadScene(1);
    }

    public void ScoreBoard()
    {
        SceneManager.LoadScene(2);
    }
      
    public void Exit()
    {
        GameManager.Instance.Exit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
