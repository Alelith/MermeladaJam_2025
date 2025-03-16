using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
    
        [SerializeField]
        GameObject dayNightCycle;
    
        [SerializeField]
        [Range(0, 3600)]
        float dayDuration = 1200;

        [SerializeField] 
        CanvasGroup pauseMenu;
        
        [SerializeField]
        AudioSource bgMusic;

        [SerializeField] 
        AudioSource sfx;

        [SerializeField] AudioClip dayBGM;
        [SerializeField] AudioClip nightBGM;
        
        [SerializeField] AudioClip EnemyDeath;
        
        Color day = new Color(0f, 0.06f, 0.5f);
        Color night = new Color(1f, 0.8f, 0.5f);
        
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
        
        public void Resume()
        {
            pauseMenu.DOFade(0, 0.5f);
            pauseMenu.blocksRaycasts = false;
            pauseMenu.interactable = false;
            
            Time.timeScale = 1;
        }

        public void Exit() => SceneManager.LoadScene("MainMenu");

        public void PlayEnemyDead() => sfx.PlayOneShot(EnemyDeath);
        
        public int DayCount => (int)(Time.time / dayDuration);
        
        public bool IsDay => dayNightCycle.transform.rotation.eulerAngles.z < 180;
    }
}
