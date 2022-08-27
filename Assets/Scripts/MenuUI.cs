using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField playerName;
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveData.instance.highScore != 0)
        {
            bestScoreText.text = "Best Score: " + SaveData.instance.playerName + ": " + SaveData.instance.highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveData.instance.SetCurrentPlayerName(playerName.text);

        }
    }

    public void StartNew()
    {
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
