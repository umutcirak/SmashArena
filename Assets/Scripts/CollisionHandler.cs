using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    PlayerSingleton playerValues;
    Player player;
    Rigidbody rgbd;

    Vector3 velocity;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        playerValues = FindObjectOfType<PlayerSingleton>();
    }
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CalculateLastVelocity();
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            float wallToughness = collision.gameObject.GetComponent<Wall>().GetToughness();
            WallBounce(collision, wallToughness);
            HitWallDamage(wallToughness);
        }
        if (collision.gameObject.tag == "Player")
        {
            float enemyToughness = collision.gameObject.GetComponent<Player>().GetToughness();
            EnemyBounce(collision, enemyToughness);
        }


    }


    void HitWallDamage(float wallToughness)
    {
        float damage = player.GetToughness() * player.GetWeight() * rgbd.velocity.magnitude * wallToughness;
        playerValues.health -= damage;
    }


    void WallBounce(Collision wallCollision, float wallToughness)
    {
        float speed = velocity.magnitude;
        var direction = Vector3.Reflect(velocity.normalized, wallCollision.contacts[0].normal);

        rgbd.velocity = direction * speed * player.GetToughness() * wallToughness / 35f;
    }

    void EnemyBounce(Collision enemyCollision, float enemyToughness)
    {
        // COLLISION PHYSICS INFO
        Player enemy = enemyCollision.gameObject.GetComponent<Player>();
        Rigidbody enemyRGBD = enemy.GetComponent<Rigidbody>();

        Vector3 speedChangeVector = (velocity.normalized * velocity.magnitude) - 
            (enemyRGBD.velocity.normalized * enemyRGBD.velocity.magnitude);
        float speedChange = speedChangeVector.magnitude;

        //Player Bounce
        Vector3 initialDirection = rgbd.velocity.normalized;
        Vector3 reflectedDirection = Vector3.Reflect(velocity.normalized, enemyCollision.contacts[0].normal);

        Vector3 playerForce = reflectedDirection * speedChange * player.GetToughness() *
            enemyToughness / player.GetWeight();
        rgbd.AddForce(playerForce);
               
        // ENEMY BOUNCE
                
        Vector3 enemyForce = initialDirection * speedChange * enemy.GetToughness() * 
            player.GetToughness() / enemy.GetWeight();
        enemy.GetComponent<Rigidbody>().AddForce(enemyForce);

    }

    void CalculateLastVelocity()
    {
        velocity = rgbd.velocity;
    }



}
