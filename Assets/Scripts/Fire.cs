using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fire : MonoBehaviour
{
    Light2D light;

    float random;
    
    void Start()
    {
        random = Random.value;
        
        light = GetComponent<Light2D>();
    }
    
    void Update()
    {
        light.intensity = Mathf.PerlinNoise(Time.time, random * 100);
    }
}
