using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject player;
    public List<GameObject> spawners;

    [Header("Canvases")]
    public GameObject inGameView;
    public GameObject restartView;
    public GameObject menuView;
    public GameObject environment;

    private float playerLastSize;
    private void Start()
    {
        playerLastSize = player.transform.localScale.x;
    }
    private void Update()
    {
        if (player.transform.localScale.x >= (playerLastSize * 1.5f) && (Camera.main.GetComponent<Camera>().orthographicSize < 40 ))
        {
            print("Zooming out");
            playerLastSize = player.transform.localScale.x;
            ZoomOut();
        }
    }
    public void ZoomOut()
    {
        environment.transform.localScale *= 2;
        Camera.main.GetComponent<Camera>().orthographicSize *= 2;
        foreach (GameObject spawnerO in spawners) {
            Spawner spawner = spawnerO.GetComponent<Spawner>();
            spawner.spawnY *= 2;
            spawner.activeDistance *= 2;
        }
    }

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
        menuView.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        StopGame();
        menuView.SetActive(true);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
