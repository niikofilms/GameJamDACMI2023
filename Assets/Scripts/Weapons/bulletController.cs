using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float lifeTime;
    public float destroyDistance;
    private Vector3 initialPotition;

    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        initialPotition = transform.position;
        transform.localScale = new Vector2(gameController.BulletSize,gameController.BulletSize);
    }

    // Update is called once per frame
    void Update()
    {
        destroyBullet(); 
    }
    void destroyBullet()
    {
        destroyDistance = gameController.Range;
        float distance = Vector3.Distance(initialPotition,transform.position);
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chest" || collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
