using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Joystick myJoyStick;
    private Rigidbody rb;
    private float movementx,movementxJoystick;
    private float movementy,movementyJoystick;
    public int Count;
    public int totalCollectable;
    void Start()
    {
        totalCollectable = GameObject.FindGameObjectsWithTag("Pickup").Length + GameObject.FindGameObjectsWithTag("GreenPickup").Length * 10;
        Count = 0;
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementx = movementVector.x;
        movementy = movementVector.y;
    }
    private void FixedUpdate()
    {
        movementxJoystick = myJoyStick.Horizontal;
        movementyJoystick = myJoyStick.Vertical;
        rb.AddForce(new Vector3(movementx+ movementxJoystick, 0f, movementy+ movementyJoystick) * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        PickupInterface pickup = other.gameObject.GetComponent<PickupInterface>();
        if (pickup != null)
        {
            pickup.hit();
        }
    }
}
