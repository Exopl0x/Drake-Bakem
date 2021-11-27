using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cldr;
    private Transform gunTransform;
    private ParticleSystem flamethrower;

    private bool canFire;

    [SerializeField][Range(0,200)]
    int playerHealth;

    [Header("Shotgun Settings")]
    public GameObject bulletObject;
    public float bulletSpeed;
    public int noOfBullets;
    public float shotgunForce;
    public float shotgunCooldown;

    [Header("Flamethrower Settings")]
    public float flamethrowerForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cldr = gameObject.GetComponent<CircleCollider2D>();
        gunTransform = gameObject.transform.Find("GunTransform");
        flamethrower = gameObject.transform.Find("GunTransform").GetComponent<ParticleSystem>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > 0)
        {
            // Point player towards mouse
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

            transform.right = direction;

            // Shotgun (Right Click)
            if (canFire == true && Input.GetMouseButtonDown(1))
            {
                StartCoroutine(ShotgunShot());
            }

            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(FlamethrowerPlay());
            }
            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(FlamethrowerStop());
            }
        }

        if(playerHealth <= 0)
        {
            GameObject.Find("Timer").GetComponent<Timer>().playerIsDead = true;
        }
    }

    void FixedUpdate()
    {
        // Flamethrower (Left Click)
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(-transform.right * flamethrowerForce, ForceMode2D.Force);
        }
    }

    IEnumerator FlamethrowerPlay()
    {
        flamethrower.Play();
        yield return null;
    }
    IEnumerator FlamethrowerStop()
    {
        flamethrower.Stop();
        yield return null;
    }

    IEnumerator ShotgunShot()
    {
        // Add force to player away from fire direction
        rb.AddForce(-transform.right * shotgunForce, ForceMode2D.Impulse);

        Vector3 bulletSpawnPoint = new Vector3(gunTransform.position.x, gunTransform.position.y, 0);

        GameObject _bulletInstance;
        // Spawn bullets from gun
        for (int i = 1; i <= 5; i++)
        {
            _bulletInstance = Instantiate(bulletObject, bulletSpawnPoint, Quaternion.FromToRotation(bulletObject.transform.up, transform.right));
            _bulletInstance.transform.eulerAngles += new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(-20.0f, 20.0f));
            _bulletInstance.GetComponent<Rigidbody2D>().AddForce(_bulletInstance.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }

        canFire = false;

        // Hitstop
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1.0f;

        yield return new WaitForSecondsRealtime(shotgunCooldown);
        canFire = true;

        yield return null;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Cake"){
            playerHealth -= 10;
            col.gameObject.SetActive(false);
        }
        if(col.gameObject.tag == "Cupcake"){
            playerHealth -= 5;
            col.gameObject.SetActive(false);
        }
    }
}
