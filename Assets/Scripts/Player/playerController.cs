using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    new Rigidbody2D rigidbody;
    //shooting
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();
        //collectedMaterials();
        shoot();
    }
    void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float horVel = horizontal * speed;
        float vertVel = vertical * speed;
        rigidbody.velocity = new Vector3(horVel, vertVel, 0);
    }

    void shoot()
    {
        float horShoot = Input.GetAxisRaw("HorizontalShoot");
        float verShoot = Input.GetAxisRaw("VerticalShoot");
        
        //if ((horShoot != 0 || verShoot != 0) && Time.time > canFire)
        if ((horShoot != 0 || verShoot != 0) && Time.time > lastFire + fireDelay)

        {
            if (horShoot != 0) { 
                verShoot = 0;
                this.transform.rotation = Quaternion.Euler(0, 0, -90 * horShoot);
            }
            if (verShoot != 0) { 
                horShoot = 0;
                if( verShoot ==1)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                
            }
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            //canFire = Time.time + fireRate;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (horShoot < 0) ? Mathf.Floor(horShoot) * bulletSpeed : Mathf.Ceil(horShoot) * bulletSpeed,
            (verShoot < 0) ? Mathf.Floor(verShoot) * bulletSpeed : Mathf.Ceil(verShoot) * bulletSpeed, 0
            );
            lastFire = Time.time;
        }      
    }
}
