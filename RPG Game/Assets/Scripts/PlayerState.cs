using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private string aminBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _aminBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.aminBoolName = _aminBoolName;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }

}
