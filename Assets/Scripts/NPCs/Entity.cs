using AI;
using UnityEngine;

namespace NPCs
{
    /// <summary>
    /// Base class for all entities in the game.
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The cooldown time between attacks.")]
        protected float attackCooldown;

        [SerializeField]
        [Tooltip("The amount of damage dealt by attacks.")]
        protected float attackDamage;

        /// <summary>
        /// The target the entity is currently moving towards.
        /// </summary>
        protected Transform objective;

        /// <summary>
        /// The state machine controlling the entity's behavior.
        /// </summary>
        protected StateMachine brain;

        /// <summary>
        /// Indicates whether the entity is currently attacking.
        /// </summary>
        protected bool isAttacking;

        /// <summary>
        /// The time remaining until the entity can attack again.
        /// </summary>
        protected float attackTimer;

        /// <summary>
        /// The animator component for the entity.
        /// </summary>
        protected Animator animator;

        protected virtual void Start()
        {
            brain = new StateMachine();

            animator = GetComponent<Animator>();

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
