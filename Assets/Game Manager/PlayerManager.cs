using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private GameObject player;

    public static GameObject GetPlayer()
    {
        return instance.player;
    }

    void Awake()
    {
        instance = this;
        player = gameObject;
    }
}
