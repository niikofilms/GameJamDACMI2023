using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VolcanTrampa : MonoBehaviour, ITakeDamage
{
    public GameObject spawnRoot = null;
    public GameObject[] fireBallSpawnPoints = null;
    public GameObject fireBallPrefab = null;
    public float fireBallSpeed = 2;

    public float attackRate = 1;
    public float lifeTime = 5;
    public float health = 1;

    private float attackCounter = 0;
    private float elapsedTime = 0;
    private SpriteRenderer spriteRenderer = null;

    private float currentRotation = 0;

    void Start ()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackCounter = 0.1f;
        elapsedTime = 0;
    }
    void Update ()
    {
        //Starts counting for the volcano lifetime
        elapsedTime = math.max(0, elapsedTime + Time.deltaTime);

        attackCounter = math.max(0, attackCounter - Time.deltaTime);

        if(spawnRoot)
        {
            currentRotation += Time.deltaTime;
            quaternion rotation = quaternion.Euler(0, 0, currentRotation * 2);
            spawnRoot.transform.rotation = rotation;
        }

        if(attackCounter == 0)
        {
            Attack();
            attackCounter = attackRate;
        }

        if (elapsedTime >= lifeTime ) {
            Die();
        }
    }

    void Attack ()
    {

        foreach( GameObject spawnPosition in fireBallSpawnPoints ) {
            GameObject instance = Instantiate(fireBallPrefab, spawnPosition.transform.position, quaternion.identity);

            instance.GetComponent<bulletController>().senderTag = gameObject.tag;
            instance.GetComponent<Rigidbody2D>().velocity = spawnPosition.transform.localPosition * fireBallSpeed;
        }
    }

    public void TakeDamage (float damage, float3 position)
    {
        health -= damage;

        Utilities.ApplyColor(spriteRenderer);

        if (health <= 0)
        {
            Die();
            return;
        }
    }

    public void Die ()
    {
        Destroy(gameObject);
    }
}
