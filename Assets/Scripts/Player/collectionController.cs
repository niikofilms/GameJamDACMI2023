using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class collectionController : MonoBehaviour
{
    //Materials
    public TextMeshProUGUI collectedTextRoble;
    public TextMeshProUGUI collectedTextMagma;
    public TextMeshProUGUI collectedTextSlime;
    public TextMeshProUGUI collectedTextIce;
    public static int collectedRoble = 0;
    public static int collectedSlime = 0;
    public static int collectedMagma = 0;
    public static int collectedIce = 0;
    private GameObject player;
    private Vector3 materialPotition;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        collectedMaterials();
        attractMaterial();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int randomAmount;

            switch (gameObject.tag)
            {
                case "roble":
                    randomAmount = UnityEngine.Random.Range(2, 6);
                    collectedRoble += randomAmount;
                    break;

                case "slime":
                    randomAmount = UnityEngine.Random.Range(2, 6);
                    collectedSlime += randomAmount;
                    break;

                case "magma":
                    randomAmount = UnityEngine.Random.Range(2, 6);
                    collectedMagma += randomAmount;
                    break;

                case "ice":
                    randomAmount = UnityEngine.Random.Range(2, 6);
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

    void attractMaterial()
    {
        materialPotition = transform.position;
        float distance = Vector3.Distance(materialPotition, player.transform.position);
        if (distance < 6.5f)
        {
            transform.position = Vector3.Lerp(this.transform.position, player.transform.position,t:0.8f*Time.deltaTime);
        }
    }
}
