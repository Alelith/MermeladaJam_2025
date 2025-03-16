using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
        
        Color day = new Color(0f, 0.06f, 0.5f);
        Color night = new Color(1f, 0.8f, 0.5f);

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        void Update()
        {
            dayNightCycle.transform.Rotate(Vector3.forward, Time.deltaTime * 360 / dayDuration);
            
            //globalLight.color = Color.Lerp(night, day, Mathf.PingPong(Time.time  / dayDuration, 1));
            
            Debug.Log(DayCount);
        }

        public void Pause()
        {
            if (Town.Instance.Gold <= 0) return;
            
            pauseMenu.DOFade(1, 0.5f);
            pauseMenu.blocksRaycasts = true;
            pauseMenu.interactable = true;
            
            Time.timeScale = 0;
        }
        
        public void Resume()
        {
            pauseMenu.DOFade(0, 0.5f);
            pauseMenu.blocksRaycasts = false;
            pauseMenu.interactable = false;
            
            Time.timeScale = 1;
        }
        
        public int DayCount => (int)(Time.time / dayDuration);
        
        public bool IsDay => dayNightCycle.transform.rotation.eulerAngles.z < 180;
    }
}
