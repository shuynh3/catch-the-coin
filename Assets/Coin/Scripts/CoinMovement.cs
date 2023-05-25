using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Transform groundCheck;
    private CoinInteraction coinInteraction;
    private float gravity;

    private float currentVerticalVelocity = 0f;
    private bool isGrounded = false;

    void Awake()
    {
        coinInteraction = GetComponent<CoinInteraction>();
        groundCheck = transform.Find("GroundCheck");
    }

    void Start()
    {
        gravity = GameSettings.instance.coinGravity;
    }

    void Update()
    {
        AddGravity();
        HandleGroundCollision();
        HandleVerticalMovement();
    }

    void AddGravity()
    {
        currentVerticalVelocity -= gravity * Time.deltaTime;
    }

    void HandleVerticalMovement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + currentVerticalVelocity * Time.deltaTime);
    }

    void HandleGroundCollision()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (isGrounded && currentVerticalVelocity < 0)
        {
            currentVerticalVelocity = 0f;
            coinInteraction.Expire();
        }
    }
}
