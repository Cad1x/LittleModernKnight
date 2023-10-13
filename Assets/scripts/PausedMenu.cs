using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f; // Ustaw na 1, aby wznowiæ czas

        Paused = false;
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;

        Paused = true;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGameButton()
    {
        Debug.Log("Exiting the game");
        Application.Quit(); // Ta funkcja mo¿e nie dzia³aæ w niektórych œrodowiskach (np. wewn¹trz Unity Editora)
    }

}
