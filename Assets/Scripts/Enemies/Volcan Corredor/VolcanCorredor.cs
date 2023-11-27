using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class VolcanCorredor : EnemyBase, ITakeDamage
{
    public float minDistanceFromPlayer = 0;
    private float2 wanderPosition = float2.zero;
    private float wanderTime = 0;
    private Rigidbody2D rb = null;
    private Transform target = null;

    private int attackState = 0;

    [Header("Attack settings")]
    public GameObject[] fireBallSpawnPoints;
    public GameObject fireBall = null;
    public float fireBallSpeed = 7;

    [Space]
    public GameObject lavaPuddle = null;
    public float lavaPuddleRate = 0.5f;
    [Space]
    public GameObject smallVolcano = null;

    private float puddleTimer = 0;


    private float attackTimer = 0;

    public static event Action<float, float3> OnTakeDamage;

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate ()
    {
        // Handle movement logic
        wanderTime = Mathf.Max(0, wanderTime - Time.deltaTime);

        if (wanderTime == 0)
        {
            // Calculate a random point around the player within the wanderRange
            Vector2 wanderOffset = UnityEngine.Random.insideUnitCircle * wanderRange;
            // Calculate the new position by combining chasing and wandering
            wanderPosition = (Vector2)target.position + wanderOffset;
            wanderTime = wanderRate;
        }

        // Handle attack logic
        attackTimer = Mathf.Max(0, attackTimer - Time.deltaTime);

        if (attackTimer == 0)
        {
            attackTimer = attackSpeed;

            attackState = UnityEngine.Random.Range(0, 4);
            Attack(attackState); 
        }

        Move(wanderPosition);
    }

    public override void Attack (int state)
    {
        switch (state)
        {
            //Spawn fire projectiles
            case 1:
                foreach (GameObject spawnPoint in fireBallSpawnPoints)
                {
                    GameObject instance = Instantiate(fireBall, spawnPoint.transform.position, quaternion.identity);
                    instance.GetComponent<bulletController>().senderTag = gameObject.tag;
                    instance.GetComponent<Rigidbody2D>().velocity = spawnPoint.transform.localPosition * fireBallSpeed;
                }
                break;
            case 2:
                //Spawn volcanoes
                GameObject volcanoInstance = Instantiate(smallVolcano, new float3(wanderPosition.x, wanderPosition.y, 0), quaternion.identity);
                break;

        }
    }

    public override void Move (float2 direction)
    {
        if (math.distance(transform.position, new float3(wanderPosition.x, wanderPosition.y, 0)) < minDistanceFromPlayer)
        {
          
        }


        spriteRenderer.flipX = Utilities.CheckFlip((Vector2)transform.position, wanderPosition).flipX;
       // spriteRenderer.flipY = Utilities.CheckFlip((Vector2)transform.position, wanderPosition).flipY;

        // Handle attack logic
        puddleTimer = Mathf.Max(0, puddleTimer - Time.deltaTime);

        if(puddleTimer ==0)
        {
            puddleTimer = lavaPuddleRate;
            quaternion rotation = quaternion.Euler(0, 0, UnityEngine.Random.rotation.x);
            GameObject instance = Instantiate(lavaPuddle, rb.position, rotation);
        }


        // Use Lerp to smoothly move towards the target position
        float step = wanderSpeed * Time.fixedDeltaTime;
        float2 newPosition = math.lerp((float2)rb.position, direction, step);
        rb.MovePosition(newPosition);

        Debug.DrawLine(rb.position, (Vector2)wanderPosition);


    }

    public override void Die ()
    {
        Instantiate(dropPrefab, transform.position, quaternion.identity);
        Destroy(gameObject);
    }


    public void TakeDamage (float damage, float3 position)
    {
        health -= damage;

        //Colorize on damage
        StartCoroutine(Utilities.ApplyColor(spriteRenderer));

        if (health < 0)
        {
            health = 0;
            Die();
            return;
        }

        OnTakeDamage?.Invoke(damage, position);
    }

   
}
