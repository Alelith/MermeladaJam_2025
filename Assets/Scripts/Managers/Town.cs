using System;
using System.Collections.Generic;
using DG.Tweening;
using NPCs;
using TMPro;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manages the town and its buildings.
    /// </summary>
    public class Town : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the Town.
        /// </summary>
        public static Town Instance { get; private set; }

        [SerializeField]
        [Tooltip("The center point of the town.")]
        Transform townCenter;

        [SerializeField]
        [Tooltip("List of all buildings in the town.")]
        List<Building> buildings;

        [SerializeField]
        [Tooltip("Canvas group for the game over screen.")]
        CanvasGroup gameOverScreen;

        [SerializeField]
        [Tooltip("Text element to display the current gold amount.")]
        TextMeshProUGUI goldText;

        /// <summary>
        /// Number of available allies in the town.
        /// </summary>
        int availableAllies;

        /// <summary>
        /// Number of filled allies in the town.
        /// </summary>
        int filledAllies;

        /// <summary>
        /// Amount of gold the town has.
        /// </summary>
        public int Gold { get; set; } = 10;

        /// <summary>
        /// Number of available allies in the town.
        /// </summary>
        public int AvailableAllies { get => availableAllies; set => availableAllies = value; }

        /// <summary>
        /// Number of filled allies in the town.
        /// </summary>
        public int FilledAllies { get => filledAllies; set => filledAllies = value; }

        /// <summary>
        /// List of all buildings in the town.
        /// </summary>
        public List<Building> Buildings => buildings;

        /// <summary>
        /// The center point of the town.
        /// </summary>
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
            goldText.text = Gold.ToString();

            if (Gold >= 0) return;
            Debug.Log("Game Over");

            gameOverScreen.DOFade(1, 0.5f).OnComplete(() => Time.timeScale = 0);
            gameOverScreen.blocksRaycasts = true;
            gameOverScreen.interactable = true;
        }

        /// <summary>
        /// Assigns a villager to a building in the town.
        /// </summary>
        /// <param name="ally">The villager to assign.</param>
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
