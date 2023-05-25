using System;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    private GameObject player;
    private float coinDistance;
    private float distanceToPlayerHorizontal;
    private float distanceToPlayerVertical;


    private float expireTime;

    public void Expire()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        coinDistance = GameSettings.instance.coinDistance;
        expireTime = GameSettings.instance.coinExpireTime;
        player = PlayerManager.GetPlayer();
    }

    void Update()
    {
        HandleExpiration();
        SetDistanceToPlayer();
        HandlePlayerCollision();
    }

    void SetDistanceToPlayer()
    {
        distanceToPlayerHorizontal = Math.Abs(transform.position.x - player.transform.position.x);
        distanceToPlayerVertical = Math.Abs(transform.position.y - player.transform.position.y);
    }

    void HandlePlayerCollision()
    {
        if (distanceToPlayerVertical <= 1f && distanceToPlayerHorizontal <= coinDistance)
        {
            AddToScore();
            Destroy(gameObject);
        }
    }

    void AddToScore()
    {
        ScoreManager.AddScore(1);

    }

    void HandleExpiration()
    {
        expireTime -= Time.deltaTime;

        if (expireTime <= 0)
        {
            Expire();
        }
    }
}
