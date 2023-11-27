using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class playerController : MonoBehaviour, ITakeDamage
{
    public float speed;
    private Rigidbody2D rigidbody;
    private float horVel;
    private float vertVel;
    //shooting
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float canFire = -1f;
    public float fireRate;
    private SpriteRenderer spriteRenderer;

    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();
        shoot();
    }
    void movement()
    {
        speed = gameController.MoveSpeed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        horVel = horizontal * speed;
        vertVel = vertical * speed;
        rigidbody.velocity = new Vector3(horVel, vertVel, 0);
    }

    void shoot()
    {
        fireRate= gameController.FireRate;
        bulletSpeed = gameController.BulletSpeed;
        float horShoot = Input.GetAxisRaw("HorizontalShoot");
        float verShoot = Input.GetAxisRaw("VerticalShoot");

        //if ((horShoot != 0 || verShoot != 0) && Time.time > canFire)
        if ((horShoot != 0 || verShoot != 0) && Time.time > canFire)
        {
            canFire = Time.time + fireRate;
            if (horShoot != 0)
            {
                verShoot = 0;
                this.transform.rotation = Quaternion.Euler(0, 0, -90 * horShoot);
            }
            if (verShoot != 0)
            {
                horShoot = 0;
                if (verShoot == 1) { this.transform.rotation = Quaternion.Euler(0, 0, 0); }
                else { this.transform.rotation = Quaternion.Euler(0, 0, 180); }
            }
            Vector3 positionBullet = new Vector3(transform.position.x + (0.7f * horShoot), transform.position.y + (0.7f * verShoot));
            GameObject bullet = Instantiate(bulletPrefab, positionBullet, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (horShoot < 0) ? Mathf.Floor(horShoot) * bulletSpeed : Mathf.Ceil(horShoot) * bulletSpeed,
            (verShoot < 0) ? Mathf.Floor(verShoot) * bulletSpeed : Mathf.Ceil(verShoot) * bulletSpeed, 0
            );
        }
    }

    public void TakeDamage (float damage, float3 position)
    {
        StartCoroutine(Utilities.ApplyColor(spriteRenderer));
    }

    public void Die ()
    {
       
    }
}
