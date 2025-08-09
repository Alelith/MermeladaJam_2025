using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// Manages the states of an NPC.
    /// </summary>
    public class StateMachine
    {
        /// <summary>
        /// The stack of states.
        /// </summary>
        Stack<State> states;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateMachine"/> class.
        /// </summary>
        public StateMachine() => states = new Stack<State>();

        /// <summary>
        /// Updates the current state.
        /// </summary>
        public void Update() { if (Time.timeScale != 0) GetCurrentState()?.Execute(); }

        /// <summary>
        /// Pushes a new state onto the stack.
        /// </summary>
        public void PushState(Action active, Action onEnter, Action onExit)
        {
            GetCurrentState()?.OnExit();

            State state = new(active, onEnter, onExit);
            states.Push(state);

            GetCurrentState().OnEnter();
        }

        /// <summary>
        /// Pops the current state off the stack.
        /// </summary>
        public void PopState()
        {
            GetCurrentState()?.OnExit();

            GetCurrentState().ActiveAction = null;
            states.Pop();

            GetCurrentState().OnEnter();
        }

        /// <summary>
        /// Gets the current state.
        /// </summary>
        State GetCurrentState() => states.Count > 0 ? states.Peek() : null;

        /// <summary>
        /// Gets the stack of states.
        /// </summary>
        public Stack<State> States { get => states; set => states = value; }
    }
}
