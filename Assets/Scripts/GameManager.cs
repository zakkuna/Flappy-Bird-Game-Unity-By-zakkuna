using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public AudioClip scoreSound; // Deklarasi variabel AudioClip
    private int score;
    private AudioSource audioSource; // Deklarasi variabel AudioSource

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();

        // dapatkan komponen AudioSource dari GameManager
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        // mainkan sound effect ketika score bertambah
        audioSource.PlayOneShot(scoreSound);
    }
}