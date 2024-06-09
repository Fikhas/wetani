using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyerScript : MonoBehaviour
{
    [SerializeField] private HeartManager heartManager;
    [SerializeField] private GameObject bulletMissSoundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Instantiate(bulletMissSoundEffect);
            heartManager.UpdateHearts();
        }
    }
}
