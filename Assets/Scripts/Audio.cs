using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip flapSound;
    private AudioSource audioSource;

    public static Audio instance;

    public AudioSource scoreAudio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Dapatkan komponen AudioSource dari GameObject ini
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayScoreSound()
    {
        scoreAudio.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(flapSound);
            // kode untuk menggerakkan burung ke atas
        }
    }
}
