using System;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;


namespace NPCs
{
    public class Enemy : Entity
    {
        [SerializeField] 
        protected float health;
        
        [SerializeField]
        [Range(0, 1)]
        float speed;
        
        [SerializeField]
        AudioClip attackClip;

        Building building;

        public float Health { get => health; set => health = value; }
        
        protected override void Start()
        {
            objetive = Town.Instance.TownCenter;
            
            base.Start();
        }

        void FixedUpdate()
        {
            if (!GameManager.Instance.IsDay) return;
            Destroy(gameObject, Random.Range(1, 3));
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Building"))
            {
                var building = other.GetComponent<Building>();
                if (!building.IsBroken)
                {
                    isAttacking = true;
                    this.building = building;
                }
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {
                    attackTimer = attackCooldown;
                    Town.Instance.Gold -= Mathf.RoundToInt(attackDamage);
                }
            }
        }

        protected override void OnIdleEnter() { }

        protected override void Idle()
        {
            if (isAttacking)
                brain.PushState(Attack, OnAttackEnter, OnAttackExit);
            else
                transform.position = Vector3.MoveTowards(transform.position, objetive.position, speed * Time.deltaTime);
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
                building.Health -= attackDamage;
                
                GameManager.Instance.Sfx.PlayOneShot(attackClip);

                if (building.Health <= 0)
                {
                    isAttacking = false;
                    building.Broke();
                    building = null;
                    brain.PopState();
                }
            }
        }

        protected override void OnAttackExit() { }
    }
}
