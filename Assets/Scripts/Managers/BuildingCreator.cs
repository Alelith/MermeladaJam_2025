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
        float y;
        
        public int MoneyCost => moneyCost;
        
        public GameObject BuildingPrefab => buildingPrefab;

        public void CreateBuilding()
        {
            GameObject instance = Instantiate(buildingPrefab, new(transform.position.x, y, 1), Quaternion.identity);
            
            Town.Instance.Buildings.Add(instance.GetComponent<Building>());
        }
    }
}
