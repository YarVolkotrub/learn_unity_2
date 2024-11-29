using System.Collections.Generic;
using System.Linq;

public class EnemyStateMachine : IStateSwitcher, IStateUpdate
{
    public IState CurrentState;
    protected List<IState> States;

    public EnemyStateMachine(EnemyAnimation enemyAnimation, Mover mover, Enemy enemy)
    {
        States = new()
        {
            new EnemyIdleState(enemyAnimation, mover, this, enemy),
            new EnemyMovingState(enemyAnimation, mover, this, enemy)
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