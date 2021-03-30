using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cameraAnchor;
    public float lookSensitivity;
    public float minXLook;
    public float maxXLook;
    public bool invertXRotation;
    private float currentXRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * mouseX * lookSensitivity;

        currentXRotation -= mouseY * lookSensitivity;
        currentXRotation = Mathf.Clamp(currentXRotation, minXLook, maxXLook);

        Vector3 clampedAngle = cameraAnchor.eulerAngles;
        clampedAngle.x = currentXRotation;

        cameraAnchor.eulerAngles = clampedAngle;
    }

}
