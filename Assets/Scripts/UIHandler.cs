using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;

    private void Start()
    {
        DisplayHighScore();
    }
    void DisplayHighScore()
    {
        HighScoreText.text = $"High Score - {PersistenceManager.Instance.highScoreName}: {PersistenceManager.Instance.highScore}";
    }
    public void StartGame()
    {
        PersistenceManager.Instance.GetName();
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
