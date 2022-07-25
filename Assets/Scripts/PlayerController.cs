using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] [Range(0f,10f)]float slowSpeed;
        
    Vector2 moveInput;
    Rigidbody rgbd;
    Vector3 currentVelocity;

    void Awake()
    {
        
    }
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SlowDown();
        Debug.Log(rgbd.velocity.normalized);
    }

    void OnMove(InputValue value)
    {
        if (player.isAI) { return; }
        moveInput = value.Get<Vector2>();      
               
    }


    void Move()
    {
        if (player.isAI) { return; }
        // Physics Movement
         Vector3 forceInput = new Vector3(moveInput.x, moveInput.y, 0f) * player.GetSpeed() * Time.deltaTime * 10f;
         rgbd.AddRelativeForce(forceInput);
    }

    void SlowDown()
    {
        if(moveInput.magnitude > 0.1f && player.isAI) { return; }

        float speedMultiplier = 1 - ( (slowSpeed / 10f )* Time.deltaTime);
        currentVelocity = rgbd.velocity * speedMultiplier;

        if (rgbd.velocity.magnitude > 0.05f)
        {            
            rgbd.velocity = currentVelocity;         
        }
        else
        {
            rgbd.velocity = Vector3.zero;
        }

        
    }




}
