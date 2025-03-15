using NPCs;
using UnityEngine;

namespace Managers
{
    public class Summon : MonoBehaviour
    {
        [SerializeField]
        GameObject summonPrefab;
    
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (Town.Instance.AvailableAllies > 0)
                    Town.Instance.AsignVillager(Instantiate(summonPrefab, transform.position, Quaternion.identity).GetComponent<Ally>());
            }
        }
    }
}
