using System;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Represents a building in the game.
    /// </summary>
    public class Building : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The health of the building.")]
        protected float health = 100;

        [SerializeField]
        [Tooltip("The cost to repair the building.")]
        protected int repairPrice = 100;

        [SerializeField]
        [Tooltip("The cost to upgrade the building.")]
        protected int upgradePrice = 300;

        [SerializeField]
        [Tooltip("The sprite for the building when it is not broken.")]
        protected Sprite fixedBuilding;
        [SerializeField]
        [Tooltip("The sprite for the building when it is broken.")]
        protected Sprite brokenBuilding;
        [SerializeField]
        [Tooltip("The sprite for the building when it is made of rock.")]
        protected Sprite rockBuilding;

        [SerializeField]
        [Tooltip("The audio clip played when the building breaks.")]
        AudioClip breakClip;

        [SerializeField]
        [Tooltip("The audio clip played when the building is repaired.")]
        AudioClip repairClip;

        /// <summary>
        /// Indicates whether the building is broken.
        /// </summary>
        protected bool isBroken = false;

        /// <summary>
        /// Indicates whether the building is made of rock.
        /// </summary>
        protected bool isRock = false;

        /// <summary>
        /// The sprite renderer for the building.
        /// </summary>
        protected SpriteRenderer spriteRenderer;

        /// <summary>
        /// The collider for the building.
        /// </summary>
        protected Collider2D collider2D;

        /// <summary>
        /// Indicates whether the building is broken.
        /// </summary>
        public bool IsBroken => isBroken;

        /// <summary>
        /// Indicates whether the building is made of rock.
        /// </summary>
        public bool IsRock => isRock;

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2D = GetComponent<Collider2D>();
        }

        /// <summary>
        /// Called when the building is broken.
        /// </summary>
        public virtual void Broke()
        {
            isBroken = true;
            collider2D.isTrigger = true;
            spriteRenderer.sprite = brokenBuilding;

            GameManager.Instance.Sfx.PlayOneShot(breakClip);
        }

        /// <summary>
        /// Called when the building is repaired.
        /// </summary>
        public virtual void Repair()
        {
            isBroken = false;
            health = 100;
            collider2D.isTrigger = false;

            spriteRenderer.sprite = isRock ? rockBuilding : fixedBuilding;

            GameManager.Instance.Sfx.PlayOneShot(repairClip);
        }

        /// <summary>
        /// The health of the building.
        /// </summary>
        public float Health { get => health; set => health = value; }

        /// <summary>
        /// The cost to repair the building.
        /// </summary>
        public int RepairPrice => repairPrice;
    }
}
