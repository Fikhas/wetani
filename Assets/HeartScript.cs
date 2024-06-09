using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    private float timer;
    private bool isPlaySoundEffect;
    [SerializeField] private GameObject heartTouchGrassSoundEffect;
    [SerializeField] private GameObject heartMissSoundEffect;
    [SerializeField] private GameObject heartTakenSoundEffect;

    private void Start()
    {
        isPlaySoundEffect = false;
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -3.5)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (!isPlaySoundEffect)
            {
                Instantiate(heartTouchGrassSoundEffect);
                isPlaySoundEffect = true;
            }
        }
        timer += Time.deltaTime;
        if (timer > 10f)
        {
            Instantiate(heartMissSoundEffect);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(heartTakenSoundEffect);
            HeartManager.sharedInstance.AddHearts();
            Destroy(gameObject);
        }
    }
}
