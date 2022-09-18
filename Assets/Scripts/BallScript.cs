using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Particle Effects")]
    [SerializeField] private GameObject feedbackThump; 
    [SerializeField] private GameObject explosion;

    [Header("Ball Variables")]
    [SerializeField] private float force = 1f;
    [SerializeField] private float attractionForce = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 targetDelta = player.transform.position - transform.position;
        rb.AddForce(targetDelta.normalized * attractionForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "GameController")
        {
            Instantiate(feedbackThump, collision.GetContact(0).point, Quaternion.identity);
            rb.AddForce(collision.contacts[0].normal * force, ForceMode.Impulse);
        }

        if (collision.transform.tag == "Enviroment")
        {
            Instantiate(explosion, collision.GetContact(0).point, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
