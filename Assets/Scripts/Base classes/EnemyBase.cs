using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public enum EnemyType { Melee, Range }
    public EnemyType enemyType;

    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    [Header("Stats")]
    public float health = 100;
    public float maxHealth = 100;

    [Header("Attack")]
    public float attackSpeed = 1;

    [Header("Wandering")]
    public float wanderSpeed = 2;
    public float wanderRange = 5f;
    public float wanderRate = 1f;

    [Header("Drop")]
    public float itemDropRate = 100f;
    public GameObject dropPrefab = null;

    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Actions
    public abstract void Attack (int state);
    public abstract void Move (float2 position);
    public abstract void Die ();



}
