using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] pauseComponents;
    public AudioSource[] audioSources;

    private bool isPaused = false;
    private float originalTimeScale;

    void Start()
    {
        originalTimeScale = Time.timeScale;
        pauseMenu.SetActive(false);
        foreach (GameObject component in pauseComponents)
        {
            component.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        foreach (GameObject component in pauseComponents)
        {
            component.SetActive(false);
        }
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

   public void Resume()
    {
        isPaused = false;
        Time.timeScale = originalTimeScale;
        pauseMenu.SetActive(false);
        foreach (GameObject component in pauseComponents)
        {
            component.SetActive(true);
        }
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause();
        }
    }
}