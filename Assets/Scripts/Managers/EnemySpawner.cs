using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manages the spawning of enemies in the game.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The rate at which enemies spawn.")]
        float spawnRate = 1;

        [SerializeField]
        [Tooltip("The prefabs for the enemies.")]
        GameObject[] enemyPrefab;

        [SerializeField]
        [Tooltip("The GameObject that this spawner depends on.")]
        GameObject spawnerDependence;

        [SerializeField]
        [Tooltip("The spawn probabilities for each enemy.")]
        float[] spawnProbabilities;

        void Update()
        {
            if (GameManager.Instance.IsDay || spawnerDependence) return;

            if (Time.time % spawnRate < Time.deltaTime)
                SpawnEnemy();
        }

        /// <summary>
        /// Spawns a new enemy.
        /// </summary>
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
