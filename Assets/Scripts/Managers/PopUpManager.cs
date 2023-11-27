using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPrefab;

    private void OnEnable ()
    {
        VolcanCorredor.OnTakeDamage += ShowPopUp;
    }

    private void OnDestroy ()
    {
        VolcanCorredor.OnTakeDamage -= ShowPopUp;
    }

    void ShowPopUp (float damage, float3 position) 
    {
        GameObject instance = Instantiate(popUpPrefab, position, quaternion.identity);
        instance.GetComponent<TextMeshPro>().text = damage.ToString();
        StartCoroutine(Utilities.LerpPosition(instance.transform, new float3(0, 1, 0)));
    }
}