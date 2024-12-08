using System.Collections.Generic;
using System.Linq;

public class PlayerMovingStateMachine : IStateSwitcher, IStateUpdate
{
    public IState CurrentState { get; private set; }
    protected List<IState> States;

    public PlayerMovingStateMachine(PlayerAnimation playerAnimation, PlayerMover mover, PlayerPhysics playerPhysics, InputReader inputSystem)
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