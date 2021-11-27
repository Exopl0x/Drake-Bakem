using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cldr;

    private bool canFire;

    [Header("Shotgun Settings")]
    public float shotgunForce;
    public float shotgunCooldown;

    [Header("Flamethrower Settings")]
    public float flamethrowerForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cldr = gameObject.GetComponent<CircleCollider2D>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
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
    }

    void FixedUpdate()
    {
        // Flamethrower (Left Click)
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(-transform.right * flamethrowerForce, ForceMode2D.Force);
        }
    }

    IEnumerator ShotgunShot()
    {
        // Add force to player away from fire direction
        rb.AddForce(-transform.right * shotgunForce, ForceMode2D.Impulse);

        canFire = false;

        // Hitstop
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1.0f;

        yield return new WaitForSecondsRealtime(shotgunCooldown);
        canFire = true;

        yield return null;
    }
}
