using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] GameObject paused;
    [SerializeField] GameObject mainMenu;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject Restarting;
    [SerializeField] GameObject pauseKey;
    void Start()
    {
        Restarting.SetActive(false);
        paused.SetActive(false);
        mainMenu.SetActive(false);
        LevelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex);
    }
    public void resume() {
        Time.timeScale=1;
        paused.SetActive(false);
        mainMenu.SetActive(false);
        pauseKey.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Restarting.activeSelf)
        {
                Time.timeScale = 0;
                paused.SetActive(true);
                mainMenu.SetActive(true);
        }
        if (player.Count == player.totalCollectable && !Restarting.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        SetCountText();
        if (player.transform.position.y < -5)
        {
            Restarting.SetActive(true);
            Invoke("restart", 1);
        }
    }
    public void PauseKey()
    {
        Time.timeScale = 0;
        paused.SetActive(true);
        mainMenu.SetActive(true);
        pauseKey.SetActive(false);
    }
    void SetCountText()
    {
        countText.text = "Score " + player.Count.ToString();
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}