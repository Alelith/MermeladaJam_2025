using UnityEngine;

namespace Managers
{
    public class Tower : Building
    {
        [SerializeField]
        
        int cats = 2;

        public int Cats { get => cats; set => cats = value; }
    }
}
