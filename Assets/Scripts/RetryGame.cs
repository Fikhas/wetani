using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryGame : MonoBehaviour
{
    [SerializeField]
    private FloatValue heartPlayer;
    [SerializeField]
    private FloatValue enemySpeed;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private ScoreScript scoreToReset;
    [SerializeField]
    private PlayerShoot playerDelayShoot;
    [SerializeField]
    private HeartManager initHearts;
    [SerializeField]
    private AudioSource backsound;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject birdDrop;
    [SerializeField]
    private FloatValue dropDelay;
    [SerializeField]
    private FloatValue enemyDelay;

    public void RetryGameActive()
    {
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird");
        GameObject[] birdClues = GameObject.FindGameObjectsWithTag("BirdClue");
        foreach (GameObject birdClue in birdClues)
        {
            Destroy(birdClue);
        }
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject bird in birds)
        {
            Destroy(bird);
        }
        heartPlayer.RuntimeValue = 5;
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        scoreToReset.scoreNow = 0;
        scoreToReset.UpdateScore();
        enemySpeed.RuntimeValue = 3;
        playerDelayShoot.shootDelay = 0;
        initHearts.InitHearts();
        backsound.Play();
        birdDrop.GetComponent<BirdDrop>().timer = 0;
        dropDelay.RuntimeValue = 5;
        enemyDelay.RuntimeValue = 3;
    }
}
