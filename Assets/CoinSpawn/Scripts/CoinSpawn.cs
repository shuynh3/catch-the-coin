using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    private float horizontalCoinSpawnRange;
    private float verticalCoinSpawnRange;
    private float coinSpawnRate;

    private float targetTime;

    void Start()
    {
        horizontalCoinSpawnRange = GameSettings.instance.horizontalCoinSpawnRange;
        verticalCoinSpawnRange = GameSettings.instance.verticalCoinSpawnRange;
        coinSpawnRate = GameSettings.instance.coinSpawnRate;
        targetTime = coinSpawnRate;
    }

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }
    }

    void TimerEnded()
    {
        SpawnCoin();
        targetTime = coinSpawnRate;
    }

    void SpawnCoin()
    {
        GameObject.Instantiate(Resources.Load("Prefabs/Coin"), GetRandomSpawnPosition(), Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-horizontalCoinSpawnRange, horizontalCoinSpawnRange);
        float y = Random.Range(0, verticalCoinSpawnRange);

        return new Vector3(transform.position.x + x, transform.position.y + y);
    }
}
