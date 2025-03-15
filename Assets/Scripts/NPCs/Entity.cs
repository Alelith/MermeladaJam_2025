using AI;
using UnityEngine;

namespace NPCs
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        protected float attackCooldown;

        [SerializeField] 
        protected float attackDamage;

        protected Transform objetive;
        
        protected StateMachine brain;

        protected bool isAttacking;

        protected float attackTimer;
        
        protected virtual void Start() 
        {
            brain = new StateMachine();
            
            brain.PushState(Idle, OnIdleEnter, OnIdleExit);
        }

        protected virtual void Update() => brain.Update();

        protected abstract void OnIdleEnter();

        protected abstract void Idle();
        
        protected abstract void OnIdleExit();

        protected abstract void OnMoveEnter();

        protected abstract void Move();

        protected abstract void OnMoveExit();

        protected abstract void OnAttackEnter();

        protected abstract void Attack();

        protected abstract void OnAttackExit();
    }
}
