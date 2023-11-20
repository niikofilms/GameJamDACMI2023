using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class playerController : MonoBehaviour
{

    public float speed;
    new Rigidbody2D rigidbody;
    //collectables & variables
    public TextMeshProUGUI collectedTextRoble;
    public TextMeshProUGUI collectedTextMagma;
    public TextMeshProUGUI collectedTextSlime;
    public TextMeshProUGUI collectedTextIce;
    public static int collectedRoble = 0;
    public static int collectedSlime = 0;
    public static int collectedMagma = 0;
    public static int collectedIce = 0;
    //shooting
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;
    private float horShoot;
    private float verShoot;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        collectedMaterials();

        horShoot = Input.GetAxis("HorizontalShoot");
        verShoot = Input.GetAxis("VerticalShoot");
        if ((horShoot != 0) || (verShoot != 0) && Time.time > lastFire + fireDelay)
        {
            shoot(horShoot, verShoot);
            lastFire = Time.time;
        }
    }
    void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float horVel = horizontal * speed;
        float vertVel = vertical * speed;
        rigidbody.velocity = new Vector3(horVel, vertVel, 0);
    }

    void shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed, 0
            );
    }
    void collectedMaterials()
    {
        collectedTextRoble.text = "Roble: " + collectedRoble;
        collectedTextSlime.text = "Slime: " + collectedSlime;
        collectedTextMagma.text = "Magma: " + collectedMagma;
        collectedTextIce.text = "Ice: " + collectedIce;
    }
}
