using System.Collections.Generic;
using System.Linq;

public class EnemyStateMachine : IStateSwitcher, IStateUpdate
{
    public IState CurrentState { get; private set; }
    protected List<IState> States;

    public EnemyStateMachine(IEnemyView view, IEnemyAnimator enemyAnimation, IEnemyMover mover, Enemy enemy)
    {
        States = new()
        {
            new EnemyIdleState(view, enemyAnimation, mover, this, enemy),
            new EnemyMovingState(view, enemyAnimation, mover, this, enemy),
            new EnemyFollowState(view, enemyAnimation, mover, this, enemy),
            new EnemyAttackState(view, enemyAnimation, mover, this, enemy)
        };
    }

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