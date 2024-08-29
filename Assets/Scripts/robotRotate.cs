using UnityEngine;

public class robotRotate : MonoBehaviour
{
    public Transform donusNoktasi; // Karakterin etrafýnda döneceði nokta
    public float rotationSpeed = 50f; // Dönme hýzý

    void Update()
    {
        // Karakteri belirlenen nokta etrafýnda döndür
        transform.RotateAround(donusNoktasi.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
