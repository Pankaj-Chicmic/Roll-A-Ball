using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] Animator Levels,MainMenu,VolumePanel;
    private void Start()
    {
        Time.timeScale=1;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void SelectLevel()
    {
        Levels.SetBool("isHidden", false);
        MainMenu.SetBool("isHidden", true);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Quit()
    {
        Application.Quit();        
    }
    public void QuitLevels()
    {
        Levels.SetBool("isHidden", true);
        MainMenu.SetBool("isHidden", false);
    }
    public void Settings()
    {
        MainMenu.SetBool("isHidden", true);
        VolumePanel.SetBool("isHidden", false);
    }
    public void VolumeQuit()
    {
        MainMenu.SetBool("isHidden", false);
        VolumePanel.SetBool("isHidden", true);
    }
}
