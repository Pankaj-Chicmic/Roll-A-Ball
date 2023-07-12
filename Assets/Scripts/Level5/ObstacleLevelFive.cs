using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObstacleLevelFive: MonoBehaviour
{
    [SerializeField] float speed;
    bool wall2;
    [SerializeField] GameObject Restarting;
    [SerializeField] GameObject audioDie;
    void Start()
    {
        if (this.name == "obstacleLevel4_1")
        {
            wall2 = false;
        }
        else
        {
            wall2 = true;
        }
    }
    void Update()
    {
        if (wall2)
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else
        {
            transform.position = transform.position - new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            audioDie.GetComponent<AudioSource>().Play();
            Restarting.SetActive(true);
            Invoke("restart", 1);
        }
        if (collision.gameObject.name == "Wall2")
        {
            wall2 = false;
        }
        else if (collision.gameObject.name == "Wall1")
        {
            wall2 = true;
        }

    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
