using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
    
        [SerializeField]
        GameObject dayNightCycle;
    
        [SerializeField]
        [Range(0, 3600)]
        float dayDuration = 1200;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        void Update()
        {
            dayNightCycle.transform.Rotate(Vector3.forward, Time.deltaTime * 360 / dayDuration);
        }
    }
}
