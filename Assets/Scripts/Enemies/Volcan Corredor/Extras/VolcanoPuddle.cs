using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VolcanoPuddle : MonoBehaviour
{
    public float fadeSpeed = 1;
    private SpriteRenderer spriteRenderer;

    public float damage = 1;
    public float damageRate = 1;
    private float damageTimer = 0;

    // Start is called before the first frame update
    void Start ()
    {
        damageTimer = damageRate;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(0, 0, 0, 0), Time.deltaTime * fadeSpeed);
     
        if (spriteRenderer.color.a <= 0.05f)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerStay2D (Collider2D collision)
    {
        damageTimer = Mathf.Max(0, damageTimer - Time.deltaTime);

        if (damageTimer == 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ITakeDamage target = collision.gameObject.GetComponent<ITakeDamage>();

                if (target != null)
                {
                    target.TakeDamage(damage, transform.position);
                }

                damageTimer = damageRate;
            }
        }
    }
}
