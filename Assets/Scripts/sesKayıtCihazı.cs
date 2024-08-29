using UnityEngine;

public class SesKayitCihazı : MonoBehaviour
{
    public Transform player;  // Player objesini sahneye ekleyin.
    public Transform sesKayıt; // SesKayıt objesini sahneye ekleyin.
    public float activationDistance = 1f; // Mesafe kontrolü için değişken.
    private AudioSource audioSource; // Ses kaynağı bileşeni.

    void Start()
    {
        // SesKayıt objesindeki AudioSource bileşenini alın.
        audioSource = sesKayıt.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Player ve sesKayıt objesi arasındaki mesafeyi kontrol edin.
        float distance = Vector3.Distance(player.position, sesKayıt.position);

        // E tuşuna basıldığında ve mesafe 1 metreden az veya eşitse, ses çalmaya başlasın.
        if (Input.GetKeyDown(KeyCode.E) && distance <= activationDistance)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}