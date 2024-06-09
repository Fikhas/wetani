using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private FloatValue enemySpeed;
    [SerializeField]
    private bool isFromLeft;
    public static EnemyScript sharedInstance;
    [SerializeField]
    private AudioSource dieAudio;

    private void Start()
    {
        sharedInstance = this;
    }

    void Update()
    {
        if (isFromLeft)
        {
            transform.Translate(Vector2.right * enemySpeed.RuntimeValue * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * enemySpeed.RuntimeValue * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            ScoreScript.sharedInstance.AddScore();
            StartCoroutine(EnemyDestroyCo());
        }
    }

    private IEnumerator EnemyDestroyCo()
    {
        dieAudio.Play();
        gameObject.GetComponent<EnemyAnimation>().AnimationDestroy();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
