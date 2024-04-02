using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public LogicManager logic;
    public AudioPlayerScript audioPlayer;
    public int enemyHealth = 1;
    public float enemySpeed = 4;
    public GameObject enemyDeath;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        audioPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioPlayerScript>();

        moveDirection = Random.Range(0f, 1f) >= 0.5f ? Vector2.left : Vector2.right;
    }
    
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        rb.MovePosition(rb.position + moveDirection * enemySpeed * 0.4f * Time.fixedDeltaTime);
        if (rb.position.x > 7 && moveDirection == Vector2.right)
        {
            moveDirection = Vector2.left;
        }
        if (rb.position.x < -7 && moveDirection == Vector2.left)
        {
            moveDirection = Vector2.right;
        }
    }

    void Die()
    {
        GameObject deathObject = Instantiate(enemyDeath, transform.position, Quaternion.identity);
        Destroy(deathObject, 0.34f);
        Destroy(gameObject);
        audioPlayer.sfxEnemyDie();
        logic.addScore();
    }
}
