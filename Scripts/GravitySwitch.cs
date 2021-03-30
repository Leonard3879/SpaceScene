using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    bool gravityOn = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if(gravityOn)
            {
                Physics.gravity = new Vector3(0, 9.81f, 0);
                gravityOn = false;
            }
            else
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
                gravityOn = true;
            }
        }
    }
}
