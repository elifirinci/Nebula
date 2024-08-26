using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpValue = 10f;
    [SerializeField] float mouseSensivity = 5f;
    [SerializeField] float speedAccelaretion; 
    [SerializeField] float speedDeccalariton; 
    float currentRotationX = 0f;
    [Header("Objects")]
    Rigidbody rb;
    float defaultSpeed;
    float forceSpeed;
    [Header("Bool")]
    bool isGround;

    void Start()
    {
        defaultSpeed = speed;
        forceSpeed = speed + 5;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Direction();
        Jump();
        Force();
        Debug.Log(speed);
    }

    void Direction()
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

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Vector3 jump = new Vector3(0, transform.position.y + jumpValue, 0);
            rb.velocity += jump;    
        }

    }

    void Force()
    {
        bool forceInput = Input.GetKey(KeyCode.LeftShift);
        speed = Mathf.Clamp(speed,defaultSpeed,forceSpeed);
        if (forceInput)
        {
            speed += Time.deltaTime * speedAccelaretion;
            
        }
        if (!forceInput)
        {
            speed -= Time.deltaTime * speedDeccalariton;
        }

        if (speed > forceSpeed)
        {
            speed = forceSpeed;
        }

        else if (speed<defaultSpeed)
        {
            speed = defaultSpeed;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = false;

    }
}
