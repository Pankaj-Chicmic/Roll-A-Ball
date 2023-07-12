using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPickup : MonoBehaviour,PickupInterface
{

    [SerializeField] PlayerController player;
    [SerializeField] GameObject AudioCollect;
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
    public void hit()
    {
        player.Count += 10;
        AudioCollect.GetComponent<AudioSource>().Play();
        Invoke("destroyObject", 0.1f);
    }
    public void destroyObject()
    {
        gameObject.SetActive(false);
    }
}
