using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void RestartGame ()
    {
        SceneManager.LoadScene("SecondScene");
    }

    public void QuitGameAgain ()
    {
        Debug.Log("Quitted application!");
        Application.Quit();
    }
}
