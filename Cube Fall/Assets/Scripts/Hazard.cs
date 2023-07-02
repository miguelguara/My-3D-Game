using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public ParticleSystem breakEffect;

    public void Update()
    {
        transform.Rotate(new Vector3(1f,0f,0f)*-150 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hazard"))
        {
            Instantiate(breakEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}
