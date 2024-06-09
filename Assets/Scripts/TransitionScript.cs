using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject transitionToInstantiate;
    [SerializeField]
    private bool isInstantiateOnAwake;

    private void Start()
    {
        if (isInstantiateOnAwake)
        {
            GameObject fadeTransition = Instantiate(transitionToInstantiate, Vector3.zero, Quaternion.identity);
            fadeTransition.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
    }

    public void StartTransition()
    {
        GameObject fadeTransition = Instantiate(transitionToInstantiate, Vector3.zero, Quaternion.identity);
        fadeTransition.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }
}
