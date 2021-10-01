using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    public Player player;
    public State CurrentState { get; private set; }

public void Initialize(State startingState)
{
    CurrentState = startingState;
    player = GameObject.FindObjectOfType<Player>();
    startingState.Enter();
}

public void ChangeState(State newState)
{
    CurrentState.Exit();

    CurrentState = newState;
    newState.Enter();
}

}
