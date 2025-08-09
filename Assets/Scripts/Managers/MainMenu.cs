using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the main menu interactions.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
