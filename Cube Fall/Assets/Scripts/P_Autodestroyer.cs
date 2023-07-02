using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Autodestroyer : MonoBehaviour
{
    public float delay;

    void Start()
    {
        Destroy(gameObject,delay);
    }

}
