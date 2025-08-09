using System;
using System.Collections.Generic;
using NPCs;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manages the tower and its allied NPCs.
    /// </summary>
    public class Tower : Building
    {
        [SerializeField]
        [Tooltip("The spawn points for allied NPCs.")]
        List<Transform> spawnPoints;

        /// <summary>
        /// The allies assigned to each spawn point.
        /// </summary>
        Dictionary<Transform, Ally> allies = new Dictionary<Transform, Ally>();

        protected override void Awake()
        {
            base.Awake();

            foreach (var spawn in spawnPoints)
                allies.Add(spawn, null);
        }

        /// <summary>
        /// Called when the tower is destroyed.
        /// </summary>
        public override void Broke()
        {
            base.Broke();

            foreach (var ally in allies)
                if (ally.Value != null)
                    Destroy(ally.Value.gameObject);

            Town.Instance.AvailableAllies -= 2;
            Town.Instance.FilledAllies -= Allies;
            allies = new Dictionary<Transform, Ally>();
            foreach (var spawn in spawnPoints)
                allies.Add(spawn, null);
        }

        /// <summary>
        /// Called when the tower is repaired.
        /// </summary>
        public override void Repair()
        {
            Town.Instance.AvailableAllies += 2;

            base.Repair();
        }

        /// <summary>
        /// Assigns a villager to the tower.
        /// </summary>
        public void AsignVillager(Ally ally)
        {
            foreach (var spawn in spawnPoints)
            {
                if (allies[spawn] == null)
                {
                    allies[spawn] = ally;
                    ally.Tower = spawn;

                    break;
                }
            }
        }

        /// <summary>
        /// The number of allies assigned to the tower.
        /// </summary>
        public int Allies
        {
            get
            {
                int count = 0;

                foreach (var ally in allies)
                {
                    if (ally.Value != null)
                        count++;
                }

                return count;
            }
        }
    }
}
