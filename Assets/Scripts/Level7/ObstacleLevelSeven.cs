using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObstacleLevelSeven : MonoBehaviour
{
    bool wall2;
    [SerializeField] GameObject Restarting;
    [SerializeField] GameObject audioDie;
    void Start()
    {
        if (this.name == "obstacle3" || this.name=="obstacle2"){
            wall2 = true;
        }
        else
        {
            wall2 = false;
        }
    }
    void FixedUpdate()
    {
        if (wall2)
        {
            transform.position = transform.position + new Vector3(0.08f, 0, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(0.08f, 0, 0);
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
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag== "Obstacle")
        {
            wall2 = !wall2;
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
