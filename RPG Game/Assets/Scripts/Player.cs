using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region State
    public PlayerStateMachine stateMachine{ get; private set; }

    public PlayerIdleState idleState { get; private set;}
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    #endregion


    [Header("Move info")]
    public float moveSpeed = 5f;
    public float jumpForce;

    [Header("Collosion info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistanse;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistanse;
    [SerializeField] private LayerMask whatIsGround;

    public int faceDir { get; private set; } = 1;
    private bool faceRight = true;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "isIdle");
        moveState = new PlayerMoveState(this, stateMachine, "isWalk");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.curentState.Update();
        
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        FlipControler(_xVelocity);
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistanse));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistanse, wallCheck.position.y));
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistanse, whatIsGround);

    public void Flip()
    {
        faceDir = faceDir * -1;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipControler(float _x)
    {
        if(_x > 0 && !faceRight)
        {
            Flip();
        }
        else if (_x < 0 && faceRight)
        {
            Flip();
        }
    }
}
