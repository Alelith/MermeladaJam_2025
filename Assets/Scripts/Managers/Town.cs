using System;
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
        
        public int Gold { get; set; } = 1000;

        public int AvailableAllies { get => availableAllies; set => availableAllies = value; }

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
                if (building is Tower)
                    availableAllies += ((Tower)building).Cats;
            }
        }
        
        public void AsignVillager(Ally ally)
        {
            foreach (var building in buildings)
            {
                if (building is Tower)
                {
                    if (((Tower)building).Cats > 0)
                    {
                        availableAllies--;
                        ((Tower)building).Cats--;
                        
                        break;
                    }
                }
            }
        }
    }
}
