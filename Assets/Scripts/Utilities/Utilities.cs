using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Utilities
{

    public static float2 GenerateRandomPositionFromPosition (float3 center, float radius)
    {
        float angle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
        float distance = UnityEngine.Random.Range(0f, radius);

        float x = center.x + distance * Mathf.Cos(angle);
        float y = center.y + distance * Mathf.Sin(angle);

        return new float2(x, y);
    }

    public static IEnumerator ApplyColor (SpriteRenderer target)
    {
        float duration = 0.08f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            target.color = Color.Lerp(Color.white, Color.red, t);

            yield return null;
        }
        target.color = Color.red;

        elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            target.color = Color.Lerp(Color.red, Color.white, t);

            yield return null;
        }

        target.color = Color.white;
    }

    public static IEnumerator LerpPosition (Transform target, float3 position)
    {
        float duration = 4;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            target.localPosition = math.lerp(target.localPosition, new float3(target.position.x, target.position.y + position.y, target.position.z), elapsed);

            yield return null;
        }
        
        target.position = position;
    }
    /// <summary>
    /// Checks if a transform is facing to a direction based on the destination
    /// </summary>
    /// <param name="playerPosition"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public static (bool flipX, bool flipY) CheckFlip (float2 playerPosition, float2 destination)
    {
        bool flipX = destination.x < playerPosition.x;
        bool flipY = destination.y < playerPosition.y;

        return (flipX, flipY);
    }
}
