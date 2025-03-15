using UnityEngine;

namespace NPCs
{
    public class Ally : Entity
    {
        bool isOnTower;
        
        public Transform Tower { get; set; }
        
        protected override void OnIdleEnter() { }

        protected override void Idle()
        {
            if (!isOnTower)
            {
                brain.PushState(Move, OnMoveEnter, OnMoveExit);
            }
            else if (isAttacking)
            {
                brain.PushState(Attack, OnAttackEnter, OnAttackExit);
            }
        }

        protected override void OnIdleExit() { }

        protected override void OnMoveEnter() { }

        protected override void Move()
        {
            
        }

        protected override void OnMoveExit() { }

        protected override void OnAttackEnter() { }

        protected override void Attack()
        {
            
        }

        protected override void OnAttackExit() { }
    }
}
