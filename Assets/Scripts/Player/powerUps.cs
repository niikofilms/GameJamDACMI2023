using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public string description;
    public Sprite itemImage;
}
public class powerUps : MonoBehaviour
{
    public Item item;
    //player
    public int healthChange;
    public int maxHealthChange;
    public float moveSpeedChange;
    //bullet
    public float fireRateChange;
    public float bulletSizeChange;
    public float bulletRangeChange;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.itemImage;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            gameController.maxHealthChange(maxHealthChange);
            gameController.HealPlayer(healthChange);
            gameController.MoveSpeedChange(moveSpeedChange);
            gameController.FireRateChange(fireRateChange); 
            gameController.BulletSizeChange(bulletSizeChange);
            gameController.bulletRangeChange(bulletRangeChange);
            Destroy(gameObject);
        }
    }
}
