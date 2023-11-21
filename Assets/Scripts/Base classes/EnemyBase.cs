using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public enum EnemyType { Melee, Range }
    public EnemyType enemyType;

    [Header("Attack")]
    public float attackSpeed = 1;

    [Header("Wandering")]
    public float wanderSpeed = 2;
    public float wanderRange = 5f;
    public float wanderRate = 1f;

    [Header("Drop")]
    public float itemDropRate = 100f;
    public GameObject dropPrefab = null;

    //Actions
    public abstract void Attack ();
    public abstract void Move (float2 position);
    public abstract void Die ();



}
