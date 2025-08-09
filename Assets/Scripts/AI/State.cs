using System;

namespace AI
{
    /// <summary>
    /// Represents a state in the NPCs like a patrol or idle state.
    /// </summary>
    public class State 
    {
        Action activeAction, onEnterAction, onExitAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        /// <param name="active">The action to be performed while in this state.</param>
        /// <param name="onEnter">The action to be performed when entering this state.</param>
        /// <param name="onExit">The action to be performed when exiting this state.</param>
        public State(Action active, Action onEnter, Action onExit)
        {
            activeAction = active;
            onEnterAction = onEnter;
            onExitAction = onExit;
        }

        /// <summary>
        /// Executes the active action.
        /// </summary>
        public void Execute() => activeAction?.Invoke();

        /// <summary>
        /// Invokes the onEnter action.
        /// </summary>
        public void OnEnter() => onEnterAction?.Invoke();

        /// <summary>
        /// Invokes the onExit action.
        /// </summary>
        public void OnExit() => onExitAction?.Invoke();

        /// <summary>
        /// Gets or sets the action to be performed while in this state.
        /// </summary>
        public Action ActiveAction { get => activeAction; set => activeAction = value; }

        /// <summary>
        /// Gets the action to be performed when entering this state.
        /// </summary>
        public Action OnEnterAction { get => onEnterAction; }

        /// <summary>
        /// Gets the action to be performed when exiting this state.
        /// </summary>
        public Action OnExitAction { get => onExitAction; }
    }
}
