using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float lifeTime;
    public float destroyDistance;
    private Vector3 initialPotition;
    public float damage = 2;

    [HideInInspector]
    public string senderTag = "";

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

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITakeDamage target) && collision.transform.tag != senderTag)
        {
            target.TakeDamage(damage, collision.transform.position);

        }
        Destroy(gameObject);
    }


}
