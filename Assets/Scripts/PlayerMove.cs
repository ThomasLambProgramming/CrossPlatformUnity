using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] PauseMenu FailMenu;
    [SerializeField] Joystick joyStickPlayer;
    [SerializeField] Joystick joyStickCamera;

    public float rotationSpeed = 100.0f;
    public float speed = 10.0f;
    public float jumpForce;
    public float fallMultiplier = 1;
    public float smallJump = 1;

    bool holdingJump = false;
    bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float rotationX = 0f;
        float sideMovement = 0f;
        float forwardMovement = 0f;

        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            sideMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            rotationX = Input.GetAxisRaw("RotateX") * rotationSpeed * Time.deltaTime;

            if (Input.GetAxisRaw("Jump") > 0 && canJump == true && holdingJump == false)
            {
                rb.AddForce(0, jumpForce, 0);
                canJump = false;
                holdingJump = true;
            }
            if (Input.GetAxisRaw("Jump") == 0)
                holdingJump = false;
        }
        else
        {
            sideMovement = joyStickPlayer.Horizontal * speed * Time.deltaTime;
            forwardMovement = joyStickPlayer.Vertical * speed * Time.deltaTime;
            rotationX = joyStickCamera.Horizontal * rotationSpeed * Time.deltaTime;
        }
        Vector3 movePos = transform.position + (transform.forward * forwardMovement + transform.right * sideMovement);
        rb.MovePosition(movePos);
        transform.Rotate(0, rotationX, 0);

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && holdingJump == false)
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (smallJump - 1) * Time.deltaTime;
        }
    }
    public void AndroidJump()
    {
        if (canJump == true && holdingJump == false)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = false;
            holdingJump = true;
        }
    }
    public void yeet()
    {
        holdingJump = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.tag == "Platform")
        {
            canJump = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            FailMenu.LoadFail();
        }
    }
    
    
}
