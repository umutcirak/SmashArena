using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 10f)] float wallToughness;   

    public enum WallType { soft, hard, regular }
    public WallType type;

    void Start()
    {
        SetupWall();
    }


    void SetupWall()
    {              
              
        
    }


    public float GetToughness() { return wallToughness; }





}
