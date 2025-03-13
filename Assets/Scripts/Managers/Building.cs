using System;
using UnityEngine;

namespace Managers
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        protected float health = 100;
        
        [SerializeField]
        protected int repairPrice = 100;
        
        [SerializeField]
        protected Sprite fixedBuilding;
        [SerializeField]
        protected Sprite brokenBuilding;
        
        protected bool isBroken = false;
        
        protected SpriteRenderer spriteRenderer;
        protected Collider2D collider2D;
        
        public bool IsBroken => isBroken;

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            collider2D = GetComponent<Collider2D>();
        }

        public virtual void Broke()
        {
            isBroken = true;
            collider2D.isTrigger = true;
            spriteRenderer.sprite = brokenBuilding;
        }
        
        public virtual void Repair()
        {
            if (isBroken)
            {
                if (Town.Instance.Gold >= repairPrice)
                {
                    Town.Instance.Gold -= repairPrice;
                    isBroken = false;
                    health = 100;
                    collider2D.isTrigger = false;
            
                    spriteRenderer.sprite = fixedBuilding;
                }
            }
        }

        public float Health { get => health; set => health = value; }
    }
}
