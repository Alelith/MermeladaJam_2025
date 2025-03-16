using System;
using UnityEngine;

namespace Managers
{
    public class BuildingCreator : MonoBehaviour
    {
        [SerializeField]
        int moneyCost = 100;
        [SerializeField]
        GameObject buildingPrefab;
        
        [SerializeField]
        AudioClip clip;

        [SerializeField] 
        float y;
        
        public int MoneyCost => moneyCost;
        
        public GameObject BuildingPrefab => buildingPrefab;

        public void CreateBuilding()
        {
            GameObject instance = Instantiate(buildingPrefab, new(transform.position.x, y, 1), Quaternion.identity);
            
            GameManager.Instance.Sfx.PlayOneShot(clip);
            
            Town.Instance.Buildings.Add(instance.GetComponent<Building>());
        }
    }
}
