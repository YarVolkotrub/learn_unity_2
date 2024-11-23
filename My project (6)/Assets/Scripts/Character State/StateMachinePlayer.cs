using UnityEngine;

public class StateMachinePlayer : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    public void Change(IState state)
    {
        if (state == null)
        {
            return;
        }

        if (CurrentState == state)
        {
            CurrentState.Update();
        }
        else
        {
            if (CurrentState != null)
            {
                CurrentState.Exit();
            }

            CurrentState = state;
            CurrentState.Enter();
        }
    }
}