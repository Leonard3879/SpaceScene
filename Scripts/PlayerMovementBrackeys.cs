using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBrackeys : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    Vector3 velocity;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.2f;
    public float jumpHeight = 3f;
    public LayerMask groundMask;
    bool isGrounded;

    //music
    public AudioClip bgSound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgSound;
        audioSource.Play();
        audioSource.loop = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
