using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private AudioSource soundEffect;

    private void Start()
    {
        soundEffect.Play();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }
}
