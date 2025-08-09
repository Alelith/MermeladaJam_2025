using System;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manages the creation of buildings.
    /// </summary>
    public class BuildingCreator : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The cost to create a building.")]
        int moneyCost = 100;
        [SerializeField]
        [Tooltip("The prefab for the building.")]
        GameObject buildingPrefab;

        [SerializeField]
        [Tooltip("The audio clip played when the building is created.")]
        AudioClip clip;

        [SerializeField]
        [Tooltip("The Y position for the building.")]
        float y;

        /// <summary>
        /// The cost to create a building.
        /// </summary>
        public int MoneyCost => moneyCost;

        /// <summary>
        /// The prefab for the building.
        /// </summary>
        public GameObject BuildingPrefab => buildingPrefab;

        /// <summary>
        /// Creates a new building.
        /// </summary>
        public void CreateBuilding()
        {
            GameObject instance = Instantiate(buildingPrefab, new(transform.position.x, y, 1), Quaternion.identity);

            GameManager.Instance.Sfx.PlayOneShot(clip);

            Town.Instance.Buildings.Add(instance.GetComponent<Building>());
        }
    }
}
