using UnityEngine;

public class collectionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int randomAmount;

            switch (gameObject.tag)
            {
                case "roble":
                    randomAmount = Random.Range(2, 6);
                    playerController.collectedRoble += randomAmount;
                    break;

                case "slime":
                    randomAmount = Random.Range(2, 6);
                    playerController.collectedSlime += randomAmount;
                    break;

                case "magma":
                    randomAmount = Random.Range(2, 6);
                    playerController.collectedMagma += randomAmount;
                    break;

                case "ice":
                    randomAmount = Random.Range(2, 6);
                    playerController.collectedIce += randomAmount;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
