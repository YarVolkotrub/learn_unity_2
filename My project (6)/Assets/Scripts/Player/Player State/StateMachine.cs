using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState _currentState;

    public void Change(IState state)
    {
        if (state == null)
        {
            return;
        }

        if (_currentState == state)
        {
            _currentState.Update();
        }
        else
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = state;
            _currentState.Enter();
        }
    }
}