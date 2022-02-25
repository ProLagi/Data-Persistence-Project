using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void NewAllScoreScene()
    {
        SceneManager.LoadScene(2);
    }

    public void NewExitScene()
    {
        Application.Quit();
    }

}
