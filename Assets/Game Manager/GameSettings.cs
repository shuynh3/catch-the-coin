using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    public float playerGravity;
    public float playerSpeed;
    public float playerJumpHeight;

    public float coinGravity;
    public float coinDistance;
    public float coinExpireTime;

    public float horizontalCoinSpawnRange;
    public float verticalCoinSpawnRange;
    public float coinSpawnRate;


    void Awake()
    {
        Initialize();

        playerGravity = 30f;
        playerSpeed = 20f;
        playerJumpHeight = 4f;

        coinGravity = 10f;
        coinDistance = 1.5f;
        coinExpireTime = 10f;

        horizontalCoinSpawnRange = 15f;
        verticalCoinSpawnRange = 10f;
        coinSpawnRate = 1f;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void Initialize()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
