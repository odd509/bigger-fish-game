using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject inGameView;
    public GameObject restartView;
    public GameObject menuView;
    public GameObject environment;
    public void Dead()
    {
        StopGame();
        restartView.SetActive(true);
    }
    void StopGame() {
        Time.timeScale = 0;
        inGameView.SetActive(false);
        environment.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        inGameView.SetActive(true);
        environment.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        StopGame();
    }
}
