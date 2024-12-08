using System.Collections.Generic;
using System.Linq;

public class PlayerCombatStateMachine : IStateSwitcher, IStateUpdate
{
    public IState CurrentState { get; private set; }
    protected List<IState> States;

    public PlayerCombatStateMachine(PlayerAnimation playerAnimation, PlayerPhysics playerPhysics, InputReader inputSystem)
    {
        States = new()
        {
            //new PlayerCombatIdleState(playerAnimation, playerPhysics, inputSystem, this)
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