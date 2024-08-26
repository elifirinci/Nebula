using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Values")]
    public float speed = 5f;
    public float mouseSensivity = 5f;
    float currentRotationX = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, vertical);


        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity;

        currentRotationX -= mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, -25f, 25f);

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(currentRotationX, 0, 0);
    }
}
