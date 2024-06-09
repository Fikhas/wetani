using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Vector2 enemyPosition;
    private bool isCanSpawn;
    [SerializeField]
    private FloatValue enemySpawnDelay;

    private void Start()
    {
        enemySpawnDelay.RuntimeValue = 3;
        isCanSpawn = false;
        StartCoroutine(EnemySpawnCo());
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > enemySpawnDelay.RuntimeValue && isCanSpawn)
        {
            Instantiate(enemy, enemyPosition, Quaternion.identity);
            timer = 0;
        }
    }

    private IEnumerator EnemySpawnCo()
    {
        yield return new WaitForSeconds(9f);
        isCanSpawn = true;
    }
}
