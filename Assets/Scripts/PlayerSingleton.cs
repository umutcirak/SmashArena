using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    int selectedPlayer;
    public float health = 560f;
    public float score = 31;    


    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instances = FindObjectsOfType(GetType()).Length;
        if(instances > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
