using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public enum PlayerState
{
    attacking,
    walking,
}

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector3 change;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [HideInInspector]
    public PlayerState playerCurrentState;

    private void Start()
    {
        playerCurrentState = PlayerState.walking;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        change = Vector3.zero;
        if (playerCurrentState != PlayerState.attacking && Time.timeScale != 0)
        {
            change.x = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            change = Vector3.zero;
        }

        if (change.x != 0)
        {
            gameObject.GetComponent<PlayerAnimation>().AnimationWalking();
        }
        else
        {
            gameObject.GetComponent<PlayerAnimation>().AnimationStopWalking();
        }
    }

    private void FixedUpdate()
    {
        change.Normalize();
        rb.velocity = new Vector3(change.x * speed, change.y, change.z);
    }
}
