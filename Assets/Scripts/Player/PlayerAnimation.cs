using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [HideInInspector]
    public Animator playerAnim;

    private void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
    }

    public void AnimationWalking()
    {
        playerAnim.SetBool("isWalking", true);
        playerAnim.SetFloat("moveX", gameObject.GetComponent<PlayerMovement>().change.x);
    }

    public void AnimationStopWalking()
    {
        playerAnim.SetBool("isWalking", false);
    }

    public void AnimationAttacking()
    {
        playerAnim.SetBool("isAttacking", true);
    }

    public void AnimationStopAttacking()
    {
        playerAnim.SetBool("isAttacking", false);
    }
}
