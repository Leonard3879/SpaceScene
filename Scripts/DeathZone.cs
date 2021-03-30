using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
            SceneManager.LoadScene("LoseMenu");
            Cursor.lockState =  CursorLockMode.None;
        }
    }
}
