using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Fields
    public float jumpForce = 2;
    public float walkSpeed;
    public float runSpeed;

    Animator animator;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumping = Input.GetButtonDown("Jump");

        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0,0,vertical);

        // set walk animation to play when pressing forward
        animator.SetFloat("isWalkingForward", vertical);

        transform.Translate(movement * Time.deltaTime * walkSpeed);

        if(isJumping) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            animator.SetBool("isJumping", isJumping);


            Debug.Log("This jumps");
        }

        // if(isJumping) {
        //     rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // }

  
    }
}
