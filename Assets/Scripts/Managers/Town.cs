using System;
using System.Collections.Generic;
using DG.Tweening;
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
        List<Building> buildings;
        
        [SerializeField]
        CanvasGroup gameOverScreen;

        int availableAllies;
        
        int filledAllies;
        
        public int Gold { get; set; } = 1000;

        public int AvailableAllies { get => availableAllies; set => availableAllies = value; }
        public int FilledAllies { get => filledAllies; set => filledAllies = value; }

        public List<Building> Buildings => buildings;
        
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
            buildings = new(FindObjectsOfType<Building>());

            foreach (var building in buildings)
            {
                if (building is Tower tower)
                    availableAllies += 2 - tower.Allies;
            }
        }

        void Update()
        {
            if (Gold > 0) return;
            Debug.Log("Game Over");

            gameOverScreen.DOFade(1, 0.5f);
            gameOverScreen.blocksRaycasts = true;
            gameOverScreen.interactable = true;
            
            Time.timeScale = 0;
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
