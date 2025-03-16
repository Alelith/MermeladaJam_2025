using System;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 50)]
        float speed = 10;

        [SerializeField] 
        CanvasGroup canvas;
        [SerializeField] 
        Button button;
        [SerializeField] 
        TextMeshProUGUI text;
        
        InputActions actions;
        Rigidbody2D rb;
        SpriteRenderer spriteRenderer;
        
        Vector2 movement;

        int tempCost;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            actions = new InputActions();
        
            actions.Player.Move.started += ctx => Move(ctx.ReadValue<Vector2>());
            actions.Player.Move.canceled += ctx => Move(ctx.ReadValue<Vector2>());
            actions.Player.Pause.performed += ctx => GameManager.Instance.Pause();
            
            actions.Enable();
        }

        void FixedUpdate()
        {
            rb.linearVelocity = movement * speed;
            
            if (movement.x != 0)
                spriteRenderer.flipX = movement.x < 0;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Aqui entro");
            
            if (other.CompareTag("Building"))
            {
                var building = other.GetComponent<Building>();

                if (building.IsBroken)
                {
                    text.text = $"{building.RepairPrice} Dabloons";
                
                    button.onClick.RemoveAllListeners();
                
                    button.onClick.AddListener(() =>
                    {
                        if (building.RepairPrice > Town.Instance.Gold)
                        {
                            Debug.Log("Not enough money");
                            return;
                        }
                    
                        Town.Instance.Gold -= building.RepairPrice;
                        building.Repair();
                    
                        canvas.DOFade(0, 0.5f);
                    
                        canvas.interactable = false;
                    });
                
                    canvas.interactable = true;
                
                    canvas.DOFade(1, 0.5f);
                }
            }
            
            if (other.CompareTag("BuildingCreator"))
            {
                var buildingCreator = other.GetComponent<BuildingCreator>();
                
                text.text = $"{buildingCreator.MoneyCost} Dabloons";
                
                button.onClick.RemoveAllListeners();
                
                button.onClick.AddListener(() =>
                {
                    if (buildingCreator.MoneyCost > Town.Instance.Gold)
                    {
                        Debug.Log("Not enough money");
                        return;
                    }
                    
                    Town.Instance.Gold -= buildingCreator.MoneyCost;
                    buildingCreator.CreateBuilding();
                    
                    if (buildingCreator.BuildingPrefab.name == "Tower")
                        Town.Instance.AvailableAllies += 2;
                    
                    canvas.DOFade(0, 0.5f);
                    
                    canvas.interactable = false;
                    
                    Destroy(other.gameObject);
                });
                
                canvas.interactable = true;
                
                canvas.DOFade(1, 0.5f);
            }
            
            if (other.CompareTag("Summoner"))
            {
                var summoner = other.GetComponent<Summon>();
                
                text.text = $"{summoner.MoneyCost} Dabloons";
                
                button.onClick.RemoveAllListeners();
                
                button.onClick.AddListener(() =>
                {
                    if (summoner.MoneyCost > Town.Instance.Gold || Town.Instance.FilledAllies == Town.Instance.AvailableAllies)
                    {
                        Debug.Log("Not enough money");
                        return;
                    }
                    
                    Town.Instance.Gold -= summoner.MoneyCost;
                    summoner.SummonMichi();
                });
                
                canvas.interactable = true;
                
                canvas.DOFade(1, 0.5f);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Building") && !other.CompareTag("BuildingCreator") && !other.CompareTag("Summoner"))
                return;
            button.onClick.RemoveAllListeners();
            canvas.DOFade(0, 0.5f);
            
            canvas.interactable = false;
        }

        void OnDisable() => actions.Disable();

        void Move(Vector2 direction) => movement = direction;
    }
}
