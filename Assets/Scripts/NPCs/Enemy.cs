using Managers;
using UnityEngine;


namespace NPCs
{
    public class Enemy : Entity
    {
        [SerializeField] 
        protected float health;
        
        [SerializeField]
        [Range(0, 1)]
        float speed;

        Building building;

        public float Health { get => health; set => health = value; }
        
        protected override void Start()
        {
            objetive = Town.Instance.TownCenter;
            
            base.Start();
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
