using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    private static int health = 6;
    private static int maxHealth = 6;
    private static float moveSpeed = 5f;
    private static float fireRate = 0.5f;

    public static int Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    public static void DamagePlayer (int damage)
    {
        health -= damage;

        if (Health <=0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(int healAmount)
    {
        health = Mathf.Min(MaxHealth, Health + healAmount);
    }

    private static void KillPlayer()
    {

    }
}