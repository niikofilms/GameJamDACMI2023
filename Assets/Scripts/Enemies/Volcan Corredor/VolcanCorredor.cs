using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VolcanCorredor : EnemyBase
{
    private float2 wanderPosition = float2.zero;
    private float wanderTime = 0;
    private Transform target = null;

    private void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update ()
    {
        //Handle movement logic
        wanderTime = Mathf.Max(0, wanderTime - Time.deltaTime);

        if (wanderTime == 0)
        {
            wanderPosition = (Vector2)target.position;
            wanderTime = wanderRate;
        }

        Move(wanderPosition);
    }

    public override void Attack ()
    {

    }

    public override void Move (float2 direction)
    {
        float step = Time.deltaTime * wanderSpeed;

        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, direction, step);
        Debug.DrawLine(transform.position, (Vector2)wanderPosition);
    }

    public override void Die ()
    {
        Instantiate(dropPrefab, transform.position, quaternion.identity);
    }
}
