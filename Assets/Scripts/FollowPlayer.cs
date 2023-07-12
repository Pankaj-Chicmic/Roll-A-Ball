using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Light;
    private Vector3 offset;
    void Start()
    {
        Light.transform.position = transform.position;
        Light.transform.rotation = transform.rotation;
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = offset + player.transform.position;
        Light.transform.position = transform.position;
    }
}
