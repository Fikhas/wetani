using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    public float shootDelay;
    [SerializeField]
    private Slider sliderDelay;

    private void Start()
    {
        sliderDelay.maxValue = 1f;
    }

    void Update()
    {
        shootDelay += Time.deltaTime;
        sliderDelay.value = shootDelay;
        if (Input.GetButtonDown("Shoot") && Time.timeScale != 0)
        {
            if (shootDelay > 1f)
            {
                StartCoroutine(ShootBulletCo());
                shootDelay = 0;
            }
        }
    }

    private IEnumerator ShootBulletCo()
    {
        gameObject.GetComponent<PlayerAnimation>().AnimationAttacking();
        gameObject.GetComponent<PlayerMovement>().playerCurrentState = PlayerState.attacking;
        Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        gameObject.GetComponent<PlayerAnimation>().AnimationStopAttacking();
        gameObject.GetComponent<PlayerMovement>().playerCurrentState = PlayerState.walking;

    }
}
