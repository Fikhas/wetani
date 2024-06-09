using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    public float scoreNow = 0f;
    public static ScoreScript sharedInstance;
    [SerializeField]
    private FloatValue enemySpeed;
    [SerializeField]
    private FloatValue delayDrop;
    [SerializeField]
    private FloatValue enemyDelay;

    private void Start()
    {
        scoreText.text = scoreNow.ToString();
        sharedInstance = this;
    }

    public void UpdateScore()
    {
        scoreText.text = scoreNow.ToString();
    }

    public void AddScore()
    {
        scoreNow += 10f;
        scoreText.text = scoreNow.ToString();
        if (scoreNow % 10 == 0)
        {
            enemySpeed.RuntimeValue += 0.2f;
        }
        if (scoreNow % 50 == 0)
        {
            if (delayDrop.RuntimeValue > 2.5f)
            {
                delayDrop.RuntimeValue -= 0.2f;
                HeartDropScript.sharedInstance.HeartDrop();
            }
        }
        if (scoreNow % 50 == 0)
        {
            if (enemyDelay.RuntimeValue > 1.5f)
            {
                enemyDelay.RuntimeValue -= 0.2f;
            }
        }
    }
}
