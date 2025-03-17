using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] Sprite better;
    
    public void Upgrade()
    {
        GetComponent<SpriteRenderer>().sprite = better;
    }
}
