using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   

    PlayerSingleton playerValues;

    [Header("Player Settings")]
    [SerializeField] [Range(0f, 10f)] float sense = 5f;
    [SerializeField] [Range(1f, 10f)] float speed = 5f;
    [SerializeField] [Range(1f, 10f)] float toughness = 5f;
    [SerializeField] [Range(1f, 10f)] float weight = 5f;
    [SerializeField] [Range(1f, 10f)] float size = 5f;

    [Header("AI Settings")]
    public bool isAI;

    bool isAlive;
    void Awake()
    {
        playerValues = FindObjectOfType<PlayerSingleton>();
    }
    void Start()
    {
        SetupPlayer();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void SetupPlayer()
    {
        
        float sizeNormalized = size / 5f ;        
        GetComponent<Transform>().localScale = new Vector3(sizeNormalized, sizeNormalized, sizeNormalized);

        float weightNormalized = weight / 50f;      
        GetComponent<Rigidbody>().mass = weightNormalized;

        float bounciness = Mathf.Clamp(toughness / weight / 5f,0.1f,1f);
        GetComponent<SphereCollider>().material.bounciness = bounciness;
                

    }

    



    public float GetSense() { return sense; }
    public float GetSpeed() { return speed; }
    public float GetWeight() { return weight; }
    public float GetToughness() { return toughness; }
    public float GetSize() { return size; }


}
