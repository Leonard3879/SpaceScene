using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame ()
    {
        SceneManager.LoadScene("SecondScene");
    }

    public void QuitGame ()
    {
        Debug.Log("Quitted application!");
        Application.Quit();
    }
}
