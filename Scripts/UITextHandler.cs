using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHandler : MonoBehaviour
{
    private BoxCollider boxCollider;
    public Image AI;
    public Text AIText;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }



    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Make text appear
            Debug.Log("Text appears");
            AI.enabled = true;
            AIText.enabled = true;
            boxCollider.enabled = false;

            StartCoroutine(Delay());
            //AI.enabled = false;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        AI.enabled = false;
        AIText.enabled = false;

    }
}
