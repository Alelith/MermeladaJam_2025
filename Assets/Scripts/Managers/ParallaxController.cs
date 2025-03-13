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

        Vector3[] initialPositions;

        void Start()
        {
            initialPositions = new Vector3[parallaxLayers.Length];
            for (int i = 0; i < parallaxLayers.Length; i++)
                initialPositions[i] = parallaxLayers[i].transform.position;
        }

        void Update()
        {
            for (int i = 0; i < parallaxLayers.Length; i++)
                parallaxLayers[i].transform.position = initialPositions[i] + (player.position - player.position * parallaxFactors[i]);
        }
    }
}
