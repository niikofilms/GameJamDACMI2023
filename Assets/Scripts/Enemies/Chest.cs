using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private int chestLive;
    public GameObject icePrefab;
    public GameObject roblePrefab;
    public GameObject magmaPrefab;
    public GameObject slimePrefab;

    public float radius = 1.5f;
    public  Vector3 randomPos;

    // Start is called before the first frame update
    void Start()
    {
        chestLive = 3;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "bullet")
        {
            chestLive--;
            if (chestLive == 0)
            {
                randomReward();
                Destroy(gameObject);
                
            }
        }
    }

    void randomReward()
{
    Vector3 chestPos = new Vector3(transform.position.x, transform.position.y, 0);
    int randomAmount = UnityEngine.Random.Range(1, 5);
    for (int i = 0; i < 6; i++)
    {
        randomPos = Random.insideUnitCircle * radius;
        Vector3 randomPosMat = randomPos + chestPos;
        switch (randomAmount)
        {
            case 1:
                Instantiate(icePrefab, randomPosMat, Quaternion.identity);
                break;
            case 2:
                Instantiate(roblePrefab, randomPosMat, Quaternion.identity);
                break;
            case 3:
                Instantiate(magmaPrefab, randomPosMat, Quaternion.identity);
                break;
            case 4:
                Instantiate(slimePrefab, randomPosMat, Quaternion.identity);
                break;
        }
    }
}
}
