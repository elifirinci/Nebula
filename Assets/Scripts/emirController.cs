using System.Collections;
using UnityEngine;

public class emirController : MonoBehaviour
{
    public GameObject player;  // Oyuncu küpü
    public float detectionDistance = 2f;  // Mesafe ölçümü
    public float moveDistance = 3f;  // Ýleri hareket mesafesi
    public float moveSpeed = 2f;  // Hareket hýzý (sabit hýz)
    public AudioSource audioSource;  // Ses kaynaðý
    private bool soundPlayed = false;  // Ses çaldý mý kontrolü
    private bool isMoving = false;  // Hareket halinde mi kontrolü

    void Update()
    {
        // Yalnýzca hareket etmiyorsa mesafeyi kontrol et
        if (!soundPlayed && !isMoving)
        {
            // Oyuncu ve yandaþ arasýndaki mesafeyi kontrol et
            float distance = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log("Distance to player: " + distance);  // Mesafeyi yazdýr
            // Mesafe 2 metreden azsa ses çal ve ardýndan hareket et
            if (distance <= detectionDistance)
            {
                StartCoroutine(PlaySoundAndMove());
            }
        }
    }

    // Ses çal ve sonra hareket et
    IEnumerator PlaySoundAndMove()
    {
        soundPlayed = true;

        // Sesi çal
        audioSource.Play();

        // Sesin bitmesini bekle
        yield return new WaitForSeconds(audioSource.clip.length);

        // Hareket etmeye baþla
        StartCoroutine(MoveForward());
    }

    // 3 metre sabit hýzla hareket et
    IEnumerator MoveForward()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + transform.forward * moveDistance;

        // Zaman içinde hareket ettir
        float elapsedTime = 0;
        float journeyTime = moveDistance / moveSpeed;  // Hedef pozisyona varma süresi

        while (elapsedTime < journeyTime)
        {
            // Hýzla nesneyi hareket ettir
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / journeyTime);
            elapsedTime += Time.deltaTime;
            yield return null;  // Bir sonraki frame'e geç
        }

        // Tam hedef pozisyona yerleþtir
        transform.position = targetPosition;

        // Yandas küpünü devre dýþý yap (setActive false)
        gameObject.SetActive(false);
        isMoving = false;
    }
}