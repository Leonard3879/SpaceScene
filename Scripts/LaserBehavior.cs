using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBehavior : MonoBehaviour
{

    private LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);

                if (hit.collider.gameObject.tag == "Player")
                {
                    //Debug.Log("Player was hit");
                    SceneManager.LoadScene("LoseMenu");
                    Cursor.lockState =  CursorLockMode.None;
                }


            }
        }
        else
        {
            lr.SetPosition(1, transform.position + (transform.forward * 5000));
        }
    }
}