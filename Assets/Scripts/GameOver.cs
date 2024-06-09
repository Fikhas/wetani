using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private AudioSource gameOverAudio;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private ScoreScript finalScore;

    public void GameOverPanelActive()
    {
        gameObject.SetActive(true);
        gameOverAudio.Play();
        Time.timeScale = 0;
        scoreText.text = finalScore.scoreNow.ToString();
        GameObject.FindGameObjectWithTag("Backsound").GetComponent<AudioSource>().Stop();
    }
}
