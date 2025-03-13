using UnityEngine;

namespace Managers
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField]
        GameObject[] parallaxLayers;

        [SerializeField]
        float[] parallaxFactors;

        [SerializeField]
        Transform player;

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
