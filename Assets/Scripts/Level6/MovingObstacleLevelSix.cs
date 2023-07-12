using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovingObstacleLevelSix : MonoBehaviour
{
    bool wall3;
    [SerializeField] GameObject Restarting;
    [SerializeField] GameObject audioDie;
    private void Start()
    {
        if (this.name == "obstacle2")
        {
            wall3 = true;
        }
        else
        {
            wall3 = false;
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
    }
    private void FixedUpdate()
    {
        if (wall3)
        {
            transform.position = transform.position + new Vector3(0, 0, 0.08f);
        }
        else
        {
            transform.position = transform.position - new Vector3(0, 0, 0.08f);
        }
        if(wall3 && transform.position.z>= 5.19)
        {
            wall3 = false;
        }
        if(!wall3 && transform.position.z<= -6.77)
        {
            wall3 = true;
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
