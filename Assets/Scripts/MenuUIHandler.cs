using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField nameInput;
    private string playerName;

    void Start()
    {
        DataPersistenceManager.Instance.LoadHighScore();
        string bestPlayer = DataPersistenceManager.Instance.bestPlayer;
        int bestScore = DataPersistenceManager.Instance.highScore;
        if (bestScore != 0)
        {
            bestScoreText.text = $"High Score: {bestPlayer}: {bestScore}";
        }
        else
        {
            bestScoreText.text = "";
        }
    }

    public void SaveName()
    {
        playerName = nameInput.text;
    }


    public void StartNew()
    {
        DataPersistenceManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }


}
