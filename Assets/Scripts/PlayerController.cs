using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using MoreMountains.Tools;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cldr;
    private Transform gunTransform;
    private ParticleSystem flamethrower;
    public MMFeedbacks shotgunFeedbacks;
    public GameObject deathCanvas;

    private bool canFire;

    [SerializeField]
    [Range(0, 200)]
    int playerHealth;
    private AudioSource[] sounds;

    [Header("Shotgun Settings")]
    public GameObject bulletObject;
    public float bulletSpeed;
    public int noOfBullets;
    public float shotgunForce;
    public float shotgunCooldown;
    public GameObject score;
    public TextMeshProUGUI deathS;
    [Header("Flamethrower Settings")]
    public float flamethrowerForce;
    public CakeStats cake;
    public CakeStats cupcake;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cldr = gameObject.GetComponent<CircleCollider2D>();
        gunTransform = gameObject.transform.Find("GunTransform");
        flamethrower = gameObject.transform.Find("GunTransform").GetComponent<ParticleSystem>();
        sounds = gameObject.GetComponents<AudioSource>();
        shotgunFeedbacks = GameObject.Find("Main Camera").GetComponent<MMFeedbacks>();
        deathCanvas.SetActive(false);
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

        if (playerHealth <= 0)
        {
            //GameObject.Find("Timer").GetComponent<Timer>().playerIsDead = true;

            deathCanvas.SetActive(true);
            score.SetActive(false);
            Debug.Log(score.GetComponent<Score>().score);
            GameObject.Find("DeathScore").GetComponent<TextMeshProUGUI>().text = score.GetComponent<Score>().score.ToString();
            
            
            
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
        sounds[0].Play();       // Flamethrower burn sound
        yield return null;
    }
    IEnumerator FlamethrowerStop()
    {
        flamethrower.Stop();
        sounds[0].Stop();       // Flamethrower burn sound
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

        // Hitstop, shots appear, but don't move
        Time.timeScale = 0.0f;
        sounds[2].Play();       // Short, juicy prefire sound
        yield return new WaitForSecondsRealtime(0.1f);

        // Shots move and shotgun is now shot
        Time.timeScale = 1.0f;
        sounds[1].Play();       // Shotgun blast sound effect
        shotgunFeedbacks?.PlayFeedbacks();


        yield return new WaitForSecondsRealtime(shotgunCooldown * 0.7f);
        sounds[3].Play();       // Shotgun pump 1

        yield return new WaitForSecondsRealtime(shotgunCooldown * 0.3f);
        // Shotgun can be fired again; charge time is finished.
        canFire = true;
        sounds[4].Play();       // Shotgun pump 2

        yield return null;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        sounds[5].Play();
        if (col.gameObject.tag == "Cake")
        {
            playerHealth -= cake.damage;
            GameObject.Find("Health_Bar").GetComponent<MMHealthBar>().UpdateBar(playerHealth, 0, 50, true);
            col.gameObject.SetActive(false);

        }
        if (col.gameObject.tag == "Cupcake")
        {
            playerHealth -= cupcake.damage;
            GameObject.Find("Health_Bar").GetComponent<MMHealthBar>().UpdateBar(playerHealth, 0, 50, true);
            col.gameObject.SetActive(false);
        }
    }
}
