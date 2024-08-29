using UnityEngine;

public class markovController : MonoBehaviour
{
    public Transform player; // Player objesini sahneye ekleyin.
    public float activationDistance = 3f; // Mesafe kontrolü için deðiþken.
    public float moveDistance = 2f; // Markov objesinin hareket edeceði mesafe.
    public float moveSpeed = 2f; // Hareket hýzý.
    private Vector3 initialPosition; // Markov objesinin baþlangýç pozisyonu.
    private AudioSource audioSource; // Markov objesine baðlý AudioSource.

    private bool isMovingForward = false; // Hareket yönünü kontrol etmek için deðiþken.
    private bool hasAudioPlayed = false;  // AudioSource'un bir kez oynatýlýp oynatýlmadýðýný kontrol etmek için deðiþken.

    void Start()
    {
        // Markov objesinin baþlangýç pozisyonunu kaydedin.
        initialPosition = transform.position;

        // AudioSource bileþenini alýn.
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Player ve Markov objesi arasýndaki mesafeyi kontrol edin.
        float distance = Vector3.Distance(player.position, transform.position);

        // Eðer mesafe 3 metreden azsa ve ses daha önce çalýnmamýþsa, ses çalmaya baþla ve hareket et.
        if (distance <= activationDistance && !hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
            isMovingForward = true;
        }

        // Eðer ses çalýyorsa, Markov objesini hareket ettir.
        if (audioSource.isPlaying)
        {
            MoveMarkov();
        }
    }

    void MoveMarkov()
    {
        // Hareket yönünü kontrol edin ve Markov objesini ileri veya geri hareket ettirin.
        if (isMovingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition + transform.forward * moveDistance, moveSpeed * Time.deltaTime);

            // Markov objesi belirtilen mesafeye ulaþtýðýnda, geri dönmeye baþlayýn.
            if (Vector3.Distance(transform.position, initialPosition + transform.forward * moveDistance) < 0.01f)
            {
                isMovingForward = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            // Markov objesi baþlangýç pozisyonuna döndüðünde, ileri hareket etmeye baþlayýn.
            if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
            {
                isMovingForward = true;
            }
        }
    }
}