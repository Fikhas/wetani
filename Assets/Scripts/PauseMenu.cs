using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject fadeInParent;
    private bool isCanPause;

    private void Start()
    {
        isCanPause = false;
        StartCoroutine(CanPauseCo());
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape") && pauseMenu.activeInHierarchy && isCanPause)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown("escape") && isCanPause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        StartCoroutine(BackToMenuCo());
    }

    private IEnumerator BackToMenuCo()
    {
        Time.timeScale = 1;
        fadeInParent.GetComponent<TransitionScript>().StartTransition();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("TitleScreen");
    }

    private IEnumerator CanPauseCo()
    {
        yield return new WaitForSeconds(8f);
        isCanPause = true;
    }
}
