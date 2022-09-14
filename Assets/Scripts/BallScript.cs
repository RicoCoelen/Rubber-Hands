using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "GameController")
        {
            rb.AddForce(collision.contacts[0].normal * force, ForceMode.Impulse);
        }
    }
}
