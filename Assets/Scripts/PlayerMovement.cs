using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody Rigidbody;
    [SerializeField]float movementSpeed = 6f;
    [SerializeField]float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Rigidbody.velocity = new Vector3(horizontalInput * movementSpeed, Rigidbody.velocity.y, verticalInput * movementSpeed);

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            jump();
        }
        //if (Input.GetKeyDown("space"))
        //{
        //    Rigidbody.velocity = new Vector3(0, 5f, 0);
        //}
        //if(Input.GetKey("up"))
        //{
        //    Rigidbody.velocity = new Vector3(0, 0, 5f);
        //}
        //if (Input.GetKey("right"))
        //{
        //    Rigidbody.velocity = new Vector3(5f, 0, 0);
        //}
        //if (Input.GetKey("left"))
        //{
        //    Rigidbody.velocity = new Vector3(-5f, 0, 0);
        //}
        //if (Input.GetKey("down"))
        //{
        //    Rigidbody.velocity = new Vector3(0, 0,-5f);
        //}
    }

    void jump()
    {
        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, jumpForce, Rigidbody.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            jump();
        }
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
