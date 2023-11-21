using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Utilities : MonoBehaviour
{

    public static float2 GenerateRandomPositionFromPosition (float3 center, float radius)
    {
        float angle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
        float distance = UnityEngine.Random.Range(0f, radius);

        float x = center.x + distance * Mathf.Cos(angle);
        float y = center.y + distance * Mathf.Sin(angle);

        return new float2(x, y);
    }
}
