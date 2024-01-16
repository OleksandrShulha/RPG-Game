using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim { get; private set; }

    public PlayerStateMachine stateMachine{ get; private set; }

    public PlayerIdleState idleState { get; private set;}
    public PlayerMoveState moveState { get; private set; }

    public Rigidbody2D rb { get; private set; }

    public float moveSpeed = 5f;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "isIdle");
        moveState = new PlayerMoveState(this, stateMachine, "isWalk");
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
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
}
