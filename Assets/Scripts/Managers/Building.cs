using UnityEngine;

namespace Managers
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        float health = 100;

        public float Health { get => health; set => health = value; }
    }
}
