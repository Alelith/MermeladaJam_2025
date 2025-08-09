using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Managers
{
    /// <summary>
    /// Manages the overall game state and progression.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton instance of the GameManager.
        /// </summary>
        public static GameManager Instance { get; private set; }

        [SerializeField]
        [Tooltip("The GameObject that controls the day-night cycle.")]
        GameObject dayNightCycle;

        [SerializeField]
        [Range(0, 3600)]
        [Tooltip("The duration of a day in seconds.")]
        float dayDuration = 1200;

        [SerializeField]
        [Tooltip("The canvas group for the pause menu.")]
        CanvasGroup pauseMenu;

        [SerializeField]
        [Tooltip("The audio source for the background music.")]
        AudioSource bgMusic;

        [SerializeField]
        [Tooltip("The audio source for the sound effects.")]
        AudioSource sfx;

        [SerializeField]
        [Tooltip("The audio clip played during the day.")]
        AudioClip dayBGM;
        [SerializeField]
        [Tooltip("The audio clip played during the night.")]
        AudioClip nightBGM;

        [SerializeField]
        [Tooltip("The audio clip played when an enemy dies.")]
        AudioClip EnemyDeath;

        /// <summary>
        /// The color of the day.
        /// </summary>
        Color day = new Color(0f, 0.06f, 0.5f);
        /// <summary>
        /// The color of the night.
        /// </summary>
        Color night = new Color(1f, 0.8f, 0.5f);

        /// <summary>
        /// The audio source for the sound effects.
        /// </summary>
        public AudioSource Sfx => sfx;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        bool temp;

        void Update()
        {
            dayNightCycle.transform.Rotate(Vector3.forward, Time.deltaTime * 360 / dayDuration);

            // Check if the day/night state has changed
            if (temp != IsDay)
            {
                temp = IsDay;
                bgMusic.DOFade(0, 1).OnComplete(() =>
                {
                    bgMusic.clip = IsDay ? dayBGM : nightBGM;
                    bgMusic.Play();
                    bgMusic.DOFade(1, 1);
                });
            }

            Debug.Log(DayCount);
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void Pause()
        {
            if (Town.Instance.Gold <= 0) return;

            pauseMenu.DOFade(1, 0.5f).OnComplete(() =>
            {
                pauseMenu.blocksRaycasts = true;
                pauseMenu.interactable = true;

                Time.timeScale = 0;
            });
        }

        /// <summary>
        /// Resumes the game.
        /// </summary>
        public void Resume()
        {
            pauseMenu.DOFade(0, 0.5f);
            pauseMenu.blocksRaycasts = false;
            pauseMenu.interactable = false;

            Time.timeScale = 1;
        }

        /// <summary>
        /// Exits the game and returns to the main menu.
        /// </summary>
        public void Exit() => SceneManager.LoadScene("MainMenu");

        /// <summary>
        /// Plays the sound effect for when an enemy dies.
        /// </summary>
        public void PlayEnemyDead() => sfx.PlayOneShot(EnemyDeath);

        /// <summary>
        /// The current day count.
        /// </summary>
        public int DayCount => (int)(Time.time / dayDuration);

        /// <summary>
        /// Indicates whether it is currently day.
        /// </summary>
        public bool IsDay => dayNightCycle.transform.rotation.eulerAngles.z < 180;
    }
}
