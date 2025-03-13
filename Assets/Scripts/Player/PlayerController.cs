using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 50)]
        float speed = 10;
        
        [SerializeField]
        GameObject[] buildings;
        
        InputActions actions;
        Rigidbody2D rb;
        
        Vector2 movement;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            
            actions = new InputActions();
        
            actions.Player.Move.started += ctx => Move(ctx.ReadValue<Vector2>());
            actions.Player.Move.canceled += ctx => Move(ctx.ReadValue<Vector2>());
            
            actions.Enable();
        }

        void FixedUpdate() => rb.linearVelocity = movement * speed;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Building"))
            {
                var building = other.GetComponent<Building>();
                
                if (building.IsBroken)
                    building.Repair();
            }
        }

        void OnDisable() => actions.Disable();

        void Move(Vector2 direction) => movement = direction;
    }
}
