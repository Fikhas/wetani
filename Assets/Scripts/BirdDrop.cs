using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using System.Threading;
using UnityEngine;

public class BirdDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    private FloatValue delayDrop;
    [HideInInspector]
    public float timer;
    [SerializeField]
    private GameObject birdClue;
    private bool isCanDrop;
    private Vector2 playerPosition;

    private void Start()
    {
        isCanDrop = false;
        StartCoroutine(CanDropCo());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayDrop.RuntimeValue && isCanDrop)
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
            Instantiate(bird, new Vector2(playerPosition.x, 7), Quaternion.identity);
            Instantiate(birdClue, new Vector2(playerPosition.x, -4), Quaternion.identity);
            timer = 0;
        }
    }

    private IEnumerator CanDropCo()
    {
        yield return new WaitForSeconds(9f);
        isCanDrop = true;
        GameState.sharedInstance.isGameOn = true;
    }
}
