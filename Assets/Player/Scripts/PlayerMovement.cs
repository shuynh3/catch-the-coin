using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform groundCheck;
    private SpriteRenderer spriteRenderer;
    private float gravity;
    private float speed;
    private float jumpHeight;

    private float currentVerticalVelocity = 0f;
    private bool isGrounded = false;
    private bool isTouchingLeftWall = false;
    private bool isTouchingRightWall = false;


    void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        gravity = GameSettings.instance.playerGravity;
        speed = GameSettings.instance.playerSpeed;
        jumpHeight = GameSettings.instance.playerJumpHeight;
    }

    void Update()
    {
        AddGravity();
        HandleJump();
        HandleWallCollision();
        HandleMoveLeft();
        HandleMoveRight();
        HandleGroundCollision();
        HandleVerticalMovement();
    }

    void HandleMoveRight()
    {
        if (InputManager.GetInput(InputManager.right))
        {
            spriteRenderer.flipX = false;
            if (!isTouchingRightWall)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
        }
    }

    void HandleMoveLeft()
    {
        if (InputManager.GetInput(InputManager.left))
        {
            spriteRenderer.flipX = true;
            if (!isTouchingLeftWall)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        }
    }

    void HandleJump()
    {
        if (InputManager.GetInput(InputManager.up) && isGrounded)
        {
            currentVerticalVelocity = GetVelocityForJumpHeight();
        }
    }

    float GetVelocityForJumpHeight()
    {
        return Mathf.Sqrt(2 * gravity * jumpHeight);
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
        }
    }

    void HandleWallCollision()
    {
        isTouchingLeftWall = Physics2D.Linecast(transform.position, new Vector2(transform.position.x - 0.5f, transform.position.y), 1 << LayerMask.NameToLayer("Wall"));
        isTouchingRightWall = Physics2D.Linecast(transform.position, new Vector2(transform.position.x + 0.5f, transform.position.y), 1 << LayerMask.NameToLayer("Wall"));
        if (isTouchingLeftWall) { Debug.Log(isTouchingLeftWall); }
    }
}
