using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavControlScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] navControlToShow;

    private void Start()
    {
        StartCoroutine(NavControlCo());
    }

    private IEnumerator NavControlCo()
    {
        yield return new WaitForSeconds(2f);
        GameObject navControl = Instantiate(navControlToShow[0], Vector3.zero, Quaternion.identity);
        navControl.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        yield return new WaitForSeconds(3f);
        GameObject navControlTwo = Instantiate(navControlToShow[1], Vector3.zero, Quaternion.identity);
        navControlTwo.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }
}
