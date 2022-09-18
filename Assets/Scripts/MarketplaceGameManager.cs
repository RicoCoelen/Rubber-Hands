using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketplaceGameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject aicrowd;
    [SerializeField] private GameObject gameball;
    [SerializeField] private GameObject screens;

    [Header("Game Positions")]
    [SerializeField] private GameObject aicrowdpos;
    [SerializeField] private GameObject antagonistpos;
    [SerializeField] private GameObject ballpos;

    [Header("Game Variables")]
    [SerializeField] private float score;
    [SerializeField] private float lerpspeed;

    void Start()
    {
        enemy.GetComponent<NavigationScript>().desiredPosition = antagonistpos.transform.GetChild(0);
    }

    void FixedUpdate()
    {   
        // check if enemy is already at the end
        if (enemy.GetComponent<NavigationScript>().desiredPosition != antagonistpos.transform.GetChild(1).transform)
        {
            // check enemy distance if they at the player
            float dis = Vector3.Distance(enemy.GetComponent<NavigationScript>().transform.position, antagonistpos.transform.GetChild(0).transform.position);
            if (dis < 0.5f)
            {
                gameball.transform.parent = null;
                float dis2 = Vector3.Distance(gameball.transform.position, ballpos.transform.position);
                if (dis2 < 0.5f)
                {
                    gameball.GetComponent<Rigidbody>().isKinematic = false;
                }
                else
                {
                    gameball.transform.position = Vector3.Lerp(gameball.transform.position, ballpos.transform.position, lerpspeed * Time.deltaTime);
                    enemy.GetComponent<NavigationScript>().desiredPosition = antagonistpos.transform.GetChild(1);
                }
            }
        }
       
    }
}
