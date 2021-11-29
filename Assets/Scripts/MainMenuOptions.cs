using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    delegate void MyDelegate();
    MyDelegate myDelegate;

    [SerializeField]
    int playSceneIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            myDelegate = PlayGame;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            myDelegate = ExitGame;
        }

        if (myDelegate != null)
        {
            myDelegate();
        }
    }

    void PlayGame()
    {
        SceneManager.LoadScene(playSceneIndex);
    }

    void ExitGame()
    {
        
        Application.Quit();
    }
}
