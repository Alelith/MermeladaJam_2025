using System;
using NPCs;
using UnityEngine;

namespace Managers
{
    public class Town : MonoBehaviour
    {
        public static Town Instance { get; private set; }

        [SerializeField] 
        Transform townCenter;
        
        [SerializeField]
        Building[] buildings;

        int availableAllies;
        
        int filledAllies;
        
        public int Gold { get; set; } = 1000;

        public int AvailableAllies { get => availableAllies; set => availableAllies = value; }
        public int FilledAllies { get => filledAllies; set => filledAllies = value; }

        public Transform TownCenter => townCenter;
    
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        void Start()
        {
            buildings = FindObjectsOfType<Building>();

            foreach (var building in buildings)
            {
                if (building is Tower tower)
                    availableAllies += 2 - tower.Allies;
            }
        }

        void Update()
        {
            if (Gold <= 0)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }
        }
        
        public void AsignVillager(Ally ally)
        {
            foreach (var building in buildings)
            {
                if (building is Tower tower)
                {
                    if (tower.Allies < 2)
                    {
                        tower.AsignVillager(ally);

                        filledAllies++;
                        
                        break;
                    }
                }
            }
        }
    }
}
