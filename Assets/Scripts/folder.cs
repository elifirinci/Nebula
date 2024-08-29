using UnityEngine;
using UnityEngine.UI;

public class folder : MonoBehaviour
{
    public Transform player; // Player objesini sahneye ekleyin.
    public Transform folder1; // Folder objesini sahneye ekleyin.
    public Canvas canvas;    // Canvas objesini sahneye ekleyin.
    public float activationDistance = 2f; // Mesafe kontrolü için deðiþken.

    void Update()
    {
        // Player ve folder arasýndaki mesafeyi kontrol edin.
        float distance = Vector3.Distance(player.position, folder1.position);

        // E tuþuna basýldýðýnda ve mesafe 2 metreden az olduðunda canvas'ý açýn.
        if (Input.GetKeyDown(KeyCode.E) && distance <= activationDistance)
        {
            canvas.gameObject.SetActive(true);
        }
    }

    // Continue butonuna baðlanacak fonksiyon.
    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}