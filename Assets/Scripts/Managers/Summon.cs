using UnityEngine;

namespace Managers
{
    public class Summon : MonoBehaviour
    {
        [SerializeField]
        GameObject summonPrefab;
        
        public void SummonMichi() => Instantiate(summonPrefab, transform.position, Quaternion.identity);
        
        public int MoneyCost { get; } = 100;
    }
}
