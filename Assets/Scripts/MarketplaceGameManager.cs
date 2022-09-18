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

    [SerializeField] private GameObject screen1;
    [SerializeField] private GameObject screen2;
    [SerializeField] private GameObject screen3;

    [Header("Game Positions")]
    [SerializeField] private GameObject aicrowdpos;
    [SerializeField] private GameObject antagonistpos;
    [SerializeField] private GameObject ballpos;
    [SerializeField] private GameObject marketcenter;

    [Header("Game Variables")]
    [SerializeField] private int score = 0;
    [SerializeField] private float lerpspeed;
    [SerializeField] private int scene = 0;

    void Start()
    {
        enemy.GetComponent<NavigationScript>().desiredPosition = antagonistpos.transform.GetChild(0);
    }

    void FixedUpdate()
    {   
        // level sequence
        switch(scene)
        {
            case 0:
                CheckPickUp();
                break;
            case 1:
                WalkToPlayer();
                break;
            case 2:
                ThrowBomb();
                break;
            case 3:
                GamePlay();
                break;
            case 4:
                LoseScreen();
                break;
        }      
    }

    public void CheckPickUp()
    {
        // if both paddles are pickup and locked to hand
        scene++;
    }
    public void WalkToPlayer()
    {
        // check enemy distance if they at the player
        float dis = Vector3.Distance(enemy.GetComponent<NavigationScript>().transform.position, antagonistpos.transform.GetChild(0).transform.position);
        if (dis < 0.5f)
        {
            scene++;
        }
    }

    public void ThrowBomb()
    {
        gameball.transform.parent = null;
       
        float dis2 = Vector3.Distance(gameball.transform.position, ballpos.transform.position);
        if (dis2 > 0.5f)
        {
            gameball.transform.position = Vector3.Lerp(gameball.transform.position, ballpos.transform.position, lerpspeed * Time.deltaTime);
            
        }
        else
        {
            enemy.GetComponent<NavigationScript>().desiredPosition = antagonistpos.transform.GetChild(1);
            gameball.GetComponent<Rigidbody>().isKinematic = false;
            scene++;
        }

    }

    public void GamePlay()
    {
        if (gameball != null)
        {
            score = gameball.GetComponent<BallScript>().bounces;
            screen1.GetComponent<TMPro.TextMeshProUGUI>().text = "Bounces: " + score;
            screen2.GetComponent<TMPro.TextMeshProUGUI>().text = "Bounces: " + score;
            screen3.GetComponent<TMPro.TextMeshProUGUI>().text = "Bounces: " + score;
        }
        else
        {
            scene++;
        }
    }


    public void LoseScreen()
    {
        screen1.GetComponent<TMPro.TextMeshProUGUI>().text = "Game Over Bounces: " + score;
        screen2.GetComponent<TMPro.TextMeshProUGUI>().text = "Game Over Bounces: " + score;
        screen3.GetComponent<TMPro.TextMeshProUGUI>().text = "Game Over Bounces: " + score;
    }
}
