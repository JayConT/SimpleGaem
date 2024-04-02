using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float projSpeed;
    public int damage = 1;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.down * projSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        ShipMovement player = hitInfo.GetComponent<ShipMovement>();
        if (player != null)
        {
            player.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
