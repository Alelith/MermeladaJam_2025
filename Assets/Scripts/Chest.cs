using Managers;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    string message = "Open chest!";
    
    [SerializeField]
    Sprite openSprite;

    [SerializeField] 
    int money;

    public string Message => message;

    public bool IsOpen { get; private set; } = false;
    
    public void Open()
    {
        Debug.Log(message);
        IsOpen = true;
        GetComponent<SpriteRenderer>().sprite = openSprite;
        Town.Instance.Gold += money;
    }
}
