using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RedPickup : MonoBehaviour,PickupInterface
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject restarting;
    [SerializeField] GameObject audioDie;
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
    public void hit()
    {
        audioDie.GetComponent<AudioSource>().Play();
        restarting.SetActive(true);
        Invoke("restart", 1);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
