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
        protected int upgradePrice = 300;
        
        [SerializeField]
        protected Sprite fixedBuilding;
        [SerializeField]
        protected Sprite brokenBuilding;
        [SerializeField]
        protected Sprite rockBuilding;
        
        [SerializeField]
        AudioClip breakClip;
        
        [SerializeField]
        AudioClip repairClip;
        
        protected bool isBroken = false;

        protected bool isRock = false;
        
        protected SpriteRenderer spriteRenderer;
        protected Collider2D collider2D;
        
        public bool IsBroken => isBroken;
        public bool IsRock => isRock;

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
            
            GameManager.Instance.Sfx.PlayOneShot(breakClip);
        }
        
        public virtual void Repair()
        {
            isBroken = false;
            health = 100;
            collider2D.isTrigger = false;
    
            spriteRenderer.sprite = isRock ? rockBuilding : fixedBuilding;
            
            GameManager.Instance.Sfx.PlayOneShot(repairClip);
        }

        public float Health { get => health; set => health = value; }

        public int RepairPrice => repairPrice;
    }
}
