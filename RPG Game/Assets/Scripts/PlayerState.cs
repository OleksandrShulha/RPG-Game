using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private string aminBoolName;

    protected float xInput;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _aminBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.aminBoolName = _aminBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(aminBoolName, true);
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    public virtual void Exit()
    {
        player.anim.SetBool(aminBoolName, false);
    }

}
