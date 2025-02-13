using System.Collections.Generic;
using System.Linq;

public class StateMachine : IStateSwitcher, IStateUpdate
{
    protected List<IState> States;

    public StateMachine(IVisionEnemy view, IEnemyAnimator enemyAnimation, IEnemyMover mover, Enemy enemy)
    {
        States = new()
        {
            new EnemyIdleState(view, enemyAnimation, mover, this, enemy),
            new EnemyMovingState(view, enemyAnimation, mover, this, enemy),
            new EnemyFollowState(view, enemyAnimation, mover, this, enemy),
            new EnemyAttackState(view, enemyAnimation, mover, this, enemy)
        };
    }

    public StateMachine(IPlayerAnimator playerAnimation, IMover mover, PlayerPhysics playerPhysics, IInputSystem inputSystem)
    {
        States = new()
        {
            new PlayerIdleState(playerAnimation, mover, playerPhysics, this, inputSystem),
            new PlayerRunState(playerAnimation, mover, playerPhysics,this, inputSystem),
            new PlayerJumpState(playerAnimation, mover, playerPhysics, this, inputSystem),
            new PlayerFallState(playerAnimation, mover, playerPhysics, this, inputSystem),
            new PlayerMeleeAttackState(playerAnimation, mover, playerPhysics, this, inputSystem)
        };
    }

    public IState CurrentState { get; private set; }

    public void Update()
    {
        CurrentState.Update();
    }

    public void FixedUpdate()
    {
        CurrentState.FixedUpdate();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = States.FirstOrDefault(state => state is T);

        CurrentState?.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}