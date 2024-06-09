using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class HeartDropScript : MonoBehaviour
{
    [SerializeField] private GameObject heartToDrop;
    [HideInInspector] public static HeartDropScript sharedInstance;

    private void Start()
    {
        sharedInstance = this;
    }

    public void HeartDrop()
    {
        Instantiate(heartToDrop, new Vector2(Random.Range(-8, 8), 7), Quaternion.identity);
    }
}
