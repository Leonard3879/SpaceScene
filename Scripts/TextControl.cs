using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public Text AIText;
    public Image AIImage;



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider TestCollider)
    {
        AIText.text = "Welcome to the Descensus. I am the ship's AI.";
        //AIImage.image = //
    }
}
