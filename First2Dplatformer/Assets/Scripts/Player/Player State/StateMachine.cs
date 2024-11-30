using System.Collections.Generic;
using System.Linq;

public class PlayerStateMachine : IStateSwitcher, IStateUpdate
{
    public IState CurrentState;
    protected List<IState> States;

    public PlayerStateMachine(PlayerAnimation playerAnimation, Mover mover, PlayerPhysics playerPhysics, InputSystem inputSystem)
    {
        States = new()
        {
            new PlayerIdleState(playerAnimation, mover, playerPhysics, this, inputSystem),
            new PlayerRunState(playerAnimation, mover, playerPhysics,this, inputSystem),
            new PlayerJumpState(playerAnimation, mover, playerPhysics, this, inputSystem),
            new PlayerFallState(playerAnimation, mover, playerPhysics, this, inputSystem)
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