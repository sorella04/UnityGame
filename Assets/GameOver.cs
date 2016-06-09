using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GameObject GameOverUI;

    private bool lose = false;
    static bool gameover_bool = true;

    void Start()
    {
        //show(true);
    }

    void Update() {
        Debug.logger.Log(gameover_bool);
        //show(gameover_bool);
    }

    public void show(bool state) {
        GameOverUI.SetActive(state);
    }
}
