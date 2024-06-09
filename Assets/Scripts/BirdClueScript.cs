using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdClueScript : MonoBehaviour
{
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bird"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
