using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float damage = 2;
    public float lifeTime;

    [HideInInspector]
    public string senderTag = "";

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ITakeDamage target) && collision.transform.tag != senderTag)
        {
            target.TakeDamage(damage, collision.transform.position);
           
        }

        Destroy(gameObject);

    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

}
