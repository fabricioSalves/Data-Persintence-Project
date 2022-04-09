using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{

    public InputField iField;
    public Text bestScore;

    private void Start()
    {
        ControlGame.instance.LoadGame();
        bestScore.text = "BEST SCORE: " + ControlGame.instance.namePlayerBestScore + ": " + ControlGame.instance.bestScore;
    }

    public void StartGame()
    {
        if (iField.text != "")
        {
            ControlGame.instance.namePlayer = iField.text;
            SceneManager.LoadScene(1);
        }
    }


    public void QuitGame()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }

        else
        {
            Application.Quit();
        }
    }

}
