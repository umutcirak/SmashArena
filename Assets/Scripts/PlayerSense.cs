using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSense : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject warningPrefab;

    public Player[] allEnemies;
    public bool[] visibleEnemies;
    public GameObject[] warningObjects;



    void Start()
    {
        Setup();        
    }

    void Setup()
    {
        allEnemies = enemies.GetComponentsInChildren<Player>();
        visibleEnemies = new bool[allEnemies.Length];
        warningObjects = new GameObject[allEnemies.Length];
    }



    void Update()
    {
        CheckEnemies();
        SetAlert();
    }


    void CheckEnemies()
    {
        for (int i = 0; i < allEnemies.Length; i++)
        {
            Player enemy = allEnemies[i];
            float distance = Vector3.Distance(enemy.transform.localPosition, this.transform.localPosition);

            if (distance < player.GetSense())
            {
                visibleEnemies[i] = true;
            }
            else
            {
                visibleEnemies[i] = false;
            }
        }    
    }


    void SetAlert()
    {
        for (int i = 0; i < visibleEnemies.Length; i++)
        {
            if (visibleEnemies[i] && warningObjects[i] == null)
            {
                GameObject warning = Instantiate(warningPrefab);
                Vector3 pos = GetWarningPosition(allEnemies[i], warning);
                warning.transform.localPosition = pos;
                
                warningObjects[i] = warning;
            }
            else
            {
                if(warningObjects[i] != null)
                {                    
                    warningObjects[i].SetActive(false);
                    Destroy(warningObjects[i]);
                    warningObjects[i] = null;
                }
            }
        }
    }


    Vector3 GetWarningPosition(Player enemy, GameObject warning)
    {
        Vector3 direction = (this.transform.position - enemy.transform.position).normalized;
        Vector3 warningPos = direction * 10f;

        Vector3 playerPos = player.transform.position;   
        
        Vector2 xBoundaries = new Vector2(playerPos.x - 2f, playerPos.x + 2f);
        Vector2 yBoundaries = new Vector2(playerPos.x - 6f, playerPos.x + 5f);

        float warningPosX = Mathf.Clamp(warningPos.x, xBoundaries.x, xBoundaries.y);
        float warningPosY = Mathf.Clamp(warningPos.y, yBoundaries.x, yBoundaries.y);

        warning.transform.parent = player.transform;
        warningPos = new Vector3(warningPosX, warningPosY, 0f);

        return warningPos;


    }







}
