using UnityEngine;

namespace Managers
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        float spawnRate = 1;
    
        [SerializeField]
        GameObject[] enemyPrefab;

        [SerializeField] 
        GameObject spawnerDependence;

        [SerializeField] 
        float[] spawnProbabilities;
    
        void Update()
        {
            if (GameManager.Instance.IsDay || spawnerDependence) return;
        
            if (Time.time % spawnRate < Time.deltaTime) 
                SpawnEnemy();
        }
        
        void SpawnEnemy()
        {
            float random = Random.value;
            float sum = 0;
            for (int i = 0; i < spawnProbabilities.Length; i++)
            {
                sum += spawnProbabilities[i] + GameManager.Instance.DayCount * 0.1f;
                if (random < sum)
                {
                    Instantiate(enemyPrefab[i], transform.position, Quaternion.identity);
                    break;
                }
            }
        }
    }
}
