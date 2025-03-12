using UnityEngine;

namespace Managers
{
    public class Town : MonoBehaviour
    {
        public static Town Instance { get; private set; }

        [SerializeField] 
        Transform townCenter;
        
        public Transform TownCenter => townCenter;
    
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    }
}
