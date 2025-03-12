using Managers;
using UnityEngine;

namespace NPCs
{
    public class Enemy : Entity
    {
        protected override void Start()
        {
            objetive = Town.Instance.TownCenter;
            
            base.Start();
        }

        protected override void OnIdleEnter() { }

        protected override void Idle()
        {
            if (Vector2.Distance(transform.position, objetive.transform.position) > 1)
                brain.PushState(Move, OnMoveEnter, OnMoveExit);
        }

        protected override void OnIdleExit()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMoveEnter()
        {
            throw new System.NotImplementedException();
        }

        protected override void Move()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMoveExit()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnAttackEnter()
        {
            throw new System.NotImplementedException();
        }

        protected override void Attack()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnAttackExit()
        {
            throw new System.NotImplementedException();
        }
    }
}
