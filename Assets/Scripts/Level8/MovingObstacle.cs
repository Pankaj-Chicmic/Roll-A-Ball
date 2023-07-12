using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovingObstacle : MonoBehaviour
{
    bool left;
    [SerializeField] GameObject Restarting;
    [SerializeField] GameObject audioDie;
    void Start()
    {
        if (this.name == "obstacle3")
        {
            left = false;
        }
        else
        {
            left = true;
        }
    }
    void FixedUpdate()
    {
        if (left)
        {
            transform.position = transform.position + new Vector3(0.025f, 0, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(0.025f, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            left= !left;
        }
        if (collision.gameObject.name == "Player")
        {
            audioDie.GetComponent<AudioSource>().Play();
            Restarting.SetActive(true);
            Invoke("restart", 1);
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
