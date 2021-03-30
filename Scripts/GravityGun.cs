using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Transform objectHolder;
    private Vector3 originalHolderPosition;
    Rigidbody grabbedRb;
    public Camera cam;
    public float maxGrabDistance = 12f;
    public float throwForce = 20f;
    public float lerpSpeed = 10f;
    public float scrollSpeed = 500f;
    private LineRenderer lineRenderer;
    public Transform barrelPoint;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0.45f, 0.45f);
        lineRenderer.enabled = false;



        originalHolderPosition = objectHolder.transform.localPosition;
    }



    // Update is called once per frame
    void Update()
    {
        if(grabbedRb)
        {

            //Gizmos.DrawLine(barrelPoint.position, grabbedRb.position);

            grabbedRb.MovePosition(Vector3.Lerp(grabbedRb.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));

            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                grabbedRb.isKinematic = false;
                grabbedRb.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRb = null;
                lineRenderer.enabled = false;
                ResetObjectHolderPosition();
            }

            objectHolder.transform.position = objectHolder.transform.position + cam.transform.forward * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
        }


        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            if(grabbedRb)
            {
                grabbedRb.isKinematic = false;
                grabbedRb = null;


                lineRenderer.enabled = false;


                ResetObjectHolderPosition();
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if(Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    grabbedRb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if(grabbedRb)
                    {
                        grabbedRb.isKinematic = true;
                    }
                }
            }
        }
    }

    void LateUpdate()
    {
        if(grabbedRb)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, barrelPoint.position);
            lineRenderer.SetPosition(1, grabbedRb.position);
        }
    }



    void ResetObjectHolderPosition()
    {
        objectHolder.transform.localPosition = originalHolderPosition;
    }

}
