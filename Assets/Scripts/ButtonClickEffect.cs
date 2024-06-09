using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickEffect : MonoBehaviour
{
    [SerializeField] private GameObject clickSoundEffect;

    public void PlaySoundEffect()
    {
        Instantiate(clickSoundEffect);
    }
}
