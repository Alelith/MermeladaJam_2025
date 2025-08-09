using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manages the parallax scrolling effect for background layers.
    /// </summary>
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The GameObjects representing the parallax layers.")]
        GameObject[] parallaxLayers;

        [SerializeField]
        [Tooltip("The parallax movement multipliers for each layer.")]
        float[] parallaxFactors;

        [SerializeField]
        [Tooltip("The transform representing the player.")]
        Transform player;

        /// <summary>
        /// The initial positions of the parallax layers.
        /// </summary>
        float[] initialPositions;

        void Start()
        {
            initialPositions = new float[parallaxLayers.Length];
            for (int i = 0; i < parallaxLayers.Length; i++)
                initialPositions[i] = parallaxLayers[i].transform.position.x;
        }

        void Update()
        {
            for (int i = 0; i < parallaxLayers.Length; i++)
                parallaxLayers[i].transform.position = new(initialPositions[i] + (player.position.x - player.position.x * parallaxFactors[i]), parallaxLayers[i].transform.position.y);
        }
    }
}
