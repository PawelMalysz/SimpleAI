using UnityEngine;
using System.Collections;

namespace StateMachineStuff
{
    public class StateMachine<T>
    {
        public State<T> CurrentState { get; set; }
        public T Owner;

        public StateMachine(T owner)
        {
            Owner = owner;
            CurrentState = null;
        }

        public void ChangeState(State<T> newState)
        {
            if (CurrentState != null)
            {
                CurrentState.ExitState(Owner);
            }

            CurrentState = newState;
            CurrentState.EnterState(Owner);
        }

        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.UpdateState(Owner);
            }
        }
    }
}
