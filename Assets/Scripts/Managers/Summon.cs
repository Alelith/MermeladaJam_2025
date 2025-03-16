using UnityEngine;

namespace Managers
{
    public class Summon : MonoBehaviour
    {
        [SerializeField]
        GameObject summonPrefab;
        
        [SerializeField]
        AudioClip clip;
        
        public void SummonMichi() 
        {
            GameManager.Instance.Sfx.PlayOneShot(clip);
            
            Instantiate(summonPrefab, transform.position, Quaternion.identity);
        }
        
        public int MoneyCost { get; } = 2;
    }
}
