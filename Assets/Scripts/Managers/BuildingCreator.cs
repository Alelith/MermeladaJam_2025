using UnityEngine;

namespace Managers
{
    public class BuildingCreator : MonoBehaviour
    {
        [SerializeField]
        int moneyCost = 100;
        [SerializeField]
        GameObject buildingPrefab;
        
        public int MoneyCost => moneyCost;

        public void CreateBuilding() => Instantiate(buildingPrefab, transform.position, Quaternion.identity);
    }
}
