using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtkilesimliObject : MonoBehaviour
{
    public float ışınUzunluğu = 10f;

    public AudioSource sazSesi;
    public AudioSource japonObjeSesi;
    public AudioSource meksikaObjeSesi;
    public AudioSource gameMusic;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    private AudioClip[] musicClips;

    private void Start()
    {
        musicClips = new AudioClip[] { music1, music2, music3 };

        gameMusic.clip = musicClips[0];
        gameMusic.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        Ray ışın = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(ışın, out hitInfo, ışınUzunluğu))
        {
            if (hitInfo.collider.CompareTag("Saz"))
            {
                sazSesi.Play();
            }
            else if (hitInfo.collider.CompareTag("JaponObje"))
            {
                japonObjeSesi.Play();
            }
            else if (hitInfo.collider.CompareTag("MeksikaObje"))
            {
                meksikaObjeSesi.Play();
            }
            else if (hitInfo.collider.CompareTag("Radio"))
            {
                gameMusic.Stop();

                int currentIndex = System.Array.IndexOf(musicClips, gameMusic.clip);
                int nextIndex = (currentIndex + 1) % musicClips.Length;

                AudioClip nextClip = musicClips[nextIndex];
                gameMusic.clip = nextClip;

                gameMusic.Play();
            }
        }
    }
}
