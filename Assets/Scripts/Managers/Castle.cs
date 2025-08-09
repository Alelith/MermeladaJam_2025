using UnityEngine;

/// <summary>
/// Represents a castle in the game.
/// </summary>
public class Castle : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The upgraded sprite for the castle.")]
    Sprite better;

    /// <summary>
    /// Upgrades the castle to a better version.
    /// </summary>
    public void Upgrade()
    {
        GetComponent<SpriteRenderer>().sprite = better;
    }
}
