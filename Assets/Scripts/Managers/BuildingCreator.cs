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

        public void CreateBuilding() => Instantiate(buildingPrefab, new(transform.position.x, y, 1), Quaternion.identity);
    }
}
