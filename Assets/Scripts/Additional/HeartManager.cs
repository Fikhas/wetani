using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private FloatValue heartAmount;
    [SerializeField] private Image[] heart;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] GameObject healthWarningAnim;
    [HideInInspector] public static HeartManager sharedInstance;

    private void Start()
    {
        InitHearts();
        sharedInstance = this;
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartAmount.initialValue; i++)
        {
            heart[i].gameObject.SetActive(true);
        }
        healthWarningAnim.GetComponent<Animator>().SetBool("isWarningOn", false);
    }

    public void AddHearts()
    {
        if (heartAmount.RuntimeValue < 5)
        {
            heartAmount.RuntimeValue += 1;
        }
        for (int i = 0; i < heartAmount.initialValue; i++)
        {
            heart[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < heartAmount.RuntimeValue; i++)
        {
            heart[i].gameObject.SetActive(true);
        }
        if (heartAmount.RuntimeValue <= 2)
        {
            healthWarningAnim.GetComponent<Animator>().SetBool("isWarningOn", true);
        }
        else
        {
            healthWarningAnim.GetComponent<Animator>().SetBool("isWarningOn", false);
        }
    }

    public void UpdateHearts()
    {
        if (GameState.sharedInstance.isGameOn == true)
        {
            heartAmount.RuntimeValue -= 1;
            for (int i = 0; i < heartAmount.initialValue; i++)
            {
                heart[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < heartAmount.RuntimeValue; i++)
            {
                heart[i].gameObject.SetActive(true);
            }
            if (heartAmount.RuntimeValue == 0)
            {
                gameOverPanel.GetComponent<GameOver>().GameOverPanelActive();
                return;
            }
            if (heartAmount.RuntimeValue <= 2)
            {
                healthWarningAnim.GetComponent<Animator>().SetBool("isWarningOn", true);
            }
            else
            {
                healthWarningAnim.GetComponent<Animator>().SetBool("isWarningOn", false);
            }
        }
    }
}
