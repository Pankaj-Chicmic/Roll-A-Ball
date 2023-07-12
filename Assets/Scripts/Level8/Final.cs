using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    bool left = true;
    void FixedUpdate()
    {
        if (left)
        {
            transform.position = transform.position - new Vector3(0, 0, 0.05f);
        }
        else
        {
            transform.position = transform.position + new Vector3(0, 0, 0.05f);
        }
        if (transform.position.z <= 13|| transform.position.z >= 25)
        {
            left = !left;
        }
    }
}
