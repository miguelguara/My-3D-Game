using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem PlayerEffect;
    [SerializeField]
    private float Force;
    [SerializeField]
    private float MaxVelocity;
    private Rigidbody rb;
    [SerializeField]
    private GameObject GMN;
 

    void Awake()
    {
       rb= GetComponent<Rigidbody>();
       
    }
    private void OnEnable()
    {
        transform.position = new Vector3(7.78f, 4.44f, -4.37f);
        rb.velocity = Vector3.zero;
    }
    // Update 1is called once per frame
    void Update()
    {

        if (rb.velocity.magnitude <= MaxVelocity)
        {
            rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * Force * Time.deltaTime, 0f, 0f),ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Hazard"))
        {
            Instantiate(PlayerEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GMN.GetComponent<GameManager>().Game_Over();
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Instantiate(PlayerEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GMN.GetComponent<GameManager>().Game_Over();
        }
    }
}
