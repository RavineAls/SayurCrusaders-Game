using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMove : MonoBehaviour
{   
    float rotationX = 0f;
    float rotationY = 0f;
 
    public bool cursLock = true;
    public float sensitivity = 7f;
    float speed =5.0f;
    public float jumpForce = 8f;
    private Rigidbody rb;
    bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            //rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
            transform.localEulerAngles = new Vector3(rotationX,rotationY,0);

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            { 
                transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A))
            { 
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-1 * Vector3.left * Time.deltaTime * speed);
            }
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumping = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 10.0f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 5.0f;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cursLock == true)
            {
                cursLock = false;
            }

            else
            {
                cursLock = true;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
