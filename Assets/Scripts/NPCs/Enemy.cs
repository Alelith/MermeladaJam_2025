using System;
using Managers;
using UnityEngine;

namespace NPCs
{
    public class Enemy : Entity
    {
        [SerializeField] 
        protected float health;
        
        [SerializeField]
        float attackCooldown;

        bool isAttacking;

        float attackTimer;

        Building building;
        
        protected override void Start()
        {
            objetive = Town.Instance.TownCenter;
            
            base.Start();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Building"))
            {
                isAttacking = true;
                building = other.GetComponent<Building>();
            }
        }

        protected override void OnIdleEnter() { }

        protected override void Idle()
        {
            if (isAttacking)
            {
                brain.PopState();
                brain.PushState(Attack, OnAttackEnter, OnAttackExit);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, objetive.position, 1 * Time.deltaTime);
            }
        }

        protected override void OnIdleExit() { }

        protected override void OnMoveEnter() { }

        protected override void Move() { }

        protected override void OnMoveExit() { }

        protected override void OnAttackEnter() { }

        protected override void Attack()
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = attackCooldown;
                building.Health -= 10;

                if (building.Health <= 0)
                {
                    isAttacking = false;
                    Destroy(building.gameObject);
                    building = null;
                    brain.PopState();
                }
            }
        }

        protected override void OnAttackExit() { }
    }
}
