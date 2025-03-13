using System;
using UnityEngine;

namespace Managers
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        float health = 100;
        
        [SerializeField]
        int repairPrice = 100;
        
        [SerializeField]
        Sprite fixedBuilding;
        [SerializeField]
        Sprite brokenBuilding;
        
        bool isBroken = false;
        
        SpriteRenderer spriteRenderer;
        Collider2D collider2D;
        
        public bool IsBroken => isBroken;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            collider2D = GetComponent<Collider2D>();
        }

        public void Broke()
        {
            isBroken = true;
            collider2D.isTrigger = true;
            spriteRenderer.sprite = brokenBuilding;
        }
        
        public void Repair()
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
