using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    [SerializeField]
    private FloatValue enemySpeed;
    [SerializeField]
    private FloatValue heartPlayer;
    [SerializeField]
    private FloatValue dropDelay;
    [SerializeField]
    private FloatValue enemyDelay;


    public void EnterToGame()
    {
        StartCoroutine(EnterToGameCo());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator EnterToGameCo()
    {
        gameObject.GetComponent<TransitionScript>().StartTransition();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        enemySpeed.RuntimeValue = 3;
        heartPlayer.RuntimeValue = 5;
        dropDelay.RuntimeValue = 5;
        enemyDelay.RuntimeValue = 3;
        GameState.sharedInstance.isGameOn = false;
    }
}
