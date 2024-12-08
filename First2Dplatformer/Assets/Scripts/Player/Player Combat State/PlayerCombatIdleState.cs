using UnityEngine;

public class PlayerCombatIdleState : PlayerCombatBaseState
{
    float _moveDirection;
    public PlayerCombatIdleState(PlayerAnimation playerAnimation, PlayerPhysics playerPhysics, InputReader inputSystem, PlayerCombatStateMachine stateMachine) 
        : base(playerAnimation, playerPhysics, inputSystem, stateMachine) { }

    public override void Enter()
    {

    }

    public override void Update() 
    {

    }

    public override void FixedUpdate() { }
}