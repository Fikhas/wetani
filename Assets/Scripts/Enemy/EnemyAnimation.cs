using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator enemyAnim;

    private void Start()
    {
        enemyAnim = gameObject.GetComponent<Animator>();
    }

    public void AnimationDestroy()
    {
        enemyAnim.SetBool("isDestroying", true);
    }
}
