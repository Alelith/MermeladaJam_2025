using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manages the summoning of characters.
    /// </summary>
    public class Summon : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The prefab for the summoned character.")]
        GameObject summonPrefab;

        [SerializeField]
        [Tooltip("The audio clip played when summoning.")]
        AudioClip clip;

        /// <summary>
        /// Summons the character Michi.
        /// </summary>
        public void SummonMichi()
        {
            GameManager.Instance.Sfx.PlayOneShot(clip);

            Instantiate(summonPrefab, transform.position, Quaternion.identity);
        }

        /// <summary>
        /// The cost in money to summon the character.
        /// </summary>
        public int MoneyCost { get; } = 2;
    }
}
