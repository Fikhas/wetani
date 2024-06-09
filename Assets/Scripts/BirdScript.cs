using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private float timer;
    private HeartManager heartManager;
    [SerializeField] GameObject birdSpawnSoundEffect;
    [SerializeField] GameObject hitPlayerSoundEffect;
    [SerializeField] FloatValue playerHealth;
    private Animator camAnim;

    private void Start()
    {
        heartManager = GameObject.FindGameObjectWithTag("HeartStatus").GetComponent<HeartManager>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        Instantiate(birdSpawnSoundEffect);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth.RuntimeValue > 1)
            {
                camAnim.SetBool("isShaking", true);
            }
            Instantiate(hitPlayerSoundEffect);
            heartManager.UpdateHearts();
            Destroy(gameObject);
        }
    }
}
