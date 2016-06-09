using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    public GameObject GameOverUI;

    private bool paused = false;

    void Start() {
        PauseUI.SetActive(false);
        GameOverUI.SetActive(false);
    }

    bool isPlayerOnScene()
    {
        return GameObject.Find("Player");
    }

    void Update() {
        Debug.logger.Log("Dupa");

        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

        if(!isPlayerOnScene()) {
            GameOverUI.SetActive(true);
        }
    }


    public void Resume() {
        paused = false;

    }

    public void Restart(){
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void Exit() {
        Application.Quit();
    }
}
