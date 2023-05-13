using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public bool cursLock = true;
    float rotationX = 0f;
    float rotationY = 0f;
 
    public float sensitivity = 7f;

    void Update()
    {
        //rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX,rotationY,0);
        
        //Press the space bar to toggle Cursor Lock
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cursLock == true)
            {
                Cursor.lockState = CursorLockMode.None;
                cursLock = false;
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursLock = true;
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}