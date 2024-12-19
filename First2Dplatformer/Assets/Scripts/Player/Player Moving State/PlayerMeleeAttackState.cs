using UnityEngine;

public class PlayerMeleeAttackState : PlayerMovingBaseState
{
    private float _lenghtAnimation;
    private float _timer;

    public PlayerMeleeAttackState(PlayerAnimation playerAnimation, IMover mover, PlayerPhysics playerPhysics, IStateSwitcher stateMachine, IInputSystem inputSystem) 
        : base(playerAnimation, mover, playerPhysics, stateMachine, inputSystem) { }

    public override void Enter()
    {
        _timer = 0;
        Mover.Stand();
        PlayerAnimation.MeleeAttack();
    }

    public override void Update() 
    {
        if (_lenghtAnimation == 0)
        {
            _lenghtAnimation = PlayerAnimation.Lenght;
        }

        if (_timer >= _lenghtAnimation)
        {
            StateMachine.SwitchState<PlayerIdleState>();
        }

        _timer += Time.deltaTime;
    }

    public override void FixedUpdate() 
    {

    }
}