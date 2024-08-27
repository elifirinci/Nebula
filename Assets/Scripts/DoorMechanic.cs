using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    Transform doorLeft;
    Transform openDoorLeftPosition;
    Transform openDoorRightPosition;
    Transform doorRight;
    Transform classicDoor;

    Vector3 doorLeftPosition;
    Vector3 doorRightPosition;

    [SerializeField] float lerpValue = 10;
    [SerializeField] float distanceToClassicDooValue = 10;
    bool isExit;
    bool isClassicExit;
    bool isRotate;

    void Update()
    {
        if (isExit)
        {
            doorLeft.position = Vector3.Lerp(doorLeft.position, doorLeftPosition, lerpValue * Time.deltaTime);
            doorRight.position = Vector3.Lerp(doorRight.position, doorRightPosition, lerpValue * Time.deltaTime);

        }
        if (isClassicExit)
        {
            Quaternion lerpDoor = Quaternion.Euler(0, 0, 0);
            classicDoor.rotation = Quaternion.Slerp(classicDoor.rotation, lerpDoor, lerpValue * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoorTrigger"))
        {
            doorRightPosition = other.transform.GetChild(4).position;
            doorLeftPosition = other.transform.GetChild(5).position;
        }


    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("DoorTrigger"))
        {
            isExit = false;

            doorRight = other.transform.GetChild(0);
            doorLeft = other.transform.GetChild(1);
            openDoorRightPosition = other.transform.GetChild(2);
            openDoorLeftPosition = other.transform.GetChild(3);

            doorLeft.position = Vector3.Lerp(doorLeft.position, openDoorLeftPosition.position, lerpValue * Time.deltaTime);
            doorRight.position = Vector3.Lerp(doorRight.position, openDoorRightPosition.position, lerpValue * Time.deltaTime);
        }

        if (other.gameObject.CompareTag("ClassicDoor"))
        {
            isClassicExit = false;
            classicDoor = other.transform.GetChild(0);
            float distanceToClassicDoor = transform.position.x - classicDoor.position.x;
            Debug.Log("Distancetoclassic" + distanceToClassicDoor);
            Debug.Log("Transfom Position" + transform.position);
            if (distanceToClassicDoor > distanceToClassicDooValue && !isRotate)
            {
                isRotate = true;
                Quaternion lerpDoor = Quaternion.Euler(0, 90, 0);
                classicDoor.rotation = Quaternion.Slerp(classicDoor.rotation, lerpDoor, lerpValue * Time.deltaTime);
            }
            else
            {
                if (!isRotate)
                {
                    isRotate = true;
                }
                Quaternion lerpDoor = Quaternion.Euler(0, -90, 0);
                classicDoor.rotation = Quaternion.Slerp(classicDoor.rotation, lerpDoor, lerpValue * Time.deltaTime);
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DoorTrigger"))
        {
            isExit = true;
        }

        if (other.gameObject.CompareTag("ClassicDoor"))
        {
            isRotate = false;
            isClassicExit = true;
        }
    }
}
