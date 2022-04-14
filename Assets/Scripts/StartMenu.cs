using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class StartMenu : MonoBehaviour
{    
    public InputField playerName;
       
    public void StartGame()
    {
        Debug.Log("Player name is:" + playerName.text);
        MainManager.playerNameInGame = playerName.text;
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
