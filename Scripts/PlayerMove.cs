using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    bool hasDoubleJumped = false;
    bool canJump = true;
    private Rigidbody rb;
    bool holdingJump = false;


    public float jumpForce;
    public float fallMultiplier = 1;
    public float smallJump = 1;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float rotationX = Input.GetAxisRaw("RotateX") * rotationSpeed * Time.deltaTime;



        Vector3 movePos = transform.position + (transform.forward * forwardMovement + transform.right * sideMovement);
        rb.MovePosition(movePos);
        
        
        transform.Rotate(0, rotationX, 0);

        if (Input.GetAxisRaw("Jump") > 0 && canJump == true && holdingJump == false)
        {
            rb.AddForce(0, jumpForce, 0);
            if (hasDoubleJumped == false)
            {
                hasDoubleJumped = true;
            }
            if (hasDoubleJumped == true)
            {
                canJump = false;
            }

            holdingJump = true;
        }
        if (Input.GetAxisRaw("Jump") == 0)
            holdingJump = false;

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (smallJump - 1) * Time.deltaTime;
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            canJump = true;
        }
    }
}
