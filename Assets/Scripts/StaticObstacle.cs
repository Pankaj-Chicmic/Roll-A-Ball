using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StaticObstacle: MonoBehaviour
{
    [SerializeField] GameObject restarting;
    [SerializeField] GameObject audioDie;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            restarting.SetActive(true);
            audioDie.GetComponent<AudioSource>().Play();
            Invoke("restart", 1);
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
