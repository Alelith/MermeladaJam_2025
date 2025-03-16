using System;
using Managers;
using UnityEngine;

namespace NPCs
{
    public class Ally : Entity
    {
        bool isOnTower;

        Enemy enemy;
        
        public Transform Tower { get; set; }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                isAttacking = true;
                
                enemy = other.GetComponent<Enemy>();
            }
        }

        protected override void OnIdleEnter() { }

        protected override void Idle()
        {
            if (!isOnTower)
                brain.PushState(Move, OnMoveEnter, OnMoveExit);
            else if (isAttacking)
                brain.PushState(Attack, OnAttackEnter, OnAttackExit);
        }

        protected override void OnIdleExit() { }

        protected override void OnMoveEnter() => animator.SetBool("IsWalking", true);

        protected override void Move()
        {
            if (Tower)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Tower.position.x, transform.position.y), 2 * Time.deltaTime);

                if (Mathf.Abs(transform.position.x - Tower.position.x) < 5f)
                {
                    transform.position = Tower.position;
                    isOnTower = true;
                    brain.PopState();
                }
            }
            else
                Town.Instance.AsignVillager(this);
        }

        protected override void OnMoveExit() => animator.SetBool("IsWalking", false);

        protected override void OnAttackEnter() => animator.SetBool("IsAttacking", true);

        protected override void Attack()
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = attackCooldown;
                enemy.Health -= attackDamage;

                if (enemy.Health <= 0)
                {
                    isAttacking = false;
                    Destroy(enemy.gameObject);
                    enemy = null;
                    brain.PopState();
                    
                    GameManager.Instance.PlayEnemyDead();
                    
                    //Town.Instance.Gold += 100;
                }
            }
        }

        protected override void OnAttackExit() => animator.SetBool("IsAttacking", false);
    }
}
