using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public interface ITakeDamage 
{
    void TakeDamage (float damage, float3 position);

    void Die ();
}
