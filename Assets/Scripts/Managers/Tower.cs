using System.Collections.Generic;
using NPCs;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class Tower : Building
    {
        [SerializeField]
        List<Transform> spawnPoints;

        Dictionary<Transform, Ally> allies = new Dictionary<Transform, Ally>();
        
        protected override void Awake()
        {
            base.Awake();

            foreach (var spawn in spawnPoints)
                allies.Add(spawn, null);
        }

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

        public override void Repair()
        {
            Town.Instance.AvailableAllies += 2;
            
            base.Repair();
        }

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
