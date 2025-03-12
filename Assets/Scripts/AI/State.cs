using System;

namespace AI
{
    public class State 
    {
        Action activeAction, onEnterAction, onExitAction;

        public State(Action active, Action onEnter, Action onExit)
        {
            activeAction = active;
            onEnterAction = onEnter;
            onExitAction = onExit;
        }

        public void Execute() => activeAction?.Invoke();

        public void OnEnter() => onEnterAction?.Invoke();

        public void OnExit() => onExitAction?.Invoke();

        public Action ActiveAction { get => activeAction; set => activeAction = value; }
        public Action OnEnterAction { get => onEnterAction; }
        public Action OnExitAction { get => onExitAction; }
    }
}
