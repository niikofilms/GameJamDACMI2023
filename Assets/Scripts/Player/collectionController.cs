using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class collectionController : MonoBehaviour
{
    public TextMeshProUGUI collectedTextRoble;
    public TextMeshProUGUI collectedTextMagma;
    public TextMeshProUGUI collectedTextSlime;
    public TextMeshProUGUI collectedTextIce;
    public static int collectedRoble = 0;
    public static int collectedSlime = 0;
    public static int collectedMagma = 0;
    public static int collectedIce = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collectedMaterials();
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
                    collectedRoble += randomAmount;
                    break;

                case "slime":
                    randomAmount = Random.Range(2, 6);
                    collectedSlime += randomAmount;
                    break;

                case "magma":
                    randomAmount = Random.Range(2, 6);
                    collectedMagma += randomAmount;
                    break;

                case "ice":
                    randomAmount = Random.Range(2, 6);
                    collectedIce += randomAmount;
                    break;
            }
            Destroy(gameObject);
        }
    }
    void collectedMaterials()
    {
        if (collectedTextRoble != null)
            collectedTextRoble.text = "Roble: " + collectedRoble;

        if (collectedTextSlime != null)
            collectedTextSlime.text = "Slime: " + collectedSlime;

        if (collectedTextMagma != null)
            collectedTextMagma.text = "Magma: " + collectedMagma;

        if (collectedTextIce != null)
            collectedTextIce.text = "Ice: " + collectedIce;
    }
}
